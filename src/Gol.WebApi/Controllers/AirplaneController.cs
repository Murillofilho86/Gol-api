using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Service;
using Gol.Domain.Shared.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Gol.WebApi.Controllers
{
    public class AirplaneController : Controller
    {

        private readonly IAirplaneService _service;

        public AirplaneController(IAirplaneService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/airplanes")]
        public void Insert([FromBody] Airplane airplane)
        {
            _service.Add(airplane);
        }

        [HttpDelete]
        [Route("v1/airplanes/{id}")]
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }

        [HttpGet]
        [Route("v1/airplanes")]
        public IEnumerable<AirplaneDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("v1/airplanes/{id}")]
        public AirplaneDto GetById(Guid id)
        {
            return _service.GetById(id);
        }

        [HttpPut]
        [Route("v1/airplanes")]
        public void Update([FromBody]AirplaneDto airplane)
        {
            _service.Update(airplane);
        }

    }
}