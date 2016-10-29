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

            tbx_server.Text = winfarm_vede_prezzi_2._0.Properties.Settings.Default.server;
            tbx_percorso.Text = winfarm_vede_prezzi_2._0.Properties.Settings.Default.percorso;
            tbxIntestazione.Text = winfarm_vede_prezzi_2._0.Properties.Settings.Default.farmacia;
            tbxTime.Text = (winfarm_vede_prezzi_2._0.Properties.Settings.Default.timer).ToString();


        }


        private void btn_salva_Click(object sender, RoutedEventArgs e)
        {
            winfarm_vede_prezzi_2._0.Properties.Settings.Default.server = tbx_server.Text;
           winfarm_vede_prezzi_2._0.Properties.Settings.Default.percorso = tbx_percorso.Text;
            winfarm_vede_prezzi_2._0.Properties.Settings.Default.farmacia= tbxIntestazione.Text;
            winfarm_vede_prezzi_2._0.Properties.Settings.Default.timer=int.Parse(tbxTime.Text);
            Properties.Settings.Default.Save();
            this.Close();


        }

        private void comboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                     
        }
    }
}
