using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.domain.Session
{
    public class UserSession : Persistable
    {
        public String UserName { get; set; }
        public DateTime SessionStartTime { get; set; }
        public String Category { get; set; }
    }
}
