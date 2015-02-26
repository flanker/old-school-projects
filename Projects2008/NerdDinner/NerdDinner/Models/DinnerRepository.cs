using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NerdDinner.Helper;

namespace NerdDinner.Models
{
    public class DinnerRepository
    {
        private NerdDinnerDataContext db = new NerdDinnerDataContext();

        readonly int PageSize = 10;

        // 查询方法
        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinner;
        }
        public IQueryable<Dinner> FindUpcomingDinners()
        {
            return from dinner in db.Dinner
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner;
        }
        public PaginatedList<Dinner> FindUpcomingDinners(int? Page)
        {
            var dinners = FindUpcomingDinners();

            return new PaginatedList<Dinner>(dinners, Page ?? 0, PageSize);
        }
        public Dinner GetDinner(int id)
        {
            return db.Dinner.SingleOrDefault(d => d.DinnerID == id);
        }

        // 插入/删除
        public void Add(Dinner dinner)
        {
            db.Dinner.InsertOnSubmit(dinner);
        }
        public void Delete(Dinner dinner)
        {
            db.RSVP.DeleteAllOnSubmit(dinner.RSVPs);
            db.Dinner.DeleteOnSubmit(dinner);
        }

        // 持久化
        public void Save()
        {
            db.SubmitChanges();
        }

        public IQueryable<Dinner> FindByLocation(float latitude, float longitude)
        {
            var dinners = from dinner in FindUpcomingDinners()
                          join i in db.NearestDinners(latitude, longitude)
                          on dinner.DinnerID equals i.DinnerID
                          select dinner;
            return dinners;
        }
    }
}
