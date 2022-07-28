using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPhotoRepository
    {
        PagedList<Photo> GetAllPhotos(int authorId, PhotoParameters photoParameters,bool trackChanges);
        Photo GetPhotoById(int authorId,int id, bool trackChanges);
    }
}
