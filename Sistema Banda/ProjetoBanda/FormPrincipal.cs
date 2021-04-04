using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBanda
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.ShowDialog();
            /*if (login.Login != "adm")
            {
                //btnProdutos.Enabled = false;
                //btnUsuarios.Enabled = false;

            }
            else
            {
                //btnProdutos.Enabled = true;
                //btnUsuarios.Enabled = true;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCadastroDeFuncionario formCadastroFunc = new FormCadastroDeFuncionario();
            formCadastroFunc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCadastroDeUsuario formCadastroUsuario = new FormCadastroDeUsuario();
            formCadastroUsuario.ShowDialog();
        }

       

        private void btnCadastroEquipamento_Click(object sender, EventArgs e)
        {

            FormEquipamento formCadastroEquip = new FormEquipamento();
            formCadastroEquip.ShowDialog();
        }   
private void btnRelatorios_Click(object sender, EventArgs e)
        {
            //FormRelatorio formRelatorio = new FormRelatorio();
            //formRelatorio.ShowDialog();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
    }

