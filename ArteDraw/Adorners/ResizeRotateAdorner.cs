using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DiagramDesigner
{
    public class ResizeRotateAdorner : Adorner
    {
        private VisualCollection visuals;
        private ResizeRotateChrome chrome;

        protected override int VisualChildrenCount
        {
            get
            {
                return this.visuals.Count;
            }
        }

        protected override void OnRender(DrawingContext drawingContext) {
            base.OnRender(drawingContext);
            UIElement designerItem = chrome.DataContext as UIElement;
            DrawingBrush b = new DrawingBrush();
            Pen p = new Pen();
            p.Thickness = 5;
            if(designerItem.Clip != null)
                drawingContext.DrawRectangle(b, p, designerItem.Clip.Bounds);

        }

        public ResizeRotateAdorner(UIElement designerItem)
            : base(designerItem)
        {
            SnapsToDevicePixels = true;
            this.chrome = new ResizeRotateChrome();
            this.chrome.DataContext = designerItem;
            this.visuals = new VisualCollection(this);
            this.visuals.Add(this.chrome);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            this.chrome.Arrange(new Rect(arrangeBounds));
            return arrangeBounds;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.visuals[index];
        }
    }
}
