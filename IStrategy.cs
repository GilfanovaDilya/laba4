using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public interface IStrategy
    {
        int[] Algorithm(int[] arrayForSort, bool flag = true);
    }
}
