
let durTime = document.getElementById("durTime");
let endTime = document.getElementById("endTime");
let IsPlay = false;
let ProgressContainer = document.getElementById("Progress-Container");
let Progress = document.getElementById("Progress");
let audioIndex = document.getElementById("audioIndex");

//PlayAjax
function PlayMusicAjax(id) {
    console.log("Music Clicked Id : " + id);
    $.ajax({
        url: "/Home/Player/" + id,
        type: "GET",
    }).done(function (res) {
        $("#Player").html(res);
        //console.log(res);
        durTime = document.getElementById("durTime");
        endTime = document.getElementById("endTime");
        IsPlay = false;
        ProgressContainer = document.getElementById("Progress-Container");
        Progress = document.getElementById("Progress");
        audioIndex = document.getElementById("audioIndex");
    });
}
function AddScore(id, score) {
    if (id != 0) {
        console.log("Score: " + score);
        console.log("Id: " + id);
        $.ajax({
            url: "/Home/AddScore/" + id,
            type: "GET",
            data: { score: score }
        }).done(function (res) {
            $("#Player").html(res);
        });
    }
}



function Play() {
    if (IsPlay) {
        $("#PlayBtn").removeClass("fa-pause");
        $("#PlayBtn").addClass("fa-play");
        IsPlay = false;
        Pause();
    } else {
        $("#PlayBtn").removeClass("fa-play");
        $("#PlayBtn").addClass("fa-pause");
        IsPlay = true;
        loadSong();
    }
}
function Stop() {
    $("#PlayBtn").removeClass("fa-pause");
    $("#PlayBtn").addClass("fa-play");
    IsPlay = false;
    audioIndex = document.getElementById("audioIndex");
    audioIndex.pause();
    audioIndex.currentTime = 0;
}
function Pause() {
    audioIndex = document.getElementById("audioIndex");
    audioIndex.pause();
}
function GetTime(sec) {
    let Time = 0;
    let Minute = Math.floor(sec / 60);
    let Second = Math.floor(sec - (Minute * 60));
    if (Minute < 10) {
        if (Second < 10) {
            Time = `0${Minute}:0${Second}`;
        } else {
            Time = `0${Minute}:${Second}`;
        }
    } else {
        if (Second < 10) {
            Time = `${Minute}:0${Second}`;
        } else {
            Time = `${Minute}:${Second}`;
        }
    }
    return Time;
}
function UpdateTimer() {
    let Time = GetTime(audioIndex.currentTime);
    let progressPercent = (audioIndex.currentTime / audioIndex.duration) * 100;
    Progress.style.width = progressPercent + "%";
    durTime.innerHTML = Time;
}
function setProgress(e) {
    const width = this.clientWidth;
    const clickX = e.offsetX;
    const duration = audioIndex.duration;
    audioIndex.currentTime = (clickX / width) * duration;
}
function loadSong() {
    audioIndex = document.getElementById("audioIndex");
    audioIndex.play();
    Progress.style.width = 0 + "%";
    endTime.innerHTML = GetTime(audioIndex.duration);
    ProgressContainer.addEventListener('click', setProgress);
    audioIndex.addEventListener("timeupdate", UpdateTimer);
    setTimeout(function () {
        durTime.innerHTML = GetTime(audioIndex.duration);
    }, 1000);
}