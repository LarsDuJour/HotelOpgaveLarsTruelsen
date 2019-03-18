using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageHotelFacilities : IManage<HotelFacilities>
    {
        private const String GET_ALL = "select * from HotelFacilities";
        private const String GET_ONE = "select * from HotelFacilities WHERE Hotel_No = @HID AND Facility_Id = @FID";
        private const String DELETE = "delete from HotelFacilities WHERE Hotel_No = @HID AND Facility_Id = @FID";
        private const String INSERT = "insert into HotelFacilities values (@FID, @HID)";
        private const String UPDATE = "update HotelFacilities " +
                                      "SET Hotel_no = @HotelId, Facility_Id = @Facility_Id" +
                                      "WHERE Hotel_No = @HID AND Facility_Id = @FID";


        protected HotelFacilities ReadNextElement(SqlDataReader reader)
        {
            HotelFacilities elem = new HotelFacilities();

            elem.FacilityId = reader.GetInt32(0);
            elem.HotelNo = reader.GetInt32(1);

            return elem;
        }

        public IEnumerable<HotelFacilities> Get()
        {
            List<HotelFacilities> liste = new List<HotelFacilities>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                HotelFacilities elem = ReadNextElement(reader);
                liste.Add(elem);
            }
            reader.Close();

            return liste;
        }

        public HotelFacilities Get(int hid, int fid)
        {
            HotelFacilities elem = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@FID", fid);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                elem = ReadNextElement(reader);
            }
            reader.Close();

            return elem;
        }


        public bool Post(HotelFacilities r)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", r.HotelNo);
            cmd.Parameters.AddWithValue("@FID", r.FacilityId);
            

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Put(int hid, int fid, HotelFacilities r)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HotelId", r.HotelNo);
            cmd.Parameters.AddWithValue("@Facility_Id", r.FacilityId);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@FID", fid);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;

        }

        public bool Delete(int hid, int fid)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@HID", hid);
            cmd.Parameters.AddWithValue("@FID", fid);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Put(int id, HotelFacilities elem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HotelFacilities Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}