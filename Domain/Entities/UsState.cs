using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class UsState : Entity<Guid>
{
    public string? StateName { get; set; }

    public string? StateAbbr { get; set; }

    public string? StateRegion { get; set; }
}
