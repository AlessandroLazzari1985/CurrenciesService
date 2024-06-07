using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSempione.Infrastructure.Logging
{
    internal class SerilogDatabaseConfiguration
    {
        public string ConnectionString { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
    }
}
