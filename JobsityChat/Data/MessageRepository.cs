using JobsityChat.Models;
using System.Collections.Generic;
using System.Linq;

namespace JobsityChat.Data
{
    public class MessageRepository: IRepository<Message> 
    {
        ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Message entity)
        {
            _context.Messages.Add(entity);
            _context.SaveChanges();
        }

        public List<Message> GetAll()
        {
            return _context.Messages
                .OrderByDescending(x => x.TimeStamp)
                .Take(50)
                .ToList();
        }
    }
}
