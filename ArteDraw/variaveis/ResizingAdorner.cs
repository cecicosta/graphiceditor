﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace ArteDraw
{
    public class ResizingAdorner : Adorner
    {
        // Resizing adorner uses Thumbs for visual elements.  
        // The Thumbs have built-in mouse input handling.
        Thumb topLeft, topRight, bottomLeft, bottomRight, center;

        // To store and manage the adorner's visual children.
        VisualCollection visualChildren;

        // Initialize the ResizingAdorner.
        public ResizingAdorner(UIElement adornedElement)
            : base(adornedElement)
        {                
            visualChildren = new VisualCollection(this);

            // Call a helper method to initialize the Thumbs
            // with a customized cursors.
            BuildAdornerCorner(ref topLeft, Cursors.SizeNWSE);
            BuildAdornerCorner(ref topRight, Cursors.SizeNESW);
            BuildAdornerCorner(ref bottomLeft, Cursors.SizeNESW);
            BuildAdornerCorner(ref bottomRight, Cursors.SizeNWSE);
            BuildAdornerCorner(ref center, Cursors.UpArrow);


            // Add handlers for resizing.
            bottomLeft.DragDelta += new DragDeltaEventHandler(HandleBottomLeft);
            bottomRight.DragDelta += new DragDeltaEventHandler(HandleBottomRight);
            topLeft.DragDelta += new DragDeltaEventHandler(HandleTopLeft);
            topRight.DragDelta += new DragDeltaEventHandler(HandleTopRight);
            center.DragDelta += new DragDeltaEventHandler(HandleTopRight);

        }
        

        // Handler for resizing from the bottom-right.
        void HandleBottomRight(object sender, DragDeltaEventArgs args){

	        FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
	        Thumb hitThumb = sender as Thumb;

	        if (adornedElement == null || hitThumb == null) return;
	        FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

	        // Ensure that the Width and Height are properly initialized after the resize.
	        EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.

            ScaleTransform s = adornedElement.RenderTransform as ScaleTransform;
            s = s == null ? new ScaleTransform() : s;
            //Matrix m = new Matrix();
            //m.Scale(((adornedElement.Width + args.HorizontalChange) / adornedElement.Width) * Math.Sign(s.ScaleX),
            //        ((adornedElement.Height + args.VerticalChange) / adornedElement.Height) * Math.Sign(s.ScaleY));
            ////Canvas.SetLeft(adornedElement, (adornedElement.Width + args.HorizontalChange) / 2);
            ////Canvas.SetTop(adornedElement, (adornedElement.Height + args.VerticalChange) / 2);
            //MatrixTransform t = new MatrixTransform(m);
            //adornedElement.RenderTransform = t;



            ////s.ScaleX = ((adornedElement.Width + args.HorizontalChange) / adornedElement.Width)*Math.Sign(s.ScaleX);
            //////s.ScaleY *= (adornedElement.Height + args.VerticalChange) / adornedElement.Height;
            ////adornedElement.RenderTransform = s;

            ////System.Console.WriteLine("scale X: " + s.ScaleX);
            ////System.Console.WriteLine("width: " + adornedElement.Width);
            ////System.Console.WriteLine("drag: " + args.HorizontalChange);

            ////TranslateTransform t = adornedElement.RenderTransform as TranslateTransform;
            ////t = t == null ? new TranslateTransform(): t;
            //////t.X = Canvas.GetLeft(adornedElement) + adornedElement.Width * s.ScaleX / 2;

            //adornedElement.RenderTransform = s;

            if (s == null || s.ScaleX > 0) {
                adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            } else if (s.ScaleX < 0) {
                Canvas.SetLeft(adornedElement, Canvas.GetLeft(adornedElement) - args.HorizontalChange);
                adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            }

            if (s == null || s.ScaleY > 0) {
                adornedElement.Height = Math.Max(args.VerticalChange + adornedElement.Height, hitThumb.DesiredSize.Height);
            } else {
                double oldHeight = adornedElement.Height;
                adornedElement.Height = Math.Max((adornedElement.Height + args.VerticalChange), hitThumb.DesiredSize.Height);
                Canvas.SetTop(adornedElement, Canvas.GetTop(adornedElement) + (oldHeight - adornedElement.Height));
            }
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
            } else if (s.ScaleX < 0) {
                adornedElement.Width = Math.Max((adornedElement.Width - args.HorizontalChange), hitThumb.DesiredSize.Width);
            }

            if (s == null || s.ScaleY > 0) {
                double oldHeight = adornedElement.Height;
                adornedElement.Height = Math.Max((adornedElement.Height - args.VerticalChange), hitThumb.DesiredSize.Height);
                Canvas.SetTop(adornedElement, Canvas.GetTop(adornedElement) + (oldHeight - adornedElement.Height));

            } else {
                adornedElement.Height = Math.Max(adornedElement.Height - args.VerticalChange, hitThumb.DesiredSize.Height);
            }
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
            cornerThumb.Background = new SolidColorBrush(Colors.MediumBlue);

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
