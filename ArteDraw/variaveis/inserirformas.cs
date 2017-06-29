using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ArteDraw
{
    public class inserirformas
    {


        public void inseir_quadrado2()
        {
            Polygon myPolygon2 = new Polygon();
            myPolygon2 = new Polygon();
            myPolygon2.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon2.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon2.StrokeThickness = 2;
   //         myPolygon2.HorizontalAlignment = HorizontalAlignment.Left;
    //        myPolygon2.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(100, 0);
            System.Windows.Point Point2 = new System.Windows.Point(75, 75);
            System.Windows.Point Point3 = new System.Windows.Point(100, 100);
            System.Windows.Point Point4 = new System.Windows.Point(125, 75);
            PointCollection myPointCollectionx = new PointCollection();
            myPointCollectionx.Add(Point1);
            myPointCollectionx.Add(Point2);
            myPointCollectionx.Add(Point3);
            myPointCollectionx.Add(Point4);
            myPolygon2.Points = myPointCollectionx;
          // form1.mycanvas.Children.Add(myPolygon2);
        }
    }
}
