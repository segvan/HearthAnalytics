using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HearthAnalytics.Model.Repositories;
using HearthAnalytics.Model;
using Newtonsoft.Json;
using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Infrastructure;

namespace HearthAnalytics.API.Controllers
{

    [Route("api/[controller]")]
    public class ArchyTypesController : Controller
    {
        private readonly IArchyTypesRepository _archyTypesRepository;
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

        public ArchyTypesController(IArchyTypesRepository archyTypesRepository, IUnitOfWork unitOfWork)
        {
            this._archyTypesRepository = archyTypesRepository;
            this._unitOfWork = unitOfWork;
        }

        // GET api/archytypes
        [HttpGet]
        public IActionResult Get()
        {
            var model = this._archyTypesRepository.FindAll(x => x.Class);
            var dto = Mapper.Map<IEnumerable<ArchyTypeDto>>(model);
            return new JsonResult(dto, DefaultJsonSettings);
        }

        // GET api/archytypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = this._archyTypesRepository.FindById(id, x => x.Class);
            if (item != null)
            {
                var dto = Mapper.Map<ArchyTypeDto>(item);
                return new JsonResult(dto, DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/archytypes
        [HttpPost]
        public IActionResult Post([FromBody]ArchyTypeDto archyTypeDto)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<ArchyType>(archyTypeDto);
                this._archyTypesRepository.Add(entity);
                _unitOfWork.Complete();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/archytypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ArchyTypeDto archyTypeDto)
        {
            if (ModelState.IsValid)
            {
                var item = this._archyTypesRepository.FindById(id);
                if (item != null)
                {
                    var entity = Mapper.Map(archyTypeDto, item, typeof(ArchyTypeDto), typeof(ArchyType));
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

        // DELETE api/archytypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._archyTypesRepository.Remove(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
