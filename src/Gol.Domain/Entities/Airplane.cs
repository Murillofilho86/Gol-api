using Gol.Domain.Shared.EntityBase;
using System;

namespace Gol.Domain.Entities
{
    public class Airplane : EntityBase
    {
        public Airplane()
        {
            CreateDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy "));
        }
        public string Code { get; set; }
        public string Model { get; set; }
        public DateTime CreateDate { get; set; }
        public int PassengersQuantity { get; set; }
    }
}
