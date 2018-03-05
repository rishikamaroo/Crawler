namespace Crawler
{
    using System;
    public class DB
    {

        public DBConnector conn = null;

        private Logger logger;

        public DB()
        {
            this.logger = new Logger();
            conn = new DBConnector(); 
            conn.getConnection();
        }

        public void runSql(String sql)
        {
            try
            {
                //Execute sql query
            }
            catch (Exception e)
            {
                this.logger.LogException("Exception while executing sql query", e);
            }
            finally
            {
                finalize();
            }
        }

        protected void finalize()
        {
            conn.CloseConnection();
        }
    }
}
