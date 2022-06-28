namespace MonteCarloMethod.Common.Entities
{
    public class PointEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointEntity() { }
        public PointEntity(int x, int y) { this.X = x; this.Y = y; }
    }
}