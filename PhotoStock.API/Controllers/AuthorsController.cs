using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStock.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthorsController(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _repository.Author.GetAllAuthors(false);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(authors);
        }
        [HttpGet("{id}",Name = "AuthorById")]
        public IActionResult GetAuthor(int id)
        {
            var author = _repository.Author.GetAuthorById(id,false);
            if (author == null)
            {
                _logger.LogInfo($"Author with id: { id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var authorDto = _mapper.Map<AuthorDto>(author);
                return Ok(author);
            }
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody]AuthorForCreationDto author)
        {
            if (author == null)
            {
                _logger.LogError($"AuthorForCreationDto object sent from client is null");
                return BadRequest("AuthorForCreationDto object is null");
            }
            var authorEntity = _mapper.Map<Author>(author);
            _repository.Author.CreateAuthor(authorEntity);
            _repository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("authorById", new { id = authorToReturn.Id }, authorToReturn);
        }
    }
}
