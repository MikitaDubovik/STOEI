using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    public interface IPayRepository
    {
        List<DalPayment> Get();

        DalPayment Get(int id);

        void Pay(DalPayment payment);
    }
}
