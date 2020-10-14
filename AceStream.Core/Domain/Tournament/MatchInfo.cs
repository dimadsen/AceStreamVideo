﻿using System;
using Newtonsoft.Json;

namespace AceStream.Core.Domain.Tournament
{
    public class MatchInfo
    {
        public string Id { get; set; }

        public Date Date { get; set; }

        public Status Status { get; set; }

        public string Score { get; set; }

        public Team Home { get; set; }

        public Team Visitor { get; set; }
    }

    public class Date
    {

        public DateTime StartDate { get; set; }
    }

    public class Status
    {
        public string Name { get; set; }
    }

}
