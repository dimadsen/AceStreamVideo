using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AceStream.Core.Entity.Models;
using AceStream.Services.Repositories;
using SQLite;

namespace AceStreamDb
{
    public class DataBase : IDataBase
    {
        private SQLiteConnection _db;

        private string DATABASE_NAME = "AceStreamDb.db";

        private string _path;

        public DataBase()
        {
            _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);

            if (!File.Exists(_path))
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataBase)).Assembly;

                using (var stream = assembly.GetManifestResourceStream($"AceStreamDb.{DATABASE_NAME}"))
                {
                    using (var fs = new FileStream(_path, FileMode.OpenOrCreate))
                    {
                        stream.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
        }

        public List<Championat> GetChampionats()
        {
            using (_db = new SQLiteConnection(_path))
            {
                var championats = _db.Table<Championat>().ToList();

                return championats;
            }
        }

        public Championat GetChampionat(int championatId)
        {
            using (_db = new SQLiteConnection(_path))
            {
                var championats = _db.Table<Championat>().FirstOrDefault(c => c.Id == championatId);

                return championats;
            }
        }

        public List<Match> GetMatches(int championatId)
        {
            using (_db = new SQLiteConnection(_path))
            {
                var matches = _db.Table<Match>().Where(m => m.ChampionatId == championatId).ToList();

                return matches;
            }
        }

        public Match GetMatch(int valueId)
        {
            using (_db = new SQLiteConnection(_path))
            {
                var match = _db.Table<Match>().FirstOrDefault(m => m.ValueId == valueId);

                return match;
            }
        }

        public void SaveMatches(List<Match> matches)
        {
            using (_db = new SQLiteConnection(_path))
            {
                _db.InsertAll(matches);
            }
        }

        public void SaveMatch(Match match)
        {
            using (_db = new SQLiteConnection(_path))
            {
                _db.Insert(match);
            }
        }

        public void Update(Match match)
        {
            using (_db = new SQLiteConnection(_path))
            {
                _db.Update(match);
            }
        }

        public User GetUser(int id)
        {
            using (_db = new SQLiteConnection(_path))
            {
                var user = _db.Table<User>().FirstOrDefault(u => u.Id == id);

                return user;
            }
        }

        public User GetUser(string email, string password)
        {
            using (_db = new SQLiteConnection(_path))
            {
                var user = _db.Table<User>().FirstOrDefault(u => u.Email == email && u.Password == password);

                return user;
            }
        }

        public bool SaveUser(string name, string email, string password)
        {
            using (_db = new SQLiteConnection(_path))
            {
                var existingUser = _db.Table<User>().FirstOrDefault(u => u.Email == email);

                if (existingUser == null)
                {
                    existingUser = new User
                    {
                        Email = email,
                        Name = name,
                        Password = password
                    };

                    _db.Insert(existingUser);

                    return true;
                }

                return false;
            }
        }
    }
}
