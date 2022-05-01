
using CapaNegocio;



namespace CapaPresentacion
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
        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtProd.Clear();
            txtEsta.Clear();
        }
        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                    MessageBox.Show("Registro insertado exitosamente");
                    LeerProds();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registro actualizado exitosamente");
                }
            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, idProducto);
                    MessageBox.Show("Registro actualizado exitosamente ");
                    LeerProds();
                    LimpiarForm();
                    Editar = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registro no pudo ser actualizado, el motivo es :" + ex);
                }   
            }   
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
             if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            }
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
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LeerProds();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
           
            
                try
                {
                objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                    MessageBox.Show("Registro insertado exitosamente");
                    LeerProds();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registro actualizado exitosamente");
                }
            
            
        }
    }
}