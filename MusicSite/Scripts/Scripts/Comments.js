//Comment
let ID = document.getElementById("OpenComment");
$("#OpenComment").click(() => {
    console.log("Clicked by JQuery");
});
function AddSongComment() {
    console.log("Add Song : " + ID.getAttribute("data-id"));
    console.log($("#name").val());
    console.log($("#email").val());
    console.log($("#comment").val());
    addComment(ID.getAttribute("data-id"));
}
function addComment(id) {
    $.ajax({
        url: "/Comments/AddComment/" + id,
        type: "GET",
        data: { name: $("#name").val(), email: $("#email").val(), comment: $("#comment").val() }
    }).done(function (res) {
        $("#CommentList").html(res);
        $("#name").val("");
        $("#email").val("");
        $("#comment").val("");
    });
}