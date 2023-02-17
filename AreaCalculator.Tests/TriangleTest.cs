using System;
using AreaCalculator.Shapes;
using AreaCalculator.Shapes.Interfaces;
using Xunit;

namespace AreaCalculator.Tests;

public class TriangleTest
{
    private ITriangle? _triangle;

    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(5, 5, 6, 12)]
    [InlineData(7.53, 4.67, 9.33, 17.45247260997)]
    public void ValidCalculateAreaTest(double sideA, double sideB, double sideC, double expectedArea)
    {
        _triangle = new Triangle(sideA, sideB, sideC);
        var actualArea = _triangle.CalculateArea();

        Assert.Equal(expectedArea, actualArea, 10);
    }

    [Theory]
    [InlineData(9, 12, 15)]
    [InlineData(13, 15, 19.84943324128)]
    [InlineData(4.6, 7.3, 8.62844134244)]
    public void ValidIsRightTriangle(double sideA, double sideB, double sideC)
    {
        _triangle = new Triangle(sideA, sideB, sideC);
        var isRightTriangle = _triangle.IsRightTriangle();

        Assert.True(isRightTriangle);
    }

    [Theory]
    [InlineData(9, 11, 15)]
    [InlineData(13, 16, 19.84943324128)]
    [InlineData(3.3, 7.3, 8.62844134244)]
    public void InvalidIsRightTriangle(double sideA, double sideB, double sideC)
    {
        _triangle = new Triangle(sideA, sideB, sideC);
        var isRightTriangle = _triangle.IsRightTriangle();

        Assert.False(isRightTriangle);
    }

    [Theory]
    [InlineData(2, 0, 3)]
    [InlineData(2, 5, 8)]
    [InlineData(16.53, 4.67, 9.33)]
    public void InvalidSidesTest(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
}