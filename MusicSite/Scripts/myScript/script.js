let modal_container = document.getElementById("modal-container");
let navListItem = document.querySelectorAll(".nav-list-item");
let modalHeaderSite = document.getElementById("modal-header-site");
let modalHeaderTitle = document.getElementById("modal-header-title");
let userPanel = document.getElementById("userPanel");

modal_container.addEventListener("click", (event) => {
    // console.log(event.target);
    if (event.target.getAttribute("id") === "modal-container" || event.target.classList.contains("fa-close")) {
        modal_container.classList.add("d-none");
    }
});
navListItem.forEach(item => {
    item.addEventListener("click", () => {
        console.log(item);
        if (item.getAttribute("id") != "HomePage") {
            modal_container.classList.remove("d-none");
            modalHeaderSite.innerHTML = "موزیک سایت";
            modalHeaderTitle.innerHTML = item.firstChild.innerHTML;
        }
    });
});
userPanel.addEventListener("click", () => {
    modalHeaderSite.innerHTML = "موزیک سایت";
    modalHeaderTitle.innerHTML = "صفحه ورود کاربر";

    modal_container.classList.remove("d-none");

});