using System;
using System.Data;
using System.Data.OleDb;
using static System.Console;

namespace ConsoleTester.Testers
{
    class MsAccessTester
    {
        static void Main(string[] args)
        {
            try
            {
                TestConnection();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        static void TestConnection()
        {
            var accessFilename = @"D:\MonthlySalesReport\MonthlySalesReports.accdb";
            var connection = new OleDbConnection
            {
                ConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False", accessFilename)
            };



            var query = "SP_ORDERdETAILS";

            var command = new OleDbCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RegionId", 1);
            connection.Open();
            //var rowsEffeced = command.ExecuteNonQuery();
            var dataAdapter = new OleDbDataAdapter(command);


            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    Console.Write(dataTable.Rows[i]["TerritoryName"] + "\t");
            //    Console.Write(dataTable.Rows[i]["GrossSales"] + "\t");
            //    Console.Write(dataTable.Rows[i]["NetSales"] + "\t");
            //    Console.WriteLine();
            //}


            Console.WriteLine("Success : " + dataTable.Rows.Count);

            //Console.WriteLine("Success : " + rowsEffeced);

            connection.Close();

        }
    }
}
