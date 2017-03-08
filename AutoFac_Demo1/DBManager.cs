using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Demo1
{

    
    public class DBManager
    {
        IDAL _dal;
        public DBManager(IDAL dal)
        {
            _dal = dal;
        }
        public string Insert(string commandText)
        {
            return _dal.Insert(commandText);
        }
    }
}
