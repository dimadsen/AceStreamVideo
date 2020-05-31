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

        public string Score { get; set; }

        public string Status { get; set; }

        public string Home { get; set; }

        public string HomeIcon { get; set; }

        public string Visitor { get; set; }

        public string VisitorIcon { get; set; }
    }
}
