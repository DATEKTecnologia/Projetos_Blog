using System;
using System.Data;
using System.Globalization;
using System.IO;
using MetroFramework.Forms;

namespace NumeroDoMeio.Janelas
{
    public partial class Placar : MetroForm
    {
        private readonly String _caminhoArquivo =
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\DATEK\\NumeroDoMeio\\recordesNumeroDoMeio.xml";

        //endereço do arquivo para salvar os recordes

        private readonly DataSet _dsRecordes = new DataSet("RecordesNumeroDoMeio");
        private DataTable _dtRecordes;
        private readonly int _pontosJogador; //variável para receber os pontos da outra form

        public Placar(int pontosGanhos)
        {
            InitializeComponent();
            //recebendo a variável da outra form pelo construtor e passando para variável privada da classe
            _pontosJogador = pontosGanhos;
        }

        private void PlacarLoad(object sender, EventArgs e)
        {
            //preenche os labels com os dados do arquivo XML para a atualização funcionar baseado neles
            CarregarRecordes();
            //passar os parâmetros da data e quantos pontos o jogador marcou
            AtualizarRecordes(DateTime.Now.ToString(CultureInfo.InvariantCulture), _pontosJogador);
        }

        private void CarregarRecordes()
        {
            try
            {
                if (File.Exists(_caminhoArquivo))
                {
                    //tenta ler o arquivo no link indicado e joga no dataset
                    _dsRecordes.ReadXml(_caminhoArquivo);
                    _dtRecordes = _dsRecordes.Tables["Registro"];
                }
                else
                {
                    CriarArquivoXml();
                }
            }

            catch (FileNotFoundException)
            {
                //se o arquivo não existir ele chama a função que cria o arquivo XML
                CriarArquivoXml();
            }

            //joga os valores do dataset nos labels correspondentes
            lblNomeJogador1.Text = _dtRecordes.Rows[0][0].ToString();
            lblPontosJogador1.Text = _dtRecordes.Rows[0][1].ToString();
            lblData1.Text = _dtRecordes.Rows[0][2].ToString();

            lblNomeJogador2.Text = _dtRecordes.Rows[1][0].ToString();
            lblPontosJogador2.Text = _dtRecordes.Rows[1][1].ToString();
            lblData2.Text = _dtRecordes.Rows[1][2].ToString();

            lblNomeJogador3.Text = _dtRecordes.Rows[2][0].ToString();
            lblPontosJogador3.Text = _dtRecordes.Rows[2][1].ToString();
            lblData3.Text = _dtRecordes.Rows[2][2].ToString();
        }

        private void AtualizarRecordes(string data, int pontos)
        {
            //se os pontos forem maior que o primeiro lugar
            if (int.Parse(lblPontosJogador1.Text) < pontos)
            {
                //colocar o valor do segundo no terceiro lugar
                _dsRecordes.Tables[0].Rows[2][0] = _dsRecordes.Tables[0].Rows[1][0];
                _dsRecordes.Tables[0].Rows[2][1] = _dsRecordes.Tables[0].Rows[1][1];
                _dsRecordes.Tables[0].Rows[2][2] = _dsRecordes.Tables[0].Rows[1][2];
                //colocar o valor do primeiro no segundo lugar
                _dsRecordes.Tables[0].Rows[1][0] = _dsRecordes.Tables[0].Rows[0][0];
                _dsRecordes.Tables[0].Rows[1][1] = _dsRecordes.Tables[0].Rows[0][1];
                _dsRecordes.Tables[0].Rows[1][2] = _dsRecordes.Tables[0].Rows[0][2];
                //atualizar o valor do primeiro lugar
                _dsRecordes.Tables[0].Rows[0][0] = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                _dsRecordes.Tables[0].Rows[0][1] = pontos.ToString(CultureInfo.InvariantCulture);
                _dsRecordes.Tables[0].Rows[0][2] = data;

                //salvar tudo do dataset no XML
                _dsRecordes.WriteXml(_caminhoArquivo);
            }
            //se os pontos forem maior que o segundo lugar
            else if (int.Parse(lblPontosJogador2.Text) < pontos)
            {
                //colocar o valor do segundo no terceiro lugar
                _dsRecordes.Tables[0].Rows[2][0] = _dsRecordes.Tables[0].Rows[1][0];
                _dsRecordes.Tables[0].Rows[2][1] = _dsRecordes.Tables[0].Rows[1][1];
                _dsRecordes.Tables[0].Rows[2][2] = _dsRecordes.Tables[0].Rows[1][2];
                //atualizar o valor do primeiro lugar
                _dsRecordes.Tables[0].Rows[1][0] = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                _dsRecordes.Tables[0].Rows[1][1] = pontos.ToString(CultureInfo.InvariantCulture);
                _dsRecordes.Tables[0].Rows[1][2] = data;

                //salvar tudo do dataset no XML
                _dsRecordes.WriteXml(_caminhoArquivo);
            }
            //se os pontos forem maior que o terceiro lugar
            else if (int.Parse(lblPontosJogador3.Text) < pontos)
            {
                //atualizar o valor do terceiro lugar
                _dsRecordes.Tables[0].Rows[2][0] = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                _dsRecordes.Tables[0].Rows[2][1] = pontos.ToString(CultureInfo.InvariantCulture);
                _dsRecordes.Tables[0].Rows[2][2] = data;

                //salvar tudo do dataset no XML
                _dsRecordes.WriteXml(_caminhoArquivo);
            }
            //carrega novamente para atualizar os labels
            CarregarRecordes();
        }

        private void CriarArquivoXml()
        {
            if (!Directory.Exists(Path.GetDirectoryName(_caminhoArquivo)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_caminhoArquivo));
            }
            //criar um datatable com o nome Registro e duas colunas Data e Pontos
            _dtRecordes = new DataTable("Registro");
            _dtRecordes.Columns.Add("Jogador");
            _dtRecordes.Columns.Add("Pontos");
            _dtRecordes.Columns.Add("Data");

            //Popular os DataTable com a DataRow abaixo tres vezes
            for (int i = 1; i <= 3; i++)
            {
                DataRow novoRecorde = _dtRecordes.NewRow();
                novoRecorde[0] = "-";
                novoRecorde[1] = "0";
                novoRecorde[2] = "-";
                
                _dtRecordes.Rows.Add(novoRecorde);
            }

            //adicionar o DataTable no DataSet
            _dsRecordes.Tables.Add(_dtRecordes);
            //Gravar o arquivo XML no link indicado
            _dsRecordes.WriteXml(_caminhoArquivo);
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            //Fechar janela ao pertar ok
            Close();
        }
    }
}