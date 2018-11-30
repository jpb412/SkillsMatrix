using System;
using System.Data.SqlClient;
using System.Data;

namespace NetCoreConsoleSqlDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting App!");
            DataTable retVal = new DataTable();
            
            using (SqlConnection cn = new SqlConnection("Data Source=BRADYJ102W8\\SQL2017;Initial Catalog=SkillsMatrix;Integrated Security=true;"))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Matrix.Employee", cn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //SqlParameter tt = cmd.Parameters.AddWithValue("@input", dt);
                    //tt.SqlDbType = SqlDbType.Structured;
                    //tt.TypeName = "Algorithm.CyberRiskGroupCombinationType";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        retVal.Load(rdr);
                    }
                }
            }

            //Loop Datatable
            foreach (DataRow r in retVal.Rows)
            {
                Console.WriteLine($"EmployeeId: {r["EmployeeId"].ToString()}, FirstName: {r["FirstName"].ToString()}, LastName: {r["LastName"].ToString()}, JobId: {r["JobId"].ToString()}, ChapterId: {r["ChapterId"].ToString()}");
            }
            Console.WriteLine("Run Completed!");
            Console.ReadLine();

        }
    }
}
