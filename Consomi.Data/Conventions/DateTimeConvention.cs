using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Conventions
{
    class DateTimeConvention : Convention
    {
        public DateTimeConvention()
        {
            Properties<DateTime>()
                .Configure(d => d.HasColumnType("datetime2"));
        }
    }
}
