using System;
using DynamiteStore.DBObjectState;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DynamiteStore.DomainModel
{
  public class LineItem:IObjectWithState
  {
    public int LineItemId { get; set; }

    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public int OrderQty { get; set; }
    public Nullable<decimal> UnitPrice { get; set; }
    public Nullable<decimal> UnitPriceDiscount { get; set; }

    [NotMapped]
    public decimal LineTotal { get; set; }

    public  Product Product { get; set; }
    [IgnoreDataMember]
    public  Order Order { get; set; }

    public Nullable<int> ShipmentId { get; set; }
    
    [NotMapped]
    public State State { get; set; }
  }
}