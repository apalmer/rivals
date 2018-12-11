using rivals.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Models
{
    public class SpikeModel
    {
        public SpikeItem Item { get; set; }

        public SpikeModel()
        {
            Item = new SpikeItem();
        }
    }
}
