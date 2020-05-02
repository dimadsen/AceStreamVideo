using System;
using SQLite;

namespace AceStreamDb.Models
{
    public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ChampionatId { get; set; }
        /// <summary>
        /// Идентифкатор матча на сайте
        /// </summary>
        public int ValueId { get; set; }
        public string Date { get; set; }
    }
}
