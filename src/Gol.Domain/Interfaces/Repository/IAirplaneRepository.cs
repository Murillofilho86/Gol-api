using Gol.Domain.Entities;
using Gol.Domain.Shared.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Gol.Domain.Interfaces.Repository
{
    public interface IAirplaneRepository
    {
        void Add(Airplane airplane);
        void Update(AirplaneDto airplaneDto);
        AirplaneDto GetById(Guid id);
        IEnumerable<AirplaneDto> GetAll();
        void Delete(Airplane airplane);
    }
}
