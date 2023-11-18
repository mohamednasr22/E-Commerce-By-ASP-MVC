using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Size
    {
        //static Size()
        //{
                // that is call one time
                // can not use static class as argument  or return type
        //}
        [Key]
        public  int SizeId { get; set; }
        public  string SizeName { get; set; }
        public  ICollection<ProductSize> ProductSizes { get; set; }

    }
}
