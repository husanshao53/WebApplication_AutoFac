using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Demo1.DAL
{
    public class OracleDAL : IDAL
    {
        public string Insert(string commandText)
        {
            return commandText+"-------use oracle...";
        }
    }
}
