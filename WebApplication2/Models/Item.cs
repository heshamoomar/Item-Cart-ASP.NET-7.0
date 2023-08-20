using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Item
    {
        [Key]
        public int Code { get; set; }

        [StringLength(50)]
        [Display(Name = "Name in Arabic")]
        [Required(ErrorMessage = "Please enter item name in Arabic.")]
        public string NameInArabic { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Name in English")]
        [Required(ErrorMessage = "Please enter item name in English.")]
        public string NameInEnglish { get; set; } = string.Empty;

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; } = string.Empty;

        [Display(Name = "Item Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemPrice { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please choose a warehouse.")]
        public int Warehouse { get; set; }

        public string? ItemImageFileName { get; set; }

        [NotMapped]
        [Display(Name = "Item Image")]
        public IFormFile? ItemImage { get; set; }

    }
}
