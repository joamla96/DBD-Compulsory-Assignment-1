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
        Depatment UpdateName(Depatment obj);
        Depatment UpdateManager(Depatment obj);
        void Delete(int id);
    }
}
