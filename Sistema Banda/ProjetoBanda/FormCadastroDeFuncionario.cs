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
    public partial class FormCadastroDeFuncionario : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        public FormCadastroDeFuncionario()
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
                selecionar = "select count(*) from Funcionario where Nome ='" + txtNomeMusico.Text + "'";
                comando = new SqlCommand(selecionar, conexao);

                int registro;
                registro = (int)comando.ExecuteScalar();
                if (registro == 1)
                {
                    MessageBox.Show("Músico já Cadastrado ");
                }
                else
                {
                    string inserir = "insert into Funcionario values('" + txtNomeMusico.Text + "', '" + txtNomeInst.Text + "', '" + comboBoxTipo.Text + "', '" + txtTelefone.Text + "')";
                    SqlCommand objinserir = new SqlCommand(inserir, conexao);
                    if (objinserir.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Músico Cadastrado ");
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
                if (txtNomeMusico.Text != "")
                {
                    string selecionar;
                    selecionar = "select Id, Nome, Instrumento, Tipo, Telefone from Funcionario where Nome ='" + txtNomeMusico.Text + "'";
                    comando = new SqlCommand(selecionar, conexao);
                    SqlDataReader leitor;
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        string sCod, sNome, sInstr, sTipo, sTel;


                        //sCod = leitor["CodProduto"].ToString();

                        sNome = leitor["Nome"].ToString();
                        sInstr = leitor["Instrumento"].ToString();
                        sTipo = leitor["Tipo"].ToString();
                        sTel = leitor["Telefone"].ToString();

                        lblCod.Text = leitor["Id"].ToString();
                        txtNomeMusico.Text = sNome;
                        txtNomeInst.Text = sInstr;
                        txtTelefone.Text = sTel;
                        comboBoxTipo.Text = sTipo;
                        btnEditar.Enabled = true;
                        btnExcluir.Enabled = true;
                    }
                }

                if (txtNomeMusico.Text == "")
                {
                    string select;
                    select = "select Id, Nome, Instrumento, Tipo, Telefone from Funcionario ";
                    comando = new SqlCommand(select, conexao);
                    SqlDataReader MyReader;

                    MyReader = comando.ExecuteReader();
                    while (MyReader.Read())
                    {

                        string sCod, sNome, sInstr, sTipo, sTel;

                        //sCod = MyReader["CodProduto"].ToString();

                        //lblCod.Text = MyReader["Id"].ToString();
                        sNome = MyReader["Nome"].ToString();
                        sInstr = MyReader["Instrumento"].ToString();
                        sTipo = MyReader["Tipo"].ToString();
                        sTel = MyReader["Telefone"].ToString();
                        dataGridView1.Rows.Add(sNome, sInstr, sTipo, sTel);


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
            if (txtNomeMusico.Text != "")
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();

                string delete;
                delete = "delete from Funcionario where Nome = '" + txtNomeMusico.Text + "' and Id = '" + lblCod.Text + "'";
                SqlCommand editar = new SqlCommand(delete, conexao);
                editar.ExecuteNonQuery();
                MessageBox.Show("Músico excluido", "Excluir", MessageBoxButtons.OK);
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
            lblCod.Text = "";
            txtNomeMusico.Text = "";
            txtNomeInst.Text = "";
            comboBoxTipo.Text = "";
            txtTelefone.Text = "";
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeMusico.Text != "")
                {
                    conexao = new SqlConnection();
                    conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                    conexao.Open();

                    string update;
                    update = "UPDATE Funcionario SET Nome = '" + txtNomeMusico.Text + "',Instrumento = '" + txtNomeInst.Text + "', Tipo = '" + comboBoxTipo.Text + "', Telefone= '" + txtTelefone.Text + "'  where Id = '" + lblCod.Text + "'";
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
            this.Close();
        }
    }
}
