using MonteCarloMethod.Common.Entities;
using System.Collections.Generic;

namespace MonteCarloMethod.Services.PolygonServices
{
    public interface IPolygonService
    {
        void Add(PointEntity pointEntity);

        bool IsInside(PointEntity point);

        double FindArea();

        double TriangleMethod(PointEntity insidePoint);

        double MonteCarlo(List<PointEntity> points, double canvasArea);
    }
}
