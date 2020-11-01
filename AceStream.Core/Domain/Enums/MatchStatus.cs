using System.ComponentModel;

namespace AceStream.Core.Domain.Enums
{
    public enum MatchStatus
    {
        [Description("не начался")]
        NotStarted = 1,

        [Description("онлайн")]
        InProgress = 2,

        [Description("перерыв")]
        TimeOut = 3,

        [Description("завершён")]
        Completed = 4
    }
}
