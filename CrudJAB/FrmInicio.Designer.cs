namespace CrudJAB
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOpcoes = new System.Windows.Forms.ListBox();
            this.btnOpcaoSelecionada = new System.Windows.Forms.Button();
            this.btnSairSistema = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(318, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bem vindo(a) ao Sistema de gestão de usuários!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selecione uma das opções abaixo:";
            // 
            // lbOpcoes
            // 
            this.lbOpcoes.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOpcoes.FormattingEnabled = true;
            this.lbOpcoes.ItemHeight = 28;
            this.lbOpcoes.Items.AddRange(new object[] {
            "Cadastrar novo usuário",
            "Listar todos usuários"});
            this.lbOpcoes.Location = new System.Drawing.Point(238, 194);
            this.lbOpcoes.Name = "lbOpcoes";
            this.lbOpcoes.Size = new System.Drawing.Size(352, 172);
            this.lbOpcoes.TabIndex = 3;
            this.lbOpcoes.SelectedIndexChanged += new System.EventHandler(this.lbOpcoes_SelectedIndexChanged);
            // 
            // btnOpcaoSelecionada
            // 
            this.btnOpcaoSelecionada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(69)))));
            this.btnOpcaoSelecionada.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcaoSelecionada.ForeColor = System.Drawing.Color.White;
            this.btnOpcaoSelecionada.Location = new System.Drawing.Point(238, 372);
            this.btnOpcaoSelecionada.Name = "btnOpcaoSelecionada";
            this.btnOpcaoSelecionada.Size = new System.Drawing.Size(168, 66);
            this.btnOpcaoSelecionada.TabIndex = 4;
            this.btnOpcaoSelecionada.Text = "Ir p/ opção selecionada";
            this.btnOpcaoSelecionada.UseVisualStyleBackColor = false;
            this.btnOpcaoSelecionada.Click += new System.EventHandler(this.btnOpcaoSelecionada_Click);
            // 
            // btnSairSistema
            // 
            this.btnSairSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(69)))));
            this.btnSairSistema.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairSistema.ForeColor = System.Drawing.Color.White;
            this.btnSairSistema.Location = new System.Drawing.Point(422, 372);
            this.btnSairSistema.Name = "btnSairSistema";
            this.btnSairSistema.Size = new System.Drawing.Size(168, 66);
            this.btnSairSistema.TabIndex = 5;
            this.btnSairSistema.Text = "Sair do sistema";
            this.btnSairSistema.UseVisualStyleBackColor = false;
            this.btnSairSistema.Click += new System.EventHandler(this.btnSairSistema_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSairSistema);
            this.Controls.Add(this.btnOpcaoSelecionada);
            this.Controls.Add(this.lbOpcoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Usuários";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInicio_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbOpcoes;
        private System.Windows.Forms.Button btnOpcaoSelecionada;
        private System.Windows.Forms.Button btnSairSistema;
    }
}

