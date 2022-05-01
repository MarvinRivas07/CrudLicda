using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaNegocio;
using System.Windows.Forms;
namespace CapaPresentacionn
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }
        private void LeerProds()

        {
            CN_Productos objetoCN = new CN_Productos();
            dataGridView1.DataSource = objetoCN.LeerProd();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            {
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrecio.Text, txtExis.Text, txtEsta.Text);
                        MessageBox.Show("Mensaje");
                        LimpiarForm();
                        LeerProds();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mensaje ", ex.Message);
                    }

                }
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrecio.Text, txtExis.Text, txtEsta.Text, idProducto);
                        MessageBox.Show("Se editó correctamente");
                        LimpiarForm();
                        LeerProds();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar por " + ex);
                    }
                }
            }
        }
        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrecio.Clear();
            txtExis.Clear();
            txtProd.Clear();
            txtEsta.Clear();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                objetoCN.EliProd(idProducto);
                MessageBox.Show("Eliminado correctamente ");
                LeerProds();
            }
            else
                MessageBox.Show("Seleccione una fila por favor ");
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            }
            else
                MessageBox.Show("Favor seleccionar una fila");
            
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}