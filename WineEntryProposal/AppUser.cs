﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineEntryProposal
{
    public class AppUser : IdentityUser
    {
        //add your custom properties which have not included in IdentityUser before
        public string MyExtraProperty { get; set; }
    }
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
        // extra properties here 
    }
}