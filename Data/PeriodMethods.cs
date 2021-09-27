using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Data
{
    public class PeriodMethods
    {
        public static void InsertPeriod(Period newPeriod)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;
                context.Periods.Add(newPeriod);
                context.SaveChanges();
            }
        }

        public static void InsertPeriods(List<Period> periods)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;
                context.Periods.AddRange(periods);
                context.SaveChanges();
            }
        }

        public static List<Period> SelectPeriods()
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;
                var periods = context.Periods
                    .Include(n=>n.Positions)
                    .OrderBy(n=>n.DateFrom)
                    .AsNoTracking()
                    .ToList();
                
                return periods;

                /*
                 * Find by key
                 * id = 4
                 * var period = context.Periods.Find(id);
                 * Only returns 1 record or error
                 * 
                 * var periods = context.Periods.SqlQuery("exec storedProc").ToList()
                 * 
                 */
            }
        }

        public static void UpdatePeriod(Period period)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;
                context.Periods.Attach(period);
                context.Entry(period).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void DeletePeriod(Period period)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;

                // delete the children positions
                foreach (Position p in period.Positions.ToList())
                {
                    context.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                }

                context.Entry(period).State = System.Data.Entity.EntityState.Deleted;
                context.Periods.Remove(period);


                context.SaveChanges();
            }
        }
    }
}
