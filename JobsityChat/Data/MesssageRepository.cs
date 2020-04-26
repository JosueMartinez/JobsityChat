using JobsityChat.Models;
using System.Collections.Generic;

namespace JobsityChat.Data
{
    public interface IMesssageRepository
    {
        List<Message> GetAll();
        void Add(Message message);
    }
}
