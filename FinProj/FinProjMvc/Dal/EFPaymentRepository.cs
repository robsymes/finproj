using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinProjMvc.Dal
{
    public class EFPaymentRepository : IPaymentRepository
    {
        private string _username;
        private FinProjMvcContext db = new FinProjMvcContext();

        public EFPaymentRepository(string username)
        {
            _username = username;
        }

        public List<Payment> GetList()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            Payment payment = db.Payments.Find(id);
            if (payment.Username != this._username)
            {
                throw new Exception("Incorrect user");
            }
            return payment;
        }

        public void Insert(Payment payment)
        {
            payment.Username = this._username;
            db.Payments.Add(payment);
            db.SaveChanges();
        }

        public void Update(Payment payment)
        {
            payment.Username = this._username;
            db.Payments.Attach(payment);
            db.Entry(payment).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            // Checks here

            Payment payment = this.Get(id);
            Delete(payment);
        }

        public void Delete(Payment payment)
        {
            if (db.Entry(payment).State == EntityState.Detached)
            {
                db.Payments.Attach(payment);
            }
            db.Payments.Remove(payment);
            db.SaveChanges();
        }

    }
}