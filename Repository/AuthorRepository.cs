using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext)
            :base(repositoryContext) {}

        public void CreateAuthor(Author author) => Create(author);

        public IEnumerable<Author> GetAllAuthors(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(x => x.Id)
                .ToList();

        public Author GetAuthorById(int id, bool trackChanges) =>
            FindByCondition(x=>x.Id.Equals(id),trackChanges).SingleOrDefault();
    }
}
