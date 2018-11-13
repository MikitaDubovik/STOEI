using System.Collections.Generic;
using BLL.Interface.Entities.Ad;

namespace BLL.Interface.Services
{
    public interface IPayService
    {
        List<string> All();

        void Get(int id);

        void Pay();

        List<BllSex> GetSex();

        List<BllAge> GetAges();

        List<BllCountry> GetCountries();

        List<BllLanguage> GetLanguages();

    }
}
