using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using BoxProblem.Repositories;

namespace BoxProblem.Services
{
    public class BoxService
    {
        private BoxRepository repository;

        public BoxService(ApplicationDbContext context)
        {
            repository = new BoxRepository(context);
        }
        public void SaveEdits(BoxInventory toSave)
        {
            repository.SaveEdits(toSave);
        }
        public BoxInventory GetBoxById(int id)
        {
            return repository.GetBoxById(id);
        }

    }
}
