using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStock.API.Controllers
{
    [Route("api/text")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TextController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTexts(int authorId, [FromQuery] TextParameters textParameters)
        {
            var author = _repository.Author.GetAuthorById(authorId, false);
            if (author == null)
            {
                _logger.LogInfo($"Author with Id : {authorId} doesn't exist in the database");
                return NotFound();
            }
            var texts = _repository.Text.GetAllTexts(authorId, textParameters, false);

            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(texts.MetaData));

            var textToReturn = _mapper.Map<IEnumerable<TextDto>>(texts);
            foreach (var item in textToReturn)
            {
                item.AuthorName = author.FirstName;
                item.AuthorNickName = author.NickName;
            }
            return Ok(textToReturn);
        }

        [HttpGet("{id}", Name = "gettextforauthor")]
        public IActionResult GetText(int authorId, int id)
        {
            var author = _repository.Author.GetAuthorById(authorId, false);
            if (author == null)
            {
                _logger.LogInfo($"Author with Id: {authorId} doesn't exist in the database");
                return NotFound();
            }
            var text = _repository.Text.GetTextById(authorId, id, false);
            if (text == null)
            {
                _logger.LogInfo($"Text with id: { id} doesn't exist in the database.");
                return NotFound();
            }
            var textToReturn = _mapper.Map<TextDto>(text);
            textToReturn.AuthorName = author.FirstName;
            textToReturn.AuthorNickName = author.NickName;

            return Ok(textToReturn);
        }
        [HttpPost]
        public IActionResult CreateTextForAuthor(int authorId, [FromBody] TextForCreationDto text)
        {
            if (text == null)
            {
                _logger.LogError("text object sent from client is null");
                return BadRequest("text object is null");
            }
            var author = _repository.Author.GetAuthorById(authorId, false);
            if (author == null)
            {
                _logger.LogInfo($"Author with Id: {authorId} doesn't exist in the database");
                return NotFound();
            }
            var textEntity = _mapper.Map<Text>(text);
            _repository.Text.CreateTextForAuthor(authorId, textEntity);
            _repository.Save();
            var textToReturn = _mapper.Map<TextDto>(textEntity);
            return CreatedAtRoute("gettextforauthor", new { authorId, id = textToReturn.Id }, textToReturn);
        }

    }
}
