using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainEvents
{
    internal sealed class automovilDeleted : DomainEvent
    {
        public int AutomovilId { get; set; }

        public automovilDeleted(int id)
        {
            AutomovilId = id;
        }
    }
}
