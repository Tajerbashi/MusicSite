﻿using DAL;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicSite.Controllers
{
    public class SectionController : Controller
    {
        DbContexts DB=new DbContexts();
        IGroupRepository groupRepository;
        ISongRepository songRepository;
        IPlayListRepository playListRepository;
        IAlbumRepository albumRepository;
        ICountryRepository countryRepository;
        ISingerRepository singerRepository;
        // GET: Section
        public SectionController()
        {
            groupRepository = new GroupRepository(DB);
            songRepository = new SongRepository(DB);
            playListRepository = new PlayListRepository(DB);
            albumRepository= new AlbumRepository(DB);
            countryRepository= new CountryRepository(DB);
            singerRepository= new SingerRepository(DB);
        }
        public ActionResult Group()
        {
            return PartialView(groupRepository.GetAllGroupToShow());
        }
        public ActionResult Songs()
        {
            return PartialView(songRepository.GetAllSongView().Where(c => c.SongType).ToList());
        }
        public ActionResult PlaySong(int id)
        {
            ViewBag.List = songRepository.GetAllSongView().Where(c => c.SongId==id).ToList();
            return PartialView();
        }
        public ActionResult PlayTopSongs()
        {
            return PartialView(songRepository.GetAllSongView().OrderByDescending(c => c.Visit).ToList());
        }
        public ActionResult PlayLists()
        {
            return PartialView(playListRepository.GetAllToShow());
        }
        public ActionResult PlayListsShowSongs(int id)
        {
            return PartialView(playListRepository.GetAllToShow().Where(c => c.PlayListId==id).ToList());
        }
        public ActionResult Padcasts()
        {
            return PartialView(songRepository.GetAllSongView().Where(c => !c.SongType).ToList());
        }
        public ActionResult PlayListsPlay(int id)
        {
            PlayList playList = playListRepository.GetById(id);
            playList.Visit += 1;
            playListRepository.Save();
            ViewBag.Name = playList.PlayListName;
            return View(playListRepository.GetAllToShow().Where(c => c.PlayListId == id).ToList());
        }
        public ActionResult Albums()
        {
            return PartialView(albumRepository.GetAllModelAlbum());
        }
        public ActionResult ShowAlbumSongs(int id)
        {
            return PartialView(songRepository.GetAllSongView().Where(c => c.Album.AlbumId == id).ToList());
        }
        public ActionResult AlbumPlay(int id)
        {
            Album album = albumRepository.GetById(id);
            album.Visit += 1;
            albumRepository.Save();
            ViewBag.Name = album.AlbumName;
            return View(songRepository.GetAllSongView().Where(c => c.Album.AlbumId == id).ToList());
        }
        public ActionResult Countries()
        {
            return PartialView(countryRepository.GetAllToShow().Where(c => c.PlayLists.Count>0 || c.Singers.Count>0).ToList());
        }
        public ActionResult CountriesPlayLists(int id)
        {
            return PartialView(playListRepository.GetAllToShow().Where(c => c.CountryId == id).ToList());
        }
        public ActionResult CountriesSingers(int id)
        {
            return PartialView(singerRepository.GetAllToShow().Where(c => c.CountryId == id).ToList());
        }
        public ActionResult CountriesPadcasts(int id)
        {
            return PartialView(songRepository.GetAllSongView().Where(c => c.CountryId == id && !c.SongType).ToList());
        }
        public ActionResult Singers()
        {
            return PartialView(singerRepository.GetAllToShow().Where(c => c.SongCount > 0).ToList());
        }
        public ActionResult PlaySingerSongs(int id)
        {
            Singer singer = singerRepository.GetById(id);
            ViewBag.Name = singer.SingerName;
            return View(songRepository.GetAllSongView().Where(c => c.SingerName==singer.SingerName).ToList());
        }
        public ActionResult Remix()
        {
            return PartialView(songRepository.GetAllSongView().OrderBy(c => c.SingerName).Where(c => c.Remix).ToList());
        }
    }
}