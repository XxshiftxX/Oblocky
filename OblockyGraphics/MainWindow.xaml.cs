using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace OblockyGraphics
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Canvas MainCanvas;

        public List<BaseBlockControl> Blocks = new List<BaseBlockControl>();

        private bool isClicking;
        private FrameworkElement movingControl;
        private Point clickedPos;

        public MainWindow()
        {
            MainCanvas = MainCanvasControl;

            InitializeComponent();
        }

        public void CreatePrintBlock()
        {
            PrintBlockControl pb = new PrintBlockControl();

            pb.MouseDownHandler += (sender, e) =>
            {
                Debug.WriteLine(sender);
                movingControl = sender as FrameworkElement;
                clickedPos = e.GetPosition(movingControl);
                isClicking = true;
            };

            pb.MouseUpHandler += (sender, e) =>
            {
                movingControl = null;
                isClicking = false;
            };

            pb.MouseMoveHandler += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed && isClicking)
                {
                    var pos = e.GetPosition(this);

                    var transform = movingControl.RenderTransform as TranslateTransform;
                    if (transform == null)
                    {
                        transform = new TranslateTransform();
                        movingControl.RenderTransform = transform;
                    }

                    var res = pos - clickedPos;
                        
                    foreach (var b in Blocks)
                    {
                        if (b.BackgroundBorderControl == sender)
                            continue;

                        for(int i = 0; i < b.BlockSnapRanges.Count; i++)
                        {
                            if (b.BlockSnapRanges[i].range.Contains(pos))
                            {
                                Console.WriteLine($">> ({res.X}, {res.Y}) in ({b.BlockSnapRanges[i].range.X}, {b.BlockSnapRanges[i].range.Y}) <<");
                                Console.WriteLine($">> ({b.BlockSnapRanges[i].range.Height}, {b.BlockSnapRanges[i].range.Width}) <<");
                                res.X = b.BlockSnapRanges[i].point.X;
                                res.Y = b.BlockSnapRanges[i].point.Y;
                            }
                        }
                    }

                    transform.X = res.X;
                    transform.Y = res.Y;

                    return true;
                }
                return false;
            };

            Blocks.Add(pb);

            MainCanvasControl.Children.Add(pb);
        }

        private void Test_Click(object sender, RoutedEventArgs e) => CreatePrintBlock();
    }
}
