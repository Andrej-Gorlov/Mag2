using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Models.ViewModels
{
    public class ProductUserVM //модель для стр покупок
    {
        public ProductUserVM()
        {
            ProductsList = new List<Product>();//
        }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Product> ProductsList { get; set; }

    }
}
