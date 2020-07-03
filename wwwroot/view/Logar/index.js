let index = {
    btnLogar: function () {

        const user = {
            email: document.getElementById('email').value,
            password: document.getElementById('password').value
        };

        const config = {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
            body: JSON.stringify(user)
        }

        fetch('Logar/Logar', config)
            .then(resp => resp.json())
            .then(resp => {
                if (resp.operacao) {

                    localStorage.setItem('email_user', user.email);
                    window.location.href = '/Catalogo/';
                }
                else {
                    document.getElementById('divMsg').innerHTML = resp.msg;
                }
            })
            .catch(err => {
                document.getElementById('divMsg').innerHTML = "Erro na operação.";
            })
    }
}