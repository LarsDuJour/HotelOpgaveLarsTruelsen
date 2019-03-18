using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelDBREST.DBUtil;
using ModelLib.model;

namespace HotelDBREST.Controllers
{
    public class HotelFacilitiesController : ApiController
    {
        private static ManageHotelFacilities manager = new ManageHotelFacilities();
        // GET: api/HotelFacilities
        public IEnumerable<HotelFacilities> Get()
        {
            return manager.Get();
        }

        // GET: api/HotelFacilities/5
        [Route("api/HotelFacilities/{fid}/hotelId/{hid}")]
        public HotelFacilities Get(int fid, int hid)
        {
            return manager.Get(hid, fid);
        }

        // POST: api/HotelFacilities
        public bool Post([FromBody]HotelFacilities elem)
        {
            return manager.Post(elem);
        }

        // PUT: api/HotelFacilities/5
        [Route("api/HotelFacilities/{fid}/hotelId/{hid}")]
        public bool Put(int fid, int hid, [FromBody]HotelFacilities elem)
        {
            return manager.Put(hid, fid, elem);
        }

        // DELETE: api/HotelFacilities/5
        [Route("api/HotelFacilities/{fid}/hotelId/{hid}")]
        public bool Delete(int fid, int hid)
        {
            return manager.Delete(hid, fid);
        }
    }
}