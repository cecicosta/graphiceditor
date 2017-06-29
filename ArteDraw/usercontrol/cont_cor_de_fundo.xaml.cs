using Microsoft.Win32;
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

namespace ArteDraw
{
    /// <summary>
    /// Interaction logic for cor_de_fundo.xaml
    /// </summary>
    public partial class cor_de_fundo : UserControl
    {

        public cor_de_fundo()
        {
            InitializeComponent();
        }

        private void btn_red_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Fill = Brushes.Red;
        }

        private void btn_black_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Fill = Brushes.Black;
        }

        private void btn_verde_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Fill = Brushes.Green;
        }

        private void btn_img_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog() { Filter = "JPEG(*.jpeg) | *.jpeg; | JPG(*.JPG) | *.jpg; | PNG(*.PNG) | *.png;" };
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Por favor, selecione um arquivo para abrir";
            var result = dlg.ShowDialog();
            if (result != true) return;
            var filename = dlg.FileName;
            variaveis.atual.Fill = new ImageBrush(new BitmapImage(new Uri(@filename)));
        }
    }
}
