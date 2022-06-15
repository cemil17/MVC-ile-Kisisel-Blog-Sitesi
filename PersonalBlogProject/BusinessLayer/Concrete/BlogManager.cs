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
    public class BlogManager : IBlogService
    {

        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDal.List(x => x.CategoryID == id);
        }     
        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AuthorID == id);
        }
        public List<Blog> BlogTrueList()
        {
            return _blogDal.List(x => x.BlogStatus == true);
        }
        public List<Blog> BlogFalseList()
        {
            return _blogDal.List(x => x.BlogStatus == false);
        }
        public void DeleteBlog(int p)
        {
            Blog blog = _blogDal.Find(x => x.BlogID == p);
            blog.BlogStatus = false;
            _blogDal.Update(blog);
        }
        public void TrueToBlog(int p)
        {
            Blog blog = _blogDal.Find(x => x.BlogID == p);
            blog.BlogStatus = true;
            _blogDal.Update(blog);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public Blog GetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void TUpdate(Blog p)
        {
            _blogDal.Update(p);
        }

        public void TAdd(Blog p)
        {
            p.BlogStatus = true;
            _blogDal.Insert(p);
        }
    }
}
