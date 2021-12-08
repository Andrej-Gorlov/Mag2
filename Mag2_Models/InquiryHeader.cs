using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_Models
{
    public class InquiryHeader
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }//реквизиты клиента
        [ForeignKey("ApplicationUserId")]//привязка к таблице ApplicationUser
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime InquiryDate { get; set; }//дата регистрации Inquiry(запроса)
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
