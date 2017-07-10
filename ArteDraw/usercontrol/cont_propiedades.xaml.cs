
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

    public static class ExtensionMethods {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement) {
            uiElement.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
    }
    /// <summary>
    /// Interaction logic for propiedades.xaml
    /// </summary>
    public partial class propiedades : UserControl
    {
        public string Points { get; private set; }
        ContentControl c;
        Point mouseStartPosition;
        Point min;
        Point max;
        private Polyline polyline;

        public propiedades()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Event called when the buttom to create Rectangle is pressed.
        /// it binds the callback methods to handle the drawing of the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertQuadStart(object sender, RoutedEventArgs e)
        {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseDown -= InsertQuadMouseDown;
            canvas.PreviewMouseDown += InsertQuadMouseDown;
        }

        private void InsertQuadMouseDown(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseDown -= InsertQuadMouseDown;
            canvas.PreviewMouseUp += ShapeDragFinish;
            canvas.PreviewMouseMove += ShapeDrag;
            //Create the Rectangle and set its values
            mouseStartPosition = e.GetPosition(canvas);
            //Create and init shape
            Rectangle rect = new Rectangle();
            Shape init = (Shape)rect;
            StartShape(ref init, mouseStartPosition);

            //Insert the ContentControl into the canvas
            canvas.Children.Add(CreateContentControl(rect));
        }
        
        /// <summary>
        /// Event called when the buttom to create Ellipses is pressed.
        /// it binds the callback methods to handle the drawing of the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertCircleStart(object sender, RoutedEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseDown -= InsertCircleMouseDown;
            canvas.PreviewMouseDown += InsertCircleMouseDown;
        }

        private void InsertCircleMouseDown(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseDown -= InsertCircleMouseDown;
            canvas.PreviewMouseUp += ShapeDragFinish;
            canvas.PreviewMouseMove += ShapeDrag;
            //Create the Rectangle and set its values
            mouseStartPosition = e.GetPosition(canvas);
            //Create and init shape
            Ellipse ellipse = new Ellipse();
            Shape init = (Shape)ellipse;
            StartShape(ref init, mouseStartPosition);

            //Insert the ContentControl into the canvas
            canvas.Children.Add(CreateContentControl(ellipse));
        }

        private void InsertLineStart(object sender, RoutedEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseLeftButtonDown -= InsertLineMouseDown;
            canvas.PreviewMouseLeftButtonDown += InsertLineMouseDown;
        }

        private void InsertLineMouseDown(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseLeftButtonDown -= InsertLineMouseDown;
            canvas.PreviewMouseLeftButtonDown += InsertLinePoints;
            canvas.PreviewMouseRightButtonDown += FinishLine;

            mouseStartPosition = e.GetPosition(canvas);

            // Create a polyline
            polyline = new Polyline();
            Shape shape = (Shape)polyline;
            StartShape(ref shape, new Point(0,0));
            
            polyline.Points.Add(mouseStartPosition);
            canvas.Children.Add(polyline);

            min = mouseStartPosition;
            max = mouseStartPosition;
        }

        private void InsertLinePoints(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            Point point = e.GetPosition(canvas);
            polyline.Points.Add(point);

            min.X = min.X > point.X ? point.X : min.X;
            min.Y = min.Y > point.Y ? point.Y : min.Y;
            max.X = max.X < point.X ? point.X : max.X;
            max.Y = max.Y < point.Y ? point.Y : max.Y;
        }

        private void FinishLine(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseLeftButtonDown -= InsertLinePoints;
            canvas.PreviewMouseRightButtonDown -= FinishLine;

            double thickness = Math.Ceiling(polyline.StrokeThickness / 2);
            c = new ContentControl();
            c.Padding = new Thickness(-min.X, -min.Y, -thickness, -thickness);

            Style s = (Style)FindResource("DesignerItemStyle");
            c.Style = s;
            
            c.Height = max.Y - min.Y;
            c.Width = max.X - min.X;
            Canvas.SetTop(c, min.Y);
            Canvas.SetLeft(c, min.X);
            c.Content = polyline;
            canvas.Children.Remove(polyline);
            canvas.Children.Add(c);
        }

        private void ShapeDrag(object sender, MouseEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            c.Width = Math.Max(e.GetPosition(canvas).X - mouseStartPosition.X, 0);
            c.Height = Math.Max(e.GetPosition(canvas).Y - mouseStartPosition.Y, 0);
        }

        private void ShapeDragFinish(object sender, MouseButtonEventArgs e) {
            Canvas canvas = ((MainWindow)System.Windows.Application.Current.MainWindow).canvas;
            canvas.PreviewMouseUp -= ShapeDragFinish;
            canvas.PreviewMouseMove -= ShapeDrag;
        }

        private Shape StartShape(ref Shape shape, Point position) {
            Canvas.SetLeft(shape, position.X);
            Canvas.SetTop(shape, position.Y);
            shape.StrokeThickness = 3;
            shape.Stroke = Brushes.Black;
            shape.Fill = Brushes.Transparent;
            shape.IsHitTestVisible = false;
            shape.RenderTransformOrigin = new Point(0.5, 0.5);
            return shape;
        }

        private ContentControl CreateContentControl(Shape shape) {
            //Create the ContentControl
            c = new ContentControl();
            c.Height = 0;
            c.Width = 0;
            c.Padding = new Thickness(0);
            Canvas.SetTop(c, mouseStartPosition.Y);
            Canvas.SetLeft(c, mouseStartPosition.X);
            c.Content = shape;
            Style s = (Style)FindResource("DesignerItemStyle");
            c.Style = s;
            return c;
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
