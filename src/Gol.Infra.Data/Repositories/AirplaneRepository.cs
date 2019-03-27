using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repository;
using Gol.Domain.Shared.DataTransferObject;
using Gol.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gol.Infra.Data.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {

        private readonly GolAirlinesContext _context;

        public AirplaneRepository(GolAirlinesContext context)
        {
            _context = context;
        }

        public void Add(Airplane airplane)
        {
            _context.Entry<Airplane>(airplane)
              .State = EntityState.Added;
            _context.SaveChanges();
        }


        public void Delete(Airplane airplane)
        {
            _context.Remove(airplane);
            _context.SaveChanges();
        }

        public IEnumerable<AirplaneDto> GetAll()
        {
            return _context
                .Airplanes
                .Select(x => new AirplaneDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Model = x.Model,
                    CreateDate = x.CreateDate,
                    PassengersQuantity = x.PassengersQuantity
                })
                .AsNoTracking()
                .ToList();
        }

        public AirplaneDto GetById(Guid id)
        {
            return _context
              .Airplanes
              .Select(x => new AirplaneDto
              {
                  Id = x.Id,
                  Code = x.Code,
                  Model = x.Model,
                  CreateDate = x.CreateDate,
                  PassengersQuantity = x.PassengersQuantity
              })
              .AsNoTracking()
              .Where(x => x.Id == id)
              .FirstOrDefault();

        }


        public void Update(AirplaneDto airplanedto)
        {
            var airplane = new Airplane
            {
                Id = airplanedto.Id,
                Code = airplanedto.Code,
                PassengersQuantity = airplanedto.PassengersQuantity
            };
            _context.Entry<Airplane>(airplane)
                .State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
