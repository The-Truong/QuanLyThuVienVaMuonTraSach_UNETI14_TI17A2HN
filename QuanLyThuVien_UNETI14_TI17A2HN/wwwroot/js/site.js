const sidebarToggle = document.getElementById("sidebarToggle");
const sidebar = document.getElementById("sidebar");
const mainContent = document.querySelector(".main-content");

if (sidebarToggle) {

    sidebarToggle.addEventListener("click", function () {

        if (window.innerWidth <= 768) {

            sidebar.classList.toggle("show");

        } else {

            sidebar.classList.toggle("collapsed");

            mainContent.classList.toggle("expanded");

        }

    });

}