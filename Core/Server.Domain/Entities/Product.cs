using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; set; } = string.Empty;
}
