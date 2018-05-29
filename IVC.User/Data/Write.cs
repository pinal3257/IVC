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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand cmd = new SqlCommand("SP_User_InsertUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = (user.UserId == 0) ? (object)DBNull.Value : user.UserId;

                    SqlParameter paraUserId = new SqlParameter("@UserId", (user.UserId == 0) ? (object)DBNull.Value : user.UserId);
                    paraUserId.Direction = ParameterDirection.InputOutput;
                    paraUserId.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(paraUserId);

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;

                    SqlParameter paraError = new SqlParameter("@RetError", string.Empty);
                    paraError.SqlDbType = SqlDbType.VarChar;
                    paraError.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paraError);

                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@RetError"].Value)))
                    {
                        return new Response<int?>
                        {
                            StatusCode = -99,
                            Message = Convert.ToString(cmd.Parameters["@RetError"].Value),
                            Content = null,
                        };
                    }

                    return new Response<int?>
                    {
                        StatusCode = 200,
                        Content = Convert.ToInt32(cmd.Parameters["@UserId"].Value),
                    };
                }
                catch (Exception ex)
                {
                    return new Response<int?>
                    {
                        StatusCode = -99,
                        Message = ex.Message,
                        Content = null,
                    };
                }
            }
        }
    }
}
