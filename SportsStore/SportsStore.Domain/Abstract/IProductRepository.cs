using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {

        /*A class that depends on the IProductRepository interface 
         * can obtain Product objects without needing to know anything 
         * about where they are coming from or how the implementation class will deliver them. 
         * This is the essence of the repository pattern.*/
        IEnumerable<Product> Products { get; }
    }
}
