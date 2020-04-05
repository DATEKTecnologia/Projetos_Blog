using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Media;
using System.Windows.Forms;
using MetroFramework.Forms;
using NumeroDoMeio.Properties;

namespace NumeroDoMeio.Janelas
{
    public partial class FormPrincipal : MetroForm
    {
        private int _acertos;

        private int _lastA;
        private int _lastB;
        private int _nivel;
        private int _respostaDada;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipalLoad(object sender, EventArgs e)
        {
            GerarNovosNumeros();
            progressBar1.Maximum = int.Parse(lblCron.Text.Trim());            
        }

        private void TbRespostaKeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir somente números no evento KeyPress
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char) 8)
                e.Handled = true;

            //se apertar enter e tiver algo escrito no textbox
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtResposta.Text))
            {
                //pegar os valores dos labels e por em ints
                var valorA = int.Parse(lblValorA.Text.Trim());
                var valorB = int.Parse(lblValorB.Text.Trim());
                //calcular a resposta certa que deveria ser digitada
                var respostaCorreta = (valorA + valorB) / 2;

                //tratar o textbox pegando somente valores não nulos
                if (!string.IsNullOrEmpty(txtResposta.Text))
                    _respostaDada = int.Parse(txtResposta.Text.Trim());
                //limpar o textbox para prepará-lo para próxima rodada
                txtResposta.Text = null;

                //se a resposta estiver correta chamar os métodos descritos
                if (respostaCorreta == _respostaDada)
                {
                    GanharPonto();
                    GerarNovosNumeros();
                    ReiniciarCronometro();
                }

                //se a resposta estiver errada
                else
                {
                    tocarSomErrou();
                    //pausar cronometro
                    timerCron.Enabled = false;
                    //guardar o númeor de acertos escrito no label
                    _acertos = int.Parse(lblPlacar.Text);
                    //Mostrar numa messageBox quantos acertos o jogar fez
                    MessageBox.Show(@"Resposta errada. Você marcou " + _acertos + @" pontos.", @"Fim de jogo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //chamar método finalizarPartida passando quantos acertos o jogador fez como parâmetro para gravar no placar
                    finalizarPartida(_acertos);
                    //zerar o placar
                    ZerarPlacar();
                    //método que gera dois novos números
                    GerarNovosNumeros();
                    //reiniciar o cronometro
                    ReiniciarCronometro();
                }
            }
        }

        //a cada 1 segundo esta função é executada automaticamente
        private void TimerCronTick(object sender, EventArgs e)
        {
            //pega o label e converte para int
            var cronometro = int.Parse(lblCron.Text.Trim());
            //subtrai 1
            cronometro--;


            //se for maior ou igual a = atualiza o label com o valor
            if (cronometro >= 0)
            {
                lblCron.Text = cronometro.ToString(CultureInfo.InvariantCulture);
                lblCron.ForeColor = Color.Black;
                progressBar1.BackColor = Color.Green;
            }

            //se for menor ou igual a 4 pinta o label de vermelho
            
            if (cronometro <= 4)
            {
                lblCron.ForeColor = Color.Red;
                progressBar1.BackColor = Color.Red;
            }
            else if(cronometro <= 7)
            {
                lblCron.ForeColor = Color.Goldenrod;
                progressBar1.BackColor = Color.Goldenrod;
            }
            progressBar1.Value = int.Parse(lblCron.Text.Trim());

            //se o tempo esgotar (0)
            if (cronometro == 0)
            {
                //pausa o cronometro
                timerCron.Enabled = false;
                //toca o som de tempo esgotado
                tocarSomEsgotado();
                //guardar o númeor de acertos escrito no label
                _acertos = int.Parse(lblPlacar.Text);
                //Mostrar numa messageBox quantos acertos o jogar fez
                MessageBox.Show(@"Tempo esgotado. Você marcou " + _acertos + @" pontos.", @"Fim de jogo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //chamar método finalizarPartida passando quantos acertos o jogador fez como parâmetro para gravar no placar
                finalizarPartida(_acertos);
                //zera o placar
                ZerarPlacar();
                //método que gera dois novos números
                GerarNovosNumeros();
                //reiniciar o cronometro
                ReiniciarCronometro();
            }
        }

        private void GerarNovosNumeros()
        {
            var a = new Random();
            var b = new Random();
            int valorA;
            int valorB;

            //enquanto a soma dos números não por par ou a subtração deles for 0, gere novos números novamente
            do
            {
                //o valor A só pode ser de 0 a 95
                valorA = a.Next(0, (int) (8 * Math.Exp(_nivel)));
                //o valor  B tem que ser entre valor a e 99
                valorB = b.Next(valorA, (int) (9 * Math.Exp(_nivel)));
            } while ((valorA + valorB) % 2 != 0 || valorB - valorA == 0 || valorB == int.Parse(lblValorB.Text) ||
                     valorA == int.Parse(lblValorA.Text) || _lastA == valorA || _lastB == valorB);

            _lastA = valorA;
            _lastB = valorB;
            //coloca os números obtidos nos labels
            lblValorA.Text = valorA.ToString(CultureInfo.InvariantCulture);
            lblValorB.Text = valorB.ToString(CultureInfo.InvariantCulture);
        }

        private void GanharPonto()
        {
            //tocar som de acerto
            tocarSomAcertou();
            //converter o label para int
            var placar = int.Parse(lblPlacar.Text.Trim());
            //somar 1 ponto
            placar++;
            //jogar resultado de volta para o label
            lblPlacar.Text = placar.ToString(CultureInfo.InvariantCulture);
            if (placar % 10 == 0)
                _nivel++;
            lblNivel.Text = _nivel.ToString(CultureInfo.InvariantCulture);
        }

        private void ZerarPlacar()
        {
            //apenas zerar o label do cronometro
            lblPlacar.Text = @"0";
            lblNivel.Text = @"0";
            _nivel = 0;
            lblCron.Text = @"1";
        }

        private void ReiniciarCronometro()
        {
            //ativar cronometro
            timerCron.Enabled = true;
            //voltar a cor do label para preto
            lblCron.ForeColor = Color.Black;
            //contagem regressiva a partir de 10
            lblCron.Text = (int.Parse(lblCron.Text.Trim()) + 5).ToString(CultureInfo.InvariantCulture);
            progressBar1.Maximum = int.Parse(lblCron.Text.Trim());
        }

        //tocar som
        private void tocarSomAcertou()
        {
            var player = new SoundPlayer(Resources.acerto);
            player.Load();
            player.Play();
        }

        //tocar som
        private void tocarSomErrou()
        {
            var player = new SoundPlayer(Resources.erro);
            player.Load();
            player.Play();
        }

        //tocar som
        private void tocarSomEsgotado()
        {
            var player = new SoundPlayer(Resources.tempoesgotado);
            player.Load();
            player.Play();
        }

        //método que recebe os pontos marcados quando o jogador erra ou acaba o tempo
        private void finalizarPartida(int pontos)
        {
            //instanciar o Placar e passar quantos pontos o jogador marcou
            var formPlacar = new Placar(pontos);
            //abrir a form Placar e bloquear todas as demais
            formPlacar.ShowDialog();
        }

        private void lblCron_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

    public class ProgressBarEx : ProgressBar
    {
        public ProgressBarEx()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = new Rectangle(0, 0, Width, Height);

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int) (rec.Width * ((double) Value / Maximum)) - 4;
            rec.Height -= 4;
            var brush = new LinearGradientBrush(rec, ForeColor, BackColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
    }
}