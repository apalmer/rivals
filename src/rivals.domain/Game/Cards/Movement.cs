using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain.Game.Cards
{
    public class Movement
    {
        public MovementType Type { get; set; }
        public Nullable<Int32> Magnitude { get; set; }
    }
}
