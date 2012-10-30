using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Dal
{
    public interface ICreditRepository
    {
        List<Credit> GetList();
        Credit Get(int id);
        void Insert(Credit asset);
        void Update(Credit asset);
        void Delete(int id);
        void Delete(Credit asset);

    }
}
