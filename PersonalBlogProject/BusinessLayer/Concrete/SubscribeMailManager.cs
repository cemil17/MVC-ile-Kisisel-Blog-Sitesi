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
    public class SubscribeMailManager: ISubscribeMailService
    {

        ISubscribeMailDal _mailDal;

        public SubscribeMailManager(ISubscribeMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public SubscribeMail GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> GetSubscribeMails()
        {
            return _mailDal.List();
        }
     

        public void TAdd(SubscribeMail p)
        {
            _mailDal.Insert(p);
        }

        public void TUpdate(SubscribeMail p)
        {
            throw new NotImplementedException();
        }
    }
}
