using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PayRepository : IPayRepository
    {
        private readonly ApplicationDbContext _context;

        public List<DalPayment> Get()
        {
            throw new NotImplementedException();
        }

        public DalPayment Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Pay(DalPayment payment)
        {
            throw new NotImplementedException();
        }

        public List<DalSex> GetSex()
        {
            return _context.Sex.Select(s => new DalSex {SexId = s.SexId, Label = s.Label}).ToList();
        }

        public List<DalAge> GetAge()
        {
            return _context.Ages.Select(s => new DalAge { AgeId = s.AgeId, Label = s.Label }).ToList();
        }

        public List<DalCountry> GetCountries()
        {
            return _context.Countries.Select(s => new DalCountry { CountryId = s.CountryId, Label = s.Label }).ToList();
        }

        public List<DalLanguage> GetLanguages()
        {
            return _context.Languages.Select(s => new DalLanguage() { LanguageId = s.LanguageId, Label = s.Label }).ToList();
        }
    }
}
