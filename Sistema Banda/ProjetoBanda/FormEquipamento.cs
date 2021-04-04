using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBanda
{
    public partial class FormEquipamento : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        public FormEquipamento()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                string selecionar;
                selecionar = "select count(*) from Equipamento where Nome ='" + txtEquip.Text + "'";
                comando = new SqlCommand(selecionar, conexao);

                int registro;
                registro = (int)comando.ExecuteScalar();
                if (registro == 1)
                {
                    MessageBox.Show("Equipamento já Cadastrado ");
                }
                else
                {
                    string inserir = "insert into Equipamento values('" + txtEquip.Text + "')";
                    SqlCommand objinserir = new SqlCommand(inserir, conexao);
                    if (objinserir.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Equipamento Cadastrado ");
                        btnLimpar.PerformClick();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar " + ex.Message);

            }
            conexao.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();
                if (txtEquip.Text != "")
                {
                    string selecionar;
                    selecionar = "select Id, Nome from Equipamento where Nome ='" + txtEquip.Text + "'";
                    comando = new SqlCommand(selecionar, conexao);
                    SqlDataReader leitor;
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        string sCod, sNome, sInstr, sTipo, sTel;


                        //sCod = leitor["CodProduto"].ToString();

                        sNome = leitor["Nome"].ToString();
                        

                        lblCod.Text = leitor["Id"].ToString();
                        txtEquip.Text = sNome;
                     
                    }
                }

                if (txtEquip.Text == "")
                {
                    string select;
                    select = "select Nome from Equipamento ";
                    comando = new SqlCommand(select, conexao);
                    SqlDataReader MyReader;

                    MyReader = comando.ExecuteReader();
                    while (MyReader.Read())
                    {

                        string sCod, sNome, sInstr, sTipo, sTel;

                        //sCod = MyReader["CodProduto"].ToString();

                        //lblCod.Text = MyReader["Id"].ToString();
                        sNome = MyReader["Nome"].ToString();
                      
                        dataGridView2.Rows.Add(sNome);


                        //listBox1.Items.Add(registro);

                    }
                }
                conexao.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Consultar " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtEquip.Text != "")
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                string delete;
                delete = "delete from Equipamento where Nome = '" + txtEquip.Text + "' and Id = '" + lblCod.Text + "'";
                SqlCommand editar = new SqlCommand(delete, conexao);
                editar.ExecuteNonQuery();
                MessageBox.Show(" excluido", "Excluir", MessageBoxButtons.OK);
                btnLimpar.PerformClick();
            }
            else
            {
                MessageBox.Show("Erro ao Excluir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEquip.Text = "";
            lblCod.Text = "";

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        if (cell.FormattedValue != String.Empty)
                            cell.Value = "";
                        dataGridView2.Rows.Clear();
                    }

                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEquip.Text != "")
                {
                    conexao = new SqlConnection();
                    conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                    conexao.Open();

                    string update;
                    update = "UPDATE Equipamento SET Nome = '" + txtEquip.Text + "' where Id = '" + lblCod.Text + "'";
                    SqlCommand editar = new SqlCommand(update, conexao);
                    editar.ExecuteNonQuery();
                    MessageBox.Show("Editado");
                    btnLimpar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Consulte Primeiro!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar " + ex.Message);

            }

            conexao.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
