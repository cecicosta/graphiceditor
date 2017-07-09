using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace ArteDraw
{
    public class RotateAdorner : Adorner
    {
        // Resizing adorner uses Thumbs for visual elements.  
        // The Thumbs have built-in mouse input handling.
        Thumb topLeft, topRight, bottomLeft, bottomRight, center;
        double top, bottom, left, right;
        double width, height;
        bool mouseUp = true;

        // To store and manage the adorner's visual children.
        VisualCollection visualChildren;

        // Initialize the ResizingAdorner.
        public RotateAdorner(UIElement adornedElement)
            : base(adornedElement)
        {                
            visualChildren = new VisualCollection(this);

            // Call a helper method to initialize the Thumbs
            // with a customized cursors.
            BuildAdornerCorner(ref topLeft, Cursors.Cross);
            BuildAdornerCorner(ref topRight, Cursors.Cross);
            BuildAdornerCorner(ref bottomLeft, Cursors.Cross);
            BuildAdornerCorner(ref bottomRight, Cursors.Cross);
            BuildAdornerCorner(ref center, Cursors.UpArrow);
            

            // Add handlers for rotating.
            bottomLeft.DragDelta += new DragDeltaEventHandler(HandleBottomLeft);
            bottomRight.DragDelta += new DragDeltaEventHandler(HandleBottomRight);
            topLeft.DragDelta += new DragDeltaEventHandler(HandleTopLeft);
            topRight.DragDelta += new DragDeltaEventHandler(HandleTopRight);
            center.DragDelta += new DragDeltaEventHandler(HandleTopRight);

        }

        private void MouseDownHandler(Object sender, MouseButtonEventArgs args) {
            if (!mouseUp)
                return;
            left = Canvas.GetLeft(AdornedElement);
            right = Canvas.GetRight(AdornedElement);
            top = Canvas.GetTop(AdornedElement);
            bottom = Canvas.GetBottom(AdornedElement);

            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            width = adornedElement.Width;
            height = adornedElement.Height;
            mouseUp = false;
        }

        private void MouseUpHandler(Object sender, MouseButtonEventArgs args) {
            if (mouseUp)
                return;
            mouseUp = true;
        }
        // A common way to implement an adorner's rendering behavior is to override the OnRender
        // method, which is called by the layout system as part of a rendering pass.
        protected override void OnRender(DrawingContext drawingContext) {

            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

            drawingContext.DrawRectangle(Brushes.Transparent, null, adornedElementRect);

            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 5.0;

            //// Draw a circle at each corner.
            //drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
            //drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
            //drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
            //drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        }

        // Handler for resizing from the bottom-right.
        void HandleBottomRight(object sender, DragDeltaEventArgs args){


            RotateTransform r = new RotateTransform();
            r = r == null ? new RotateTransform() : r;
            r.Angle = Math.Sqrt(Math.Pow(args.VerticalChange,2) + Math.Pow(args.HorizontalChange,2))* 
            Math.Sign(args.HorizontalChange*args.VerticalChange);

            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
	        Thumb hitThumb = sender as Thumb;
            

	        if (adornedElement == null || hitThumb == null) return;
	        FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

	        // Ensure that the Width and Height are properly initialized after the resize.
	        EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.

            adornedElement.RenderTransform = r;
        }

        // Handler for resizing from the top-right.
        void HandleTopRight(object sender, DragDeltaEventArgs args) {
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

            // Ensure that the Width and Height are properly initialized after the resize.
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.
            ScaleTransform s = variaveis.atual.RenderTransform as ScaleTransform;
            if (s == null || s.ScaleX > 0) {
                adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            } else if (s.ScaleX < 0) {
                Canvas.SetLeft(adornedElement, Canvas.GetLeft(adornedElement) - args.HorizontalChange);
                adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            }

            if (s == null || s.ScaleY > 0) {
                double oldHeight = adornedElement.Height;
                adornedElement.Height = Math.Max((adornedElement.Height - args.VerticalChange), hitThumb.DesiredSize.Height);
                Canvas.SetTop(adornedElement, Canvas.GetTop(adornedElement) + (oldHeight - adornedElement.Height));
                
            } else {
                adornedElement.Height = Math.Max(adornedElement.Height - args.VerticalChange, hitThumb.DesiredSize.Height);
            }
        }

        // Handler for resizing from the top-left.
        void HandleTopLeft(object sender, DragDeltaEventArgs args)
        {
            if (mouseUp)
                return;
            FrameworkElement adornedElement = AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;

            // Ensure that the Width and Height are properly initialized after the resize.
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.
            ScaleTransform s = variaveis.atual.RenderTransform as ScaleTransform;
            RotateTransform r = variaveis.atual.RenderTransform as RotateTransform;
            r = r == null ? new RotateTransform() : r;
            Point axisX = r.Transform((new Point(1,0)));
            Point axisY = r.Transform((new Point(0,1)));

            System.Console.WriteLine("horizonta: " + args.HorizontalChange);

            double dotPX = axisX.X*args.HorizontalChange;
            double dotPY = axisY.X*args.HorizontalChange;

            System.Console.WriteLine("px: " + dotPX);
            System.Console.WriteLine("py: " + dotPY);

            Point W = new Point( axisX.X * (dotPX), axisX.Y * (dotPX));
            double Wdist = Math.Sqrt(Math.Pow(W.X, 2) + Math.Pow(W.Y, 2))* Math.Sign(-dotPX);
            System.Console.WriteLine("wdist: " + Wdist);

            Point H = new Point(axisY.X * (dotPY), axisY.Y * (dotPY));
            double Hdist = Math.Sqrt(Math.Pow(H.X, 2) + Math.Pow(H.Y, 2)) * Math.Sign(-dotPY);
            System.Console.WriteLine("Hdist: " + Hdist);

            //
            Vector v1 = new Vector(W.X, W.Y);
            Vector v2 = new Vector(H.X, H.Y);
            Vector resultante = Vector.Add(v1, v2);
            double dotPCanonX = resultante.X;
            double dotPCanonY = resultante.Y;

            System.Console.WriteLine("canonx: " + dotPCanonX);
            System.Console.WriteLine("canony: " + dotPCanonY);


            if (s == null || s.ScaleX > 0) {
                adornedElement.Width = width + Wdist;
                adornedElement.Height = height + Hdist;
                Canvas.SetLeft(adornedElement, left + dotPCanonX);
                Canvas.SetTop(adornedElement, top + dotPCanonY);
            } else if (s.ScaleX < 0) {
                //adornedElement.Width = Math.Max((adornedElement.Width + Wdist), hitThumb.DesiredSize.Width);

            }

            //if (s == null || s.ScaleY > 0) {
            //    double oldHeight = adornedElement.Height;
            //    adornedElement.Height = Math.Max((adornedElement.Height - vertical), hitThumb.DesiredSize.Height);
            //    Canvas.SetTop(adornedElement, Canvas.GetTop(adornedElement) + (oldHeight - adornedElement.Height));

            //} else {
            //    adornedElement.Height = Math.Max(adornedElement.Height - vertical, hitThumb.DesiredSize.Height);
            //}
        }

        // Handler for resizing from the bottom-left.
        void HandleBottomLeft(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            // Ensure that the Width and Height are properly initialized after the resize.
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.
            ScaleTransform s = variaveis.atual.RenderTransform as ScaleTransform;

			if (s == null || s.ScaleX > 0) {
				double oldWidth = adornedElement.Width;
				adornedElement.Width = Math.Max((adornedElement.Width - args.HorizontalChange), hitThumb.DesiredSize.Width);
				Canvas.SetLeft(adornedElement, Canvas.GetLeft(adornedElement) + (oldWidth - adornedElement.Width));
			}else if(s.ScaleX < 0) {
                adornedElement.Width = Math.Max((adornedElement.Width - args.HorizontalChange), hitThumb.DesiredSize.Width);
            }

            if (s == null || s.ScaleY > 0) {
                adornedElement.Height = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height);
            } else {
                double oldHeight = adornedElement.Height;
                adornedElement.Height = Math.Max((adornedElement.Height + args.VerticalChange), hitThumb.DesiredSize.Height);
                Canvas.SetTop(adornedElement, Canvas.GetTop(adornedElement) + (oldHeight - adornedElement.Height));
            }
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform) {
            FrameworkElement e = (Application.Current.MainWindow as FrameworkElement);
            FrameworkElement adorneElement = AdornedElement as FrameworkElement;
            ScaleTransform s = adorneElement.RenderTransform as ScaleTransform;
            s = s == null ? new ScaleTransform() : s;
            RotateTransform r = adorneElement.RenderTransform as RotateTransform;
            r = r == null ? new RotateTransform() : r;
            MatrixTransform m = new MatrixTransform();
            
            Point center = TransformToAncestor(e).Transform(new Point(ActualWidth / 2, ActualHeight / 2));
            System.Console.WriteLine("x: " + center.X + ", Y: " + center.Y );
            System.Console.WriteLine("Angle: " + r.Angle);
            if (visualChildren != null) {
                //m.Matrix.Scale(1 / s.ScaleX, 1 / s.ScaleY);
                m.Matrix.Rotate(-r.Angle);
                
                foreach (Thumb thumb in visualChildren) {
                    thumb.RenderTransform = new RotateTransform(-r.Angle, center.X, center.Y);
                    thumb.RenderTransformOrigin = new Point(0.5, 0.5);
                }
            }
            return base.GetDesiredTransform(transform);
        }

        // Arrange the Adorners.
        protected override Size ArrangeOverride(Size finalSize)
        {
            // desiredWidth and desiredHeight are the width and height of the element that's being adorned.  
            // These will be used to place the ResizingAdorner at the corners of the adorned element.  
            double desiredWidth = AdornedElement.DesiredSize.Width;
            double desiredHeight = AdornedElement.DesiredSize.Height;
            // adornerWidth & adornerHeight are used for placement as well.
            double adornerWidth = this.DesiredSize.Width;
            double adornerHeight = this.DesiredSize.Height;

            topLeft.Arrange(new Rect(-adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight));
            topRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight));
            bottomLeft.Arrange(new Rect(-adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));
            bottomRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));

            // Return the final size.
            return finalSize;
        }

        // Helper method to instantiate the corner Thumbs, set the Cursor property, 
        // set some appearance properties, and add the elements to the visual tree.
        void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor)
        {
            if (cornerThumb != null) return;

            cornerThumb = new Thumb();

            // Set some arbitrary visual characteristics.
            cornerThumb.Cursor = customizedCursor;
            cornerThumb.Height = cornerThumb.Width = 10;
            cornerThumb.Opacity = 0.40;
            cornerThumb.Background = new SolidColorBrush(Colors.Transparent);
            cornerThumb.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(MouseDownHandler);
            cornerThumb.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(MouseUpHandler);


            visualChildren.Add(cornerThumb);
        }

        // This method ensures that the Widths and Heights are initialized.  Sizing to content produces
        // Width and Height values of Double.NaN.  Because this Adorner explicitly resizes, the Width and Height
        // need to be set first.  It also sets the maximum size of the adorned element.
        void EnforceSize(FrameworkElement adornedElement)
        {
            if (adornedElement.Width.Equals(Double.NaN))
                adornedElement.Width = adornedElement.DesiredSize.Width;
            if (adornedElement.Height.Equals(Double.NaN))
                adornedElement.Height = adornedElement.DesiredSize.Height;

            FrameworkElement parent = adornedElement.Parent as FrameworkElement;
            if (parent != null)
            {
                adornedElement.MaxHeight = parent.ActualHeight;
                adornedElement.MaxWidth = parent.ActualWidth;
            }
        }
        // Override the VisualChildrenCount and GetVisualChild properties to interface with 
        // the adorner's visual collection.
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
    }
}
