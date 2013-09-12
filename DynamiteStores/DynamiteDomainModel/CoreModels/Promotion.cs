using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DynamiteStore.DBObjectState;

namespace DynamiteStore.DomainModel
{
  public class Promotion: IObjectWithState
  {
    public Promotion()
    {
      Products = new List<Product>();
      Categories = new List<Category>();
    }
    public int PromotionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [StringLength(150)]
    public String Name { get; set; }
    public String Description { get; set; }
    public bool AllProducts { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Category> Categories { get; set; }

    [NotMapped]
    public State State { get; set; }

  }
}