using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStock.API.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PhotosController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPhotos(int authorId, [FromQuery] PhotoParameters photoParameters)
        {
            var author = _repository.Author.GetAuthorById(authorId,false);
            if (author == null)
            {
                _logger.LogInfo($"Author with Id: {authorId} doesn't exist in the database");
                return NotFound();
            }
            var photos = _repository.Photo.GetAllPhotos(authorId,photoParameters, false);
            var photosDto = _mapper.Map<IEnumerable<PhotoDto>>(photos);
            foreach (var item in photosDto)
            {
                item.AuthorName = author.FirstName;
                item.AuthorNickName = author.NickName;
            }
            return Ok(photosDto);
        }
        [HttpGet("{id}", Name = "getphotoforauthor")]
        public IActionResult GetPhoto(int authorId, int id)
        {
            var author = _repository.Author.GetAuthorById(authorId, false);
            if (author == null)
            {
                _logger.LogInfo($"Author with Id: {authorId} doesn't exist in the database");
                return NotFound();
            }
            var photo = _repository.Photo.GetPhotoById(authorId, id, false);
            if (photo == null)
            {
                _logger.LogInfo($"Photo with id: { id} doesn't exist in the database.");
                return NotFound();
            }
            var photoDto = _mapper.Map<PhotoDto>(photo);
            photoDto.AuthorName = author.FirstName;
            photoDto.AuthorNickName = author.NickName;
            return Ok(photoDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePhoto(int authorId, int id, [FromBody] PhotoForUpdateDto photo)
        {
            if (photo == null)
            {
                _logger.LogError("PhotoForUpdateDto object sent from client is null.");
                return BadRequest("PhotoForUpdateDto object is null");
            }
            var author = _repository.Author.GetAuthorById(authorId, false);
            if (author == null)
            {
                _logger.LogInfo($"Author with Id: {authorId} doesn't exist in the database");
                return NotFound();
            }
            var photoEntity = _repository.Photo.GetPhotoById(authorId, id, true);
            if (photoEntity == null)
            {
                _logger.LogInfo($"Photo with id: { id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(photo, photoEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
