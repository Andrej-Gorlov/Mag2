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
        [Key]
        public int Id { get; set; }
        [Required]// также в EntityFrameworkCore преднозначен для передачи данных в бд  
        public string Name { get; set; }

        public string ShortDesc { get; set; }// краткое описание
        public string Description { get; set; }//описание
        [Range(1, int.MaxValue)]
        public string Price { get; set; }


        public string Image { get; set; }// ссылка на image


        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }// связь сущности между Categery и Product
        [ForeignKey("CategoryId")]//автоматическая связь между текущим объектом и Categery(создаётся столбец id Categery (т.е. внешний ключ))
        public virtual Category Category { get; set; }



        [Display(Name = "Application Type")]
        public int ApplicationTypeId { get; set; }// связь сущности между Categery и Product
        [ForeignKey("ApplicationTypeId")]//автоматическая связь между текущим объектом и Categery(создаётся столбец id Categery (т.е. внешний ключ))
        public virtual ApplicationType ApplicationType { get; set; }
    }
}
