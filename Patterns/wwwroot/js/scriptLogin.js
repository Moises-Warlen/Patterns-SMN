function login() {
    // Obtém os valores dos campos de entrada de usuário e senha
    var user = document.getElementById('user').value;
    var password = document.getElementById('password').value;

    // Verifica se as credenciais são corretas
    if (user === "admin" && password === "1234") {
        window.location.href = "dashboard.html"; // Redireciona para o painel caso os dados estejam corretos
    } else {
        showModal(); // Exibe um modal de erro caso os dados estejam incorretos
    }
}

function showModal() {
    // Exibe o modal de erro alterando o estilo CSS
    document.getElementById("errorModal").style.display = "flex";
}

function closeModal() {
    // Oculta o modal de erro
    document.getElementById("errorModal").style.display = "none";
}

