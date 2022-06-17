using System.ComponentModel.DataAnnotations;

namespace DebtNote.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Money { get; set; }
    }
}
