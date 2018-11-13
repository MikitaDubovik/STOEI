using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    public interface IPayRepository
    {
        IEnumerable<DalPayment> Get();

        DalPayment Get(int id);

        void Pay(DalPayment payment);

        IEnumerable<DalSex> GetSex();

        IEnumerable<DalAge> GetAge();

        IEnumerable<DalCountry> GetCountries();

        IEnumerable<DalLanguage> GetLanguages();
    }
}
