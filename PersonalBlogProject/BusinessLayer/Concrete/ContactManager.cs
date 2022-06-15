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
    public class ContactManager: IContactService
    {

        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

       
        public List<Contact> GetStatusActive()
        {
            return _contactDal.List(z => z.ContactStatus == true);
        }
        public List<Contact> GetStatusPassive()
        {
            return _contactDal.List(z => z.ContactStatus == false);
        }
        public void ContactToFalse(int id)
        {
            Contact contact = _contactDal.Find(x => x.ContactID == id);
            contact.ContactStatus = false;
            _contactDal.Update(contact);
        }
       

        public void TUpdate(Contact p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Contact p)
        {
            _contactDal.Insert(p);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Find(x => x.ContactID == id);
        }
    }
}
