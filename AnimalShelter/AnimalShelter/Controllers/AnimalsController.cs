﻿using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [ApiController]
    [Route("animals")]
    public class AnimalsController : ControllerBase
    {
        private IMockDb _mockDb;

        public AnimalsController(IMockDb mockDb)
        {
            _mockDb = mockDb;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mockDb.GetAllAnimals());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            var animal = _mockDb.GetAnimal(id);
            if (animal is null)
            {
                return NotFound();
            }
            return Ok(animal);
        }
        
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            _mockDb.AddAnimal(animal);
            return Created($"animals/{animal.Id}",animal);
        }
        
        [HttpPut("{id}")]
        public IActionResult Replace(int id, Animal animal)
        {
            _mockDb.RemoveAnimal(id);
            _mockDb.AddAnimal(animal);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            if (_mockDb.RemoveAnimal(id) is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}