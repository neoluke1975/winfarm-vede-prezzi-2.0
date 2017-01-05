using System.Windows;
using System.Collections;
using System.Linq;

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
            cbxcolori.Items.Add(System.Drawing.Color.AliceBlue);
            cbxcolori.Items.Add(System.Drawing.Color.AntiqueWhite);
            cbxcolori.Items.Add(System.Drawing.Color.Aqua);
            cbxcolori.Items.Add(System.Drawing.Color.Aquamarine);
            cbxcolori.Items.Add(System.Drawing.Color.Azure);
            cbxcolori.Items.Add(System.Drawing.Color.Beige);
            cbxcolori.Items.Add(System.Drawing.Color.Bisque);
            cbxcolori.Items.Add(System.Drawing.Color.Black);
            cbxcolori.Items.Add(System.Drawing.Color.BlanchedAlmond);
            cbxcolori.Items.Add(System.Drawing.Color.Blue);
            cbxcolori.Items.Add(System.Drawing.Color.BlueViolet);
            cbxcolori.Items.Add(System.Drawing.Color.Brown);
            cbxcolori.Items.Add(System.Drawing.Color.BurlyWood);
            cbxcolori.Items.Add(System.Drawing.Color.CadetBlue);
            cbxcolori.Items.Add(System.Drawing.Color.Chartreuse);
            cbxcolori.Items.Add(System.Drawing.Color.Chocolate);
            cbxcolori.Items.Add(System.Drawing.Color.Coral);
            cbxcolori.Items.Add(System.Drawing.Color.CornflowerBlue);
            cbxcolori.Items.Add(System.Drawing.Color.Cornsilk);
            cbxcolori.Items.Add(System.Drawing.Color.Crimson);
            cbxcolori.Items.Add(System.Drawing.Color.Cyan);
            cbxcolori.Items.Add(System.Drawing.Color.DarkBlue);
            cbxcolori.Items.Add(System.Drawing.Color.DarkCyan);
            cbxcolori.Items.Add(System.Drawing.Color.DarkGoldenrod);
            cbxcolori.Items.Add(System.Drawing.Color.DarkGray);
            cbxcolori.Items.Add(System.Drawing.Color.DarkGreen);
            cbxcolori.Items.Add(System.Drawing.Color.DarkKhaki);
            cbxcolori.Items.Add(System.Drawing.Color.DarkMagenta);
            cbxcolori.Items.Add(System.Drawing.Color.DarkOliveGreen);
            cbxcolori.Items.Add(System.Drawing.Color.DarkOrange);
            cbxcolori.Items.Add(System.Drawing.Color.DarkOrchid);
            cbxcolori.Items.Add(System.Drawing.Color.DarkRed);
            cbxcolori.Items.Add(System.Drawing.Color.DarkSalmon);
            cbxcolori.Items.Add(System.Drawing.Color.DarkSeaGreen);
            cbxcolori.Items.Add(System.Drawing.Color.DarkSlateBlue);
            cbxcolori.Items.Add(System.Drawing.Color.DarkSlateGray);
            cbxcolori.Items.Add(System.Drawing.Color.DarkTurquoise);
            cbxcolori.Items.Add(System.Drawing.Color.DarkViolet);
            cbxcolori.Items.Add(System.Drawing.Color.DeepPink);
            cbxcolori.Items.Add(System.Drawing.Color.DeepSkyBlue);
            cbxcolori.Items.Add(System.Drawing.Color.DimGray);
            cbxcolori.Items.Add(System.Drawing.Color.DodgerBlue);
            cbxcolori.Items.Add(System.Drawing.Color.Empty);
            cbxcolori.Items.Add(System.Drawing.Color.Firebrick);
            cbxcolori.Items.Add(System.Drawing.Color.FloralWhite);
            cbxcolori.Items.Add(System.Drawing.Color.ForestGreen);
            cbxcolori.Items.Add(System.Drawing.Color.Fuchsia);
            cbxcolori.Items.Add(System.Drawing.Color.Gainsboro);
            cbxcolori.Items.Add(System.Drawing.Color.GhostWhite);
            cbxcolori.Items.Add(System.Drawing.Color.Gold);
            cbxcolori.Items.Add(System.Drawing.Color.Goldenrod);
            cbxcolori.Items.Add(System.Drawing.Color.Gray);
            cbxcolori.Items.Add(System.Drawing.Color.Green);
            cbxcolori.Items.Add(System.Drawing.Color.GreenYellow);
            cbxcolori.Items.Add(System.Drawing.Color.Honeydew);
            cbxcolori.Items.Add(System.Drawing.Color.HotPink);
            cbxcolori.Items.Add(System.Drawing.Color.IndianRed);
            cbxcolori.Items.Add(System.Drawing.Color.Indigo);
            cbxcolori.Items.Add(System.Drawing.Color.Ivory);
            cbxcolori.Items.Add(System.Drawing.Color.Khaki);
            cbxcolori.Items.Add(System.Drawing.Color.Lavender);
            cbxcolori.Items.Add(System.Drawing.Color.LavenderBlush);
            cbxcolori.Items.Add(System.Drawing.Color.LawnGreen);
            cbxcolori.Items.Add(System.Drawing.Color.LemonChiffon);
            cbxcolori.Items.Add(System.Drawing.Color.LightBlue);
            cbxcolori.Items.Add(System.Drawing.Color.LightCoral);
            cbxcolori.Items.Add(System.Drawing.Color.LightCyan);
            cbxcolori.Items.Add(System.Drawing.Color.LightGoldenrodYellow);
            cbxcolori.Items.Add(System.Drawing.Color.LightGray);
            cbxcolori.Items.Add(System.Drawing.Color.LightGreen);
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
