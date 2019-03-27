using System;

namespace Gol.Domain.Shared.DataTransferObject
{
    public class AirplaneDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Model { get; set; }
        public DateTime CreateDate { get; set; }
        public int PassengersQuantity { get; set; }
    }
}
