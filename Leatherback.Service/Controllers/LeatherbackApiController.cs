using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Leatherback.Core.Entity;
using Leatherback.Logic;

namespace Turtle.Service.Controllers
{
    [ApiController]
    public class LeatherbackApiController<TServiceEntity, TSearchCriteria> : ControllerBase 
     where TServiceEntity : class, ILeatherbackEntity
     where TSearchCriteria : class, ILeatherbackEntity
    {
        private readonly ILogic<TServiceEntity, TSearchCriteria> _logic;

        public LeatherbackApiController(ILogic<TServiceEntity, TSearchCriteria> logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAll")]
        public Task<IEnumerable<TServiceEntity>> GetAll()
        {
            return _logic.GetAllAsync();
        }

        [HttpPost("Search")]
        public Task<IEnumerable<TServiceEntity>> Search(TSearchCriteria criteria)
        {
            return _logic.SearchAsync(criteria);
        }

        [HttpPost("Add")]
        public Task<TServiceEntity> Add(TServiceEntity entity)
        {
            return _logic.AddAsync(entity);
        }

        [HttpPut("Update")]
        public async Task<StatusCodeResult> Update(TServiceEntity entity)
        {
            if (await _logic.UpdateAsync(entity))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<StatusCodeResult> Delete(Guid entityToDelete)
        {
            if (await _logic.DeleteAsync(entityToDelete))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
