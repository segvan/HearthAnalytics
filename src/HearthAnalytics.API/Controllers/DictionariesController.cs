using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HearthAnalytics.Model.Repositories;
using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using Newtonsoft.Json;

namespace HearthAnalytics.API.Controllers
{
 
    [Route("api/[controller]")]
    public class DictionariesController : Controller
    {
        private readonly IClassTypesRepository _classTypesRepository;
        private readonly IMatchResultsRepository _matchResultsRepository;
                
        /// <summary>
        /// Returns a suitable JsonSerializerSettings object that can be used to generate the JsonResult return value for this Controller's methods.
        /// </summary>
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

        public DictionariesController(IClassTypesRepository classTypesRepository, IMatchResultsRepository matchResultsRepository)
        {
            this._classTypesRepository = classTypesRepository;
            this._matchResultsRepository = matchResultsRepository;
        }

        // GET api/dictionaries/classtypes
        [HttpGet("ClassTypes")]
        public IActionResult GetClassTypes()
        {
            var model = this._classTypesRepository.FindAll();
            var dto = Mapper.Map<IEnumerable<ClassTypeDto>>(model);
            return new JsonResult(dto, DefaultJsonSettings);
        }

        // GET api/dictionaries/matchresults
        [HttpGet("MatchResults")]
        public IActionResult GetMatchResults()
        {
            var model = this._matchResultsRepository.FindAll();
            var dto = Mapper.Map<IEnumerable<MatchResultDto>>(model);
            return new JsonResult(dto, DefaultJsonSettings);
        }
    }
}
