using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections.Generic;

namespace DiagramDesigner
{
    public class CropThumb : Thumb
    {
        private RotateTransform rotateTransform;
        private double angle;
        private Adorner adorner;
        private Point transformOrigin;
        private FrameworkElement designerItem;
        private Canvas canvas;

        public CropThumb()
        {
            DragStarted += new DragStartedEventHandler(this.CropThumb_DragStarted);
            DragDelta += new DragDeltaEventHandler(this.CropThumb_DragDelta);
            DragCompleted += new DragCompletedEventHandler(this.CropThumb_DragCompleted);
        }

        private void CropThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.designerItem = this.DataContext as FrameworkElement;
            EnforceSize(designerItem);
            if (this.designerItem != null)
            {
                this.canvas = VisualTreeHelper.GetParent(this.designerItem) as Canvas;

                if (this.canvas != null)
                {
                    this.transformOrigin = this.designerItem.RenderTransformOrigin;

                    this.rotateTransform = this.designerItem.RenderTransform as RotateTransform;
                    if (this.rotateTransform != null)
                    {
                        this.angle = this.rotateTransform.Angle * Math.PI / 180.0;
                    }
                    else
                    {
                        this.angle = 0.0d;
                    }

                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.canvas);
                    if (adornerLayer != null)
                    {
                        this.adorner = new SizeAdorner(this.designerItem);
                        adornerLayer.Add(this.adorner);
                    }
                }
            }
        }

        private void CropThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (this.designerItem != null)
            {
                double deltaVertical, deltaHorizontal;
                double top = Canvas.GetTop(designerItem);
                double left = Canvas.GetLeft(designerItem);
                double width = designerItem.Width;
                double height = designerItem.Height;

                switch (VerticalAlignment)
                {
                    case System.Windows.VerticalAlignment.Bottom:
                        
                        deltaVertical = Math.Min(-e.VerticalChange, this.designerItem.ActualHeight - this.designerItem.MinHeight);
                        top =  Canvas.GetTop(this.designerItem) + (this.transformOrigin.Y * deltaVertical * (1 - Math.Cos(-this.angle)));
                        left = Canvas.GetLeft(this.designerItem) - deltaVertical * this.transformOrigin.Y * Math.Sin(-this.angle);
                        height -= deltaVertical;



                        break;
                    case System.Windows.VerticalAlignment.Top:
                        deltaVertical = Math.Min(e.VerticalChange, this.designerItem.ActualHeight - this.designerItem.MinHeight);
                        top = Canvas.GetTop(this.designerItem) + deltaVertical * Math.Cos(-this.angle) + (this.transformOrigin.Y * deltaVertical * (1 - Math.Cos(-this.angle)));
                        left = Canvas.GetLeft(this.designerItem) + deltaVertical * Math.Sin(-this.angle) - (this.transformOrigin.Y * deltaVertical * Math.Sin(-this.angle));
                        height -= deltaVertical;
                        break;
                    default:
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case System.Windows.HorizontalAlignment.Left:
                        deltaHorizontal = Math.Min(e.HorizontalChange, this.designerItem.ActualWidth - this.designerItem.MinWidth);
                        top = Canvas.GetTop(this.designerItem) + deltaHorizontal * Math.Sin(this.angle) - this.transformOrigin.X * deltaHorizontal * Math.Sin(this.angle);
                        left = Canvas.GetLeft(this.designerItem) + deltaHorizontal * Math.Cos(this.angle) + (this.transformOrigin.X * deltaHorizontal * (1 - Math.Cos(this.angle)));
                        width -= deltaHorizontal;
                        break;
                    case System.Windows.HorizontalAlignment.Right:
                        deltaHorizontal = Math.Min(-e.HorizontalChange, this.designerItem.ActualWidth - this.designerItem.MinWidth);
                        top = Canvas.GetTop(this.designerItem) - this.transformOrigin.X * deltaHorizontal * Math.Sin(this.angle);
                        left = Canvas.GetLeft(this.designerItem) + (deltaHorizontal * this.transformOrigin.X * (1 - Math.Cos(this.angle)));
                        this.designerItem.Width -= deltaHorizontal;
                        break;
                    default:
                        break;
                }
                RectangleGeometry g = new RectangleGeometry(new Rect(left, top, width, height));
                designerItem.Clip = g;
            }

            e.Handled = true;
        }

        private void CropThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (this.adorner != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.canvas);
                if (adornerLayer != null)
                {
                    adornerLayer.Remove(this.adorner);
                }

                this.adorner = null;
            }
        }

        void EnforceSize(FrameworkElement adornedElement) {
            if (adornedElement.Width.Equals(Double.NaN))
                adornedElement.Width = adornedElement.DesiredSize.Width;
            if (adornedElement.Height.Equals(Double.NaN))
                adornedElement.Height = adornedElement.DesiredSize.Height;

            FrameworkElement parent = adornedElement.Parent as FrameworkElement;
            if (parent != null) {
                adornedElement.MaxHeight = parent.ActualHeight;
                adornedElement.MaxWidth = parent.ActualWidth;
            }
        }
    }
}
