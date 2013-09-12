using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DynamiteStore.DBObjectState;

namespace DynamiteStore.DomainModel
{
  public class Category:IObjectWithState
  {
    public Category()
    {
      Products = new List<Product>();
    }

    public int CategoryId { get; set; }
    [StringLength(25)] public string Name { get; set; }

    public ICollection<Product> Products { get; set; }

    public State State { get; set; }
  }
}