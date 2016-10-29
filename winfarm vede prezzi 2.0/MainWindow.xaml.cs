using System;
using System.Windows;
using System.Windows.Input;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Xml;
using System.Windows.Threading;
using System.Globalization;
using System.Threading;


namespace winfarm_vede_prezzi_2._0
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            minsanTBX.Focusable = true;
        }

        private void minsanTBX_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try{ 
            string server = Properties.Settings.Default.server;
            string stringa_winfarm = Properties.Settings.Default.percorso;
            string intestazione = Properties.Settings.Default.farmacia;
                int tempo =Properties.Settings.Default.timer;

                txblckIntestazione.Text = intestazione.ToString();

                FbConnection connesione = connettiti(server, stringa_winfarm);

                string queryMinsan = ("select a.KM10," +
                                 "a.KDES," +
                                 "a.E_PREZZO," +
                                 "m.E_PREZZO_LISTINO," +
                                 "m.E_PREZZO_FARMACIA," +
                                 "m.SCONTO," +
                                 "a.PREZZO_UE," +
                                 "a.KEAN,"+
                                 "(select kcart from img_paraf where tiparc ='HA' and km10=a.km10),"+
                                 "(select estensione from img_paraf where tiparc ='HA' and km10=a.km10)"+
                                 " from magazzino m " +
                                 "inner join anapro a " +
                                 "on m.KM10 = a.KM10 " +
                                 "where a.KM10='");



                FbDataReader lettura = null;

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("it-IT");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("it-IT");

                
               
                if (e.Key == Key.Enter)
                {
                    label1.Visibility = Visibility.Collapsed;

                    try
                    {

                        string minsan="";


                        connesione.Open();
                        
                        minsan = minsanTBX.Text;
                        if (minsan.Length == 6)
                        {
                            
                            string primo = minsan.Substring(0, 1);
                            string secondo = minsan.Substring(1, 1);
                            string terzo = minsan.Substring(2, 1);
                            string quarto = minsan.Substring(3, 1);
                            string quinto = minsan.Substring(4, 1);
                            string sesto = minsan.Substring(5, 1);

                            int primoNumero = int.Parse(converti(primo)) * 33554432;
                            int secondoNumero = int.Parse(converti(secondo)) * 1048576;
                            int terzoNumero = int.Parse(converti(terzo)) * 32768;
                            int quartoNumero = int.Parse(converti(quarto)) * 1024;
                            int quintoNumero = int.Parse(converti(quinto)) * 32;
                            int sestoNumero = int.Parse(converti(sesto)) * 1;
                            minsan = (primoNumero + secondoNumero + terzoNumero + quartoNumero + quintoNumero + sestoNumero).ToString();
                        }
                        if (minsan.Length == 8)
                        {
                            minsan = "0" + minsan;
                          
                        }
                        minsanTBX.Text = "";
                       

                        //faccio la query per avere i dati

                        FbCommand selezione = new FbCommand(queryMinsan + minsan + "'" + " or a.KEAN='" + minsan + "'", connesione);
                        lettura = selezione.ExecuteReader();

                        try
                        {
                            while (lettura.Read())
                            {
                                minsanLBL.Content = (lettura[0].ToString());
                                descrizioneLBL.Text = (lettura[1].ToString());
                                double prezzoBancaDati = double.Parse(lettura[2].ToString());
                                double prezzoListino = double.Parse(lettura[3].ToString());
                                double prezzoVendita = double.Parse(lettura[4].ToString());
                                double sconto = double.Parse(lettura[5].ToString());
                                double prezzoKg = double.Parse(lettura[6].ToString());
                                eanLBL.Content = (lettura[7].ToString());
                                string numero_sito = (lettura[8].ToString());
                                string estensione_immagine = (lettura[9].ToString()).Replace(" ", "");
                                string webimage = "http" + "://www.farmadati.it/imgbd/imgbd.aspx?img=" + numero_sito + "." + estensione_immagine + "&sn=10352EH488";
                                //browserimage.Navigate(webimage);
                                //if (estensione_immagine=="jpg")
                                //{
                                //    image. immagine=new image("http://www.farmadati.it/imgbd/imgbd.aspx?img=063384.jpg&sn=10352EH488");
                                //}
                                minsanTBX.Visibility = Visibility.Hidden;


                                //prezzoDiPartenzaLBL.Content = prezzoBancaDati;
                                if (prezzoListino > 0)
                                    if (prezzoBancaDati == 0)
                                        if (prezzoVendita == 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo  " + ((prezzoListino).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Underline;
                                            prezzoDiPartenzaLBL.FontSize = 50;
                                        }
                                if (prezzoListino > 0)
                                    if (prezzoBancaDati > 0)
                                        if (prezzoVendita == 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo  " + ((prezzoListino).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Underline;
                                            prezzoDiPartenzaLBL.FontSize = 50;
                                        }
                                if (prezzoListino == 0)
                                    if (prezzoBancaDati > 0)
                                        if (prezzoVendita == 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo  " + ((prezzoBancaDati).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Underline;
                                            prezzoDiPartenzaLBL.FontSize = 50;
                                        }
                                if (prezzoListino == 0)
                                    if (prezzoBancaDati == 0)
                                        if (prezzoVendita > 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo  " + ((prezzoVendita).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Underline;
                                            prezzoDiPartenzaLBL.FontSize = 50;
                                        }
                                if (prezzoListino > 0)
                                    if (prezzoBancaDati == 0)
                                        if (prezzoVendita > 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo  " + ((prezzoListino).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Underline;
                                            prezzoDiPartenzaLBL.FontSize = 50;
                                        }
                                if (prezzoVendita > 0)
                                    if (prezzoVendita > prezzoBancaDati)
                                        if (prezzoListino == 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo " + ((prezzoVendita).ToString("C", CultureInfo.CurrentUICulture));
                                            //prezzoScontatoLBL.Content = "In Offerta " + ((prezzoVendita).ToString("C", CultureInfo.CurrentUICulture));
                                            //prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Strikethrough;
                                        }
                                if (prezzoVendita > 0)
                                    if (prezzoVendita < prezzoBancaDati)
                                        if (prezzoListino == 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo " + ((prezzoBancaDati).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoScontatoLBL.Content = "In Offerta " + ((prezzoVendita).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Strikethrough;
                                        }
                                if (prezzoVendita > 0)
                                    if (prezzoVendita < prezzoListino)
                                        if (prezzoListino > 0)
                                        {
                                            prezzoDiPartenzaLBL.Text = "Prezzo " + ((prezzoListino).ToString("C", CultureInfo.CurrentUICulture));
                                            prezzoScontatoLBL.Content = ("In Offerta " + ((prezzoVendita).ToString("C", CultureInfo.CurrentUICulture)));
                                            prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Strikethrough;
                                        }
                                if (sconto > 0)
                                    if (prezzoListino > 0)
                                    {
                                        prezzoDiPartenzaLBL.Text = "Prezzo " + ((prezzoListino).ToString("C", CultureInfo.CurrentUICulture));
                                        prezzoScontatoLBL.Content = "In Offerta " + ((prezzoListino - ((prezzoListino / 100) * sconto)).ToString("C", CultureInfo.CurrentUICulture));
                                        prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Strikethrough;
                                    }
                                if (sconto > 0)
                                    if (prezzoListino == 0)
                                    {
                                        prezzoDiPartenzaLBL.Text = "Prezzo " + ((prezzoBancaDati).ToString("C", CultureInfo.CurrentUICulture));
                                        prezzoScontatoLBL.Content = "In Offerta " + ((prezzoBancaDati - ((prezzoBancaDati / 100) * sconto)).ToString("C", CultureInfo.CurrentUICulture));
                                        prezzoDiPartenzaLBL.TextDecorations = TextDecorations.Strikethrough;
                                    }
                                if (prezzoKg > 0)
                                {
                                    prezzoKgLBL.Content = "Prezzo Kg/Lt." + prezzoKg.ToString("C", CultureInfo.CurrentUICulture);
                                }
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        
                            
                        
                        lettura.Close();
                        connesione.Close();
                    }

                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Hai Inserito Correttamente i Percorsi?");
                        minsanTBX.Text = "";
                        minsanTBX.Focusable = true;
                        timer(tempo);
                        connesione.Dispose();
                        lettura.Dispose();
                        par_winfarm par = new par_winfarm();
                        par.Show();
                        return;

                    }
                    e.Handled = true;
                    timer(tempo);

                }
            }
            catch
            {

            }
        }

        private static void conversione(object lettera)
        {
            throw new NotImplementedException();
        }

        private static FbConnection connettiti(string server, string stringa_winfarm)
        {
            return new FbConnection("User=SYSDBA;Password=masterkey;Database=" + stringa_winfarm + ";DataSource=" + server + ";Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;");
        }

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private void timer(int tempo)
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, tempo);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                
                descrizioneLBL.Text = "";
                eanLBL.Content = "";
                minsanLBL.Content = "";
                prezzoDiPartenzaLBL.Text = "";
                prezzoKgLBL.Content = "";
                prezzoScontatoLBL.Content = "";
                label1.Visibility = Visibility.Visible;
                if (dispatcherTimer.IsEnabled)
                {
                    dispatcherTimer.Stop();
                }
                minsanTBX.Visibility = Visibility.Visible;
                minsanTBX.Focus();
            }
            catch
            {
            }

        }


        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F9)
            {
                par_winfarm par = new par_winfarm();
                par.Show();

            }
            if (e.Key == Key.F2)

            {
                Close();
            }

        }
        static string converti(string minsan)
        {
            if (minsan == "0")
            {
                minsan = "0";
            }
            if (minsan == "1")
            {
                minsan = "1";
            }
            if (minsan == "2")
            {
                minsan = "2";
            }
            if (minsan == "3")
            {
                minsan = "3";
            }
            if (minsan == "4")
            {
                minsan = "4";
            }
            if (minsan == "5")
            {
                minsan = "5";
            }
            if (minsan == "6")
            {
                minsan = "6";
            }
            if (minsan == "7")
            {
                minsan = "7";
            }
            if (minsan == "8")
            {
                minsan = "8";
            }
            if (minsan == "9")
            {
                minsan = "9";
            }
            if (minsan == "B")
            {
                minsan = "10";
            }
            if (minsan == "C")
            {
                minsan = "11";
            }
            if (minsan == "D")
            {
                minsan = "12";
            }
            if (minsan == "F")
            {
                minsan = "13";
            }
            if (minsan == "G")
            {
                minsan = "14";
            }
            if (minsan == "H")
            {
                minsan = "15";
            }
            if (minsan == "J")
            {
                minsan = "16";
            }
            if (minsan == "K")
            {
                minsan = "17";
            }
            if (minsan == "L")
            {
                minsan = "18";
            }
            if (minsan == "M")
            {
                minsan = "19";
            }
            if (minsan == "N")
            {
                minsan = "20";
            }
            if (minsan == "P")
            {
                minsan = "21";
            }
            if (minsan == "Q")
            {
                minsan = "22";
            }
            if (minsan == "R")

            {
                minsan = "23";
            }
            if (minsan == "S")
            {
                minsan = "24";

            }
            if (minsan == "T")
            {
                minsan = "25";

            }
            if (minsan == "U")
            {
                minsan = "26";

            }
            if (minsan == "V")
            {
                minsan = "27";
            }
            if (minsan == "W")
            {
                minsan = "28";

            }
            if (minsan == "X")
            {
                minsan = "29";

            }
            if (minsan == "Y")
            {
                minsan = "30";
            }
            if (minsan == "Z")
            {
                minsan = "31";
            }
            return minsan;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
    

}



