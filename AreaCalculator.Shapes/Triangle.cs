using AreaCalculator.Shapes.Interfaces;

namespace AreaCalculator.Shapes;

public class Triangle : ITriangle
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    private const double Precision = 1e-10;

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        CheckTriangleExistence();
    }

    public double CalculateArea()
    {
        var p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    public bool IsRightTriangle()
    {
        var sides = new List<double> { SideA, SideB, SideC };
        var hypotenuse = sides.Max();
        var sumTwoLegs = sides.Where(side => side < hypotenuse)
            .Sum(side => Math.Pow(side, 2));

        return Math.Abs(Math.Pow(hypotenuse, 2) - sumTwoLegs) < Precision;
    }

    private void CheckTriangleExistence()
    {
        if (SideA + SideB <= SideC || SideA + SideC <= SideB || SideB + SideC <= SideA)
            throw new ArgumentException("Incorrect triangle side values");
    }
}