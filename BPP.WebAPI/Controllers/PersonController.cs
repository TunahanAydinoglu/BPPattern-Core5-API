using AutoMapper;
using BPP.Core.Models;
using BPP.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonController(IService<Person> service, IMapper mapper)
        {
            _personService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return Created("", newPerson);
        }

    }
}
