function toggleMenu() {
    const sidebar = document.getElementById('sidebar');
    sidebar.classList.toggle('closed');

    if (sidebar.classList.contains('closed')) {
        document.querySelectorAll('.menu-item.open').forEach(item => item.classList.remove('open'));
    }
}

function toggleSubmenu(element) {
    const sidebar = document.getElementById('sidebar');

    if (sidebar.classList.contains('closed')) {
        sidebar.classList.remove('closed');
    }

    document.querySelectorAll('.menu-item.open').forEach(item => {
        if (item !== element) {
            item.classList.remove('open');
        }
    });

    element.classList.toggle('open');
}

document.querySelectorAll('.submenu a').forEach(item => {
    item.addEventListener('click', function () {
        if (window.innerWidth <= 768) {
            document.getElementById('sidebar').classList.add('closed');
            document.querySelectorAll('.menu-item.open').forEach(menu => menu.classList.remove('open'));
        }
    });
});
