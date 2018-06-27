﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using Microsoft.EntityFrameworkCore;
using BoxProblem.Repositories;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private Data.ApplicationDbContext dbContext;

        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public BoxRepository()
        {
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
        public void AddBox(BoxInventory toAdd)
        {
            dbContext.Boxes.Add(toAdd);
            dbContext.SaveChanges();
        }
        public BoxInventory GetBoxById(int id)
        {
            return dbContext.Boxes.Find(id);
        }
        public void Delete(BoxInventory toDelete)
        {
            dbContext.Boxes.Remove(toDelete);
            dbContext.SaveChanges();
        }
    }
}
