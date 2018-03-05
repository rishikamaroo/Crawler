using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class DBConnector
    {
        private Logger logger;

        public DBConnector()
        {
            this.logger = new Logger();
        }

        public DBConnector getConnection()
        {
            try
            {
                // Use config settings to create a connection & return for use
                return new DBConnector();
            }
            catch (Exception e)
            {
                logger.LogException("Exception while trying to connect to database ", e);
                return null;
            }
        }

        public void CloseConnection()
        {
            // Close connection
        }
    }
}
