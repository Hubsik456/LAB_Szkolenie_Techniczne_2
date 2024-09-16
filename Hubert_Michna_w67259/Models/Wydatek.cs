using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubert_Michna_w67259.Models
{
    public class Wydatek
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa_Wydatku { get; set; } = null!;
        public int Typ_Wydatku_ID { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0.01, 999999.99)]
        public decimal Cena { get; set; }
        public DateTime Data_Wydatku { get; set; }
        public string Waluta { get; set; } = null!;
    }
}
