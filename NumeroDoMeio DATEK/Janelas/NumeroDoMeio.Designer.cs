using System.Windows.Forms;

namespace NumeroDoMeio.Janelas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.lblValorA = new MetroFramework.Controls.MetroLabel();
            this.lblValorB = new MetroFramework.Controls.MetroLabel();
            this.txtResposta = new System.Windows.Forms.TextBox();
            this.lblCron = new MetroFramework.Controls.MetroLabel();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.lblPlacar = new MetroFramework.Controls.MetroLabel();
            this.timerCron = new System.Windows.Forms.Timer(this.components);
            this.lblNivel = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.progressBar1 = new NumeroDoMeio.Janelas.ProgressBarEx();
            this.SuspendLayout();
            // 
            // lblValorA
            // 
            this.lblValorA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorA.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorA.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblValorA.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblValorA.ForeColor = System.Drawing.Color.Green;
            this.lblValorA.Location = new System.Drawing.Point(14, 164);
            this.lblValorA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorA.Name = "lblValorA";
            this.lblValorA.Size = new System.Drawing.Size(143, 29);
            this.lblValorA.TabIndex = 2;
            this.lblValorA.Text = "0000";
            this.lblValorA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorA.UseCustomBackColor = true;
            this.lblValorA.UseCustomForeColor = true;
            this.lblValorA.UseMemonics = false;
            // 
            // lblValorB
            // 
            this.lblValorB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorB.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblValorB.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblValorB.ForeColor = System.Drawing.Color.Green;
            this.lblValorB.Location = new System.Drawing.Point(339, 164);
            this.lblValorB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorB.Name = "lblValorB";
            this.lblValorB.Size = new System.Drawing.Size(143, 29);
            this.lblValorB.TabIndex = 3;
            this.lblValorB.Text = "0000";
            this.lblValorB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorB.UseCustomBackColor = true;
            this.lblValorB.UseCustomForeColor = true;
            this.lblValorB.UseMemonics = false;
            // 
            // txtResposta
            // 
            this.txtResposta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResposta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResposta.ForeColor = System.Drawing.Color.Gray;
            this.txtResposta.Location = new System.Drawing.Point(161, 164);
            this.txtResposta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.Size = new System.Drawing.Size(174, 29);
            this.txtResposta.TabIndex = 0;
            this.txtResposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResposta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbRespostaKeyPress);
            // 
            // lblCron
            // 
            this.lblCron.AutoSize = true;
            this.lblCron.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCron.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCron.Location = new System.Drawing.Point(427, 198);
            this.lblCron.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCron.Name = "lblCron";
            this.lblCron.Size = new System.Drawing.Size(32, 25);
            this.lblCron.TabIndex = 5;
            this.lblCron.Text = "10";
            this.lblCron.UseMemonics = false;
            this.lblCron.Click += new System.EventHandler(this.lblCron_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label1.Location = new System.Drawing.Point(217, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Acertos:";
            this.label1.UseMemonics = false;
            // 
            // lblPlacar
            // 
            this.lblPlacar.AutoSize = true;
            this.lblPlacar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPlacar.Location = new System.Drawing.Point(297, 67);
            this.lblPlacar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlacar.Name = "lblPlacar";
            this.lblPlacar.Size = new System.Drawing.Size(22, 25);
            this.lblPlacar.TabIndex = 7;
            this.lblPlacar.Text = "0";
            this.lblPlacar.UseMemonics = false;
            // 
            // timerCron
            // 
            this.timerCron.Enabled = true;
            this.timerCron.Interval = 1000;
            this.timerCron.Tick += new System.EventHandler(this.TimerCronTick);
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNivel.Location = new System.Drawing.Point(91, 67);
            this.lblNivel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(22, 25);
            this.lblNivel.TabIndex = 9;
            this.lblNivel.Text = "0";
            this.lblNivel.UseMemonics = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nivel:";
            this.label3.UseMemonics = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.label2.Location = new System.Drawing.Point(463, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "s";
            this.label2.UseMemonics = false;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(467, 57);
            this.label4.TabIndex = 10;
            this.label4.Text = "REGRAS:\r\n-DIGITE O NUMERO QUE ESTEJA EXATAMENTE NO MEIO ENTRE OS DOIS NUMEROS\r\n-P" +
    "RESSIONE A TECLA ENTER";
            this.label4.UseMemonics = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(14, 198);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(409, 25);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(497, 243);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPlacar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCron);
            this.Controls.Add(this.txtResposta);
            this.Controls.Add(this.lblValorB);
            this.Controls.Add(this.lblValorA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.Padding = new System.Windows.Forms.Padding(12, 60, 12, 11);
            this.Resizable = false;
            this.Text = "JOGO - Número do Meio";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormPrincipalLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblValorA;
        private MetroFramework.Controls.MetroLabel lblValorB;
        private TextBox txtResposta;
        private MetroFramework.Controls.MetroLabel lblCron;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel lblPlacar;
        private System.Windows.Forms.Timer timerCron;
        private MetroFramework.Controls.MetroLabel lblNivel;
        private MetroFramework.Controls.MetroLabel label3;
        private ProgressBarEx progressBar1;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label4;
    }
}

