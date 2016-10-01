using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    /*this interface uses IEnumerable<T> to allow a caller 
     * to obtain a sequesnce of Product objects,
     without saying how or where the data is stored or retrieved.*/
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
