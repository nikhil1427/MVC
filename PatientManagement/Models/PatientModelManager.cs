using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PatientManagement.Models
{
    public class PatientModelManager
    {
        private List<Patient> patients = new List<Patient>();

        //is going to fetch all the data from database table
        public List<Patient> GetPatients()
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from patient", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Patient patient = new Patient();
                patient.Id = Convert.ToInt32(dr["id"]);
                patient.Name = Convert.ToString(dr["name"]);
                patient.Age = Convert.ToInt32(dr["age"]);
                patient.Bg = Convert.ToString(dr["bg"]);
                patient.Disease = Convert.ToString(dr["disease"]);

                patients.Add(patient);
            }
            return patients;
        }

        public int AddPatient(Patient patient)
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = string.Format("insert into patient values('{0}',{1},'{2}','{3}')",
                patient.Name, patient.Age, patient.Bg, patient.Disease);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowInserted = cmd.ExecuteNonQuery();
            return rowInserted;
        
}

        public Patient GetPatientById(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = string.Format("select * from patient where id={0}", id);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Patient patient = new Patient();
            while (dr.Read())
            {
                patient.Id = Convert.ToInt32(dr["id"]);
                patient.Name = Convert.ToString(dr["name"]);
                patient.Age = Convert.ToInt32(dr["age"]);
                patient.Bg = Convert.ToString(dr["bg"]);
                patient.Disease = Convert.ToString(dr["disease"]);
            }
            return patient;
        }

        public int UpdatePatient(Patient patient)
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = string.Format(
                "update patient set Name ='{0}',Age = {1},Bg = '{2}',Disease ='{3}' where id = {4}",
                patient.Name, patient.Age, patient.Bg, patient.Disease, patient.Id);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowUpdated = cmd.ExecuteNonQuery();
            return rowUpdated;
        }

        public int DeletePatient(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = string.Format("delete patient where id={0}", id);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowInserted = cmd.ExecuteNonQuery();
            return rowInserted;
        }
    }
}