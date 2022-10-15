using Domain.Interfaces;

namespace Domain.Entities;

public class User : IEntity
{
    string Id { get; set; }
}