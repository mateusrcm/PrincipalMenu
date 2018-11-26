using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  All machines list
            List<Machine> machines = new List<Machine>();

            // Registers list empty, used to create the machines
            List<Register> registers = null;
            InitializeData(machines, registers);
            Application.Run(new modoFacil(machines));
        }

        //Create all the default machines in system
        private static void InitializeData(List<Machine> machines, List<Register> registers)
        {
            MachineSelecaoGrao(machines, registers);
            MachineMoagem(machines, registers);
            MachineBrassagem(machines, registers);
            MachineClarificacao(machines, registers);
            MachineFervura(machines, registers);
            MachineResfriamento(machines, registers);
            MachineFermentacao(machines, registers);
            MachineEnvase(machines, registers);
            MachineRotulagem(machines, registers);
            MachineLixo(machines, registers);
        }

        // Create selection machine and insert it to the machine list
        private static void MachineSelecaoGrao(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            //Create this machine registers
            Register comum = new Register("Comum", 0, "Grãos selecionados sem nenhum tipo de tostagem, todos em sua forma mais pura", false, true, true);
            Register levementeTostado = new Register("Levemente tostado", 0, "Grãos selecionados levemente tostados com um sabor mais amargo que o normal", false, true, true);
            Register tostado = new Register("Tostado", 0, "Grãos selecionados tostados, sabor amargo que pode lembrar o café", false, true, true);
            Register defeituoso = new Register("Defeituoso", 0, "Grãos que não poderam ser utilizados em processo algum pela baixa qualidade", true, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the register into a list
            registers.Add(comum);
            registers.Add(levementeTostado);
            registers.Add(tostado);
            registers.Add(defeituoso);
            registers.Add(disponivel);

            // Create the correponding machine and insert it to the machines list
            Machine m = new Machine(1, "Seletora de Grãos", 0, 100, false, registers);
            machines.Add(m);
        }

        // Create milling machine and insert it to the machine list
        private static void MachineMoagem(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            //Create this machine registers
            Register moagemFina = new Register("Moagem Fina", 0, "Moagem fina demais e consequentemente causará problemas nos processos seguintes", true, true, false);
            Register moagemIdeal = new Register("Moagem Ideal", 0, "Moagem ideal, o grão está perfeito para os próximos processos", false, true, true);
            Register moagemGrossa = new Register("Moagem Grossa", 0, "Moagem grossa, causará possíveis problemas no futuro, devem retornar para moagem", false, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(moagemFina);
            registers.Add(moagemIdeal);
            registers.Add(moagemGrossa);
            registers.Add(disponivel);

            // Create the correponding machine and insert it to the machines list
            Machine m = new Machine(2, "Moedora", 50, 200, false, registers);
            machines.Add(m);
        }

        // Create maching machine and insert it to the machine list
        private static void MachineBrassagem(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            //Create this machine registers
            Register correto = new Register("Correto", 0, "Processo de brassagem foi realizado da forma como deveria", false, true, true);
            Register incorreto = new Register("Incorreto", 0, "Processo de brassagem foi realizado de forma incorreta, enviar para o lixo", true, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(correto);
            registers.Add(incorreto);
            registers.Add(disponivel);

            // Create the correponding machine and insert it to the machines list
            Machine m = new Machine(3, "Brassadora", 250, 250, false, registers);
            machines.Add(m);
        }

        // Create clarification machine and insert it to the machine list
        private static void MachineClarificacao(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            //Create this machine registers
            Register suficiente = new Register("Suficiente", 0, "Processo de clarificação, limpou o suficiente para o próximo passo", false, true, true);
            Register insuficiente = new Register("Insuficiente", 0, "Processo de clarificação não limpou a bebida o suficiente, necessário refazer", false, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(suficiente);
            registers.Add(insuficiente);
            registers.Add(disponivel);

            // Create the correponding machine and insert it to the machines list
            Machine m = new Machine(4, "Clarificadora", 400, 600, false, registers);
            machines.Add(m);
        }

        // Create boil machine and insert it to the machine list
        private static void MachineFervura(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            //Create this machine registers
            Register insuficiente = new Register("Insuficiente", 0, "Processo de fervura insuficiente, necessário refazer", false, true, false);
            Register ideal = new Register("Ideal", 0, "Processo de fervura ideal, a fervura foi realizada com perfeição preparada para seguir ao passo seguinte", false, true, true);
            Register excessivo = new Register("Excessivo", 0, "Processo de fervura excessivo, necessário eliminar resíduos", true, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(insuficiente);
            registers.Add(ideal);
            registers.Add(excessivo);
            registers.Add(disponivel);

            // Create the correponding machine and insert it to the machines list
            Machine m = new Machine(5, "Panela", 100, 200, false, registers);
            machines.Add(m);
        }

        // Create fridge machine and insert it to the machine list
        private static void MachineResfriamento(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            // Create this machine registers
            Register suficiente = new Register("Suficiente", 0, "Resfriamento adequado de forma a deixar a cerveja no ponto ideal para fermentação", false, true, true);
            Register insuficiente = new Register("Insuficiente", 0, "Resfriamento insuficiente necessário continuar o processo", false, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(suficiente);
            registers.Add(insuficiente);
            registers.Add(disponivel);

            // Create the corresponding machine and insert it to the machines list
            Machine m = new Machine(6, "Refrigerador", 300, 400, false, registers);
            machines.Add(m);
        }

        // Create fermentation machine and insert it to the machines list
        private static void MachineFermentacao(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            // Create this machine registers
            Register suficiente = new Register("Suficiente", 0, "Fermentação ideal para uma cerveja saborosa e encorpada", false, true, true);
            Register insuficiente = new Register("Insuficiente", 0, "Fermentação insuficiente, necessário continuar o processo para atingir o padrão de qualidade", false, true, false);
            Register errado = new Register("Errado", 0, "Fermentação errada, produto contaminado de alguma forma, eliminar", true, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(suficiente);
            registers.Add(insuficiente);
            registers.Add(errado);
            registers.Add(disponivel);

            // Create the corresponding machine and insert it to the machines list
            Machine m = new Machine(7, "Fermentadora", 700, 1000, false, registers);
            machines.Add(m);
        }

        // Create packaging machine and insert it to the machine list
        private static void MachineEnvase(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            // Create this machine registers
            Register correto = new Register("Correto", 0, "Envase feito de forma correta, pronto para próxima etapa", false, true, true);
            Register incorreto = new Register("Incorreto", 0, "Envase incorreto, refazer", false, true, false);
            Register disponivel = new Register("Disponível", 0, "Em estoque aguardando processamento posterior", false, false, false);

            // Insert the registers into a list
            registers.Add(correto);
            registers.Add(incorreto);
            registers.Add(disponivel);

            // Create the corresponding machine and insert it to the list
            Machine m = new Machine(8, "Embaladora", 50, 100, false, registers);
            machines.Add(m);
        }


        private static void MachineRotulagem(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            // Create this machine registers
            Register correto = new Register("Correto", 0, "Rótulo colocado da melhor forma possível, pronto para venda", false, true, true);
            Register incorreto = new Register("Incorreto", 0, "Rótulo colocado de forma incorreto, recolocar", false, true, false);
            Register disponivel = new Register("Disponível", 0, "Pronto para venda", false, false, false);

            // Insert the registers into a list
            registers.Add(correto);
            registers.Add(incorreto);
            registers.Add(disponivel);

            // Create the corresponding machine and insert it to the list
            Machine m = new Machine(9, "Rotuladora", 20, 50, false, registers);
            machines.Add(m);
        }

        // Create the trash machine and insert it to the machines list
        private static void MachineLixo(List<Machine> machines, List<Register> registers)
        {
            registers = new List<Register>();

            // Create this machine registers
            Register eliminado = new Register("Eliminado", 0, "Residuos eliminados pelo sistema", false, true, false);

            // Insert the registers into a list
            registers.Add(eliminado);

            // Create the corresponding machine and insert it to the machines list
            Machine m = new Machine(10, "Lixeira", 10, 100, false, registers);
            machines.Add(m);
        }
    }
}
