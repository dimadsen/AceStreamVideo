using System;
using NUnit.Framework;

namespace AceStreamDb.Tests
{
    public class ChampionatTest
    {
        [Test]
        public void ChampionatTests()
        {
            //var sql = new DataBase();

            //var championats = sql.GetChampionats();
            var x = "Беларусь. Высшая лига 2020. 6 тур";
            var y = x.Split(". ", StringSplitOptions.None);
        }
    }
}
