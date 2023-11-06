using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Region : Entity<Guid>
{
    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
