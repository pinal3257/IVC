using IVC.Return;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace IVC.User.Data
{
    public class Write : IVC.User.Domain.IWrite
    {
        private string connectionString = string.Empty;

        public Write(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Response<int?> InsertUpdateUser(IVC.User.DTO.User user)
        {
            Response<int?> response = new Response<int?>
            {
                StatusCode = -99,
                Message = "",
                Content = null
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand cmd = new SqlCommand("sp_insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                 
                cmd.ExecuteNonQuery();

            }

            return response;
        }
    }
}
