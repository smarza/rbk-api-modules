﻿using Microsoft.Data.SqlClient.DataClassification;
using rbkApiModules.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbkApiModules.Tester.Models
{
    public class Client: BaseEntity
    {
        protected Client()
        {

        }

        public Client(string name, DateTime birthdate)
        {

        }

        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }

        public User User { get; private set; }
    }
}
