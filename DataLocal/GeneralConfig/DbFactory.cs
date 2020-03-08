using DataLocal.Context;
using Interfaces.GeneralConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLocal.GeneralConfig
{
    public class DbFactory : IDbFactory
    {
         dbContext context;

        public dbContext init()
        {
            return context ?? (context = new dbContext());
        }
    }
}
