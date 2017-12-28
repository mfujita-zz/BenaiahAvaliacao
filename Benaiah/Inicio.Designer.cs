namespace Benaiah
{
    partial class Inicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.MaskedTextBox();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.lblIdentificada = new System.Windows.Forms.Label();
            this.lblNomeFuncionaria = new System.Windows.Forms.Label();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Questionário de avaliação profissional";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Digite sua senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(153, 143);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(132, 30);
            this.txtSenha.TabIndex = 2;
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Location = new System.Drawing.Point(153, 194);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(132, 37);
            this.BtnConfirmar.TabIndex = 3;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // lblIdentificada
            // 
            this.lblIdentificada.AutoSize = true;
            this.lblIdentificada.Location = new System.Drawing.Point(148, 260);
            this.lblIdentificada.Name = "lblIdentificada";
            this.lblIdentificada.Size = new System.Drawing.Size(111, 25);
            this.lblIdentificada.TabIndex = 4;
            this.lblIdentificada.Text = "Identificada";
            // 
            // lblNomeFuncionaria
            // 
            this.lblNomeFuncionaria.AutoSize = true;
            this.lblNomeFuncionaria.Location = new System.Drawing.Point(148, 318);
            this.lblNomeFuncionaria.Name = "lblNomeFuncionaria";
            this.lblNomeFuncionaria.Size = new System.Drawing.Size(191, 25);
            this.lblNomeFuncionaria.TabIndex = 5;
            this.lblNomeFuncionaria.Text = "Nome da funcionária";
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.Location = new System.Drawing.Point(82, 353);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(237, 37);
            this.BtnIniciar.TabIndex = 6;
            this.BtnIniciar.Text = "Iniciar avaliação";
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 402);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.lblNomeFuncionaria);
            this.Controls.Add(this.lblIdentificada);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Inicio";
            this.Text = "Lar Evangélico Benaiah";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtSenha;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Label lblIdentificada;
        private System.Windows.Forms.Label lblNomeFuncionaria;
        private System.Windows.Forms.Button BtnIniciar;
    }
}

