using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities; 

namespace SportsStore.Domain.Concrete
{
    /*This is the repository class. 
     *It implements the IProductRepository interface and uses an instance of EFDbContext
     to retrieve data from the db using EF.*/
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
