using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminDelete(int id)
        {
            Admin admin = _adminDal.Find(x => x.AdminID == id);
            _adminDal.Delete(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.GetByID(id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public void TAdd(Admin p)
        {
            _adminDal.Insert(p);
        }

        public void TUpdate(Admin p)
        {
            _adminDal.Update(p);
        }
    }
}
