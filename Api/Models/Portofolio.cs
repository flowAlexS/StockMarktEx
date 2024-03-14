using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("Portofolios")]
    public class Portofolio
    {
        public string AppUserId { get; set; }

        public int StockId { get; set; }

        public AppUser AppUser { get; set; }

        public Stock Stock { get; set; }
    }
}
