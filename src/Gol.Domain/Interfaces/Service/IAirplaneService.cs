using Gol.Domain.Entities;
using Gol.Domain.Shared.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Gol.Domain.Interfaces.Service
{
    public interface IAirplaneService
    {
        void Add(Airplane airplane);
        void Update(AirplaneDto airplane);
        AirplaneDto GetById(Guid id);
        IEnumerable<AirplaneDto> GetAll();
        void Delete(Guid id);

    }
}
