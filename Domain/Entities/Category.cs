using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class Category : Entity<Guid>
{

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
