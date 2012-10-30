using FinProjMvc.Dal;
using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Tests.Controllers
{
    public class TestCreditRepository : ICreditRepository
    {
        private string _username;

        public TestCreditRepository(string username)
        {
            _username = username;
        }

        public List<Credit> GetList()
        {
            return new List<Credit>();
        }

        public Credit Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Credit asset)
        {
            throw new NotImplementedException();
        }

        public void Update(Credit asset)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Credit asset)
        {
            throw new NotImplementedException();
        }
    }
}
