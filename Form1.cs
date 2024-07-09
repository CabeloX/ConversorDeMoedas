using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Policy;

namespace ConversorDeMoedas
{
    public partial class CBLTech : Form
    {
        public static string tipoMoeda = "USD-BRL";

        public static string urlAPI = $"https://economia.awesomeapi.com.br/json/last/{tipoMoeda}";

        public static float dollarFixo = 0;

        public static bool altoValor = false;

        public CBLTech()
        {
            InitializeComponent();
        }
        private void CBLTech_Load(object sender, EventArgs e)
        {
            #region LocalAplicação
            /* Método usando para aplicação local!
            File.WriteAllText("C:\\Windows\\Temp\\dollarValue.txt", "5.25");
            */
            #endregion
  
            CheckForIllegalCrossThreadCalls = false;

            ObterDolar();

            guna2PictureBox1.Load("https://i.pinimg.com/originals/1a/54/e5/1a54e518e8c89a0ef3b4e47f6070ec71.gif");
        }
        private void btn_uptDollar_Click(object sender, EventArgs e)
        {
            #region LocalAplicação
            /* Método usando para aplicação local!
            string fileDollar = "C:\\Windows\\Temp\\dollarValue.txt";
            if (File.Exists(fileDollar))
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            */
            #endregion
        }
        public async void ObterDolar()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(urlAPI);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        if (altoValor == true)
                        {
                            string obterDataAtualizada = responseData.ToString().Substring(220, 10);
                            string obterHorarioAtualizado = responseData.ToString().Substring(230, 9);
                            string finalResultado = responseData.ToString().Substring(88, 4);
                            dollarFixo = float.Parse(finalResultado);
                            label1.Text = $"Dollar: ${finalResultado}";
                            guna2HtmlToolTip1.SetToolTip(label1, $"Last update was {obterDataAtualizada} | {obterHorarioAtualizado}");
                        }
                        else
                        {
                            string obterDataAtualizada = responseData.ToString().Substring(220, 10);
                            string obterHorarioAtualizado = responseData.ToString().Substring(230, 9);
                            string finalResultado = responseData.ToString().Substring(103, 4);
                            dollarFixo = float.Parse(finalResultado);
                            label1.Text = $"Dollar: ${finalResultado}";
                            guna2HtmlToolTip1.SetToolTip(label1, $"Last update was {obterDataAtualizada} | {obterHorarioAtualizado}");
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void tb_coinValue_TextChanged(object sender, EventArgs e)
        {
            #region LocalAplicação
            //try
            //{
            //    string dollarGettxt = tb_coinValue.Text;
            //    float dollarRest = Convert.ToSingle(dollarGettxt);
            //    float dollarConverted = initialDollar * dollarRest;
            //    string dollarFormat = string.Format("{0:F2}", dollarConverted);
            //    tb_finalValue.Text = "R$" + dollarFormat.ToString();
            //}
            //catch (Exception) { }
            //dollarFixo


            #endregion
            try
            {
                string obterValor = tb_coinValue.Text;
                float valorCapturado = Convert.ToSingle(obterValor);
                float realConvertido = valorCapturado * dollarFixo;
                string dollarFormat = string.Format("{0:F2}", realConvertido);
                tb_finalValue.Text = "R$" + dollarFormat.ToString();
            }
            catch (Exception) { }
        }

        private void cbl_tm1_Tick(object sender, EventArgs e)
        {
            if (!cbl_bck1.IsBusy)
            {
                cbl_bck1.RunWorkerAsync();
            }
        }

        private void cbl_bck1_DoWork(object sender, DoWorkEventArgs e)
        {
            ObterDolar();
        }
        private void s_hightValue_CheckedChanged(object sender, EventArgs e)
        {
            if (s_hightValue.Checked)
            {
                altoValor = true;
            }
            else
            {
                altoValor = false;
            }
        }
    }
}
