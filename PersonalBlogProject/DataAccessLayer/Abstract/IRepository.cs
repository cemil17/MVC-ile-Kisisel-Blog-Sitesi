﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> where); // istediğin şarta göre veri getirme işlemi yapabilirsin
        T Find(Expression<Func<T, bool>> where);
        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        T GetByID(int id);


    }
}
