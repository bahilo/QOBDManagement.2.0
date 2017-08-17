﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDCommon.Entities
{
    public class Action
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayedName { get; set; }

        public Privilege Right { get; set; }
    }
}
