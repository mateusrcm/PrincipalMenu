using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class modoFacil : Form
    {
        List<Button> botoes = new List<Button>();
        List<Machine> machinesForm;

        public modoFacil(List<Machine> machines)
        {
            InitializeComponent();
            machinesForm = machines;
            initializeButtons();
            initializeAsyncMachines();
            carregarStatusMaquina();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            modoAvancado tela = new modoAvancado(machinesForm);
            ((Form)tela).Closed += (s, args) => this.Close();
            tela.Show();
        }

        private void Maquina1_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina1);
        }

        private void Maquina2_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina2);
        }

        private void Maquina3_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina3);
        }

        private void Maquina4_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina4);
        }

        private void Maquina5_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina5);
        }

        private void Maquina6_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina6);
        }

        private void Maquina7_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina7);
        }

        private void Maquina8_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina8);
        }

        private void Maquina9_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina9);
        }

        private void Maquina10_Click(object sender, EventArgs e)
        {
            mudaStatusMaquina(Maquina10);
        }

        /* Métodos para ativar todas as maquinas */
        private void AtivarTodas_Click(object sender, EventArgs e)
        {
            if (ativarTodas())
            {
                MessageBox.Show("Todas as máquinas estão ativadas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                foreach (Machine m in machinesForm)
                {
                    if (!m.status)
                    {
                        textBox1.Text += m.name + " está ligada" + "\r\n";
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                }
                ativandoTodas();
                mudaCorButton(Color.Green);
            }
        }

        private Boolean ativarTodas()
        {
            Boolean aux = true;
            foreach (Machine m in machinesForm)
            {
                if (m.status)
                {
                    aux = true;
                }
                else
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }

        public void ativandoTodas()
        {
            foreach (Machine m in machinesForm)
            {
                m.status = true;
            }
        }

        /* Métodos para desativar todas as maquinas */
        private void DesativarTodas_Click(object sender, EventArgs e)
        {
            if (desativarTodas())
            {
                MessageBox.Show("Todas as máquinas estão desativadas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                foreach (Machine m in machinesForm)
                {
                    if (m.status)
                    {
                        textBox1.Text += m.name + " está desligada" + "\r\n";
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                }
                desativandoTodas();
                mudaCorButton(Color.Red);
            }
        }

        private Boolean desativarTodas()
        {
            Boolean aux = true;
            foreach (Machine m in machinesForm)
            {
                if (!m.status)
                {
                    aux = true;
                }
                else
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }

        public void desativandoTodas()
        {
            foreach (Machine m in machinesForm)
            {
                m.status = false;
            }
        }

        /* Método para popular o array de botões */
        private void initializeButtons()
        {
            botoes.Add(Maquina1);
            botoes.Add(Maquina2);
            botoes.Add(Maquina3);
            botoes.Add(Maquina4);
            botoes.Add(Maquina5);
            botoes.Add(Maquina6);
            botoes.Add(Maquina7);
            botoes.Add(Maquina8);
            botoes.Add(Maquina9);
            botoes.Add(Maquina10);
        }

        private void initializeAsyncMachines()
        {
            asyncMachines.machineExec(machinesForm[0], machinesForm);
            asyncMachines.machineExec(machinesForm[1], machinesForm);
            asyncMachines.machineExec(machinesForm[2], machinesForm);
            asyncMachines.machineExec(machinesForm[3], machinesForm);
            asyncMachines.machineExec(machinesForm[4], machinesForm);
            asyncMachines.machineExec(machinesForm[5], machinesForm);
            asyncMachines.machineExec(machinesForm[6], machinesForm);
            asyncMachines.machineExec(machinesForm[7], machinesForm);
            asyncMachines.machineExec(machinesForm[8], machinesForm);
            asyncMachines.machineExec(machinesForm[9], machinesForm);
            asyncMachines.mudaData += atualizaText;
        }

        private void mudaCorButton(Color cor)
        {
            foreach (Button botao in botoes)
            {
                botao.BackColor = cor;
            }
        }

        private void mudaStatusMaquina(Button botao)
        {
            if (machinesForm[botoes.IndexOf(botao)].status)
            {
                Machine m = machinesForm[botoes.IndexOf(botao)];
                m.status = false;
                botao.BackColor = Color.Red;
                if (!m.status)
                {
                    textBox1.Text += m.name + " está desligada" + "\r\n";
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                }
            }
            else
            {
                Machine m = machinesForm[botoes.IndexOf(botao)];
                m.status = true;
                botao.BackColor = Color.Green;
                if (m.status)
                {
                    textBox1.Text += m.name + " está ligada" + "\r\n";
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                }
            }
        }

        private void carregarStatusMaquina()
        {
            foreach (Machine maqui in machinesForm)
            {
                if (maqui.status)
                {
                    botoes[machinesForm.IndexOf(maqui)].BackColor = Color.Green;
                }
                else
                {
                    botoes[machinesForm.IndexOf(maqui)].BackColor = Color.Red;
                }
            }
        }

        private void atualizaText(Machine m)
        {
            try
            {
                if (m != null)
                {
                    if (m.registerList.Find(e => e.regName == "Disponível").regCount > 0)
                    {
                        textBox1.Text += m.name + " " + m.registerList.Find(e => e.regName == "Disponível").regCount + "\r\n";
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
