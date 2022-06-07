using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Zad2.Model;
using Zad2.Services;

namespace Zad2.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {

        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult getAnimals(string orderBy)
        {
            try
            {
                List<Animal> animals = null;
                if (orderBy != null)
                {
                    if (!orderBy.Equals("IdAnimal") && !orderBy.Equals("Name")&& !orderBy.Equals("Description") && !orderBy.Equals("Category") && !orderBy.Equals("Area"))
                    {
                        return BadRequest("Provided invalid parameter");
                    }
                    animals = _animalService.getAnimals(orderBy);
                }
                else
                {
                    animals = _animalService.getAnimals("Name");
                }
                if (animals.Count != 0)
                {
                    return Ok(animals);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult addAnimal(Animal animal)
        {
            try
            {
                _animalService.addAnimal(animal);
                return Ok(animal);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{idAnimal}")]
        public IActionResult updateAnimal(int idAnimal,Animal animal)
        {
            try
            {
                Animal result=_animalService.getAnimal(idAnimal);
                if (result != null)
                {
                    _animalService.updateAnimal(idAnimal, animal);
                    animal.IdAnimal = idAnimal;
                    return Ok(animal);
                }
                {
                    return NotFound("Animal not found");
                }
                
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult deleteAnimal(int idAnimal)
        {
            try
            {
                Animal result = _animalService.getAnimal(idAnimal);
                if (result != null)
                {
                    _animalService.deleteAnimal(idAnimal);
                    return Ok();
                }
                {
                    return NotFound("Animal not found");
                }
                
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
