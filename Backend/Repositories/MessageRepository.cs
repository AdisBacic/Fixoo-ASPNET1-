using Backend.Contexts;
using Backend.Models.Dtos;
using Backend.Models.Entities;

namespace Backend.Repositories
{
    public class MessageRepository
    {

        #region Constructor
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        #endregion




        public async Task<MessageEntity> AddMessage(MessageRequest req)
        {
            _context.Messages.Add(req);
            await _context.SaveChangesAsync();
            
            
            return req;
        }










    }
}
