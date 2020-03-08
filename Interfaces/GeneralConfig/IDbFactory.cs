using DataLocal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.GeneralConfig
{
    public interface IDbFactory
    {
        dbContext init();
    }
}
