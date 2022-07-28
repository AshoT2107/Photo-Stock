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
    public class TextRepository : RepositoryBase<Text>, ITextRepository
    {
        public TextRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public void CreateTextForAuthor(int authorId, Text text)
        {
            text.AuthorId = authorId;
            Create(text);
        }

        public PagedList<Text> GetAllTexts(int authorId, TextParameters textParameters, bool trackChanges)
        {
            var texts = FindByCondition(e => e.AuthorId.Equals(authorId),trackChanges)
            .OrderBy(e => e.Id)
            .ToList();
            return PagedList<Text>
            .ToPagedList(texts, textParameters.PageNumber,
            textParameters.PageSize);
        }

        public Text GetTextById(int authorId, int id, bool trackChanges) =>
            FindByCondition(x => x.AuthorId.Equals(authorId) && x.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
