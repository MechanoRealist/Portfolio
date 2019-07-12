using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorepairshop_Case
{
    interface IDatabaseObject
    {
        int Create();
        int Update();
        int Delete();
    }
}
