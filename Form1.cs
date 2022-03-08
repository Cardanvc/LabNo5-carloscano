using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabNo5_resuelto
{
    public partial class Form1 : Form
    {
        List<Empleado> empl = new List<Empleado>();
        List<DatoHoras> dathora = new List<DatoHoras>();
        List<SueldoTotal> sueldoto = new List<SueldoTotal>();
        public Form1()
        {
            InitializeComponent();
        }
        void cargarEmpleado()
        {
            FileStream stream = new FileStream(@"Empleados.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Empleado empleado = new Empleado();
                empleado.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Name = reader.ReadLine();
                empleado.SueldoHora = Convert.ToDecimal(reader.ReadLine());

                empl.Add(empleado);
            }
            reader.Close();
        }
        void cargarDatoHora()
        {
            FileStream stream = new FileStream(@"Enero.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                DatoHoras datoh = new DatoHoras();
                datoh.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                datoh.HoraMes = Convert.ToInt16((reader.ReadLine()));
                datoh.Mes = reader.ReadLine();

                dathora.Add(datoh);
            }
            reader.Close();
        }
        void cargarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = empl;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = dathora;
            dataGridView2.Refresh();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            cargarEmpleado();
            cargarDatoHora();
            cargarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < empl.Count; i++)
            {
                for (int j = 0; j < dathora.Count; j++)
                {
                    if (empl[i].NoEmpleado == dathora[j].NoEmpleado)
                    {
                        SueldoTotal sueldo = new SueldoTotal();
                        sueldo.NumeroEmpleado = empl[i].NoEmpleado;
                        sueldo.nombre = empl[i].Name;
                        sueldo.sueldototal = empl[i].SueldoHora * dathora[j].HoraMes;
                        sueldo.mes = dathora[j].Mes;

                        sueldoto.Add(sueldo);
                    }

                }

            }
            dataGridView3.DataSource = sueldoto;
            dataGridView3.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }  
}
