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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentList() // bütün yorumlar
        {
            return _commentDal.List();
        }
        public List<Comment> CommentByBlog(int id) // blog ID ye göre yorumlar
        {
            return _commentDal.List(c => c.BlogID == id);
        }
        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(c => c.CommentStatus == true);
        }
      
        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(c => c.CommentStatus == false);
        }

        public void CommentStatusChangeToFalse(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            _commentDal.Update(comment);
        }
        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == id);
            comment.CommentStatus = true;
            _commentDal.Update(comment);
        }

        public Comment GetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public void TAdd(Comment p)
        {
            p.CommentStatus = true;
            _commentDal.Insert(p);
        }
    }
}
