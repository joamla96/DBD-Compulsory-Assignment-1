using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IRepository
    {
        Depatment Create(Depatment obj);
        Depatment Get(int id);
        List<Depatment> Get();
        void UpdateName(Depatment obj);
        void UpdateManager(Depatment obj);
        void Delete(int id);
    }
}
