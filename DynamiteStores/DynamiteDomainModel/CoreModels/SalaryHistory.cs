using System;
using System.ComponentModel.DataAnnotations.Schema;
using DynamiteStore.DBObjectState;

namespace DynamiteStore.DomainModel
{
  public class SalaryHistory:  IObjectWithState
  
  {
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Salary { get; set; }
    
    [NotMapped]
    public State State { get; set; }
  }
}