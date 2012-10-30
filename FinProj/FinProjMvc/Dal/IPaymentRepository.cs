using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Dal
{
    public interface IPaymentRepository
    {
        List<Payment> GetList();
        Payment Get(int id);
        void Insert(Payment payment);
        void Update(Payment payment);
        void Delete(int id);
        void Delete(Payment payment);
    }
}
