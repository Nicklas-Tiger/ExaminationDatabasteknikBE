using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class DocumentRepository(DataContext context) : BaseRepository<DocumentEntity>(context), IDocumentRepository
{

}
