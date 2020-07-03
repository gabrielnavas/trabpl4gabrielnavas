let index = {
    btnCadastrarUsuario: function() {

        const user = {}
        user.email = document.getElementById('email').value;
        user.password = document.getElementById('password').value;
        user.nome = document.getElementById('nome').value;
        user.cpf = document.getElementById('cpf').value;
        user.data = document.getElementById('data').value;
        user.rua = document.getElementById('rua').value;
        user.num = document.getElementById('num').value;
        user.cep = document.getElementById('cep').value;
        
        console.log(user)

        const config =  {
            method: 'POST',
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
            body: JSON.stringify(user)
        }


        fetch('CadastrarUsuario/Cadastrar', config)
            .then(resp => resp.json())
            .then(resp => {
                if (resp.operacao) {


                    window.location.href = "Catalogo";
                }
                else {
                    document.getElementById('divMsg').innerHTML = resp.msg;
                }
            })
            .catch(err => {
                document.getElementById('divMsg').innerHTML = `Erro na operacao:  ${resp.msg}`;
            })
    },
}
