using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses
{
 
  [Table("Products")]
  public class ProductReference
  
  {

    [Key]public int ProductId { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    [Required, StringLength(10)]
    public string ProductNumber { get; set; }
    public int CategoryId { get; set; }
    public decimal ListPrice { get; set; }
    public byte[] Photo { get; set; }
  }
}