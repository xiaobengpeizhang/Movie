using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Models;

namespace Movie.DAL
{
    public class testDBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<testDBContext>
    {
        protected override void Seed(testDBContext context)
        {
            var films = new List<Film>
            {
                new Film{title="霸王别姬",director="陈凯歌",description="张国荣主演",show_at=DateTime.Parse("1994-09-04")},
                new Film{title="甲方乙方",director="冯小刚",description="葛优主演",show_at=DateTime.Parse("1995-09-04")},
                new Film{title="英雄",director="张艺谋",description="一堆大牌主演",show_at=DateTime.Parse("1996-09-04")},
            };
            films.ForEach(a => context.film.Add(a));
            context.SaveChanges();
        }
    }
}