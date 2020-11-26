using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonarService.Models;
using DonarService.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DonarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarsController : ControllerBase
    {
        public static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DonarsController));
        // GET: DonarController
        private readonly IRepository<Donar> _repository;

        public DonarsController(IRepository<Donar> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Donar>> GetDonar()
        {
            try
            {
                 _log4net.Info("Http get request initiated for all donars");


                var DonarsList = _repository.Get();
                if (DonarsList != null)
                {
                     _log4net.Info("All the donars were displayed");

                    return Ok(DonarsList);


                }

            }
            catch (Exception e)
            {
                   _log4net.Error("Http get Request Failed Due to " + e.Message);

                return NoContent();
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public ActionResult<Donar> GetDonar(int id)
        {
            try
            {
                _log4net.Info("Http get request initiated for the Id " + id);


                var donar = _repository.GetById(id);
                if (donar != null)
                {
                    _log4net.Info("Object Found");
                    return Ok(donar);
                }


            }
            catch (Exception e)
            {
                  _log4net.Error("Http get Request Failed Due to " + e.Message);


                return NoContent();
            }
            return BadRequest();
        }
        [HttpPost]
        public ActionResult<Donar> PostDonar([FromBody] Donar donar)
        {
            try
            {
                 _log4net.Info("Http post Request Initiated for the donar Id " + donar.DonorId);
                if (ModelState.IsValid)
                {
                      _log4net.Info("Obtained Valid Model");

                    _repository.Add(donar);


                    return CreatedAtAction("GetDonar", new { id = donar.DonorId }, donar);





                }

            }
            catch (Exception e)
            {
                  _log4net.Error("Http post Request Failed Due to " + e.Message);


                return NotFound();
            }
            return BadRequest();
        }
    }
}
