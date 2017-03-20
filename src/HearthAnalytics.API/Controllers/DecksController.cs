using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HearthAnalytics.Model.Repositories;
using HearthAnalytics.Infrastructure;
using Newtonsoft.Json;
using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Model;

namespace HearthAnalytics.API.Controllers
{
    [Route("api/[controller]")]
    public class DecksController : Controller
    {
        private readonly IDecksRepository _decksRepository;
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

        public DecksController(IDecksRepository decksRepository, IUnitOfWork unitOfWork)
        {
            this._decksRepository = decksRepository;
            this._unitOfWork = unitOfWork;
        }

        // GET api/decks
        [HttpGet]
        public IActionResult Get()
        {
            var model = this._decksRepository.FindAll(x => x.ArchyType);
            var dto = Mapper.Map<IEnumerable<DeckDto>>(model);
            return new JsonResult(dto, DefaultJsonSettings);
        }

        // GET api/decks/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = this._decksRepository.FindById(id, x => x.ArchyType);
            if (item != null)
            {
                var dto = Mapper.Map<DeckDto>(item);
                return new JsonResult(dto, DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/decks
        [HttpPost]
        public IActionResult Post([FromBody]DeckDto deckDto)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Deck>(deckDto);
                this._decksRepository.Add(entity);
                _unitOfWork.Complete();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/decks/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]DeckDto deckDto)
        {
            if (ModelState.IsValid)
            {
                var item = this._decksRepository.FindById(id);
                if (item != null)
                {
                    var entity = Mapper.Map(deckDto, item, typeof(DeckDto), typeof(Deck));
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

        // DELETE api/decks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            this._decksRepository.Remove(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
