﻿document.getElementById("modal-shadow").addEventListener("click", () => {
    document.getElementById("modal-shadow").classList.remove("d-block-modal");
});
document.getElementById("close-X").addEventListener("click", () => {
    document.getElementById("modal-shadow").classList.remove("d-block-modal");
});


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
    console.log("Create Group Clicked");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Group/Create", (res) => {
        $("#modal-title").html("ساخت گروه دسته بندی");
        $("#modal-body").html(res);
    });
});
function EditGroup(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Group/Edit/" + id, (res) => {
        $("#modal-title").html("ویرایش گروه دسته بندی");
        $("#modal-body").html(res);
    });
}
function DetailsGroup(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Group/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteGroup(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Group/Delete/" + id, (res) => {
        $("#modal-title").html("حذف گروه");
        $("#modal-body").html(res);
    });
}

//Singer
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
//PlayList
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
//User
function DetailUser(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Users/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteUser(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Users/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}
//Country
$("#Create-Country").click(function () {
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Countries/Create", (res) => {
        $("#modal-title").html("کشور جدید");
        $("#modal-body").html(res);
    });
});
function EditCountry(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Countries/Edit/" + id, (res) => {
        $("#modal-title").html("ویرایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DetailCountry(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Countries/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteCountry(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Countries/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}
//Album
$("#Create-Album").click(function () {
    console.log("Create Album Clicked");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Albums/Create", (res) => {
        $("#modal-title").html("ساخت آلبوم");
        $("#modal-body").html(res);
    });
});
function EditAlbum(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Albums/Edit/" + id, (res) => {
        $("#modal-title").html("ویرایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DetailsAlbum(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Albums/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeleteAlbum(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Albums/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}
//Padcast
function DetailPadcasts(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Padcasts/Details/" + id, (res) => {
        $("#modal-title").html("نمایش اطلاعات");
        $("#modal-body").html(res);
    });
}
function DeletePadcasts(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/Padcasts/Delete/" + id, (res) => {
        $("#modal-title").html("حذف اطلاعات");
        $("#modal-body").html(res);
    });
}

// SONGS
let songsItemsPKFK = document.querySelectorAll(".song-items-PK");
let SavePlayList = document.getElementById("SavePlayList");
let Playlists = document.getElementById("Playlists");

songsItemsPKFK.forEach(item => {
    item.addEventListener("click", (event) => {
        if (event.target.tagName === "DIV") {
            if (event.target.classList.contains("Checked")) {
                event.target.classList.remove("Checked");
            } else {
                event.target.classList.add("Checked");
            }
            //console.log(event.target);
        } else {
            if (event.target.parentElement.classList.contains("Checked")) {
                event.target.parentElement.classList.remove("Checked");
            } else {
                event.target.parentElement.classList.add("Checked");
            }
            //console.log(event.target.parentElement);
        }
    });
});

SavePlayList.addEventListener("click", () => {
    console.log("Clicked");
    CreateArraySelectedSongs(Playlists.value);
});

function CreateArraySelectedSongs(PlayListId) {
    console.log("ID : " + PlayListId);
    let SelectedSongs = document.querySelectorAll(".Checked");
    let SongIdList = [];
    SelectedSongs.forEach((item) => {
        SongIdList.push(item.getAttribute("data-id"));
        //console.log(item.getAttribute("data-id"));
    });
    console.log(SongIdList);
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

