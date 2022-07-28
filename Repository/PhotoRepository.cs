using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) {}

        public PagedList<Photo> GetAllPhotos(int authorId,PhotoParameters photoParameters, bool trackChanges)
        {
            var photos = FindByCondition(e => e.AuthorId.Equals(authorId), trackChanges)
            .OrderBy(e => e.Id)
            .ToList();
            return PagedList<Photo>
            .ToPagedList(photos, photoParameters.PageNumber,
            photoParameters.PageSize);
        }

        public Photo GetPhotoById(int authorId,int id, bool trackChanges) =>
            FindByCondition(x =>x.AuthorId.Equals(authorId) && x.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
