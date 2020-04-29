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
    }
}
