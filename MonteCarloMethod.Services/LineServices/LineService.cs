using MonteCarloMethod.Common.Entities;
using System;

namespace MonteCarloMethod.Services.LineServices
{
    public sealed class LineService : ILineService
    {
        private LineEntity _lineEntity;

        public LineService(LineEntity lineEntity)
        {
            _lineEntity = lineEntity;
        }

        public PointEntity GetMiddlePoint()
        {
            return new PointEntity()
            {
                X = (_lineEntity.A.X + _lineEntity.B.X) / 2,
                Y = (_lineEntity.A.Y + _lineEntity.B.Y) / 2
            };
        }
        
        public PointEntity GetPointA()
        {
            return this._lineEntity.A;
        }

        public PointEntity GetPointB()
        {
            return this._lineEntity.B;
        }
    }
}