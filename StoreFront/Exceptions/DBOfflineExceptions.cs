using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreFront.Exceptions
{
    public class DBOfflineExceptions : Exception
    {
        public DBOfflineExceptions()
        {

        }

        public DBOfflineExceptions(string message) : base(message)
        {

        }

        public DBOfflineExceptions(string message, Exception inner) : base(message, inner)
        {

        }
    }
}