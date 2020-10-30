using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class ShoppingCartItemInputModel
    {
        [Required]
        public string ProductIdentifier { get; set; }
        [Required]
        public float Quantity { get; set; }  // (nullable float) ATH HÉR!!!!!!!!
    }
}

/*
ShoppingCartItemInputModel
• ProductIdentifier* (string)
• Quantity* (nullable float) => The range for this number is an include 0.01 to the float type maximum value
*/