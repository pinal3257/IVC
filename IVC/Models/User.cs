using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IVC.User.DTO;

namespace IVC.Models
{
    public class User
    { 
        public bool IsError { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool NotFound { get; private set; }

        public bool IsViewLoad { get; set; } 

        public User()
        {
            this.IsViewLoad = true;
            this.IsError = false;
            this.ErrorMessage = "";             
        }
         
        internal void SetError(string error)
        {
            this.IsError = true;
            this.ErrorMessage = error;
        }
         
    }
}
