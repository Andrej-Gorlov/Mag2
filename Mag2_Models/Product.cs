using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2_Models
{
    public class Product
    {
        public Product()
        {
            QuantityOfGoods = 1;
        }
        [Key]
        public int Id { get; set; }
        [Required]// также в EntityFrameworkCore преднозначен для передачи данных в бд  
        public string Name { get; set; }

        public string ShortDesc { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }


        public string Image { get; set; }// ссылка на image


        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }



        [Display(Name = "Application Type")]
        public int ApplicationTypeId { get; set; }
        [ForeignKey("ApplicationTypeId")]
        public virtual ApplicationType ApplicationType { get; set; }

        [NotMapped]
        [Range(1, 100000,ErrorMessage = "Quantity Of Goods must be greater than 0.")]
        public int QuantityOfGoods { get; set; }
    }
}
