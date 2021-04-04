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
    public partial class FormLogin : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }
        public FormLogin()
        {
            InitializeComponent();
        }

        //desabilitando o botao (x) do form
        //CS_NOCLOSE disabilita (x) 
        private const int CS_NOCLOSE = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams mdiCp = base.CreateParams;
                mdiCp.ClassStyle = mdiCp.ClassStyle | CS_NOCLOSE;
                return mdiCp;
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ProjetoBanda.Properties.Settings.Default.stringConexao;
                conexao.Open();


                string selecionar;
                selecionar = "select count(*) from Usuario where Login ='" + txtLogin.Text + "' ";
                comando = new SqlCommand(selecionar, conexao);

                int registro;
                registro = (int)comando.ExecuteScalar();
                if (registro == 1)
                {
                    MessageBox.Show("Bem Vindo: " + txtLogin.Text);
                    txtLogin.Clear();
                    txtSenha.Clear();

                    this.Close();

                    _login = txtLogin.Text;
                    //FormPrincipal formprincipal = new FormPrincipal();
                    //formprincipal.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Erro ao Logar");
                }


                conexao.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na Conexão" + ex.Message);

            }


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
