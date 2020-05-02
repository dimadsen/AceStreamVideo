using System;
using NUnit.Framework;

namespace AceStreamDb.Tests
{
    public class ChampionatTests
    {
        [Test]
        public void GetChampionatTests()
        {
            var sql = new DataBase();

            var championats = sql.GetChampionats();
        }
    }
}
