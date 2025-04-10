// Função para alternar o estado da sidebar (expandida <-> recolhida)
function toggleMenu() {
    const sidebar = document.getElementById('sidebar'); // Seleciona a sidebar pelo ID
    sidebar.classList.toggle('closed'); // Adiciona ou remove a classe 'closed'

    // Se a sidebar estiver recolhida, remove a classe 'open' de todos os menus
    if (sidebar.classList.contains('closed')) {
        document.querySelectorAll('.menu-item.open').forEach(item => item.classList.remove('open'));
    }
}
// Função para abrir ou fechar o submenu clicado
function toggleSubmenu(element) {
    const sidebar = document.getElementById('sidebar');

    // Se a sidebar estiver fechada, abre ela automaticamente ao clicar em um submenu
    if (sidebar.classList.contains('closed')) {
        sidebar.classList.remove('closed');
    }

    // Fecha qualquer outro submenu que esteja aberto
    document.querySelectorAll('.menu-item.open').forEach(item => {
        if (item !== element) {
            item.classList.remove('open');
        }
    });

    // Alterna a classe 'open' no item clicado (abre/fecha o submenu correspondente)
    element.classList.toggle('open');
}
// Fecha a sidebar automaticamente em telas pequenas ao clicar em um link do submenu
document.querySelectorAll('.submenu a').forEach(item => {
    item.addEventListener('click', function () {
        if (window.innerWidth <= 768) { // Disparo somente em telas pequenas (modo responsivo)
            document.getElementById('sidebar').classList.add('closed'); // Fecha a sidebar
            document.querySelectorAll('.menu-item.open').forEach(menu => menu.classList.remove('open')); // Fecha os submenus
        }
    });
});
