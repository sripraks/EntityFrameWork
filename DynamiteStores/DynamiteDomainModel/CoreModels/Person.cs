using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DynamiteStore.DBObjectState;

namespace DynamiteStore.DomainModel
{
  public abstract class Person: IObjectWithState
  {
    public int Id { get; set; }

    [StringLength(10)]
    public string Title { get; set; }

    [StringLength(40)]
    public string FirstName { get; set; }

    [StringLength(40)]
    public string LastName { get; set; }

    [StringLength(100)]
    public string CompanyName { get; set; }

    [StringLength(50)]
    public string EmailAddress { get; set; }

    [StringLength(25)]
    public string Phone { get; set; }

    [NotMapped]
    public State State { get; set; }
  }
}