using MonteCarloMethod.Common.Entities;

namespace MonteCarloMethod.Services.TriangleServices
{
    public interface ITriangleService
    {
        double GetAngleA();

        double GetAngleB();

        double GetAngleC();

        double Area();

        double Perimetr();
    }
}
