let modal_container = document.getElementById("modal-container");
let navListItem = document.querySelectorAll(".nav-list-item");
let modalHeaderSite = document.getElementById("modal-header-site");
let modalHeaderTitle = document.getElementById("modal-header-title");
let userPanel = document.getElementById("userPanel");
let modalBody = document.getElementById("modal-body");
let BtnComment = document.getElementById("OpenComment"); 
let SearchHomeTxt = document.getElementById("SearchHomeTxt");
let SearchHomeIco = document.getElementById("SearchHomeIco");

function ModalInfo(Title) {
    modalHeaderSite.innerHTML = "موزیک سایت";
    modalHeaderTitle.innerHTML = Title;
    modal_container.classList.remove("d-none");
}
modal_container.addEventListener("click", (event) => {
    // console.log(event.target);
    if (event.target.getAttribute("id") === "modal-container" || event.target.classList.contains("fa-close")) {
        modal_container.classList.add("d-none");
    }
});
userPanel.addEventListener("click", () => {
    UserPanel();
});

function GroupOpen() {
    ModalInfo("دسته بندی");
    console.log("Section Groups Open Clicked");
    $.get("/Section/Group", (res) => {
        $("#modal-body").html(res);
    });
}
function SongsOpen() {
    ModalInfo("آهنگ ها");

    console.log("Section Songs Open Clicked");
    $.get("/Section/Songs", (res) => {
        $("#modal-body").html(res);
    });
}
function PlayListOpen() {
    ModalInfo("پلی لیست ها");

    console.log("Section PlayList Open Clicked");
    $.get("/Section/PlayLists", (res) => {
        $("#modal-body").html(res);
    });
}
function AlbumOpen() {
    ModalInfo("آلبوم ها");

    console.log("Section Album Open Clicked");
    $.get("/Section/Albums", (res) => {
        $("#modal-body").html(res);
    });
}
function PadcastOpen() {
    ModalInfo("پادکست ها");

    console.log("Section Padcast Open Clicked");
    $.get("/Section/Padcasts", (res) => {
        $("#modal-body").html(res);
    });
}
function CountryOpen() {
    ModalInfo("کشوری");

    console.log("Section Country Open Clicked");
    $.get("/Section/Countries", (res) => {
        $("#modal-body").html(res);
    });
}
function SingerOpen() {
    ModalInfo("خواننده گان");

    console.log("Section Country Open Clicked");
    $.get("/Section/Singers", (res) => {
        $("#modal-body").html(res);
    });
}
function RemixOpen() {
    ModalInfo("ریمیکس ها");

    console.log("Section Remix Open Clicked");
    $.get("/Section/Remix", (res) => {
        $("#modal-body").html(res);
    });
}
function SearchHome() {
    let word = SearchHomeTxt.value;
    ModalInfo("نتایج جستجو");

    console.log("Home Search Open Clicked");
    $.get("/SearchHome/"+word, (res) => {
        $("#modal-body").html(res);
    });
}
function OpenComment(id) {
    ModalInfo("موزیک سایت");
    modalHeaderTitle.innerHTML = "نظریات کاربران";
    if (id == 0 || id == null) {
        modalBody.style.color = "#efedea";
        modalBody.style.fontSize = "4rem";
        modalBody.style.paddingTop = "10rem";
        modalBody.innerHTML = "هنوز آهنگی انتخاب نشده است!!!";
    } else {
        console.log("Section Comment Open Clicked" + id);
        $.get("/Comments/AllComment/"+ id, (res) => {
            $("#modal-body").html(res);
        });
    }
}
function UserPanel() {
    ModalInfo("ورود به حساب کاربری");

    console.log("Section Remix Open Clicked");
    $.get("/Comments/UserLogin", (res) => {
        $("#modal-body").html(res);
    });
}
SearchHomeIco.addEventListener("click", () => {
    SearchHome();
});
SearchHomeTxt.addEventListener("keypress", (event) => {
    if (event.charCode === 13) {
        console.log(event.target.value);
        SearchHome();
    }
});