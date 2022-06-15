using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }              
       
        public List<About> GetList()
        {
            return _aboutDal.List();
        }   

        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About p)
        {
            _aboutDal.Update(p);
        }

        public void TAdd(About p)
        {
            throw new NotImplementedException();
        }
    }
}
