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

        public List<BoxInventory> GetAllBoxes()
        {
            return repository.GetAllBoxes();
        }

        public void DeleteBox(Box toDelete)
        {
            repository.DeleteBox(toDelete);
        }
    }
}
