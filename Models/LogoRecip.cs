using System.ComponentModel.DataAnnotations;

namespace SearchProductCode.Models
{
    public class LogoRecip
    {
        [Key]
        public int Id { get; set; }
        public string? Receipt { get; set; }
        public string? MainProduct { get; set; }
        public string? LineProduct { get; set; }
        public string? LINETYPE { get; set; }
        public string? LineProductDef { get; set; }
        public string? AMOUNT { get; set; }
    }
}
