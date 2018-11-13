using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Ad;
using BLL.Interface.Services;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class PayService : IPayService
    {
        private readonly IPayRepository _repository;

        public PayService(IPayRepository repository)
        {
            _repository = repository;
        }

        public List<string> All()
        {
            throw new NotImplementedException();
        }

        public void Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public List<BllSex> GetSex()
        {
            return _repository.GetSex().Select(p => Mapper.CreateMap().Map<BllSex>(p)).ToList();
        }

        public List<BllAge> GetAges()
        {
            return _repository.GetAge().Select(p => Mapper.CreateMap().Map<BllAge>(p)).ToList();
        }

        public List<BllCountry> GetCountries()
        {
            return _repository.GetCountries().Select(p => Mapper.CreateMap().Map<BllCountry>(p)).ToList();
        }

        public List<BllLanguage> GetLanguages()
        {
            return _repository.GetLanguages().Select(p => Mapper.CreateMap().Map<BllLanguage>(p)).ToList();
        }
    }
}
