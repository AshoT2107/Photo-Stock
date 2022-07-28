using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IAuthorRepository _authorRepository;
        private IPhotoRepository _photoRepository;
        private ITextRepository _textRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IAuthorRepository Author
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new AuthorRepository(_repositoryContext);
                return _authorRepository;
            }
        }

        public IPhotoRepository Photo
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository(_repositoryContext);
                return _photoRepository;
            }
        }

        public ITextRepository Text
        {
            get
            {
                if (_textRepository == null)
                    _textRepository = new TextRepository(_repositoryContext);
                return _textRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
