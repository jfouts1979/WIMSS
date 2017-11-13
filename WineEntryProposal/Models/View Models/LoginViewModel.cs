using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models.View_Models
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public string UserName { get; set; }
        public string Password {get; set;}


    }
}