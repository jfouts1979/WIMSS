using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WineEntryProposal;
using WineEntryProposal.Models;

namespace WineEntryProposal.Controllers
{
    public class TTBWinePermitsController : ApiController
    {
        private WineContext db = new WineContext();

        // GET: api/TTBActiveWinePermitModels
        public IQueryable<TTBActiveWinePermitModel> GetTTBActiveWinePermitModels()
        {
            return db.TTBActiveWinePermitModels;
        }


        // GET: api/TTBActiveWinePermitModels/5
        [ResponseType(typeof(TTBActiveWinePermitModel))]
        public IHttpActionResult GetTTBActiveWinePermitModel(string id)
        {
            TTBActiveWinePermitModel tTBActiveWinePermitModel = db.TTBActiveWinePermitModels.Find(id);
            if (tTBActiveWinePermitModel == null)
            {
                return NotFound();
            }

            return Ok(tTBActiveWinePermitModel);
        }

        // PUT: api/TTBActiveWinePermitModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTTBActiveWinePermitModel(string id, TTBActiveWinePermitModel tTBActiveWinePermitModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTBActiveWinePermitModel.PERMIT_NUMBER)
            {
                return BadRequest();
            }

            db.Entry(tTBActiveWinePermitModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTBActiveWinePermitModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TTBActiveWinePermitModels
        [ResponseType(typeof(TTBActiveWinePermitModel))]
        public IHttpActionResult PostTTBActiveWinePermitModel(TTBActiveWinePermitModel tTBActiveWinePermitModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TTBActiveWinePermitModels.Add(tTBActiveWinePermitModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TTBActiveWinePermitModelExists(tTBActiveWinePermitModel.PERMIT_NUMBER))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tTBActiveWinePermitModel.PERMIT_NUMBER }, tTBActiveWinePermitModel);
        }

        // DELETE: api/TTBActiveWinePermitModels/5
        [ResponseType(typeof(TTBActiveWinePermitModel))]
        public IHttpActionResult DeleteTTBActiveWinePermitModel(string id)
        {
            TTBActiveWinePermitModel tTBActiveWinePermitModel = db.TTBActiveWinePermitModels.Find(id);
            if (tTBActiveWinePermitModel == null)
            {
                return NotFound();
            }

            db.TTBActiveWinePermitModels.Remove(tTBActiveWinePermitModel);
            db.SaveChanges();

            return Ok(tTBActiveWinePermitModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TTBActiveWinePermitModelExists(string id)
        {
            return db.TTBActiveWinePermitModels.Count(e => e.PERMIT_NUMBER == id) > 0;
        }
    }
}