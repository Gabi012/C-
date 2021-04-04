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
    public partial class FormCadastroDeUsuario : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        public FormCadastroDeUsuario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
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
                if (txtLoginCadastro.Text != "")
                {
                    string selecionar;
                    selecionar = "select Login, Senha from Usuario where Login ='" + txtLoginCadastro.Text + "'";
                    comando = new SqlCommand(selecionar, conexao);
                    SqlDataReader leitor;
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        string sLog, sSen;

                        sLog = leitor["Login"].ToString();
                        sSen = leitor["Senha"].ToString();
                        txtLoginCadastro.Text = sLog;
                        txtLoginSenha.Text = sSen;
                        btnEditar.Enabled = true;
                        btnExcluir.Enabled = true;
                    }
                }

                if (txtLoginCadastro.Text == "")
                {
                    string select;
                    select = "select Login, Senha from Usuario";

                    comando = new SqlCommand(select, conexao);
                    SqlDataReader MyReader;

                    MyReader = comando.ExecuteReader();
                    while (MyReader.Read())
                    {

                        string sLog, sSen;

                        sLog = MyReader["Login"].ToString();
                        sSen = MyReader["Senha"].ToString();

                        dataGridView1.Rows.Add(sLog, sSen);


                    }
                }
                btnConsultar.Enabled = false;
                conexao.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Consultar " + ex.Message);
            }

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                /*
                    string inserir = "insert into Usuario values('" + txtLoginCadastro.Text + "','" + txtLoginSenha.Text + "' )";
                    SqlCommand objinserir = new SqlCommand(inserir, objconexao);
                    objinserir.ExecuteNonQuery();
                    MessageBox.Show("Usuário Cadastrado");
                    */
                string selecionar;
                selecionar = "select count(*) from Usuario where Login = '" + txtLoginCadastro.Text + "'";
                comando = new SqlCommand(selecionar, conexao);

                int registro;
                registro = (int)comando.ExecuteScalar();
                if (registro == 1)
                {
                    MessageBox.Show("Usuário já Cadastrado", "Cadastro", MessageBoxButtons.OK);
                }
                else
                {
                    string inserir = "insert into Usuario values('" + txtLoginCadastro.Text + "', '" + txtLoginSenha.Text + "')";
                    SqlCommand objinserir = new SqlCommand(inserir, conexao);
                    if (objinserir.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Usuário Cadastrado ");
                        btnLimpar.PerformClick();
                    }
                }
                conexao.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar " + ex.Message);

            }
        
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (txtLoginCadastro.Text != "" || txtLoginSenha.Text != "")
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                string delete;
                delete = "delete from Usuario where Login = '" + txtLoginCadastro.Text + "' and Senha = '" + txtLoginSenha.Text + "'";
                SqlCommand editar = new SqlCommand(delete, conexao);
                editar.ExecuteNonQuery();
                MessageBox.Show("Usuário Excluido", "Excluir", MessageBoxButtons.OK);
                btnLimpar.PerformClick();
            }

            else
            {
                MessageBox.Show("Erro ao Excluir", "Excluir", MessageBoxButtons.OK);
            }
            conexao.Close();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtLoginCadastro.Text != "")
                {
                    conexao = new SqlConnection();
                    conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                    conexao.Open();

                    string updatelogin;
                    string updatesenha;

                    if (radioButtonEditarSenha.Checked)
                    {
                        updatesenha = "UPDATE Usuario SET Senha = '" + txtLoginSenha.Text + "' where Login = '" + txtLoginCadastro.Text + "'";
                        SqlCommand editar = new SqlCommand(updatesenha, conexao);
                        editar.ExecuteNonQuery();


                        /*if (radioButtonEditarLogin.Checked)
                        {
                            updatelogin = "UPDATE Usuario SET Login = '" + txtLoginCadastro.Text + "' where Senha = '" + txtLoginSenha.Text + "'";

                            SqlCommand editarlogin = new SqlCommand(updatelogin, conexao);
                            editarlogin.ExecuteNonQuery();
                        }
                        else
                        {
                            if (radioButtonEditarSenha.Checked)
                            {
                                updatesenha = "UPDATE Usuario SET Senha = '" + txtLoginSenha.Text + "' where Login = '" + txtLoginCadastro.Text + "'";
                                SqlCommand editar = new SqlCommand(updatesenha, conexao);
                                editar.ExecuteNonQuery();
                            }

                        }
                        */

                        conexao.Close();

                        MessageBox.Show("Editado");
                        btnLimpar.PerformClick();


                    }
                    else
                    {
                        MessageBox.Show("Consulte o Usuario Primeiro");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar " + ex.Message);

            }


        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            btnConsultar.Enabled = true;
            txtLoginCadastro.Text = "";
            txtLoginSenha.Text = "";
            //loop pelo datagrid
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
