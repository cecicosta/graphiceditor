
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
        Rectangle r;
        ContentControl c;
        Point mouseStartPosition;

        public propiedades()
        {
            InitializeComponent();

        }

        private void InsertQuadStart(object sender, RoutedEventArgs e)
        {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseDown -= InsertQuadMouseDown;
            canvas.PreviewMouseDown += InsertQuadMouseDown;
        }

        private void InsertQuadMouseDown(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseDown -= InsertQuadMouseDown;
            canvas.PreviewMouseUp += InsertQuadMouseUp;
            canvas.PreviewMouseMove += InserQuadContinue;
            //Create the Rectangle and set its values
            mouseStartPosition = e.GetPosition(canvas);
            r = new Rectangle();
            Canvas.SetLeft(r, mouseStartPosition.X);
            Canvas.SetTop(r, mouseStartPosition.Y);
            r.StrokeThickness = 5;
            r.Stroke = Brushes.Black;
            r.Fill = Brushes.Transparent;
            r.IsHitTestVisible = false;
            r.RenderTransformOrigin = new Point(0.5, 0.5);
            //Create the ContentControl and insert the Rectangle
            c = new ContentControl();
            c.Height = 0;
            c.Width = 0;
            c.Padding = new Thickness(0);
            Canvas.SetTop(c, mouseStartPosition.Y);
            Canvas.SetLeft(c, mouseStartPosition.X);
            c.Content = r;
            Style s = (Style)FindResource("DesignerItemStyle");
            c.Style = s;
            //Insert the ContentControl for the Rectangle into the canvas
            canvas.Children.Add(c);
        }

        private void InserQuadContinue(object sender, MouseEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            c.Width = Math.Max(e.GetPosition(canvas).X - mouseStartPosition.X, 0);
            c.Height = Math.Max(e.GetPosition(canvas).Y - mouseStartPosition.Y, 0);
        }

        private void InsertQuadMouseUp(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseUp -= InsertQuadMouseUp;
            canvas.PreviewMouseMove -= InserQuadContinue;
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


        private void btn_inv1_Click_1(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleX = 1;
            variaveis.selectedElement.RenderTransform = sacel;
            variaveis.selectedElement.RenderTransformOrigin = new Point(0.5, 0.5);   
        }

        private void btn_inv2_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleX = -1;
            variaveis.selectedElement.RenderTransform = sacel;
            variaveis.selectedElement.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_inh3_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleY = 1;
            variaveis.selectedElement.RenderTransform = sacel;
            variaveis.selectedElement.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_inh4_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform sacel = new ScaleTransform();
            sacel.ScaleY = -1;      
            variaveis.selectedElement.RenderTransform = sacel;
            variaveis.selectedElement.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btn_cort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
