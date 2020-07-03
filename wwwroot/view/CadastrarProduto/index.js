let index = {

    btnInserirProduto: function () {

        const produto = {
            nome: document.getElementById('nome').value,
            descricao: document.getElementById('descricao').value,
            valor: document.getElementById('valor').value,
            categoria: document.getElementById('categoria').value,
            estoque: document.getElementById('estoque').value,
            //foto: document.getElementById('foto').value
        }

        const config = {
            method: 'POST',
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
            body: JSON.stringify(produto)
        }

        const fotos = document.getElementById('foto').files;

        if (fotos.length < 2) {
            document.getElementById('divMsg').innerHTML = `Pelo menos duas fotos por produto`;
            return;
        }

        for (let i = 0; i < fotos.length; i++) {
            const dotext = fotos[i].type.split('/')[1];
            if (dotext && dotext !== 'jpeg')  {
                document.getElementById('divMsg').innerHTML = `É permitido somente imagem .jpg`;
                return;
            }

            const tamanhoArq = fotos[i].size;
            const maxTam = (1024 * 1024 * 1024 * 40);
            if (tamanhoArq >  maxTam) {
                document.getElementById('divMsg').innerHTML = `Máximo de 40MB`;
                return;
            }
        }


        fetch('/CadastrarProduto/InserirProduto', config)
            .then(resp => resp.json())
            .then(resp => {

                if (resp.operacao) {
                    const fd = new FormData()

                    
                    //inserir fotos no formdata

                    const fotos = document.getElementById('foto').files

                    for (let i = 0; i <= fotos.length; i++) {
                        fd.append(`foto${i + 1}`, fotos[i]);
                    }

                    //fd.append('foto1', );
                    //fd.append('foto2', document.getElementById('foto').files[1]);

                    //inserir id do produto
                    fd.append('cod', resp.produto.cod);

                    //config do fetch
                    const configFetch = {
                        method: "POST",
                        headers: {
                            "Accept": "application/json"
                        },
                        body: fd
                    }

                    //inserir fotos
                    fetch('/CadastrarProduto/InserirFotos', configFetch)
                        .then(resp => resp.json())
                        .then(resp => {
                            if (resp.operacao) {
                                document.getElementById('nome').value = '';
                                document.getElementById('descricao').value = '';
                                document.getElementById('valor').value = '';
                                document.getElementById('categoria').value = '';
                                document.getElementById('estoque').value = '';
                                document.getElementById('foto').files[0] = null;
                                document.getElementById('foto').files[1] = null;

                                for (let i = 0; i < fotos.length; i++) {
                                    fotos[i] = undefined;
                                }
                            }

                            document.getElementById('divMsg').innerHTML = resp.msg;
                        })
                        .catch(err => {
                            document.getElementById('divMsg').innerHTML = resp.msg;
                        })
                        .finally(() => {
                        })
                }
                else {
                    document.getElementById('divMsg').innerHTML = resp.msg;
                }

                })
            .catch(err => {
                document.getElementById('divMsg').innerHTML = resp.msg;
                //console.log(err);
            })
            .finally(() => {
            })
    },
    obterCategorias: function() {

        const config = {
            method: 'GET',
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        }

        fetch('CadastrarProduto/ObterCategoriasProdutos', config)
            .then(resp => resp.json())
            .then(resp => {

                let opts = `<option value=""></option>`;
                for (let i = 0; i < resp.length; i++) {
                    opts += `<option value="${resp[i].cod}">${resp[i].nome}</option>`
                }

                const selCat = document.getElementById('categoria');
                selCat.innerHTML = opts;

            })
            .catch(err => {
                document.getElementById('divMsg').innerHTML = resp.msg;
                console.log(err);
            })
    }
}

index.obterCategorias();