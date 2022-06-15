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
    public class AuthorManager : IAuthorService
    {

        IAuthorDal _authordal;

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }

        // Tüm yazar listesini getirme
        //public List<Author> GetAll()
        //{
        //    return repoAuthor.List();
        //}
        public List<Author> StatusActive()
        {
            return _authordal.List(x => x.AuthorStatus == true);
        }
        public List<Author> StatusPassive()
        {
            return _authordal.List(x => x.AuthorStatus == false);
        }

        // Yazar ekleme
        //public void AuthorAdded(Author a)
        //{
        //    //if (a.AuthorTitle == "" || a.Name.Length >= 51 || a.Name.Length <= 2 || a.AuthorAbout == "" || a.ShortAbout == "" || a.Mail == "" || a.Mail.Length <= 8 || a.Mail.Length >= 51)
        //    //{
        //    //    return -1;
        //    //}
        //    repoAuthor.Insert(a);
        //}

        // Yazarın ID'ye göre update sayfasına taşınması
        //public Author FindAuthor(int id)
        //{
        //    return repoAuthor.Find(x => x.AuthorID == id);
        //}
        public void AuthorToFalse(int id)
        {
            Author author = _authordal.Find(x => x.AuthorID == id);
            author.AuthorStatus = false;
            _authordal.Update(author);
        }
        public void AuthorToTrue(int id)
        {
            Author author = _authordal.Find(x => x.AuthorID == id);
            author.AuthorStatus = true;
            _authordal.Update(author);
        }
        //public void AuthorUpdate(Author a)
        //{
        //    Author author = repoAuthor.Find(x => x.AuthorID == a.AuthorID);
        //    author.Name = a.Name;
        //    author.Mail = a.Mail;
        //    author.Image = a.Image;
        //    author.ShortAbout = a.ShortAbout;
        //    author.AuthorTitle = a.AuthorTitle;
        //    author.AuthorAbout = a.AuthorAbout;
        //    author.Password = a.Password;
        //    author.PhoneNumber = a.PhoneNumber;

        //    repoAuthor.Update(author);
        //}

        public Author GetByID(int id)
        {
            return _authordal.GetByID(id);
        }

        public void TUpdate(Author p)
        {
            p.AuthorStatus = true;
            _authordal.Update(p);
        }

        public void TAdd(Author p)
        {
            p.AuthorStatus = true;
            _authordal.Insert(p);
        }
    }
}
