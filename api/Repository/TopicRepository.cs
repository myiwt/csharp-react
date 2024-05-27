using api.Data;
using api.Dtos.Topic;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TopicRepository : ITopicRepository
    {
        // attributes
        private readonly ApplicationDBContext _context;

        // Dependency Injection -
        // brings in the global db context as part of the constructor
        // so that it is brought in before the methods are called
        public TopicRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Topic> CreateAsync(Topic topicModel)
        {
            await _context.Topics.AddAsync(topicModel);
            await _context.SaveChangesAsync();
            return topicModel;
        }

        // DELETE uses FirstOrDefault because it can return a 'null' or a 'default' 
        // if there is no Topic found. In this case, if the id doesn't exist in the
        // db, it can return null, and return to the client, yes, id=111 doesn't
        // exist in the db, which is valid.
        public async Task<Topic?> DeleteAsync(int id)
        {
            var topicModel = await _context.Topics.FirstOrDefaultAsync( x => x.Id == id);
            if(topicModel == null) 
            {
                return null;
            }

            _context.Topics.Remove(topicModel);
            await _context.SaveChangesAsync();
            return topicModel;
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _context.Topics.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _context.Topics.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> TopicExists(int id)
        {
            return await _context.Topics.AnyAsync(s => s.Id == id); // returns true if at least 1 is found
        }

        public async Task<Topic?> UpdateAsync(int id, UpdateTopicRequestDto topicDto)
        {
            var topicModel = await _context.Topics.FirstOrDefaultAsync(x => x.Id == id);
            if (topicModel == null) {
                return null;
            }
            topicModel.Name = topicDto.Name;
            topicModel.Description = topicDto.Description;

            await _context.SaveChangesAsync();
            return topicModel;
        }
    }
}