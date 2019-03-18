using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageFacility : IManage<Facility>
    {
        private const String GET_ALL = "select * from Facility";
        private const String GET_ONE = "select * from Facility WHERE Facility_Id = @ID";
        private const String DELETE = "delete from Facility WHERE Facility = @ID";
        private const String INSERT = "insert into Facility values (@ID, @Name, @Desc)";
        private const String UPDATE = "update Facility " +
                                      "SET Facility_Id = @Id, Name = @Type, Desc = @Description " +
                                      "WHERE Facility_Id = @ID";


        // GET: api/Hotels
        public IEnumerable<Facility> Get()
        {
            List<Facility> liste = new List<Facility>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Facility facility = ReadFacility(reader);
                liste.Add(facility);
            }
            reader.Close();

            return liste;
        }

        // GET: api/Hotels/5
        public Facility Get(int id)
        {
            Facility facility = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                facility = ReadFacility(reader);
            }
            reader.Close();

            return facility;
        }

        private Facility ReadFacility(SqlDataReader reader)
        {
            Facility facility = new Facility();

            facility.FacilityId = reader.GetInt32(0);
            facility.FacilityName = reader.GetString(1);
            facility.FacilityDesc = reader.GetString(2);

            return facility;
        }


        // POST: api/Hotels
        public bool Post(Facility elem)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@Id", elem.FacilityId);
            cmd.Parameters.AddWithValue("@Type", elem.FacilityName);
            cmd.Parameters.AddWithValue("@Description", elem.FacilityDesc);

            int rowsAffected;
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }

            return rowsAffected == 1;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Facility elem)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Id", elem.FacilityId);
            cmd.Parameters.AddWithValue("@Type", elem.FacilityName);
            cmd.Parameters.AddWithValue("@Description", elem.FacilityDesc);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }


        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;

        }

    }
}