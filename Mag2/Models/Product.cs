using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]// также в EntityFrameworkCore преднозначен для передачи данных в бд  
        public string Name { get; set; }
        public string Description { get; set; }//описание
        [Range(1, int.MaxValue)]
        public string Price { get; set; }


        public string Image { get; set; }// ссылка на image


        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }// связь сущности между Categery и Product
        [ForeignKey("CategoryId")]//автоматическая связь между текущим объектом и Categery(создаётся столбец id Categery (т.е. внешний ключ))
        public virtual Category Category { get; set; }
    }
}
