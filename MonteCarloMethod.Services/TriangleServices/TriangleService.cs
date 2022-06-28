using MonteCarloMethod.Common.Entities;
using System;

namespace MonteCarloMethod.Services.TriangleServices
{
    public sealed class TriangleService : ITriangleService
    {
        private TriangleEntity _triangleEntity;

        public TriangleService(TriangleEntity triangleEntity)
        {
            _triangleEntity = triangleEntity;
        }

        public double Area()
        {
            double p = Perimetr() / 2;
            return Math.Sqrt(p * (p - _triangleEntity.SideA.Length) * (p - _triangleEntity.SideB.Length) * (p - _triangleEntity.SideC.Length));
        }

        public double GetAngleA()
        {
            return _triangleEntity.AngleA;
        }

        public double GetAngleB()
        {
            return _triangleEntity.AngleB;
        }

        public double GetAngleC()
        {
            return _triangleEntity.AngleC;
        }

        public double Perimetr()
        {
            return _triangleEntity.SideA.Length + _triangleEntity.SideB.Length + _triangleEntity.SideC.Length;
        }
    }
}