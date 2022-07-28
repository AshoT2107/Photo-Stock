using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.RequestFeatures;
namespace Contracts
{
    public interface ITextRepository
    {
        PagedList<Text> GetAllTexts(int authorId, TextParameters textParameters, bool trackChanges);
        Text GetTextById(int authorId,int id, bool trackChanges);
        void CreateTextForAuthor(int AuthorId, Text text);
    }
}
