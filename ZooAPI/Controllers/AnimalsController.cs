using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Repositories;
using ZooCore;

namespace ZooAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IRepository<Animal> _repository;

        public AnimalsController(IRepository<Animal> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Animal> animals = await _repository.GetAllAsync();

            return Ok(animals);
        }        
        
        
        // TODO ajouter une route pour trouver un animal en fonction de sa famille
        //[HttpGet]
        //public async Task<IActionResult> GetAllByFamily([FromQuery] int family)
        //{
        //    IEnumerable<Animal> animals = await _repository.GetAllAsync();

        //    return Ok(animals);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entity = await _repository.GetAsync(e => e.Id == id);

            if (entity == null)
                return BadRequest("Oops something went wrong");

            return Ok(new
            {
                Message = "An animal was found",
                Animal = entity

            });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Animal animal)
        {

            var entityAdded = await _repository.AddAsync(animal);

            if (entityAdded == null)
                return BadRequest("Oops something went wrong");

            return CreatedAtAction(nameof(GetById),
                                            new
                                            {
                                                id = animal.Id,
                                            },
                                            new
                                            {
                                                Message = "The animal was added !",
                                                Animal = animal
                                            });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Animal animal)
        {
            var entity = await _repository.GetAsync(e => e.Id == id);
            if (entity == null)
                return BadRequest("The animal was not found");

            animal.Id = id;

            if (await _repository.UpdateAsync(animal))
                return Ok("The animal was updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entity = await _repository.GetAsync(e => e.Id == id);

            if (entity != null)
            {
               await _repository.DeleteAsync(entity.Id);
                return Ok("The animal was deleted");
            }
            return BadRequest("Oops something went wrong");
        }
    }
}
