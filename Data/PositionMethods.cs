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
   public class PositionMethods
    {
        public static void InsertPosition(Position newPosition)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message);

                // stop the child collection from being added twice
                foreach (Position p in newPosition.Period.Positions.ToList())
                {
                    context.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                }


                context.Positions.Add(newPosition);
                // make sure parent isnt marked for adding
                context.Entry(newPosition.Period).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        private static void AttachPosition(DataModel.Model1 context, Position position)
        {
            /*
             * https://stackoverflow.com/questions/26879968/attaching-an-entity-of-type-failed-because-another-entity-of-the-same-type-alrea
             */
            var activityInDb = context.Positions.Find(position.Id);

            // Activity does not exist in database and it's new one
            if (activityInDb == null)
            {
                context.Positions.Add(position);
                return;
            }

            // Activity already exist in database and modify it
            context.Entry(activityInDb).CurrentValues.SetValues(position);
            context.Entry(activityInDb).State = System.Data.Entity.EntityState.Modified;
        }

        public static void UpdatePosition(Position position)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;
                AttachPosition(context, position);
                context.SaveChanges();
            }
        }

        public static void DeletePosition(Position position)
        {
            using (var context = new Model1())
            {
                context.Database.Log = message => Debug.Write(message); //Console.WriteLine;
                context.Entry(position).State = System.Data.Entity.EntityState.Deleted;
                context.Positions.Remove(position);
                context.SaveChanges();
            }
        }
    }
}
