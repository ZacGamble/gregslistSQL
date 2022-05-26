using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gregslistSQL.Models;
using gregslistSQL.Services;

namespace gregslistSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;

        public CarsController(CarsService cs)
        {
            _cs = cs;
        }
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            try
            {
                List<Car> cars = _cs.Get();
                return Ok(cars);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // [HttpGet("{id}")]
        // public ActionResult<Car> Get(int id)
        // {
        //     try
        //     {
        //         Car car = _cs.Get(id);
        //         return Ok(car);
        //     }
        //     catch (System.Exception)
        //     {
        //         return BadRequest("Couldn't get that car");
        //     }
        // }
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car carData)
        {
            try
            {
                Car newCar = _cs.Create(carData);
                return Ok(newCar);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _cs.Delete(id);
                return Ok("Disposed of...");
            }
            catch (System.Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> Edit(int id, [FromBody] Car carData)
        {
            try
            {
                carData.Id = id;
                Car updated = _cs.Edit(carData);
                return Ok(updated);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}