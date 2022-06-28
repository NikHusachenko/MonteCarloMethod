using System.Collections.Generic;

namespace MonteCarloMethod.Common.Entities
{
    public sealed class PolygonEntity
    {
        public List<PointEntity> Points { get; set; }

        public PolygonEntity() { Points = new List<PointEntity>(); }
    }
}
