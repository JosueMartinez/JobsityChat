using JobsityChat.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobsityChat.Data
{
    public class MessageRepository: IMesssageRepository 
    {
        private ApplicationDbContext _context;
        private DbSet<Message> _messageEntity;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
            _messageEntity = context.Set<Message>();
        }


        public void Add(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public List<Message> GetAll()
        {
            return _messageEntity
                .OrderBy(x => x.TimeStamp)
                .Take(50)
                .ToList();
        }
    }
}
