using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Models.ViewModels
{
    public class DetailsVM
    {
        public Product Product { get; set; }
        public bool ExistsInCart { get; set; }
        public DetailsVM()
        {
            Product = new Product();
        }
    }
}
