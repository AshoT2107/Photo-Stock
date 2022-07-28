using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }
        IPhotoRepository Photo { get; }
        ITextRepository Text { get; }
        void Save();
    }
}
