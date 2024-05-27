using api.Dtos.Topic;
using api.Models;

namespace api.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetAllAsync();
        // GET by id, takes in int id
        // question mark is used because this method will
        // use FirstOrDefault, which can return NULL if
        // db is empty
        Task<Topic?> GetByIdAsync(int id);
        // POST method, create a topic entity via data model
        Task<Topic> CreateAsync(Topic topicModel);
        // PUT method, update an existing topic and return the 
        // updated topic in the response as a DTO
        Task<Topic?> UpdateAsync(int id, UpdateTopicRequestDto topicDto);
        // DELETE a topic
        Task<Topic?> DeleteAsync(int id);
        // Check if topic exists by id
        Task<bool> TopicExists(int id);

    }
}