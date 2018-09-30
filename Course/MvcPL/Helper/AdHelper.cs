using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MvcPL.Helper
{
    public class AdHelper
    {
        public static Dictionary<string, string> CountryList()
        {
            //Creating Dictionary
            var cultureList = new Dictionary<string, string>();

            //getting the specific CultureInfo from CultureInfo class
            var getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var getCulture in getCultureInfo)
            {
                //creating the object of RegionInfo class
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);
                //adding each country Name into the Dictionary
                if (!(cultureList.ContainsKey(getRegionInfo.Name)))
                {
                    cultureList.Add(getRegionInfo.Name, getRegionInfo.EnglishName);
                }
            }

            //returning country list
            return cultureList;
        }

        public static Dictionary<string, string> SexList()
        {
            return new Dictionary<string, string>
            {
                {"male", "male"},
                {"female", "female"}
            };
        }

        public static Dictionary<string, string> LanguagesList()
        {
            return new Dictionary<string, string>
            {
                {"English", "English"},
                {"Belarusian", "Belarusian"},
                {"Russian", "Russian"},
                {"Chinese", "Chinese"},
                {"German", "German"},
            };
        }

        public static Dictionary<string, string> AgeListBegin()
        {
            return new Dictionary<string, string>
            {
                {"1", "1"},
                {"2", "2"},
                {"3", "3"},
                {"4", "4"},
                {"5", "5"},
                {"6", "6"},
                {"7", "7"},
                {"8", "8"},
                {"9", "9"},
                {"10", "10"},
                {"11", "11"},
                {"12", "12"},
                {"13", "13"},
                {"14", "14"},
                {"15", "15"},
                {"16", "16"},
                {"17", "17"},
                {"18", "18"},
                {"19", "19"},
                {"20", "20"}
            };
        }

        public static Dictionary<string, string> AgeListEnd()
        {
            return new Dictionary<string, string>
            {
                {"21", "21"},
                {"22", "22"},
                {"23", "23"},
                {"24", "24"},
                {"25", "25"},
                {"26", "26"},
                {"27", "27"},
                {"28", "28"},
                {"29", "29"},
                {"30+", "30"}
            };
        }
    }
}