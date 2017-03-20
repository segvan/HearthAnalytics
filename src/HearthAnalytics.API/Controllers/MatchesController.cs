using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Infrastructure;
using HearthAnalytics.Model;
using HearthAnalytics.Model.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HearthAnalytics.API.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IUnitOfWork _unitOfWork;

        private JsonSerializerSettings DefaultJsonSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };
            }
        }

        public MatchesController(IMatchesRepository matchesRepository, IUnitOfWork unitOfWork)
        {
            this._matchesRepository = matchesRepository;
            this._unitOfWork = unitOfWork;
        }

        // GET api/matches
        [HttpGet]
        public IActionResult Get()
        {
            var model = this._matchesRepository.FindAll(x => x.Deck, x => x.EnemyArchyType, x => x.EnemyClass);
            var dto = Mapper.Map<IEnumerable<MatchDto>>(model);
            return new JsonResult(dto, DefaultJsonSettings);
        }

        // GET api/matches/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = this._matchesRepository.FindById(id, x => x.Deck, x => x.EnemyArchyType, x => x.EnemyClass);
            if (item != null)
            {
                var dto = Mapper.Map<MatchDto>(item);
                return new JsonResult(dto, DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/matches
        [HttpPost]
        public IActionResult Post([FromBody]MatchDto matchDto)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Match>(matchDto);
                this._matchesRepository.Add(entity);
                _unitOfWork.Complete();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/matches/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]MatchDto matchDto)
        {
            if (ModelState.IsValid)
            {
                var item = this._matchesRepository.FindById(id);
                if (item != null)
                {
                    var entity = Mapper.Map(matchDto, item, typeof(MatchDto), typeof(Match));
                    _unitOfWork.Complete();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/matches/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            this._matchesRepository.Remove(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
