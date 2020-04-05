using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Gauss_Jordam
{
    public partial class frmPrincipal : MetroForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCalculaClick(object sender, EventArgs e)
        {
            txt_X_1.Text = (txt_X_1.Text == string.Empty) ? "0" : txt_X_1.Text;
            txt_Y_1.Text = (txt_Y_1.Text == string.Empty) ? "0" : txt_Y_1.Text;
            txt_Z_1.Text = (txt_Z_1.Text == string.Empty) ? "0" : txt_Z_1.Text;
            txt_R_1.Text = (txt_R_1.Text == string.Empty) ? "0" : txt_R_1.Text;
            txt_X_2.Text = (txt_X_2.Text == string.Empty) ? "0" : txt_X_2.Text;
            txt_Y_2.Text = (txt_Y_2.Text == string.Empty) ? "0" : txt_Y_2.Text;
            txt_Z_2.Text = (txt_Z_2.Text == string.Empty) ? "0" : txt_Z_2.Text;
            txt_R_2.Text = (txt_R_2.Text == string.Empty) ? "0" : txt_R_2.Text;
            txt_X_3.Text = (txt_X_3.Text == string.Empty) ? "0" : txt_X_3.Text;
            txt_Y_3.Text = (txt_Y_3.Text == string.Empty) ? "0" : txt_Y_3.Text;
            txt_Z_3.Text = (txt_Z_3.Text == string.Empty) ? "0" : txt_Z_3.Text;
            txt_R_3.Text = (txt_R_3.Text == string.Empty) ? "0" : txt_R_3.Text;
            double[,] valor =
            {
                {
                    double.Parse(txt_X_1.Text), double.Parse(txt_Y_1.Text),
                    double.Parse(txt_Z_1.Text), double.Parse(txt_R_1.Text)
                },
                {
                    double.Parse(txt_X_2.Text), double.Parse(txt_Y_2.Text),
                    double.Parse(txt_Z_2.Text), double.Parse(txt_R_2.Text)
                },
                {
                    double.Parse(txt_X_3.Text), double.Parse(txt_Y_3.Text),
                    double.Parse(txt_Z_3.Text), double.Parse(txt_R_3.Text)
                }
            };
            CalcularGaussJordan(ref valor);
            //label5.Text = valor[0, 0].ToString("0.000");
            //label16.Text = valor[0, 1].ToString("0.000");
            //label17.Text = valor[0, 2].ToString("0.000");
            lblResultadoX.Text = valor[0, 3].ToString("0.000");
            //label19.Text = valor[1, 0].ToString("0.000");
            //label20.Text = valor[1, 1].ToString("0.000");
            //label21.Text = valor[1, 2].ToString("0.000");
            lblResultadoY.Text = valor[1, 3].ToString("0.000");
            //label23.Text = valor[2, 0].ToString("0.000");
            //label24.Text = valor[2, 1].ToString("0.000");
            //label25.Text = valor[2, 2].ToString("0.000");
            lblResultadoZ.Text = valor[2, 3].ToString("0.000");
        }

        private void CalcularGaussJordan(ref double[,] valor)
        {
            lock (txtHistoricoResultado)
            {
                txtHistoricoResultado.AppendText("Matriz Original:\r\n");
                PrintMatriz(ref valor);

                if (Math.Abs(valor[0, 0] - 0) <= 0)
                {
                    if (Math.Abs(valor[1, 0] - 0.0) > 0)
                    {
                        double temp = valor[0, 0];
                        valor[0, 0] = valor[1, 0];
                        valor[1, 0] = temp;
                        temp = valor[0, 1];
                        valor[0, 1] = valor[1, 1];
                        valor[1, 1] = temp;
                        temp = valor[0, 2];
                        valor[0, 2] = valor[1, 2];
                        valor[1, 2] = temp;
                        temp = valor[0, 3];
                        valor[0, 3] = valor[1, 3];
                        valor[1, 3] = temp;
                        txtHistoricoResultado.AppendText("Matriz Original Reorganizada: trocando 1° linha pela 2°\r\n");
                        PrintMatriz(ref valor);

                    }
                    else if (Math.Abs(valor[2, 0] - 0.0) > 0)
                    {
                        double temp = valor[0, 0];
                        valor[0, 0] = valor[2, 0];
                        valor[2, 0] = temp;
                        temp = valor[0, 1];
                        valor[0, 1] = valor[2, 1];
                        valor[2, 1] = temp;
                        temp = valor[0, 2];
                        valor[0, 2] = valor[2, 2];
                        valor[2, 2] = temp;
                        temp = valor[0, 3];
                        valor[0, 3] = valor[2, 3];
                        valor[2, 3] = temp;
                        txtHistoricoResultado.AppendText("Matriz Original Reorganizada: trocando 1° linha pela 3°\r\n");
                        PrintMatriz(ref valor);
                    }
                    else
                    {
                        MessageBox.Show(
                            @"Não é possivel calcular, pelo menos um das variaveis X dever ser diferente de 0!", @"Erro",
                            MessageBoxButtons.OK);
                        return;
                    }
                }
                txtHistoricoResultado.AppendText("Cancelando X da 2° e 3° Linha:\r\n");
                if (Math.Abs(valor[0, 0] - 1.0) > 0)
                {
                    double value = valor[0, 0];
                    valor[0, 0] /= value;
                    valor[0, 1] /= value;
                    valor[0, 2] /= value;
                    valor[0, 3] /= value;
                    txtHistoricoResultado.AppendText("1° Linha dividida por: " + value.ToString("0.000") + "\r\n");
                    PrintMatriz(ref valor);
                }
                // Zera Valor de X para 2 linha
                double value2 = valor[1, 0] * -1;
                valor[1, 0] = valor[0, 0] * value2 + valor[1, 0];
                valor[1, 1] = valor[0, 1] * value2 + valor[1, 1];
                valor[1, 2] = valor[0, 2] * value2 + valor[1, 2];
                valor[1, 3] = valor[0, 3] * value2 + valor[1, 3];
                txtHistoricoResultado.AppendText("1° Linha multiplicada por: " + value2.ToString("0.000") +
                                                 " e somada com a 2° linha\r\n");
                PrintMatriz(ref valor);
                // Zera Valor de X para 3 linha
                double value3 = valor[2, 0] * -1;
                valor[2, 0] = valor[0, 0] * value3 + valor[2, 0];
                valor[2, 1] = valor[0, 1] * value3 + valor[2, 1];
                valor[2, 2] = valor[0, 2] * value3 + valor[2, 2];
                valor[2, 3] = valor[0, 3] * value3 + valor[2, 3];
                txtHistoricoResultado.AppendText("1° Linha multiplicada por: " + value3.ToString("0.000") +
                                                 " e somada com a 3° linha\r\n");
                PrintMatriz(ref valor);
                txtHistoricoResultado.AppendText("Cancelando Y da 1° e 3° Linha:\r\n");
                if (Math.Abs(valor[1, 1] - 1.0) > 0)
                {
                    double value = valor[1, 1];
                    valor[1, 0] /= value;
                    valor[1, 1] /= value;
                    valor[1, 2] /= value;
                    valor[1, 3] /= value;
                    txtHistoricoResultado.AppendText("2° Linha dividida por: " + value.ToString("0.000") + "\r\n");
                    PrintMatriz(ref valor);
                }
                // Zera Valor de Y para 1 linha
                double value4 = valor[0, 1] * -1;
                valor[0, 0] = valor[1, 0] * value4 + valor[0, 0];
                valor[0, 1] = valor[1, 1] * value4 + valor[0, 1];
                valor[0, 2] = valor[1, 2] * value4 + valor[0, 2];
                valor[0, 3] = valor[1, 3] * value4 + valor[0, 3];
                txtHistoricoResultado.AppendText("2° Linha multiplicada por: " + value4.ToString("0.000") +
                                                 " e somada com a 1° linha\r\n");
                PrintMatriz(ref valor);
                // Zera Valor de Y para 3 linha
                double value5 = valor[2, 1] * -1;
                valor[2, 0] = valor[1, 0] * value5 + valor[2, 0];
                valor[2, 1] = valor[1, 1] * value5 + valor[2, 1];
                valor[2, 2] = valor[1, 2] * value5 + valor[2, 2];
                valor[2, 3] = valor[1, 3] * value5 + valor[2, 3];
                txtHistoricoResultado.AppendText("2° Linha multiplicada por: " + value5.ToString("0.000") +
                                                 " e somada com a 3° linha\r\n");
                PrintMatriz(ref valor);
                txtHistoricoResultado.AppendText("Cancelando Z da 1° e 2° Linha:\r\n");
                if (Math.Abs(valor[2, 2] - 1.0) > 0)
                {
                    double value = valor[2, 2];
                    valor[2, 0] /= value;
                    valor[2, 1] /= value;
                    valor[2, 2] /= value;
                    valor[2, 3] /= value;
                    txtHistoricoResultado.AppendText("3° Linha dividida por: " + value.ToString("0.000") + "\r\n");
                    PrintMatriz(ref valor);
                }
                // Zera Valor de Z para 1 linha
                double value6 = valor[0, 2] * -1;
                valor[0, 0] = valor[2, 0] * value6 + valor[0, 0];
                valor[0, 1] = valor[2, 1] * value6 + valor[0, 1];
                valor[0, 2] = valor[2, 2] * value6 + valor[0, 2];
                valor[0, 3] = valor[2, 3] * value6 + valor[0, 3];
                txtHistoricoResultado.AppendText("3° Linha multiplicada por: " + value4.ToString("0.000") +
                                                 " e somada com a 1° linha\r\n");
                PrintMatriz(ref valor);
                // Zera Valor de Z para 2 linha
                double value7 = valor[1, 2] * -1;
                valor[1, 0] = valor[2, 0] * value7 + valor[1, 0];
                valor[1, 1] = valor[2, 1] * value7 + valor[1, 1];
                valor[1, 2] = valor[2, 2] * value7 + valor[1, 2];
                valor[1, 3] = valor[2, 3] * value7 + valor[1, 3];
                txtHistoricoResultado.AppendText("3° Linha multiplicada por: " + value5.ToString("0.000") +
                                                 " e somada com a 2° linha\r\n");
                PrintMatriz(ref valor);

                txtHistoricoResultado.SelectionStart = 1;
                txtHistoricoResultado.ScrollToCaret();
            }
        }

        private void PrintMatriz(ref double[,] tst)
        {
            txtHistoricoResultado.AppendText("==============================================\r\n");
            txtHistoricoResultado.AppendText(
                $"|{tst[0, 0].ToString("+0.000;-0.000"),-10:N} {tst[0, 1].ToString("+0.000;-0.000"),-10:N} {tst[0, 2].ToString("+0.000;-0.000"),-10:N} |{tst[0, 3].ToString("+0.000;-0.000"),-10:N}|\r\n");
            txtHistoricoResultado.AppendText(
                $"|{tst[1, 0].ToString("+0.000;-0.000"),-10:N} {tst[1, 1].ToString("+0.000;-0.000"),-10:N} {tst[1, 2].ToString("+0.000;-0.000"),-10:N} |{tst[1, 3].ToString("+0.000;-0.000"),-10:N}|\r\n");
            txtHistoricoResultado.AppendText(
                $"|{tst[2, 0].ToString("+0.000;-0.000"),-10:N} {tst[2, 1].ToString("+0.000;-0.000"),-10:N} {tst[2, 2].ToString("+0.000;-0.000"),-10:N} |{tst[2, 3].ToString("+0.000;-0.000"),-10:N}|\r\n");
            txtHistoricoResultado.AppendText("==============================================\r\n");
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            txt_X_1.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_Y_1.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_Z_1.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_R_1.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_X_2.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_Y_2.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_Z_2.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_R_2.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_X_3.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_Y_3.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_Z_3.Text = rnd.Next(-10, 10).ToString("0.000");
            txt_R_3.Text = rnd.Next(-10, 10).ToString("0.000");
        }
    }
}