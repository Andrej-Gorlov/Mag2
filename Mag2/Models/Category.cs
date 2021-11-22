using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Models
{
    public class Category
    {
        [Key]//Первичный ключ и индификатор (значение не передаём в БД)(явное указания)
        public int Id { get; set; }//(CategeryId)

        [Required]//валидация(обизательное заполнение поля) 
        public string Name { get; set; }

        [DisplayName("Display Order")]// будет отображаться на странице вместо (DisplyOrder)
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Category display order must not be less than 1!")]
        public int DisplayOrder { get; set; }//Отобразить заказ//
    }
}
