using ASPWeb.API.Models.Domain;
using ASPWeb.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : Controller
    {
        private readonly ICaseRepository caseRepository;
        private readonly IMapper mapper;

        public CaseController(ICaseRepository caseRepository, IMapper mapper)
        {
            this.caseRepository = caseRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCases()
        {
            var cases= await caseRepository.GetAllAsync();
            // Return DTO Cases

           // var casesDTO = new List<Models.DTO.Case>();
           // cases.ToList().ForEach(cases =>
            //{
               // var caseDTO = new Models.DTO.Case()
                //{
                  //  GlobalID = cases.GlobalID,
                    //FristName = cases.FristName,
                    //LastName = cases.LastName,
                    //City = cases.City,
                //};
                //casesDTO.Add(caseDTO);
            //});

            var casesDTO=mapper.Map<List<Models.DTO.Case>>(cases);
            return Ok(casesDTO);
        }

        [HttpGet]
        [Route("{GlobalID:guid}")]
        public async Task<IActionResult> GetCases(Guid GlobalID)
        {
            var caseid = await caseRepository.GetAsync(GlobalID);
            if (caseid==null)
            {
                return NotFound();

            }
            var caseDTO=mapper.Map<Models.DTO.Case>(caseid);
            return Ok(caseDTO);

        }
        
        [HttpPost] 
        
        public async Task<IActionResult> AddCase(Models.DTO.AddCaseRequest addCaseRequest)
        {
            // Request(DTO) to Domain model
             var casenew = new Models.Domain.Case()
             {
                 FristName = addCaseRequest.FristName,
                 LastName = addCaseRequest.LastName,
                 City = addCaseRequest.City
             };

            //Pass deatils to Repository

           casenew=await caseRepository.AddAsync(casenew);

            // Convert back to DTO

            var casenewDTO = new Models.Domain.Case()
            {
                GlobalID = casenew.GlobalID,
                FristName = casenew.FristName,
                LastName = casenew.LastName,
                City = casenew.City
            };
            return CreatedAtAction(nameof(GetCases),new { GlobalID = casenewDTO.GlobalID},casenewDTO);
        }

        [HttpDelete]
        [Route("{GlobalID:guid}")]
        public async Task<IActionResult> DeleteCase(Guid GlobalID)
        {
            //Get case from database
            var caseid = await caseRepository.DeleteAsync(GlobalID);

            // If Null NotFound
            if (caseid == null)
            {
                return NotFound();

            }

            //Convert resonse back to DTO
            var caseDTO = new Models.DTO.Case()
            {
                GlobalID = caseid.GlobalID,
                FristName = caseid.FristName,
                LastName = caseid.LastName,
                City = caseid.City
            };

            // Return Ok Response


            return View(caseDTO);

        }
     
        
            
    }
}
