using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalAngular.Models;
namespace FinalAngular.Controllers
{
    public class MedicineController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
             select MedicineId,MedicineName,City,Username,PhoneNumber,Information from
             dbo.Medicines
              ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["PharmacyDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Medicine med)
        {
            try
            {
                string query = @"
                  insert into dbo.Medicines values
                  ( '" + med.MedicineName + @"'
                    ,'" + med.City + @"'
                    ,'" + med.Username + @"'
                       ,'" + med.PhoneNumber + @"'
                   ,'" + med.Information + @"'

)

                  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["PharmacyDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Medicine added successfully!";
            }
            catch (Exception)
            {
                return "Failed to Add!";
            }
        }

        public string Put(Medicine med)
        {
            try
            {
                string query = @"
                  update dbo.Medicines set 
                   MedicineName = ('" + med.MedicineName + @"')
                   ,City = ('" + med.City + @"')
                   ,Username = ('" + med.Username + @"')
                   ,PhoneNumber = ('" + med.PhoneNumber + @"')
                    ,Information = ('" + med.Information + @"')
                   
                   where MedicineId=" + med.MedicineId + @"

                  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["PharmacyDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Medicine updated successfully!";
            }
            catch (Exception)
            {
                return "Failed to update!";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                  delete from dbo.Medicines
                  where MedicineId=" + id + @"

                  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["PharmacyDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted successfully!";
            }
            catch (Exception)
            {
                return "Failed to delete!";
            }
        }
       
    
    }
}
