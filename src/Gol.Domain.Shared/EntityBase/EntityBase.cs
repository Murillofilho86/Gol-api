using System;

namespace Gol.Domain.Shared.EntityBase
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
