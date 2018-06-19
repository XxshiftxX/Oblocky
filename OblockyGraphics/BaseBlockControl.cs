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

namespace OblockyGraphics
{
    /// <summary>
    /// BaseBlockControl.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public delegate bool MouseEventHandler(object sender, MouseEventArgs e);

    public abstract class BaseBlockControl : UserControl
    {
        public List<(Rect range, Point point)> BlockSnapRanges = new List<(Rect, Point)>();

        public abstract Transform RenderBackground { get; }
        public Border BackgroundBorderControl { get; protected set; }

        public MouseEventHandler MouseMoveHandler;
        public MouseButtonEventHandler MouseDownHandler;
        public MouseButtonEventHandler MouseUpHandler;

        protected abstract void BackgroundMouseDown(object sender, MouseButtonEventArgs e);
        protected abstract void BackgroundMouseUp(object sender, MouseButtonEventArgs e);
        protected abstract void BackgroundMouseMove(object sender, MouseEventArgs e);
        
        protected abstract void SetSnapRanges();
    }
}
