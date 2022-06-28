using MonteCarloMethod.Common.Entities;
using MonteCarloMethod.Services.TriangleServices;
using System;
using System.Collections.Generic;

namespace MonteCarloMethod.Services.PolygonServices
{
    public sealed class PolygonService : IPolygonService
    {
        public PolygonEntity Polygon { get; set; }

        public PolygonService(PolygonEntity polygonEntity)
        {
            Polygon = polygonEntity;
        }

        public void Add(PointEntity pointEntity)
        {
            Polygon.Points.Add(pointEntity);
        }

        // Remake this !!
        public double FindArea()
        {
            List<PointEntity> Points = Polygon.Points;

            double xProduct = 1;
            for (int i = 0; i < Points.Count - 1; i++)
            {
                xProduct += Points[i].X * Points[i + 1].Y;
            }
            xProduct += Points[Points.Count - 1].X * Points[0].Y;

            double yProduct = 1;
            for (int i = 0; i < Points.Count - 1; i++)
            {
                yProduct += Points[i].Y * Points[i + 1].X;
            }
            yProduct += Points[Points.Count - 1].Y * Points[0].X;

            return Math.Abs(yProduct - xProduct) / 2;
        }

        public bool IsInside(PointEntity point)
        {
            TriangleService triangleService = default;
            List<PointEntity> Points = Polygon.Points;
            double angleSum = default;

            for (int i = 0; i < Points.Count - 1; i++)
            {
                triangleService = new TriangleService(new TriangleEntity(
                    Points[i], point, Points[i + 1]));
                angleSum += triangleService.GetAngleB();
            }

            triangleService = new TriangleService(new TriangleEntity(
                    Points[Points.Count - 1], point, Points[0]));
            angleSum += triangleService.GetAngleB();

            if (angleSum < 359 || angleSum > 361)
                return false;
            else
                return true;
        }

        // S / L == M / N
        // S == L * M / N
        // S -> Find this
        // L -> InkCanvas area
        // M -> Count of all point
        // N -> Count of point which entry inside of polygon
        public double MonteCarlo(List<PointEntity> points, double canvasArea)
        {
            List<PointEntity> insidePoints = new List<PointEntity>();

            for (int i = 0; i < points.Count; i++)
            {
                if (IsInside(points[i]))
                {
                    insidePoints.Add(points[i]);
                }
            }

            double area = canvasArea * insidePoints.Count / points.Count;
            return area;
        }

        public double TriangleMethod(PointEntity insidePoint)
        {
            if (!IsInside(insidePoint))
                return 0;

            TriangleService triangleService = default;
            double area = default;

            for (int i = 0; i < Polygon.Points.Count - 1; i++)
            {
                triangleService = new TriangleService(new TriangleEntity(
                    Polygon.Points[i], insidePoint, Polygon.Points[i + 1]));
                area += triangleService.Area();
            }

            triangleService = new TriangleService(new TriangleEntity(
                    Polygon.Points[Polygon.Points.Count - 1], insidePoint, Polygon.Points[0]));
            area += triangleService.Area();
            
            return area;
        }
    }
}
