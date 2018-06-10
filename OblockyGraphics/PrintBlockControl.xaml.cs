using System;
using System.Windows.Input;
using System.Windows.Controls;
using Oblocky;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Threading;

namespace OblockyGraphics
{
    /// <summary>
    /// PrintBlockControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PrintBlockControl : UserControl
    {
        private bool isClicked;
        private Thickness clickedMargin;
        private Point clickedPos;

        private DispatcherTimer timer = new DispatcherTimer();

        public PrintBlockControl()
        {
            Block = new PrintBlock();
            InitializeComponent();
        }

        public PrintBlock Block { get; set; }

        private void BackgroundMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("클맄ㅋ");
            Debug.WriteLine(Parent as UIElement);
            isClicked = true;
            clickedPos = e.GetPosition(Parent as UIElement);
            clickedMargin = Margin;
        }

        private void BorderMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isClicked = false;
            var dc = sender as UserControl;
        }

        private void BackgroundMouseMove(object sender, MouseEventArgs e)
        {
            if(isClicked)
            {
                var pos = e.GetPosition(this);
                var res = pos - clickedPos;
                Margin = new Thickness(clickedMargin.Left + res.X, clickedMargin.Top + res.Y, clickedMargin.Right, clickedMargin.Bottom);
            }
        }
    }
}
