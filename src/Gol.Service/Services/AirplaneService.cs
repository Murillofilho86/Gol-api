using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repository;
using Gol.Domain.Interfaces.Service;
using Gol.Domain.Shared.DataTransferObject;
using Gol.Infra.Crosscutting.Constants;
using System;
using System.Collections.Generic;


namespace Gol.Service.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _repository;

        public AirplaneService(IAirplaneRepository repository)
        {
            _repository = repository;
        }

        public void Add(Airplane airplane)
        {
            _repository.Add(airplane);
        }

        public void Delete(Guid id)
        {
            var airplane = _repository.GetById(id);
            if (airplane == null) throw new Exception(ExceptionConstants.AIRPLANE_NOT_FOUND);

            _repository.Delete(HydrateAirplaneDto(airplane));
        }

        public IEnumerable<AirplaneDto> GetAll()
        {
            return _repository.GetAll();
        }

        public AirplaneDto GetById(Guid id)
        {

            var airplane = _repository.GetById(id);
            if (airplane == null) throw new Exception(ExceptionConstants.AIRPLANE_NOT_FOUND);

            return airplane;
        }

        public void Update(AirplaneDto airplane)
        {
            var ap = _repository.GetById(airplane.Id);
            if (ap == null) throw new Exception(ExceptionConstants.AIRPLANE_NOT_FOUND);

            _repository.Update(ap);
        }

        private Airplane HydrateAirplaneDto(AirplaneDto airplaneDto)
        {
            var airplane = new Airplane
            {
                Id = airplaneDto.Id,
                Code = airplaneDto.Code,
                CreateDate = airplaneDto.CreateDate,
                Model = airplaneDto.Model,
                PassengersQuantity = airplaneDto.PassengersQuantity
            };

            return airplane;

        }
     
    }
}
