using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class ItemViewModel
    {
        [Display(Name = "Upload image of item")]
        public IFormFile? ItemImage { get; set; }
    }
}
