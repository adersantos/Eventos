﻿using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime TimeStamp { get;private set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
