using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService : IGenericService<Admin>
    {
        void AdminDelete(int id);
        List<Admin> GetList();
    }
}
