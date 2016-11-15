﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Services.InMemory;

namespace IS3.IdentityServer
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return  new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "bob",
                    Password = "secret",
                    Subject = "1"
                }
            };
        }
    }
}