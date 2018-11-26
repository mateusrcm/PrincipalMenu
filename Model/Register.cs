using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    public class Register
    {
        /* Common variable used in all Registers (Name, Number of registers, Description of this register) */
        public string regName { get; set; }
        public double regCount { get; set; }
        public string regDescription { get; set; }

        /* Says that this register can be changed by the machine */
        public bool registrable { get; set; }

        /* Says if this register can change the disponible field */
        public bool altDisponible { get; set; }

        /* Says wheter this have to be send to trash */
        bool trash { get; set; }

        /* Object builder */
        public Register(string n, double cnt, string desc, bool trash, bool registravel, bool alt)
        {
            this.regName = n;
            this.regCount = cnt;
            this.regDescription = desc;
            this.trash = trash;
            this.registrable = registravel;
            this.altDisponible = alt;
        }
        public Register()
        {
        }
    }
}
