using Jeopardy.Core.Data;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Models;

namespace Jeopardy.Core.Repository;

public class ClueRepository(DataContext context)
{
    private readonly DataContext _context = context;
 
}