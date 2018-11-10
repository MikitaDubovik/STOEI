using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Context;
using System;
using System.Collections.Generic;

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
    }
}
