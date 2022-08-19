using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministradorDeTareas
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            //Aqui inicializamos todos nuestros componentes
            InitializeComponent(); // Inicia el Form principal
            UpdateProcessList(); // Llama al metodo UpdateProcessList
           // timer1.Enabled = true;
        }

        private void UpdateProcessList()
        {
            dgvAdministrador.Rows.Clear();
            foreach(Process p in Process.GetProcesses())
            {
                int n = dgvAdministrador.Rows.Add();
                dgvAdministrador.Rows[n].Cells[0].Value = p.ProcessName;
                dgvAdministrador.Rows[n].Cells[1].Value = p.Id;
                dgvAdministrador.Rows[n].Cells[2].Value = p.WorkingSet64;
                dgvAdministrador.Rows[n].Cells[3].Value = p.VirtualMemorySize64;
                dgvAdministrador.Rows[n].Cells[4].Value = p.SessionId;
            }
            txtContador.Text = "Procesos Actuales: " + dgvAdministrador.Rows.Count.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreProceso_Click(object sender, EventArgs e)
        {

        }
    }
}
