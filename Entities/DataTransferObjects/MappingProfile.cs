using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Photo, PhotoDto>();
            CreateMap<Author, AuthorDto>()
                        .ForMember(d => d.FullName,
                                opt => opt.MapFrom(a => string.Join(' ', a.FirstName, a.LastName)));
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<TextForCreationDto, Text>();
            CreateMap<Text, TextDto>();
            CreateMap<PhotoForUpdateDto, Photo>();
        }
    }
}
