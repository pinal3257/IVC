using IVC.Return;
using System;
using System.Collections.Generic;
using System.Text;

namespace IVC.User.Domain
{
    public interface IWrite
    {
        Response<int?> InsertUpdateUser(IVC.User.DTO.User user);
    }
}
