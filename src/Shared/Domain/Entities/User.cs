using Domain.Interfaces;

namespace Domain.Entities;

public class User : IEntity
{
    string IBaseEntity<string>.Id { get; set; }
}
