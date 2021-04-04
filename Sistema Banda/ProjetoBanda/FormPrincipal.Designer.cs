namespace ProjetoBanda
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadastroFunc = new System.Windows.Forms.Button();
            this.btnCadastroUsuario = new System.Windows.Forms.Button();
            this.btnCadastroEquipamento = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastroFunc
            // 
            this.btnCadastroFunc.Location = new System.Drawing.Point(59, 143);
            this.btnCadastroFunc.Name = "btnCadastroFunc";
            this.btnCadastroFunc.Size = new System.Drawing.Size(193, 23);
            this.btnCadastroFunc.TabIndex = 0;
            this.btnCadastroFunc.Text = "Cadastro de Funcionários";
            this.btnCadastroFunc.UseVisualStyleBackColor = true;
            this.btnCadastroFunc.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCadastroUsuario
            // 
            this.btnCadastroUsuario.Location = new System.Drawing.Point(59, 196);
            this.btnCadastroUsuario.Name = "btnCadastroUsuario";
            this.btnCadastroUsuario.Size = new System.Drawing.Size(193, 23);
            this.btnCadastroUsuario.TabIndex = 1;
            this.btnCadastroUsuario.Text = "Cadastro de Usuários";
            this.btnCadastroUsuario.UseVisualStyleBackColor = true;
            this.btnCadastroUsuario.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCadastroEquipamento
            // 
            this.btnCadastroEquipamento.Location = new System.Drawing.Point(59, 259);
            this.btnCadastroEquipamento.Name = "btnCadastroEquipamento";
            this.btnCadastroEquipamento.Size = new System.Drawing.Size(193, 23);
            this.btnCadastroEquipamento.TabIndex = 3;
            this.btnCadastroEquipamento.Text = "Cadastro de Equipamentos";
            this.btnCadastroEquipamento.UseVisualStyleBackColor = true;
            this.btnCadastroEquipamento.Click += new System.EventHandler(this.btnCadastroEquipamento_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Firebrick;
            this.groupBox1.Controls.Add(this.btnSair);
            this.groupBox1.Controls.Add(this.btnCadastroFunc);
            this.groupBox1.Controls.Add(this.btnCadastroEquipamento);
            this.groupBox1.Controls.Add(this.btnCadastroUsuario);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 605);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoBanda.Properties.Resources.icone;
            this.pictureBox1.Location = new System.Drawing.Point(502, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(575, 473);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(59, 320);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(193, 25);
            this.btnSair.TabIndex = 46;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(1230, 607);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPrincipal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastroFunc;
        private System.Windows.Forms.Button btnCadastroUsuario;
        private System.Windows.Forms.Button btnCadastroEquipamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
    }
}