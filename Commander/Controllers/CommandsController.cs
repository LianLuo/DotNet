using System;
using System.Collections.Generic;
using AutoMapper;
using Commander.Dtos;
using Commander.IRepository;
using Commander.Models;
using Commander.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    /// <summary>
    /// api/command
    /// </summary>
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IRepositoryBase<BaseEntity> _repository;
        private readonly IMapper _mapper;

        public CommandsController(IRepositoryBase<BaseEntity> repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }
        

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = this._repository.GetEntities();
            var commandReadDtos = this._mapper.Map<IEnumerable<CommandReadDto>>(commands);
            return Ok(commandReadDtos);
        }

        // GET api/commands/5
        [HttpGet("{id}",Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var result = this._repository.GetEntity(id);
            if(null == result)
            {
                return NotFound();
            }
            var commandReadDto = this._mapper.Map<CommandReadDto>(result);
            return Ok(commandReadDto);
        }

        // POST api/command
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmdCraeteDto)
        {
            var command = this._mapper.Map<Command>(cmdCraeteDto);
            this._repository.CreateCommand(command);
            this._repository.SaveChanges();
            var commandReadDto = this._mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.ID}, commandReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto cmdUpdateDto)
        {
            var command = this._repository.GetEntity(id) as Command;
            if(null == command)
            {
                return NotFound();
            }
            this._mapper.Map(cmdUpdateDto, command);

            this._repository.UpdatedCommand(command);
            this._repository.SaveChanges();

            return NoContent();
        }
    
        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var command = this._repository.GetEntity(id);
            if(null == command)
            {
                return NotFound();
            }

            var commandToPatch = this._mapper.Map<CommandUpdateDto>(command);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            this._mapper.Map(commandToPatch, command);
            this._repository.UpdatedCommand(command);
            this._repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = this._repository.GetEntity(id);
            if(null == command)
            {
                return NotFound();
            }
            this._repository.DeleteCommand(command);
            this._repository.SaveChanges();

            return NoContent();
        }
    }
}