// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleDropdown(event) {
    event.preventDefault();
    const menu = document.getElementById("dropdownMenu");
    menu.classList.toggle("show");
}

// Cierra el menú si se hace clic fuera
window.addEventListener("click", function (e) {
    const menu = document.getElementById("dropdownMenu");
    if (!e.target.closest(".dropdown")) {
        menu.classList.remove("show");
    }
});