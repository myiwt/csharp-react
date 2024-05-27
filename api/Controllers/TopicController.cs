using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Topic;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Topic")]
    [ApiController]
    public class TopicController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITopicRepository _topicRepo;
        
        public TopicController(ApplicationDBContext context, ITopicRepository topicRepo)
        {
            _context = context;
            _topicRepo = topicRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var topics = await _topicRepo.GetAllAsync();
            var topicDto = topics.Select(s => s.ToTopicDto());
            return Ok(topicDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var topic = await _topicRepo.GetByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic.ToTopicDto());
        }

        //FromBody allows input to be a json request body
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTopicRequestDto TopicDto) 
        {
            var topicModel = TopicDto.ToTopicFromCreateDTO();
            await _topicRepo.CreateAsync(topicModel);
            return CreatedAtAction(nameof(GetById), new { id = topicModel.Id}, topicModel.ToTopicDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTopicRequestDto updateDto)
        {
            var topicModel = await _topicRepo.UpdateAsync(id, updateDto);
            if (topicModel == null)
            {
                return NotFound();
            }
            return Ok(topicModel.ToTopicDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var topicModel = await _topicRepo.DeleteAsync(id);
            if (topicModel == null)
            {
                return NotFound();
            }

            // NoContent is the "200 okay message" for a delete action
            return NoContent();
        }
    }
}