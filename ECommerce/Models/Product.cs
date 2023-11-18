using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public  Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }

        // test on const and read only
        const string ProdType = "www";
        readonly string _ProdType ;
        public Product()
        {
            _ProdType = ProdType;

        }
        protected void setProduct (Product product)
        {
            //can't pass value to const and read only
             //_ProdType= product.Name;
            // ProdType= product.Name;



            //can pass const and read only to
             product.Name =ProdType;
             product.Description=_ProdType;


            // >>>  hint 
            //const is complir type
            //read only is run time type

        }

    }
}
