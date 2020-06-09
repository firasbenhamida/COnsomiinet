using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Conventions
{
    class StringConvention : Convention

    {
        public StringConvention()
        {
            Properties<string>()
                .Configure(s => s.HasColumnType("varchar").HasMaxLength(25)); // not varchar2 & not varchar(30)
        }
    }
}
