using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flankerbase2.Models
{
    public class BlogRepository
    {
        private flankerbaseDataContext db = new flankerbaseDataContext();

        public IQueryable<Blog> FindAll()
        {
            return db.Blog.OrderByDescending(x => x.Created_at);
        }

        public Blog FindByKey(string key)
        {
            Blog blog = db.Blog.SingleOrDefault(x => x.Code == key);
            if (blog == null)
            {
                throw new flankerbase2.Helpers.Exceptions.BlogNotFoundException();
            }
            return blog;
        }

        public void Create(Blog blog)
        {
            blog.Created_at = DateTime.Now;
            blog.Updated_at = DateTime.Now;
            db.Blog.InsertOnSubmit(blog);
            db.SubmitChanges();
        }

        public void Create(Comment comment)
        {
            comment.Created_at = DateTime.Now;
            db.Comment.InsertOnSubmit(comment);
            db.SubmitChanges();
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
