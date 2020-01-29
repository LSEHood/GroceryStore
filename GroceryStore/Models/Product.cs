using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//using data annotations allows us to update the DISPLAY name in a SINGLE place - therefore code is easier to maintian. 
//Can also be done using MetaDataType class, splitting the class across multiple files (these are partial classes) but i dont like this style personally.

namespace GroceryStore.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; } //primary key for products in DB

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "The product name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a product name between 3 and 50 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a product name made up of letters and numbers only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The product description cannot be blank")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Please enter a product description between 5 and 200 characters in length")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a product description made up of letters and numbers only")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price cannot be blank")]
        [Range(0.10, 10000, ErrorMessage = "Please enter a price between 0.10 and 10000.00")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [RegularExpression("[0-9]+(\\.[0-9][0-9]?)?", ErrorMessage = "The price must be a number up to two decimal places")]
        public decimal Price { get; set; }
        public int? CategoryID { get; set; } //foreign key to link to category table in DB. 
        //Int? means product may not belong to a category. Important to avoid deletion of all products when a category is deleted
        public virtual Category Category { get; set; } //Navigation property.Type is usually ICollection
        public virtual ICollection<ProductImageMapping> ProductImageMappings { get; set; }
    }
}