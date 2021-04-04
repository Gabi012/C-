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
    public partial class FormEventos : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        public FormEventos()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                string selecionar;
                selecionar = "select count(*) from Evento where Nome ='" + txtNome.Text + "'";
                comando = new SqlCommand(selecionar, conexao);

                int registro;
                registro = (int)comando.ExecuteScalar();
                if (registro == 1)
                {
                    MessageBox.Show("Já Cadastrado ");
                }
                else
                {
                    string inserir = "insert into Evento values('" + txtNome.Text + "', '" + txtLocal.Text + "', '" + txtData.Text + "')";
                    SqlCommand objinserir = new SqlCommand(inserir, conexao);
                    if (objinserir.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cadastrado ");
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

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();
                if (txtNome.Text != "")
                {
                    string selecionar;
                    selecionar = "select Id, Nome, Local, Data from Evento where Nome ='" + txtNome.Text + "'";
                    comando = new SqlCommand(selecionar, conexao);
                    SqlDataReader leitor;
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        string   sNome, sLocal, sData;


                        //sCod = leitor["CodProduto"].ToString();
                        lblCod.Text = leitor["Id"].ToString();
                        sNome = leitor["Nome"].ToString();
                        sLocal = leitor["Local"].ToString();
                        sData = leitor["Data"].ToString();
                        
                        txtNome.Text = sNome;
                        txtLocal.Text = sLocal;
                        txtData.Text = sData;

                    }
                }

                if (txtNome.Text == "")
                {
                    string select;
                    select = "select Nome, Local, Data from Evento ";
                    comando = new SqlCommand(select, conexao);
                    SqlDataReader MyReader;

                    MyReader = comando.ExecuteReader();
                    while (MyReader.Read())
                    {

                        string sCod, sNome, sLocal, sData;

                        //sCod = MyReader["CodProduto"].ToString();

                        //lblCod.Text = MyReader["Id"].ToString();

                        sNome = MyReader["Nome"].ToString();
                        sLocal = MyReader["Local"].ToString();
                        sData = MyReader["Data"].ToString();
                        //lblCod.Text = MyReader["Id"].ToString();
                        dataGridView1.Rows.Add(sNome, sLocal, sData);


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
            if (txtNome.Text != "" && lblCod.Text !="Id")
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                string delete;
                delete = "delete from Evento where Nome = '" + txtNome.Text + "' and Id = '" + lblCod.Text + "'";
                SqlCommand editar = new SqlCommand(delete, conexao);
                editar.ExecuteNonQuery();
                MessageBox.Show("Excluido", "Excluir", MessageBoxButtons.OK);
                btnLimpar.PerformClick();
            }
            else
            {
                MessageBox.Show("Erro ao Excluir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text != "" && lblCod.Text != "Id")
                {
                    conexao = new SqlConnection();
                    conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                    conexao.Open();

                    string update;
                    update = "UPDATE Evento SET Nome = '" + txtNome.Text + "', Local = '" + txtLocal.Text + "', Data = '" + txtData.Text + "' where Id = '" + lblCod.Text + "'";
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtLocal.Text="";
            txtData.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        if (cell.FormattedValue != String.Empty)
                            cell.Value = "";
                        dataGridView1.Rows.Clear();
                    }

                }
            }
        }
    }
}
