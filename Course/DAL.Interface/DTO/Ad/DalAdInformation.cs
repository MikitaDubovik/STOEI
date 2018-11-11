using System.Collections.Generic;

namespace DAL.Interface.DTO.Ad
{
    public class DalAdInformation
    {
        public List<DalAge> Ages { get; set; }

        public List<DalCountry> Countries { get; set; }

        public List<DalLanguage> Languages { get; set; }

        public List<DalSex> Sex { get; set; }
    }
}
