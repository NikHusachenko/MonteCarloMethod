using MonteCarloMethod.Common.Entities;

namespace MonteCarloMethod.Services.LineServices
{
    public interface ILineService
    {
        PointEntity GetPointA();

        PointEntity GetPointB();

        PointEntity GetMiddlePoint();
    }
}