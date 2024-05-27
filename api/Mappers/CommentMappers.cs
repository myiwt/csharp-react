using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Subject = commentModel.Subject,
                Content = commentModel.Content,
                Created = commentModel.Created,
                TopicId = commentModel.TopicId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int topicId)
        {
            return new Comment
            {
                Subject = commentDto.Subject,
                Content = commentDto.Content,
                TopicId = topicId,
            };
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Subject = commentDto.Subject,
                Content = commentDto.Content,
            };
        }
    }
}