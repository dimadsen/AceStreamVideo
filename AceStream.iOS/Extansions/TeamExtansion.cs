using System;
namespace AceStream.Extansions
{
    public static class TeamExtansion
    {
        //public static bool IsSquards(this nint segment)
        //{
        //    //Потому что раздел с составами сейчас в первом сегменте
        //    return segment == 0;
        //}

        //public static bool IsBroadCasts(this nint segment)
        //{
        //    //Потому что развел с трансляциями сейчас во втором сегменте
        //    return segment == 1;
        //}

        public static bool IsStartings(this nint section)
        {
            return section == 0;
        }

        public static bool IsStartings(this int section)
        {
            return section == 0;
        }

        public static bool IsSubstitutes(this nint section)
        {
            return section == 1;
        }

        public static bool IsSubstitutes(this int section)
        {
            return section == 1;
        }
    }
}
