using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregslistSQL.Models;
using gregslistSQL.Controllers;
using gregslistSQL.Services;
using Dapper;

namespace gregslistSQL.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;
        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Car> Get()
        {
            string sql = @"
            SELECT * FROM cars";
            return _db.Query<Car>(sql).ToList();

        }
        internal Car Get(int id)
        {
            string sql = @"
            SELECT
            c.*,
            acct.*
            FROM cars c
            JOIN accounts acct 
            WHERE c.id = @id";
            return _db.Query<Car, Account, Car>(sql, (car, account) =>
            {
                // car.Creator = account;
                return car;
            }, new { id }).FirstOrDefault();
        }
        internal Car Create(Car carData)
        {
            string sql = @"
            INSERT INTO cars
            (color, make, model, year, price, creatorId)
            VALUES
            (@Color, @Make, @Model, @Year, @Price, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            carData.Id = _db.ExecuteScalar<int>(sql, carData);
            return carData;
        }
        internal void Edit(Car original)
        {
            string sql = @"
            UPDATE cars
            SET
            color = @Color,
            make = @Make,
            model = @Model,
            year = @Year,
            price = @Price
            
            ";
            _db.Execute(sql, original);
        }
        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}