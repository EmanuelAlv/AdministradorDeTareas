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
                //Aqui se llenan los datos del sistema en el data grid
                int n = dgvAdministrador.Rows.Add();
                dgvAdministrador.Rows[n].Cells[0].Value = p.ProcessName;
                dgvAdministrador.Rows[n].Cells[1].Value = p.Id;
                dgvAdministrador.Rows[n].Cells[2].Value = DarFormato((p.WorkingSet64/1024).ToString());
                dgvAdministrador.Rows[n].Cells[3].Value = DarFormato((p.VirtualMemorySize64/1024).ToString());
                dgvAdministrador.Rows[n].Cells[4].Value = p.SessionId;
            }
            txtContador.Text = "Procesos Actuales: " + dgvAdministrador.Rows.Count.ToString();
        }
        //Funcion para dar formato a los numeros que se muestran en memoria fisica y virtual
        private string DarFormato(string mb)
        {
            string mbFinal = "";
            //Numeros con un digito
            if (mb.Length <= 4)
            {
                int x = 0;
                foreach (char a in mb)
                {
                    if (x == 1)
                    {
                        mbFinal = mbFinal + "." + a;
                    }
                    else
                    {
                        if (x == (mb.Length - 1))
                        {
                            mbFinal = mbFinal + a;
                            mbFinal = mbFinal.Substring(0, mbFinal.Length - 1);
                            Console.WriteLine(mbFinal);
                            return mbFinal + " MB";
                        }
                        else
                        {
                            mbFinal = mbFinal + a;
                            
                        }

                    }
                    x++;
                }
            }
            //Numeros con dos digitos
            if (mb.Length > 4)
            {
                int x = 0;
                foreach (char a in mb)
                {
                    if (x == 2)
                    {
                        mbFinal = mbFinal + "." + a;
                    }
                    else
                    {
                        if (x == (mb.Length - 1))
                        {
                            mbFinal = mbFinal + a;
                            mbFinal = mbFinal.Substring(0, mbFinal.Length - 3);
                            //Console.WriteLine(mbFinal);
                            return mbFinal + " MB";
                        }
                        else
                        {
                            mbFinal = mbFinal + a;
                        }
                    }
                    x++;
                }
            }
            return "00.00 MB";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProceso.Text = dgvAdministrador.CurrentRow.Cells[0].Value.ToString();
        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName == txtProceso.Text)
                    {
                        p.Kill(); //Eliminamos el proceso
                    }
                }
            }
            catch (Exception x) //Catch al presionar boton detener sin seleccionar un proceso antes
            {
                MessageBox.Show("Selecciona un proceso." + x, "error al detener", MessageBoxButtons.OK);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombreProceso_Click(object sender, EventArgs e)
        {

        }
    }
}
