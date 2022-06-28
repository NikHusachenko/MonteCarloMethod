using MonteCarloMethod.Common.Entities;
using MonteCarloMethod.Services.PolygonServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MonteCarloMethod.Main.Drawing
{
    internal sealed class DrawPolygon : IDrawPolygon
    {
        private readonly InkCanvas _inkCanvas;
        public readonly PolygonService _polygonService;

        public DrawPolygon(InkCanvas inkCanvas, 
            PolygonService polygonService)
        {
            _inkCanvas = inkCanvas;
            _polygonService = polygonService;
        }

        public void AddPoint(PointEntity point)
        {
            _polygonService.Add(point);

            _inkCanvas.Children.Add(new Rectangle()
            {
                Height = 2,
                Width = 2,

                Margin = new Thickness(point.X, point.Y, 0, 0),

                Fill = Brushes.Black,
            });

            if (_polygonService.Polygon.Points.Count < 2)
                return;

            if (_inkCanvas.Children.Count >= 4)
            {
                _inkCanvas.Children.RemoveAt(_inkCanvas.Children.Count - 2);
            }

            Line line = new Line()
            {
                X1 = _polygonService.Polygon.Points[_polygonService.Polygon.Points.Count - 2].X,
                Y1 = _polygonService.Polygon.Points[_polygonService.Polygon.Points.Count - 2].Y,

                X2 = _polygonService.Polygon.Points[_polygonService.Polygon.Points.Count - 1].X,
                Y2 = _polygonService.Polygon.Points[_polygonService.Polygon.Points.Count - 1].Y,

                Stroke = Brushes.Black,
            };

            _inkCanvas.Children.Add(line);

            line = new Line()
            {
                X1 = _polygonService.Polygon.Points[_polygonService.Polygon.Points.Count - 1].X,
                Y1 = _polygonService.Polygon.Points[_polygonService.Polygon.Points.Count - 1].Y,

                X2 = _polygonService.Polygon.Points[0].X,
                Y2 = _polygonService.Polygon.Points[0].Y,

                Stroke = Brushes.Black,
            };

            _inkCanvas.Children.Add(line);
        }
    }
}
