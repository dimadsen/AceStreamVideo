using System.ComponentModel;

namespace AceStream.Infrastructure.SportsRuParser.Enums
{
    public enum Championship
    {
        /// <summary>
        /// Российская Премьер-Лига
        /// </summary>
        [Description("Премьер-Лига")]
        RPL = 1363803,

        /// <summary>
        /// Английская Премьер-Лига
        /// </summary>
        [Description("Премьер-Лига")]
        APL = 1363805,

        /// <summary>
        /// Ла Лига
        /// </summary>
        [Description("Ла Лига")]
        LaLiga = 1364772,

        /// <summary>
        /// Серия А
        /// </summary>
        [Description("Серия А")]
        SeriaA = 1364769,

        ///// <summary>
        ///// Бундеслига
        ///// </summary>
        [Description("Бундеслига")]
        Bundesliga = 1363808,

        /// <summary>
        /// Лига 1
        /// </summary>
        [Description("Лига 1")]
        Liga1 = 1364762,

        [Description("Лига наций")]
        NationsLeague = 161038575
    }
}
