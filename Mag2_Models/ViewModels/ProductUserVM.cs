using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2_Models.ViewModels
{
    public class ProductUserVM //модель для стр покупок
    {
        public ProductUserVM()
        {
            ProductsList = new List<Product>();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public IList<Product> ProductsList { get; set; }

    }
}
