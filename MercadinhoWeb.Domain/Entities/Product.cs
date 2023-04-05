using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Domain.Entities;

public class Product
{
    public Product()
    {
        this.Id = Guid.NewGuid();
        this.CreatedDate = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public bool Status { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
}
