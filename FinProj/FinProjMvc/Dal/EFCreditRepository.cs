using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinProjMvc.Dal
{
    public class EFCreditRepository : ICreditRepository
    {
        private string _username;
        private FinProjMvcContext db = new FinProjMvcContext();

        public EFCreditRepository(string username)
        {
            _username = username;
        }

        public List<Credit> GetList()
        {
            return db.Credits.Where(c => c.Username == this._username).ToList();
        }

        public Credit Get(int id)
        {
            return db.Credits.Where(c => c.Username == this._username).SingleOrDefault(c => c.CreditId == id);
        }

        public void Insert(Credit credit)
        {
            credit.Username = this._username;
            db.Credits.Add(credit);
            db.SaveChanges();
        }

        public void Update(Credit credit)
        {
            credit.Username = this._username;
            db.Credits.Attach(credit);
            db.Entry(credit).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            // Checks here

            Credit credit = this.Get(id);
            Delete(credit);
        }

        public void Delete(Credit credit)
        {
            if (db.Entry(credit).State == EntityState.Detached)
            {
                db.Credits.Attach(credit);
            }
            db.Credits.Remove(credit);
            db.SaveChanges();
        }
    }
}
