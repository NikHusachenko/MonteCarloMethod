using MonteCarloMethod.Common.Entities;
using MonteCarloMethod.Main.Drawing;
using MonteCarloMethod.Services.PolygonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MonteCarloMethod.Main
{
    public partial class MainWindow : Window
    {
        private DrawPolygon _drawPolygon;
        private PolygonService _polygonService;
        List<PointEntity> _pointEntities;
        private bool _drawMode;

        public MainWindow()
        {
            _polygonService = new PolygonService(new PolygonEntity());

            InitializeComponent();
        }

        private void SelectAccuracy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SelectAccuracy.Value = (int)SelectAccuracy.Value;
            AccuracyValueOutputLabel.Content = SelectAccuracy.Value;

            for (int i = _polygonService.Polygon.Points.Count * 2; i < DrawingInkCanvas.Children.Count; i++)
                DrawingInkCanvas.Children.RemoveAt(i);

            RectangleDrawing();
            WriteResult();
        }

        private void SelectAccuracy_Loaded(object sender, RoutedEventArgs e)
        {
            SelectAccuracy.ValueChanged += SelectAccuracy_ValueChanged;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            _drawMode = !_drawMode;

            if (_drawMode)
            {
                DrawingInkCanvas.Children.Clear();
                _polygonService = new PolygonService(new PolygonEntity());
                _drawPolygon = new DrawPolygon(DrawingInkCanvas, _polygonService);

                DrawButton.Content = "Stop drawing";
            }

            if (!_drawMode)
            {
                DrawButton.Content = "Start drawing";

                RectangleDrawing();
                WriteResult();
                WriteRealArea();
            }
        }

        private void DrawingInkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!_drawMode)
                return;
            
            MouseEventArgs mouseEvent = e as MouseEventArgs;

            PointEntity point = new PointEntity()
            {
                X = (int)mouseEvent.GetPosition(this).X,
                Y = (int)mouseEvent.GetPosition(this).Y,
            };

            _drawPolygon.AddPoint(point);
        }

        private Rectangle RectanglePointBuilder(double startX, double startY)
        {
            Rectangle rectangle = new Rectangle()
            {
                Height = 2,
                Width = 2,

                Margin = new Thickness(startX, startY, 0, 0),

                Fill = Brushes.Black,
            };

            return rectangle;
        }

        private void DrawingInkCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            _drawPolygon = new DrawPolygon(DrawingInkCanvas, _polygonService);
        }

        private double RectangleDrawing()
        {
            if (!_drawMode)
            {
                DrawButton.Content = "Start drawing";

                if (DrawingInkCanvas.Children.Count >= 3)
                {
                    _pointEntities = new List<PointEntity>();
                    for (int i = 0; i < SelectAccuracy.Value * 100; i++)
                    {
                        _pointEntities.Add(new PointEntity()
                        {
                            X = new Random().Next(0, (int)ImageContainer.Width),
                            Y = new Random().Next(0, (int)ImageContainer.Height),
                        });

                        DrawingInkCanvas.Children.Add(RectanglePointBuilder(_pointEntities[i].X, _pointEntities[i].Y));
                    }

                    return _polygonService.MonteCarlo(_pointEntities, (int)(ImageContainer.Width * ImageContainer.Height));
                }
            }

            return 0;
        }

        private void WriteResult()
        {
            string accuracyOutput = default;
            foreach (char sym in AreaResultLabel.Content.ToString())
            {
                if (sym == '=')
                    break;

                accuracyOutput += sym.ToString();
            }

            AreaResultLabel.Content = $"{accuracyOutput}= {RectangleDrawing()}";
        }

        private void WriteRealArea()
        {
            string accuracyOutput = default;
            foreach (char sym in RealAreaLabel.Content.ToString())
            {
                if (sym == '=')
                    break;

                accuracyOutput += sym.ToString();
            }

            RealAreaLabel.Content = $"{accuracyOutput}= {_polygonService.TriangleMethod(FindInsidePoint())}";
        }

        private PointEntity FindInsidePoint()
        {
            foreach(PointEntity point in _pointEntities)
            {
                if (_polygonService.IsInside(point))
                    return point;
            }
            return null;
        }
    }
}