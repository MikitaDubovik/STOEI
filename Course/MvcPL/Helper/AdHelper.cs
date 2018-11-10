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
            return new Dictionary<string, string>
            {
                {"CIS", "CIS"},
                {"America", "America"},
                {"Europe", "Europe"},
                {"Chine", "Chine"}
            };
        }

        public static Dictionary<string, string> SexList()
        {
            return new Dictionary<string, string>
            {
                {"male", "male"},
                {"female", "female"},
                {"male-female", "male-female" }
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

        public static Dictionary<string, string> AgeList()
        {
            return new Dictionary<string, string>
            {
                {"1-10", "1-10"},
                {"11-15", "11-15"},
                {"16-19", "16-19"},
                {"20-25", "20-25"},
                {"26-32", "26-32"},
                {"33-40", "33-40"},
                {"40-55", "40-55"},
                {"55+", "55+"}
            };
        }
    }
}