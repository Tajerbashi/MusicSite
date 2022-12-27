var aside = document.getElementById("aside-panel");

aside.addEventListener("click", (event) => {
    console.log(event.target.tagName);
    if (event.target.tagName === "UL" || event.target.tagName === "ASIDE") {
        if (aside.classList.contains("open")) {
            aside.classList.remove("open");
            aside.classList.add("close");
        } else {
            aside.classList.remove("close");
            aside.classList.add("open");
        }
    }
});

$("#modal-shadow").click((event) => {
    if (event.target.id === "modal-shadow" || event.target.id === "close-X") {
        $("#modal-shadow").removeClass("d-block");
    }
});

$("#Create-Group").click(function () {
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/GrouptTypes/Create", (res) => {
        $("#modal-title").html("ساخت گروه");
        $("#modal-body").html(res);
    });
});
function EditGroup(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/GrouptTypes/Edit/" + id, (res) => {
        $("#modal-title").html("ویرایش گروه");
        $("#modal-body").html(res);
    });
}
function DetailsGroup(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/GrouptTypes/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteGroup(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/GrouptTypes/Delete/" + id, (res) => {
        $("#modal-title").html("حذف گروه");
        $("#modal-body").html(res);
    });
}

$("#Create-Singer").click(function () {
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Singers/Create", (res) => {
        $("#modal-title").html("هنرمند جدید");
        $("#modal-body").html(res);
    });
});
function EditSinger(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Singers/Edit/" + id, (res) => {
        $("#modal-title").html("ویرایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DetailSinger(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Singers/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteSinger(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Singers/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}


$("#CreatePlayList").click(function () {
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PlayLists/Create", (res) => {
        $("#modal-title").html("پلی لیست جدید");
        $("#modal-body").html(res);
    });
});
function EditPlayLists(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PlayLists/Edit/" + id, (res) => {
        $("#modal-title").html("ویرایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DetailPlayLists(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PlayLists/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeletePlayLists(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PlayLists/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}
//ADMIN
function DetailAdmin(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Admins/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteAdmin(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Admins/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}
//Song
function DetailSong(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Songs/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteSong(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Songs/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}

let songs = document.querySelector(".SONGS");
let CreateBtn = document.getElementById("Create");
var SongIdList = [];
let PlayListId;

function Reload() {
    songs = document.querySelectorAll(".SONGS");
}

songs.addEventListener("click", (event) => {
    //console.log(event.target.tagName);
    if (event.target.tagName === "SPAN" || event.target.tagName === "P" || event.target.tagName === "IMG" || event.target.tagName === "I") {
        if (event.target.parentElement.tagName === "SPAN") {
            if (event.target.parentElement.children[2].classList.contains("d-none")) {
                    event.target.parentElement.children[2].classList.remove("d-none");
                    event.target.parentElement.parentElement.classList.add("SelectedSong");
            } else {
                    event.target.parentElement.children[2].classList.add("d-none");
                    event.target.parentElement.parentElement.classList.remove("SelectedSong");
            }
        }
    }
    if (event.target.tagName === "I") {
        if (event.target.parentElement.parentElement.children[2].classList.contains("d-none")) {
            event.target.parentElement.parentElement.children[2].classList.remove("d-none");
            event.target.parentElement.parentElement.parentElement.classList.add("SelectedSong");
        } else {
            event.target.parentElement.parentElement.children[2].classList.add("d-none");
            event.target.parentElement.parentElement.parentElement.classList.remove("SelectedSong");
        }
    }
});

$("#Create").click(() => {
    console.log("Clicked Create Btn");
    CreateArraySelectedSongs();
});
function CreateArraySelectedSongs() {
    let SelectedSongs = document.querySelectorAll(".SelectedSong");
    PlayListId = document.getElementById("groupSelected").value;
    console.log("Selected : " + SelectedSongs);
    SelectedSongs.forEach((item) => {
        SongIdList.push(item.getAttribute("data-id"));
    });
    $.ajax({
        type: 'POST',
        url: '/Admin/PlayLists/CreatePlayListSongs',
        data: { 'PlayListId': PlayListId, 'SongIdList': SongIdList },
        datatype: "json",
        traditional: true,
        success: function () {
            location.reload(true);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("jqXHR:" + jqXHR.status + " errorThrown: " + errorThrown);
        }
    });
}