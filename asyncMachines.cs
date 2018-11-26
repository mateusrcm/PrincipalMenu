using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class asyncMachines
    {
        public static async void machineExec(Machine m, List<Machine> lsm)
        {
            while (true)
            {
                await Task.Delay(10000);
                if (m.status)
                {
                    m.productionProcess(lsm);
                    mudaData(m);
                }
            }
        }

        public static ChangeDataDelegate mudaData;
    }
}
