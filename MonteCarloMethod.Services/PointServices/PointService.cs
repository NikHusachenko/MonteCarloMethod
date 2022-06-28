using MonteCarloMethod.Common.Entities;
using System;

namespace MonteCarloMethod.Services.PointServices
{
    public sealed class PointService : IPointService
    {
        private PointEntity _pointEntity;

        public PointService(PointEntity pointEntity)
        {
            this._pointEntity = pointEntity;
        }

        public double Distance()
        {
            return Math.Sqrt(Math.Pow(_pointEntity.X, 2) + Math.Pow(_pointEntity.Y, 2));
        }
    }
}