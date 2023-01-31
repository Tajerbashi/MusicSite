let BtnComment = document.getElementById("OpenComment");

BtnComment.addEventListener("click", () => {
    let Id = BtnComment.getAttribute("data-id");

    OpenComment(Id);
});
function OpenComment(id) {
    console.log("Open Comment On Song Id" + id);
}