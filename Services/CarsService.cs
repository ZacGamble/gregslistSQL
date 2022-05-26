using gregslistSQL.Models;
using gregslistSQL.Repositories;
using System.Collections.Generic;

namespace gregslistSQL.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;
        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }


        internal List<Car> Get()
        {
            return _repo.Get();
        }

        internal Car Get(int id)
        {
            Car car = _repo.Get(id);
            if (car == null)
            {
                throw new System.Exception("Invalid Car ID");
            }
            return car;
        }
        internal Car Create(Car carData)
        {
            return _repo.Create(carData);
        }

        internal Car Edit(Car carData)
        {
            Car original = Get(carData.Id);
            original.Color = carData.Color ?? original.Color;
            original.Make = carData.Make ?? original.Make;
            original.Model = carData.Model ?? original.Model;
            original.Year = carData.Year;
            original.Price = carData.Price;
            _repo.Edit(original);
            return Get(original.Id);
        }

        internal void Delete(int id)
        {
            Car car = Get(id);

            _repo.Delete(id);
        }
    }
}