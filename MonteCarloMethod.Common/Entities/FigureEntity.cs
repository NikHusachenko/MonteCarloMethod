using System.Collections.Generic;

namespace MonteCarloMethod.Common.Entities
{
    public sealed class FigureEntity<T> where T : PointEntity
    {
        public List<PointEntity> Points { get; set; }

        public FigureEntity()
        {
            Points = new List<PointEntity>();
        }
    }
}
