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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }


        private Shape _curShape;
        private Point _mDown, _mMove;
        private Line _line;





        private static readonly PointCollection _points = new PointCollection();

        private static PointCollection Points => _points;









        private void canfolha_MouseMove(object sender, MouseEventArgs e)
        {

            if (variaveis.valor_var == "ins_quaa")
            {
                _mMove = e.GetPosition(canfolha);

                if (_mMove.X <= _mDown.X && _mMove.Y <= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mMove.X, _mMove.Y, 0, 0);
                }
                else if (_mMove.X >= _mDown.X && _mMove.Y <= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mDown.X, _mMove.Y, 0, 0);
                }
                else if (_mMove.X >= _mDown.X && _mMove.Y >= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mDown.X, _mDown.Y, 0, 0);
                }
                else if (_mMove.X <= _mDown.X && _mMove.Y >= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mMove.X, _mDown.Y, 0, 0);
                }

                _curShape.Width = Math.Abs(_mMove.X - _mDown.X);
                _curShape.Height = Math.Abs(_mMove.Y - _mDown.Y);

            }

            if (variaveis.valor_var == "ins_cirr")
            {
                _mMove = e.GetPosition(canfolha);

                if (_mMove.X <= _mDown.X && _mMove.Y <= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mMove.X, _mMove.Y, 0, 0);
                }
                else if (_mMove.X >= _mDown.X && _mMove.Y <= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mDown.X, _mMove.Y, 0, 0);
                }
                else if (_mMove.X >= _mDown.X && _mMove.Y >= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mDown.X, _mDown.Y, 0, 0);
                }
                else if (_mMove.X <= _mDown.X && _mMove.Y >= _mDown.Y)
                {
                    _curShape.Margin = new Thickness(_mMove.X, _mDown.Y, 0, 0);
                }

                _curShape.Width = Math.Abs(_mMove.X - _mDown.X);
                _curShape.Height = Math.Abs(_mMove.Y - _mDown.Y);

            }


            if (variaveis.valor_var == "ins_lin" || variaveis.valor_var == "ins_sha")
            {
                try
                {
                    _mDown = e.GetPosition(canfolha);
                    _line.X2 = _mDown.X;
                    _line.Y2 = _mDown.Y;
                } catch { }
            }



        }
        private void canfolha_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var _poli = new Polyline();
            var _polig = new Polygon();


            var newPoints = new PointCollection();
            var polygonPoints = new PointCollection(_points);
            double MaxX = 0, MinX = 0, MaxY = 0, MinY = 0;
            var i = 0;


            if (variaveis.valor_var == "ins_sha" || variaveis.valor_var == "ins_lin")
            {
                Points.Add(_mDown);
                _polig.Points = polygonPoints;
                _polig.IsHitTestVisible = true;
                _poli.Points = polygonPoints;
                _poli.IsHitTestVisible = true;

                foreach (var point in polygonPoints)
                {
                    if (i == 0)
                    {
                        MaxX = point.X;
                        MinX = point.X;
                        MaxY = point.Y;
                        MinY = point.Y;
                    }
                    if (point.X > MaxX)
                        MaxX = point.X;
                    if (point.X < MinX)
                        MinX = point.X;
                    if (point.Y > MaxY)
                        MaxY = point.Y;
                    if (point.Y < MinY)
                        MinY = point.Y;
                    i++;
                }


              

                foreach (var points in _polig.Points)
                {
                    newPoints.Add(new Point(points.X - MinX, points.Y - MinY));
                }
                _polig.Points = newPoints;
                _poli.Points = newPoints;

        
                var curControl = new DesignerItem
                {
                    Width = MaxX - MinX,
                    Height = MaxY - MinY,
                    Content = _polig
                };

            }



            if (variaveis.valor_var == "ins_lin")//insere o poliline definitivo
            {
                _poli.Stroke = new SolidColorBrush(Colors.Blue);
                _poli.Fill = new SolidColorBrush(Colors.Transparent);
                _poli.StrokeThickness = 1;
                _poli.IsHitTestVisible = true;
                canfolha.Children.Add(_poli);
                _points.Clear();
                Canvas.SetLeft(_poli, MinX);
                Canvas.SetTop(_poli, MinY);
            }


            if (variaveis.valor_var == "ins_sha") //insere o poligon definitivo
            {
                _polig.Stroke = new SolidColorBrush(Colors.Blue);
               _polig.Fill = new SolidColorBrush(Colors.Transparent);
              _polig.StrokeThickness = 1;
                _polig.IsHitTestVisible = true;
                canfolha.Children.Add(_polig);
                _points.Clear();
                Canvas.SetLeft(_polig, MinX);
                Canvas.SetTop(_polig, MinY);

            }


            foreach (var line in canfolha.Children.OfType<Line>().ToList())// remove todas as linhas
            {
                canfolha.Children.Remove(line);
            }

        }


        private void canfolha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (variaveis.valor_var == "ins_qua") // insere o quadrado dinamico do mouse
            {
                _mDown = e.GetPosition(canfolha);
                _curShape = new Rectangle();
                _curShape.StrokeThickness = 1;
                _curShape.Stroke = Brushes.Black;
                _curShape.Fill = Brushes.Transparent;
                canfolha.Children.Add(_curShape);
                variaveis.valor_var = "ins_quaa";
            }

            if (variaveis.valor_var == "ins_cir") // insere o circulo dinamico do mouse
            {
                _mDown = e.GetPosition(canfolha);
                _curShape = new Ellipse();
                _curShape.StrokeThickness = 1;
                _curShape.Stroke = Brushes.Red;
                _curShape.Fill = Brushes.Transparent;
                canfolha.Children.Add(_curShape);
                variaveis.valor_var = "ins_cirr";
            }

            if (variaveis.valor_var == "ins_lin" || variaveis.valor_var == "ins_sha") // insere as linhas guias para o poligon e para o line essas guias serao removidas
            {
                _line = new Line();
                _line.Stroke = Brushes.Black;
                _line.StrokeThickness = 1;
                _line.X1 = _mDown.X;
                _line.Y1 = _mDown.Y;
                _line.X2 = _mDown.X;
                _line.Y2 = _mDown.Y;
                Points.Add(_mDown);
                canfolha.Children.Add(_line);
            }


        }


        #region adoner

        AdornerLayer aLayer;

        bool _isDown;
        bool _isDragging;
        bool selected = false;
        UIElement selectedElement = null;

        Point _startPoint;
        private double _originalLeft;
        private double _originalTop;

        private void form1_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += new MouseButtonEventHandler(form1_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(DragFinishedMouseHandler);
            this.MouseMove += new MouseEventHandler(form1_MouseMove);
            this.MouseLeave += new MouseEventHandler(form1_MouseLeave);

            canfolha.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(canfolha_PreviewMouseLeftButtonDown);
            canfolha.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(DragFinishedMouseHandler);
        }

        // Handler for drag stopping on leaving the window
        void form1_MouseLeave(object sender, MouseEventArgs e)
        {
            StopDragging();
            e.Handled = true;
        }
        // Handler for drag stopping on user choise
        void DragFinishedMouseHandler(object sender, MouseButtonEventArgs e)
        {
            StopDragging();
            e.Handled = true;



            if (variaveis.valor_var == "ins_quaa")// insere o quadrado
            {
                Shape temp = new Rectangle();
                temp.Stroke = Brushes.Black;
                temp.Fill = Brushes.Transparent;
                temp.StrokeThickness = 1;
                Canvas.SetLeft(temp, _curShape.Margin.Left);
                Canvas.SetTop(temp, _curShape.Margin.Top);
                temp.IsHitTestVisible = true;
                temp.Width = _curShape.Width;
                temp.Height = _curShape.Height;
                canfolha.Children.Remove(_curShape);
                canfolha.Children.Add(temp);
                variaveis.valor_var = "ins_qua"; // muda o valor da varivael para nao entrar novamente
            }

            if (variaveis.valor_var == "ins_cirr") // insere o circulo
            {
                Shape temp = new Ellipse();
                temp.Stroke = Brushes.Black;
                temp.Fill = Brushes.Transparent;
                temp.StrokeThickness = 1;
                Canvas.SetLeft(temp, _curShape.Margin.Left);
                Canvas.SetTop(temp, _curShape.Margin.Top);
                temp.IsHitTestVisible = true;
                temp.Width = _curShape.Width;
                temp.Height = _curShape.Height;
                canfolha.Children.Remove(_curShape);
                canfolha.Children.Add(temp);
                variaveis.valor_var = "ins_cir";// muda o valor da varivael para nao entrar novamente
            }
    }
        // Method for stopping dragging
        private void StopDragging()
        {
            if (_isDown)
            {
                _isDown = false;
                _isDragging = false;
            }
        }
        // Hanler for providing drag operation with selected element
        void form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(canfolha).X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(canfolha).Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                    _isDragging = true;

                if (_isDragging)
                {
                    Point position = Mouse.GetPosition(canfolha);
                    Canvas.SetTop(selectedElement, position.Y - (_startPoint.Y - _originalTop));
                    Canvas.SetLeft(selectedElement, position.X - (_startPoint.X - _originalLeft));
                }
            }
        }
        // Handler for clearing element selection, adorner removal
        void form1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selected)
            {
                selected = false;
                if (selectedElement != null)
                {
                    aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                    selectedElement = null;
                }
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {




            Shape temp = new Rectangle();
            temp.Stroke = Brushes.Black;
            temp.Fill = Brushes.Transparent;
            temp.StrokeThickness = 1;
            Canvas.SetLeft(temp, 100);
            Canvas.SetTop(temp, 100);
            temp.IsHitTestVisible = true;
            temp.Width = 100;
            temp.Height = 100;
            canfolha.Children.Remove(_curShape);
            canfolha.Children.Add(temp);
            variaveis.valor_var = "ins_qua"; // muda o valor da varivael para nao entrar novamente










            Polygon myPolygon2 = new Polygon();
            myPolygon2 = new Polygon();
            myPolygon2.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon2.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon2.StrokeThickness = 2;
            myPolygon2.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon2.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(100, 0);
            System.Windows.Point Point2 = new System.Windows.Point(75, 75);
            System.Windows.Point Point3 = new System.Windows.Point(100, 100);
            System.Windows.Point Point4 = new System.Windows.Point(125, 75);
            PointCollection myPointCollectionx = new PointCollection();
            canfolha.RenderTransform = new ScaleTransform(1, 1);
            myPolygon2.RenderTransform = null;
            Canvas.SetLeft(myPolygon2, 100);
            Canvas.SetTop(myPolygon2, 125);
            myPolygon2.IsHitTestVisible = true;
            myPolygon2.Width = 125;
            myPolygon2.Height = 100;
            myPolygon2.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform myScaleTransform = new ScaleTransform();
            myPointCollectionx.Add(Point1);
            myPointCollectionx.Add(Point2);
            myPointCollectionx.Add(Point3);
            myPointCollectionx.Add(Point4);
            myPolygon2.Width = 100;
            myPolygon2.Height = 100;
            myPolygon2.Points = myPointCollectionx;
            canfolha.Children.Add(myPolygon2);

            var dlg = new OpenFileDialog() { Filter = "JPEG(*.jpeg) | *.jpeg; | JPG(*.JPG) | *.jpg; | PNG(*.PNG) | *.png;" };
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Por favor, selecione um arquivo para abrir";
            var result = dlg.ShowDialog();
            if (result != true) return;
            var filename = dlg.FileName;


            Shape temp1 = new Rectangle
            {
                StrokeThickness = 1,
                //    Canvas.SetLeft(temp, _curShape.Margin.Left);
                //     Canvas.SetTop(temp, _curShape.Margin.Top);
                IsHitTestVisible = true,
                Width = 200,
                Height = 200,
                Stroke = new SolidColorBrush(Colors.Transparent),
                Fill = new ImageBrush(new BitmapImage(new Uri(@filename))),
            };
            Canvas.SetLeft(temp, canfolha.Height / 2);
            Canvas.SetTop(temp, canfolha.Width / 2);
            canfolha.Children.Add(temp1);
        }
       
        private void btn_fre_Click(object sender, RoutedEventArgs e)
        {
            int zIndex = 0;
            for (int i = 0; i < canfolha.Children.Count - 3; i++)
            {
                UIElement child = canfolha.Children[i] as UIElement;
                if (canfolha.Children[i] is UIElement) Canvas.SetZIndex(child, zIndex++);
            }
            Canvas.SetZIndex(variaveis.atual, zIndex + 1);
        }

        private void btn_tra_Click(object sender, RoutedEventArgs e)
        {
            int zIndex = 0;
            for (int i = 0; i < canfolha.Children.Count - 3; i++)
            {
                UIElement child = canfolha.Children[i] as UIElement;
                if (canfolha.Children[i] is UIElement) Canvas.SetZIndex(child, zIndex--);
            }
            Canvas.SetZIndex(variaveis.atual, zIndex - 1);

        }



        // Handler for element selection on the canvas providing resizing adorner
        void canfolha_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (variaveis.valor_var == "ins_lin" || variaveis.valor_var == "ins_sha") // insere as linhas guias para o poligon e para o line essas guias serao removidas
            {
                _line = new Line();
                _line.Stroke = Brushes.Black;
                _line.StrokeThickness = 1;
                _line.X1 = _mDown.X;
                _line.Y1 = _mDown.Y;
                _line.X2 = _mDown.X;
                _line.Y2 = _mDown.Y;
                Points.Add(_mDown);
                canfolha.Children.Add(_line);
            }

            if (variaveis.valor_var == "ins_qua") // insere o quadrado dinamico do mouse
            {
                _mDown = e.GetPosition(canfolha);
                _curShape = new Rectangle();
                _curShape.StrokeThickness = 1;
                _curShape.Stroke = Brushes.Black;
                _curShape.Fill = Brushes.Transparent;
                canfolha.Children.Add(_curShape);
                variaveis.valor_var = "ins_quaa";
            }

            if (variaveis.valor_var == "ins_cir") // insere o circulo dinamico do mouse
            {
                _mDown = e.GetPosition(canfolha);
                _curShape = new Ellipse();
                _curShape.StrokeThickness = 1;
                _curShape.Stroke = Brushes.Red;
                _curShape.Fill = Brushes.Transparent;
                canfolha.Children.Add(_curShape);
                variaveis.valor_var = "ins_cirr";
            }

            if (variaveis.valor_var == "mover")
            {
                //Make sure an actual object were selected. 
                if (!(e.Source is Shape))
                    return;
                if (selectedElement != null)
                {
                    // Remove the adorner from the selected element
                    aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                    selectedElement = null;
                }
                _isDown = true;
                _startPoint = e.GetPosition(canfolha);
                selectedElement = e.Source as UIElement;
                _originalLeft = Canvas.GetLeft(selectedElement);
                _originalTop = Canvas.GetTop(selectedElement);
                aLayer = AdornerLayer.GetAdornerLayer(selectedElement);
                aLayer.Add(new ResizingAdorner(selectedElement));
                selected = true;
                e.Handled = true;
                variaveis.adorners = aLayer;
                variaveis.atual = ((Shape)e.Source); //It will trigger an exception if the canvas is clicked, thus a Canvas cannot be converted into a Shape
            }
        }
        #endregion
    }
}
