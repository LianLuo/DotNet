using System;
using System.Collections.Generic;
using Commander.IRepository;
using Commander.Models;
using Commander.Repository;
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
        public CommandsController(IRepositoryBase<BaseEntity> repo)
        {
            _repository = repo;
        }
        

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<BaseEntity>> GetAllCommands()
        {
            var commands = this._repository.GetEntities();
            return Ok(commands);
        }

        // GET api/commands/5
        [HttpGet("{id}")]
        public ActionResult<BaseEntity> GetCommandById(int id)
        {
            var result = this._repository.GetEntity(id);
            return Ok(result);
        }

    }
}