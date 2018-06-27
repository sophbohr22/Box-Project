using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        public BoxRepository()
        {
        }

        private Data.ApplicationDbContext dbContext;

        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }
        public void AddBox(BoxInventory toAdd)
        {
            dbContext.Boxes.Add(toAdd);
            dbContext.SaveChanges();
        }
    }
}
