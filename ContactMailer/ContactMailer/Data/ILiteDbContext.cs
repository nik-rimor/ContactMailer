﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMailer.Data
{
    public interface ILiteDbContext
    {
        public LiteDatabase Database { get;  }
    }
}
