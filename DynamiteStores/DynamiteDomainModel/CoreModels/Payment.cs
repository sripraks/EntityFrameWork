using System;
using System.ComponentModel.DataAnnotations.Schema;
using DynamiteStore.DBObjectState;

namespace DynamiteStore.DomainModel
{
  public class Payment:  IObjectWithState
   
  {
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime  Date { get; set; }
    public Order Order { get; set; } 
    [NotMapped]
    public State State { get; set; }
  }
}