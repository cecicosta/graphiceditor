
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
    /// Interaction logic for propiedades.xaml
    /// </summary>
    public partial class propiedades : UserControl
    {
        public string Points { get; private set; }

        public propiedades()
        {
            InitializeComponent();
        }

        private void btn_quad_Click(object sender, RoutedEventArgs e)
        {
            variaveis.valor_var = "ins_qua";
        }

        private void btn_seta_Click(object sender, RoutedEventArgs e)
        {
            variaveis.valor_var = "mover";
        }

        private void btn_circulo_Click(object sender, RoutedEventArgs e)
        {
            variaveis.valor_var = "ins_cir";
        }

        private void btn_line_Click(object sender, RoutedEventArgs e)
        {
            variaveis.valor_var = "ins_lin";
        }

        private void btn_shape_Click(object sender, RoutedEventArgs e)
        {
            variaveis.valor_var = "ins_sha";
        }

        private void btn_inv1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_inv1_Click_1(object sender, RoutedEventArgs e)
        {
            
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleX = 1;
            variaveis.atual.RenderTransform = sacel;
            variaveis.atual.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_inv2_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleX = -1;
          
            variaveis.atual.RenderTransform = sacel;
            variaveis.atual.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_inh3_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleY = 1;
            variaveis.atual.RenderTransform = sacel;
            variaveis.atual.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_inh4_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleY = -1;
            variaveis.atual.RenderTransform = sacel;
            variaveis.atual.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_cort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
