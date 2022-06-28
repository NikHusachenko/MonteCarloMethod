using MonteCarloMethod.Common.Entities;
using System.Windows.Controls;

namespace MonteCarloMethod.Main.Drawing
{
    public interface IDrawPolygon
    {
        void AddPoint(PointEntity point);
    }
}
