using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Topic;
using api.Models;

namespace api.Mappers
{
    public static class TopicMappers
    {
        public static TopicDto ToTopicDto(this Topic topicModel)
        {
            return new TopicDto
            {
                Id = topicModel.Id,
                Name = topicModel.Name,
                Description = topicModel.Description,
                Comments = topicModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Topic ToTopicFromCreateDTO(this CreateTopicRequestDto topicDto)
        {
            return new Topic
            {
                Name = topicDto.Name,
                Description = topicDto.Description
            };
        }
    }
}