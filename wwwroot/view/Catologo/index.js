let index = {
    obterProdutos: function () {

        const config = {
            method: 'GET',
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        }

        fetch('/Catalogo/ObterProdutos', config)
            .then(resp => resp.json())
            .then(prods => {

                if (prods == null || prods == undefined || prods.length == 0) {
                    document.getElementById('divMsgs').innerHTML = `<h3>Não há produtos disponíveis</h3>`;
                    return;
                }


                let prodsHtml = "";

                for (let i = 0; i < prods.length; i++) {

                    let fotosModal = `
                                <div class="carousel-item active">
                                    <img  src="/CadastrarProduto/ObterUmaFoto?id=${prods[i].cod}&numero=${1}" alt="pc${1}" style="width: 150px; height: 150px; p-3;">
                                </div>
                                `;

                    let indicators = `
                                 <li data-target="#carouselExampleIndicators${1}" data-slide-to="0" class="active"></li>
                                `

                    for (let j = 2; j <= prods[i].qntdFotos; j++) {
                        fotosModal += `
                                 <div class="carousel-item style="text-align: center">
                                    <img style="width: 100%; height: auto;" src="/CadastrarProduto/ObterUmaFoto?id=${prods[i].cod}&numero=${j}" alt="pc${j}" style="width: 150px; height: 150px; p-3;">
                                </div>
                           `

                        indicators += `
                                <li data-target="#carouselExampleIndicators${i}" data-slide-to="${j-1}"></li>
                            `
                    }

                    prodsHtml += `
                            <div class="col-3 d-flex align-items-center p-3 m-3" style="background-color: rgb(223, 223, 223);">
                            <div class="box box-default">
                                <div class="box-header with-border">
                                    <div class="row p-1 ">
                                        <div class="col d-flex justify-content-center align-content-start flex-column ">

                                           <div id="carouselExampleIndicators${i}" class="carousel slide" data-ride="carousel">
                                              <ol class="carousel-indicators">
                                                ${indicators}
                                              </ol>
                                              <div class="carousel-inner ">
                                                ${fotosModal}
                                              </div>
                                              <a class="carousel-control-prev" href="#carouselExampleIndicators${i}" role="button" data-slide="prev">
                                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                <span class="sr-only">Previous</span>
                                              </a>
                                              <a class="carousel-control-next" href="#carouselExampleIndicators${i}" role="button" data-slide="next">
                                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                <span class="sr-only">Next</span>
                                              </a>
                                            </div>

                                        
                                        </div>
                                    </div>
                                    <div class="row p-1">
                                        <div class="col">
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                                                Mais Fotos
                                            </button>
                                        </div>
                                    </div>
                                </div>

                                <div class="box-body">
                                    <div class="col">
                                        <strong><h4>${prods[i].nome}</h4></strong>  
                                        <strong><h6>${prods[i].categoria.nome}</h6></strong>  
                                        <div class="row pl-2 text-success">
                                            <h3>R$ ${prods[i].valor}</h3>

                                        </div>
                                        <div class="row">
                                            <p class='text-dark'>
                                                <h6 class="tamanhoDescricao">
                                                    ${prods[i].descricao}
                                                </h6>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-footer">
                                    <div class="row">
                                        <div class="col text-primary">
                                            <h6>
                                                ${prods[i].estrelas} 
                                                <i class="fas fa-star"></i>

                                            </h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                      
                        `;
                }

                const contentProds = document.getElementById('prods')
                contentProds.innerHTML = prodsHtml;
            })
            .catch(err => {
                document.getElementById('divMsgs').innerHTML = `<h3>Não há produtos disponíveis</h3>`;
            })
    }
}

index.obterProdutos();