using System;
using System.Collections.Generic;

namespace Monitor
{
    public class Machine
    {
        /* Common variables used in all machine */
        public int id { get; set; }
        public string name { get; set; }

        /* This variable is used to simulate the production time of a machine,
        not the real time but proportional to the other machines */
        int minTimeProduction { get; set; }
        int maxTimeProduction { get; set; }

        /* Machine status on/off */
        public bool status { get; set; }

        /* List that contains all the machine registers */
        public List<Register> registerList { get; set; }

        /* Object builder */
        public Machine(int id, string n, int minT, int maxT, bool stts, List<Register> lst)
        {
            this.id = id;
            this.name = n;
            this.minTimeProduction = minT;
            this.maxTimeProduction = maxT;
            this.status = stts;
            this.registerList = lst;
        }

        /* Empty Object Builder */
        public Machine()
        {
        }

        /* Productive proccess os this machine, simulating a time of prodution */
        public void productionProcess(List<Machine> lsM)
        {
            int count = 0;
            
            /* Count the registers that the machine can change directly */
            foreach (Register r in registerList)
            {
                if (r.registrable)
                {
                    count++;
                }
            }

            /* Random var */
            Random rnd = new Random();

            /* Choose the register that this proccess will change if theres more than one */
            Register reg = registerList[rnd.Next(0, count--)];

            try
            {
                /*  */
                if (id > 1)
                {
                    Register regA = lsM.Find(e => e.id == id--).registerList.Find(e => e.regName == "Disponível");

                    if (regA.regCount > 0)
                    {
                        reg.regCount++;

                        /* If this register that was changed can change the disponible field, than change */
                        if (reg.altDisponible)
                        {
                            registerList.Find(e => e.regName == "Disponível").regCount++;
                        }
                    }
                }
                else
                {
                    reg.regCount++;

                    /* If this register that was changed can change the disponible field, than change */
                    if (reg.altDisponible)
                    {
                        registerList.Find(e => e.regName == "Disponível").regCount++;
                    }
                }
            }
            catch
            {

            }

            /* Simulates the proccess time */
            System.Threading.Thread.Sleep(rnd.Next(minTimeProduction, maxTimeProduction));
        }
    }
}
