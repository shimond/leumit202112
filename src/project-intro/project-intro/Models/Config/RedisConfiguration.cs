﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Models.Config
{
    public class RedisConfiguration
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public bool Enabled { get; set; }
        public string Password { get; set; }
        public int[] AlternativePorts { get; set; }
    }
}
