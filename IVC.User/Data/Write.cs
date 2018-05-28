﻿using IVC.Return;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace IVC.User.Data
{
    public class Write : IVC.User.Domain.IWrite
    {
        public Response<int?> InsertUpdateUser(IVC.User.DTO.User user)
        {
            Response<int?> response = new Response<int?>
            {
                StatusCode = -99,
                Message = "",
                Content = null
            };

            return response;
        }
    }
}
