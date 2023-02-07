//Comment

function AddSongComment(id) {
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