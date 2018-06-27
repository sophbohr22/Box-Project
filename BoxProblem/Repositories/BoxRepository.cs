using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using Microsoft.EntityFrameworkCore;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private Data.ApplicationDbContext dbContext;

        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }
        public void SaveEdits(BoxInventory toSave)
        {
            dbContext.Entry(toSave).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public BoxInventory GetBoxById(int id)
        {
            return dbContext.Boxes.Find(id);
        }

    }
}
