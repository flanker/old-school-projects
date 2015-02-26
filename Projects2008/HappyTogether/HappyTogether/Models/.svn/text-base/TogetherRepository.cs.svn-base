using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyTogether.Helper;

namespace HappyTogether.Models
{
    public class TogetherRepository
    {
        private HappyTogetherDataContext db = new HappyTogetherDataContext();

        readonly int PageSize = 7;

        // 查询方法
        public IQueryable<Together> FindAllTogethers()
        {
            return db.Together;
        }
        public IQueryable<Together> FindUpcomingTogethers()
        {
            return from together in db.Together
                   where together.StartDate > DateTime.Now
                   orderby together.StartDate
                   select together;
        }
        public PaginatedList<Together> FindUpcomingTogethers(int? Page)
        {
            var togethers = FindUpcomingTogethers();

            return new PaginatedList<Together>(togethers, Page ?? 0, PageSize);
        }
        public Together GetTogether(int id)
        {
            return db.Together.SingleOrDefault(t => t.TogetherID == id);
        }

        // 插入/删除
        public void Add(Together together)
        {
            db.Together.InsertOnSubmit(together);
        }
        public void Delete(Together together)
        {
            db.Post.DeleteAllOnSubmit(together.Posts);
            db.Attendee.DeleteAllOnSubmit(together.Attendees);
            db.Together.DeleteOnSubmit(together);
        }

        // 持久化
        public void Save()
        {
            db.SubmitChanges();
        }

        // 查询
        public IQueryable<Together> FindByLocation(float latitude, float longitude)
        {
            var togethers = from together in FindUpcomingTogethers()
                            join i in db.NearestTogether(latitude, longitude)
                            on together.TogetherID equals i.TogetherID
                            select together;
            return togethers;
        }

        // 查询
        public IQueryable<Together> FindByLocation(float latitude, float longitude, TogetherTypeWithAllEnum togetherType)
        {
            var togethers = FindByLocation(latitude, longitude);

            if (togetherType != TogetherTypeWithAllEnum.All)
            {
                togethers = from together in togethers
                            where (int)together.TogetherType == (int)togetherType
                            select together;
            }
            return togethers;
        }

        public void AddPost(Post post)
        {
            db.Post.InsertOnSubmit(post);
        }
    }
}
