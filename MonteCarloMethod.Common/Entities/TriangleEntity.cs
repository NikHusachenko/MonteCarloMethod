using System;

namespace MonteCarloMethod.Common.Entities
{
    public sealed class TriangleEntity
    {
        /*
                    A
                    /\
                   /  \
                c /    \ b
                 /      \ 
                /________\
               B     a    C
        */

        public PointEntity A { get; set; }
        public PointEntity B { get; set; }
        public PointEntity C { get; set; }

        public LineEntity SideA { get; set; } // B -- C
        public LineEntity SideB { get; set; } // A -- C
        public LineEntity SideC { get; set; } // A -- B
        
        public double AngleA { get; set; }
        public double AngleB { get; set; }
        public double AngleC { get; set; }
        
        public TriangleEntity(PointEntity a, PointEntity b, PointEntity c)
        {
            A = a;
            B = b;
            C = c;

            SideA = new LineEntity(B, C);
            SideB = new LineEntity(A, C);
            SideC = new LineEntity(A, B);

            AngleA = Math.Acos((Math.Pow(SideB.Length, 2) + Math.Pow(SideC.Length, 2) - Math.Pow(SideA.Length, 2)) / (2 * SideB.Length * SideC.Length)) * 180 / Math.PI;
            AngleB = Math.Acos((Math.Pow(SideA.Length, 2) + Math.Pow(SideC.Length, 2) - Math.Pow(SideB.Length, 2)) / (2 * SideA.Length * SideC.Length)) * 180 / Math.PI;
            AngleC = Math.Acos((Math.Pow(SideA.Length, 2) + Math.Pow(SideB.Length, 2) - Math.Pow(SideC.Length, 2)) / (2 * SideA.Length * SideB.Length)) * 180 / Math.PI;
        }
        public TriangleEntity(LineEntity a, LineEntity b, LineEntity c)
        {
            SideA = a;
            SideB = b;
            SideC = c;

            A = SideB.A;
            B = SideA.A;
            C = SideA.B;

            AngleA = Math.Acos((Math.Pow(SideB.Length, 2) + Math.Pow(SideC.Length, 2) - Math.Pow(SideA.Length, 2)) / (2 * SideB.Length * SideC.Length)) * 180 / Math.PI;
            AngleB = Math.Acos((Math.Pow(SideA.Length, 2) + Math.Pow(SideC.Length, 2) - Math.Pow(SideB.Length, 2)) / (2 * SideA.Length * SideC.Length)) * 180 / Math.PI;
            AngleC = Math.Acos((Math.Pow(SideA.Length, 2) + Math.Pow(SideB.Length, 2) - Math.Pow(SideC.Length, 2)) / (2 * SideA.Length * SideB.Length)) * 180 / Math.PI;
        }
    }
}