using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchanCountriesWorker.Domain
{
    public class MongoSettings
    {

        public string Connection { get; set; }
        public string DatabaseName { get; set; }

        public MongoSettings(string connection, string databaseName)
        {
            Connection = connection;
            DatabaseName = databaseName;
        }
    }
}