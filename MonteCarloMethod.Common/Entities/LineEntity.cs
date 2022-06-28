using System;

namespace MonteCarloMethod.Common.Entities
{
    public sealed class LineEntity
    {
        public PointEntity A { get; set; }
        public PointEntity B { get; set; }

        public double Length { get; set; }

        public LineEntity() { A = new PointEntity(); B = new PointEntity(); Length = 0; }
        public LineEntity(PointEntity a, PointEntity b)
        {
            A = a;
            B = b;
            Length = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }
    }
}