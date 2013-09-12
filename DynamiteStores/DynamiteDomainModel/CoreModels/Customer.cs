using System.Collections.Generic;

namespace DynamiteStore.DomainModel
{
  public class Customer : Person
  {
    public Customer()
    {
      Orders = new List<Order>();
      Addresses = new List<Address>();
    }

    public ICollection<Order> Orders { get; set; }

    public string SalesPersonId { get; set; }

    public ICollection<Address> Addresses { get; set; }
  }
}