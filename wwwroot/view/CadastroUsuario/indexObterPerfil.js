let index = {
    buscarDadosPerfil: function() {

        const emailUser = localStorage.getItem('email_user');


        const config =  {
            method: 'GET',
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        }

        fetch('/CadastrarUsuario/PegarUsuarioByEmail?email=' + emailUser, config)
            .then(resp => resp.json())
            .then(resp => {
                if (resp.operacao) {

                    let dia = resp.user.dataNasc.split('-')[2][0] + resp.user.dataNasc.split('-')[2][1];
                    let mes = resp.user.dataNasc.split('-')[1];
                    let ano = resp.user.dataNasc.split('-')[0];

                    console.log('data', dia, mes, ano);

                    console.log(resp.user.dataNasc);

                    document.getElementById('perfil_nome').value = resp.user.nome;
                    document.getElementById('perfil_cpf').value = resp.user.cpf;
                    document.getElementById('perfil_email').value = resp.user.email;
                    document.getElementById('perfil_dataNasc').value =
                        `${ano}-${mes}-${dia}`;
                    document.getElementById('perfil_rua').value = resp.user.endereco.rua;
                    document.getElementById('perfil_numero').value= resp.user.endereco.num;
                    document.getElementById('perfil_cep').value = resp.user.endereco.cep;

                }
                else {
                    document.getElementById('divMsg').innerHTML = resp.msgs;
                }
            })
            .catch(err => {
                console.log(err);
                document.getElementById('divMsg').innerHTML = `Erro na operacao:  ${err}`;
            })
    },
}

index.buscarDadosPerfil();
