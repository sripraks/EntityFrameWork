using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DynamiteStore.DBObjectState;

namespace DynamiteStore.DomainModel
{
  public class Shipper :IObjectWithState
 
  {
    public int ShipperId { get; set; }
    [StringLength(100)] public string Name { get; set; }
    
    [NotMapped]
    public State State { get; set; }
  }
}