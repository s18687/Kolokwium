using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class SqlServerPerscriptionsDbService : IPrescriptionsDbService 
    {
        public Prescriptions GetPerscription(int IdPrescription)
        {
            using(SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18687;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from dbo.Medicament, dbo.Prescription_Medicament, dbo.Prescription where dbo.Medicament.IdMedicament = dbo.Prescription_Medicament.IdMedicament and dbo.Prescription_Medicament.IdPrescription = dbo.Prescription.IdPrescription and dbo.Prescription.IdPrescription = @id";
                com.Parameters.AddWithValue("id", IdPrescription);
                con.Open();
                var response = new NewPrescriptions();
                SqlDataReader dr = com.ExecuteReader();
             
                while (dr.Read())
                {
                    IdPrescription = int.Parse(dr["IdPrescription"].ToString());
                    
                   
                };
            }
            return null;
        }

       public NewPrescriptions CreatePerscription(NewPrescriptions newPer)
        {
            using(SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18687;Integrated Security=True"))
            using(SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                //con.BeginTransaction = transaction;

                com.CommandText = "INSERT INTO Prescription(Date, DueDate,IdPatient, IdDoctor) VALUES(@Date, @DueDate, @IdPatient, @IdDoctor)";

                com.Parameters.AddWithValue("Date", newPer.Date);
                com.Parameters.AddWithValue("DueDate", newPer.DueDate);
                com.Parameters.AddWithValue("IdPatient", newPer.IdPatient);
                com.Parameters.AddWithValue("IdDoctor", newPer.IdDoctor);

                com.ExecuteNonQuery();
                transaction.Commit();
            }
            return newPer;
        }

        
    }
}
