using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DebtNote.Models
{
    public class Payment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Money { get; set; }
    }
}
