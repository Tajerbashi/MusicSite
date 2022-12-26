﻿using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class SongRepository : ISongRepository
    {
        DbContexts DB;
        public SongRepository(DbContexts DB) 
        {
            this.DB = DB;
        }
        public bool Add(Song song)
        {
            try
            {
                DB.Songs.Add(song);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Song song)
        {
            try
            {
                DB.Entry(song).State=EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<Song> GetAll()
        {
            return DB.Songs.ToList();
        }

        public Song GetById(int id)
        {
            return DB.Songs.Find(id);
        }

        public Song GetByName(string Name)
        {
            return DB.Songs.Where(c => c.Name==Name).SingleOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Song song)
        {
            try
            {
                DB.Entry(song).State= EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}