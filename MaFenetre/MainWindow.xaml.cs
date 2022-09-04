using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL;
using DBmySQL;


namespace MaFenetre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Event_log myEvent_Log = new Event_log("test","MainWindow","Open","N/A");
            this.AfficheDatagrid();
            this.AfficheTreeview();

        }

        private void AfficheTreeview()
        {
            //TODO : Regler problem app config, 
            //TODO : Parcours le disque C premier niveau (Appdata,etc.) lister les rep
            //Tree tnRoot = new TreeNode("base");

        }
        private void AfficheDatagrid()
        {
            Event_log myEvent_Log = new Event_log();
            dgMain.ItemsSource = myEvent_Log.Get_Events().DefaultView;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Event_log myEvent_Log = new Event_log("test", "MainWindow", "Close", "N/A");
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Event_log myEvent_Log = new Event_log("test", "MainWindow", "Resize", this.Width + "x" + this.Height.ToString());
            //this.AfficheDatagrid();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Event_log myEvent_Log = new Event_log("test", "MainWindow", "Reload", "N/A");
            this.AfficheDatagrid();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Event_log myEvent_Log = new Event_log("test", "MainWindow", "btn2", "N/A");
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Event_log myEvent_Log = new Event_log("test", "MainWindow", "btn3", "N/A");
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Event_log myEvent_Log = new Event_log("test", "MainWindow", "btn4", "N/A");
        }


    }
}
