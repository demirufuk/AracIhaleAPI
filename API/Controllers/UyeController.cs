using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UyeController : ControllerBase
    {
        private IGenericRepository<DCAUye> repository = null;
        //private IGenericRepository<ApiLog> apiLogRepository = null;

        public UyeController(IGenericRepository<DCAUye> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DCAUye>> Get()
        {
            var obj = new EntityList<DCAUye>();
            obj.Message = "Ok";
            obj.Status = true;
            obj.Result = repository.GetAll().ToList();

            return Ok(obj);
        }

        [HttpGet("{id}")]
        public ActionResult<DCAUye> Get(int id)
        {
            var obj = new Entity<DCAUye>();

            try
            {
                if (id < 1)
                {
                    obj.Message = "sap kodunu kontrol ediniz.";
                    obj.Status = false;
                    return Ok(obj);
                }

                var model = repository.First(u => u.UyeSapKodu == id.ToString());

                if (model == null)
                {
                    obj.Message = "Üye Bulunamadı.";
                    obj.Status = false;
                    return Ok(obj);
                }

                obj.Message = "ok";
                obj.Status = true;
                obj.Result = model;

                return Ok(obj);
            }
            catch (Exception)
            {
                return NotFound(new { message = "IT birimi ile iletişime geçiniz" });
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Post([FromBody] DCAUye uye)
        {
            var obj = new Entity<DCAUye>();

            try
            {
                if (ModelState.IsValid)
                {
                    repository.Insert(uye);
                    repository.Save();

                    obj.Message = "Üye kaydetme işlemi başarılı.";
                    obj.Status = true;
                    obj.Result = uye;

                    return Ok(obj);
                }
                else
                {
                    obj.Message = "Üye kaydetme işlemi başarısız.";
                    obj.Status = false;
                    obj.Result = uye;
                    return NotFound(obj);
                }
            }
            catch (Exception)
            {
                return NotFound(new { message = "IT birimi ile iletişime geçiniz" });
            }
        }
    }
}