using System.ComponentModel.DataAnnotations;

namespace gregslistSQL.Models
{
    public class Car
    {

        public int Id { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }
        public string CreatorId { get; set; }
    }
}