using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheTruthIsOutThere
{
    class dbConn
    {
        DataTable dt;
        SqlCommand myCommand;
        SqlDataAdapter adapter;
        SqlConnection myConnection;

        public dbConn()
        {
            myConnection = new SqlConnection();
            myConnection.ConnectionString = "Integrated Security=true;database=dbTheTruthIsOutThere;Data Source=LAPTOP-7DKPE6B0\\SQLEXPRESS14";
        }

        public DataTable GetPlanetsSize()
        { 
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "spGetPlanetsSize";
            dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = myCommand;
            adapter.Fill(dt);
            return dt;
        }

        public DataTable SolarSystem()
        {
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "spSolarSystem";
            dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = myCommand;
            adapter.Fill(dt);
            return dt;
        }

        public void InsertGalaxy(Galaxy myGalaxy)
        {
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "spInsertGalaxy";
            SqlParameter workparameter1 = new SqlParameter();
            SqlParameter workparameter2 = new SqlParameter();
            SqlParameter workparameter3 = new SqlParameter();
            SqlParameter workparameter4 = new SqlParameter();

            workparameter1 = myCommand.Parameters.Add("@Name", SqlDbType.VarChar);
            workparameter1.Value = myGalaxy.Name;
            workparameter2 = myCommand.Parameters.Add("@Diameter", SqlDbType.Int);
            workparameter2.Value = myGalaxy.Diameter;
            workparameter3 = myCommand.Parameters.Add("@Stars", SqlDbType.Int);
            workparameter3.Value = myGalaxy.Stars;
            workparameter4 = myCommand.Parameters.Add("@Planets", SqlDbType.Int);
            workparameter4.Value = myGalaxy.Planets;
            
            myConnection.Open();
            int i = myCommand.ExecuteNonQuery();
            if (i!=0)
            {
                MessageBox.Show("Saved successfully!");
            }
            myConnection.Close();
        }

        public DataTable GetGalaxies()
        {
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "spGetGalaxies";
            dt = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = myCommand;
            adapter.Fill(dt);
            return dt;
        }
    }
}
