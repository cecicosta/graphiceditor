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
    /// Interaction logic for cor_da_linha.xaml
    /// </summary>
    public partial class cor_da_linha : UserControl
    {
        public cor_da_linha()
        {
            InitializeComponent();
        }

        private void btn_black_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Black;
        }

        private void btn_red_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Red;
        }

        private void btn_verde_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Green;
        }

        private void btn_amarelo_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Yellow;
        }

        private void btn_azul_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Blue;
        }

        private void btn_rosa_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Pink;
        }

        private void btn_roxo_Click(object sender, RoutedEventArgs e)
        {
            variaveis.atual.Stroke = Brushes.Purple;
        }
    }
}
