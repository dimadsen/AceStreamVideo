using System;
using SQLite;

namespace AceStreamDb.Models
{
    public class Championat
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Icon { get; set; }
        public string Country { get; set; }
        public string ShortName { get; set; }
    }
}
