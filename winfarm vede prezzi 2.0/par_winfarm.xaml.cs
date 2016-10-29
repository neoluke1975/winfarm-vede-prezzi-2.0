using System.Windows;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Diagnostics;

namespace winfarm_vede_prezzi_2._0
{
    /// <summary>
    /// Logica di interazione per par_winfarm.xaml
    /// </summary>
    public partial class par_winfarm : Window
    {
        public par_winfarm()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            using (Stream lettore = File.OpenRead("c:/kiosk/parametri.xml"))
            {
                doc.Load(lettore);
                XmlElement percorso = (XmlElement)doc.DocumentElement.LastChild;
                XmlElement percorso_server = doc.DocumentElement.ChildNodes[1]["percorso_server", "parametri winfarm"];
                XmlElement percorso_winfarm = doc.DocumentElement.ChildNodes[2]["percorso_winfarm", "parametri winfarm"];
                XmlElement percorsoIntestazione = doc.DocumentElement.ChildNodes[3]["percorso_intestazione", "parametri winfarm"];
                XmlElement percorsoTempo = doc.DocumentElement.ChildNodes[4]["percorso_tempo", "parametri winfarm"];
                string server = percorso_server.FirstChild.Value;
                string stringa_winfarm = percorso_winfarm.FirstChild.Value;
                string intestazione = percorsoIntestazione.FirstChild.Value;
                string tempo = percorsoTempo.FirstChild.Value;
                tbx_server.Text = server.ToString();
                tbx_percorso.Text = stringa_winfarm.ToString();
                tbxIntestazione.Text = intestazione.ToString();
                tbxTime.Text = tempo.ToString();
            }

        }


        private void btn_salva_Click(object sender, RoutedEventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            string ns = "parametri winfarm";

            using (XmlWriter writer = XmlWriter.Create("c:/kiosk/parametri.xml", settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("parametri_winfarm_vedeprezzi", ns);
                writer.WriteComment("winfam_parametri");

                writer.WriteStartElement("parametri_server", ns);
                writer.WriteAttributeString("server", "1");
                writer.WriteElementString("percorso_server", ns, tbx_server.Text);
                writer.WriteEndElement();
                writer.WriteStartElement("parametri_server", ns);
                writer.WriteAttributeString("server", "2");
                writer.WriteElementString("percorso_winfarm", ns, tbx_percorso.Text);
                writer.WriteEndElement();
                writer.WriteStartElement("parametri_server", ns);
                writer.WriteAttributeString("server", "3");
                writer.WriteElementString("percorso_intestazione", ns, tbxIntestazione.Text);
                writer.WriteEndElement();
                writer.WriteStartElement("parametri_server", ns);
                writer.WriteAttributeString("server", "4");
                writer.WriteElementString("percorso_tempo", ns, tbxTime.Text);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                this.Close();

            }
        }

        private void comboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                     
        }
    }
}
