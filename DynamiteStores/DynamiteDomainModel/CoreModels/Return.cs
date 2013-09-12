
using System;
using DynamiteStore.DBObjectState;
using System.ComponentModel.DataAnnotations.Schema;


namespace DynamiteStore.DomainModel
{
  public class Return:  IObjectWithState
    
  {
    public int ReturnId { get; set; }
    public DateTime DateTime { get; set; }
    public string Reason { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    [NotMapped]
    public State State { get; set; }
  }
}