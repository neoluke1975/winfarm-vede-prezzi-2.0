using System.Windows;

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
    }
}
