let indexListar = {

    btnPesquisar: function () {

        const nome = document.getElementById('txtBuscarProdNome').value;
        const tbBodyProds = document.getElementById('tbBodyProds');
        document.getElementById('tbProdutos').style.display = "table";

        if (nome.length == 0) {
            tbBodyProds.innerHTML = `<tr><td colspan="7">* Digite um nome de produto para procurar.</td></tr>`
            return;
        }

        document.getElementById('btnPesquisar').disable = "disable";
        tbBodyProds.innerHTML = `<tr><td colspan="7"><img src=\"/img/ajax-loader.gif"\ /> Carregando...</td></tr>`

        const config = {
            method: 'GET',
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        }

        fetch('/CadastrarProduto/Pesquisar?prodNome=' + nome, config)
            .then(resp => resp.json())
            .then(resp => {

                if (resp.operacao && resp.produtos.length > 0) {
                    const prods = resp.produtos;
                    let tRows = "";
                    for (let i = 0; i < prods.length; i++) {
                        tRows += `<tr data-cod=${prods[i].cod}>
                                    <td>${prods[i].cod}</td>
                                    <td>${prods[i].nome}</td>
                                    <td>${prods[i].descricao}</td>
                                    <td>${prods[i].valor}</td>
                                    <td>${prods[i].estrelas}</td>
                                    <td>${prods[i].categoria.nome}</td>
                                    <td><a href="#" onclick="indexListar.deletar(${prods[i].cod})">Excluir</a></td>
                                  </tr>`;
                    }

                    tbBodyProds.innerHTML = tRows;
                }
                else {
                    tbBodyProds.innerHTML = `<tr><td  colspan="7">Não foi encontrado nenhum produto...</td></tr>`;
                }
            })
            .catch(err => {
                tbBodyProds.innerHTML = `<tr><td  colspan="7">Deu erro...</td></tr>`;
            })
            .finally(fll => {
                document.getElementById('btnPesquisar').disable = "";
            })
    },
    deletar: function (prodCod) {

        if (!confirm(`Deseja realmente excluir o produto de código ${prodCod}?`)) {
            return;
        }

        var config = {
            method: "delete",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include', //inclui cookies
        };

        fetch("/CadastrarProduto/ExcluirProduto?cod=" + prodCod, config)
            .then(resp => resp.json())
            .then(resp => {

                if (resp.operacao) {
                    var tr = document.querySelector("tr[data-cod='" + prodCod + "']");

                    if (tr != null) {
                        tr.parentNode.removeChild(tr);
                    }
                }

            })
            .catch(err => {
                alert("Deu erro.")
            });

    }
}

