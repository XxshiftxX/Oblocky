using System;
using System.Windows.Input;
using System.Windows.Controls;
using Oblocky;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace OblockyGraphics
{
    /// <summary>
    /// PrintBlockControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PrintBlockControl : BaseBlockControl
    {
        public PrintBlockControl()
        {
            Block = new PrintBlock();
            InitializeComponent();
            BackgroundBorderControl = BackgroundBorder;
            SetSnapRanges();
        }

        public PrintBlock Block { get; set; }

        public override Transform RenderBackground => BackgroundBorder.RenderTransform;

        protected override void BackgroundMouseDown(object sender, MouseButtonEventArgs e)
        {
            var handler = MouseDownHandler;
            handler?.Invoke(sender, e);
        }

        protected override void BackgroundMouseUp(object sender, MouseButtonEventArgs e)
        {
            var handler = MouseUpHandler;
            handler?.Invoke(sender, e);
        }

        protected override void BackgroundMouseMove(object sender, MouseEventArgs e)
        {
            var handler = MouseMoveHandler;
            var res = handler?.Invoke(sender, e);

            if (res.HasValue && res.Value)
                SetSnapRanges();
        }

        protected override void SetSnapRanges()
        {
            var transform = RenderBackground as TranslateTransform;

            if (transform == null)
            {
                transform = new TranslateTransform();
                RenderTransform = transform;
            }


            var temp = new Rect(transform.X, transform.Y + ActualHeight - 5, ActualWidth, 10);
            try { BlockSnapRanges[0] = (temp, new Point(transform.X, transform.Y + ActualHeight)); }
            catch (ArgumentOutOfRangeException) { BlockSnapRanges.Add((temp, new Point(transform.X, transform.Y + ActualHeight))); }
        }
    }
}
