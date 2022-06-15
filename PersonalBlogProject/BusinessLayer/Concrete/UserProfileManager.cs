using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repoUser = new Repository<Author>();
        Repository<Blog> repoUserBlog = new Repository<Blog>();

        public List<Author> GetAuthorByMail(string p)
        {
            return repoUser.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoUserBlog.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByAuthorTrue(int id)
        {
            return repoUserBlog.List(x => x.BlogStatus == true);
        }
        public void AuthorUpdate(Author a)
        {
            Author author = repoUser.Find(x => x.AuthorID == a.AuthorID);
            author.Name = a.Name;
            author.Mail = a.Mail;
            author.Image = a.Image;
            author.ShortAbout = a.ShortAbout;
            author.AuthorTitle = a.AuthorTitle;
            author.AuthorAbout = a.AuthorAbout;
            author.Password = a.Password;
            author.PhoneNumber = a.PhoneNumber;

            repoUser.Update(author);
        }
    }
}
