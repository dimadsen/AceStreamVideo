using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AceStreamDb.Models;
using SQLite;
namespace AceStreamDb
{
    public class DataBase
    {
        private SQLiteConnection _db;

        private string DATABASE_NAME = "AceStreamDb.db";

        public DataBase()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
            
            if (!File.Exists(path))
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataBase)).Assembly;
              
                using (var stream = assembly.GetManifestResourceStream($"AceStreamDb.{DATABASE_NAME}"))
                {
                    using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        stream.CopyTo(fs);  
                        fs.Flush();
                    }
                }
            }

            _db = new SQLiteConnection(path);
        }

        public List<Championat> GetChampionats()
        {
            var championats = _db.Table<Championat>().ToList();

            return championats;
        }

        public Championat GetChampionat(int championatId)
        {
            var championat = _db.Table<Championat>().FirstOrDefault(c => c.Id == championatId);

            return championat;
        }

        public List<Match> GetMatches(int championatId)
        {
            var matches = _db.Table<Match>().Where(m => m.ChampionatId == championatId).ToList();

            return matches;
        }

        public Match GetMatch(int valueId)
        {
            var match = _db.Table<Match>().FirstOrDefault(m => m.ValueId == valueId);

            return match;
        }

        public void SaveMatches(List<Match> matches)
        {
            _db.InsertAll(matches);            
        }

        public void SaveMatch(Match match)
        {
            _db.Insert(match);
        }

        public User GetUser(int id)
        {
            var user = _db.Table<User>().FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User GetUser(string email, string password)
        {
            var user = _db.Table<User>().FirstOrDefault(u => u.Email == email && u.Password == password);

            return user;
        }

        public bool SaveUser(string name, string email, string password)
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
