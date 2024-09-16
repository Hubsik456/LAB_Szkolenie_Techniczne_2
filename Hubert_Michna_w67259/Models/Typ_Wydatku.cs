using System.ComponentModel.DataAnnotations;

namespace Hubert_Michna_w67259.Models
{
    public class Typ_Wydatku
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; } = null!;
    }
}
