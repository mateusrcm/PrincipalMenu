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
    public partial class modoAvancado : Form
    {
        List<Button> botoes = new List<Button>();
        List<Machine> machinesForm;
        Button b = null;

        public modoAvancado(List<Machine> machines)
        {
            InitializeComponent();
            machinesForm = machines;
            initializeButtons();
            initializeAsyncMachines();
            buttonsNames();
        }

        private void Maquina1_Click(object sender, EventArgs e)
        {
            selectButton(Maquina1);
        }

        private void Maquina2_Click(object sender, EventArgs e)
        {
            selectButton(Maquina2);
        }

        private void Maquina3_Click(object sender, EventArgs e)
        {
            selectButton(Maquina3);
        }

        private void Maquina4_Click(object sender, EventArgs e)
        {
            selectButton(Maquina4);
        }

        private void Maquina5_Click(object sender, EventArgs e)
        {
            selectButton(Maquina5);
        }

        private void Maquina6_Click(object sender, EventArgs e)
        {
            selectButton(Maquina6);
        }

        private void Maquina7_Click(object sender, EventArgs e)
        {
            selectButton(Maquina7);
        }

        private void Maquina8_Click(object sender, EventArgs e)
        {
            selectButton(Maquina8);
        }

        private void Maquina9_Click(object sender, EventArgs e)
        {
            selectButton(Maquina9);
        }

        private void Maquina10_Click(object sender, EventArgs e)
        {
            selectButton(Maquina10);
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
                desativandoTodas();
                changeLabel();
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

        /* Métodos para ativar todas as maquinas */
        private void AtivarTodas_Click(object sender, EventArgs e)
        {
            if (ativarTodas())
            {
                MessageBox.Show("Todas as máquinas estão ativadas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                ativandoTodas();
                changeLabel();
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

        /* Método para abrir a tela do modo fácil */
        private void ModoFacil_Click(object sender, EventArgs e)
        {
            this.Hide();
            modoFacil tela = new modoFacil(machinesForm);
            ((Form)tela).Closed += (s, args) => this.Close();
            tela.Show();
        }

        /* Método para selecionar o botão */
        private void selectButton(Button botao)
        {
            for (int i = 0; i < botoes.Count; i++)
            {
                if (botoes[i] == botao)
                {
                    botoes[i].BackColor = Color.Blue;
                    Ativar.Visible = true;
                    Desativar.Visible = true;
                    b = botao;
                    botoes[i].ForeColor = Color.White;
                    myGrid.DataSource = machinesForm[botoes.IndexOf(b)].registerList;
                    myGrid.Columns["regName"].HeaderText = "Nome do registro";
                    myGrid.Columns["regCount"].HeaderText = "Quantidade disponível";
                    myGrid.Columns["regDescription"].HeaderText = "Descrição";
                    myGrid.Columns["regName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    myGrid.Columns["regCount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    myGrid.Columns["regDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    changeLabel();

                    myGrid.Columns["registrable"].Visible = false;
                    myGrid.Columns["altDisponible"].Visible = false;
                }
                else
                {
                    botoes[i].BackColor = Color.LightGray;
                    botoes[i].ForeColor = Color.Black;
                }
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
            asyncMachines t = new asyncMachines();
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
            asyncMachines.mudaData += atualizaGrid;
        }

        private void Ativar_Click(object sender, EventArgs e)
        {
            if (b != null)
            {
                machinesForm[botoes.IndexOf(b)].status = true;
                changeLabel();
            }
        }

        private void Desativar_Click(object sender, EventArgs e)
        {
            if (b != null)
            {
                machinesForm[botoes.IndexOf(b)].status = false;
                changeLabel();
            }
        }

        private void buttonsNames()
        {
            foreach (Button b in botoes)
            {
                b.Text = machinesForm[botoes.IndexOf(b)].id + " " + machinesForm[botoes.IndexOf(b)].name;
            }
        }

        public void atualizaGrid(Machine m)
        {
            myGrid.Refresh();
            changeLabel();
        }

        private void changeLabel()
        {
            if (b != null)
            {
                label1.Text = machinesForm[botoes.IndexOf(b)].status ? "Ativado" : "Desativado";
                label1.BackColor = machinesForm[botoes.IndexOf(b)].status ? Color.Green : Color.Red;
            }
        }
    }
}
