using System;
using System.Collections.Generic;
using Xunit;
using MartianRobots.Domain;
using System.Linq;

namespace Tests
{
    public class SurfaceTests
    {
        [Fact]
        public void WhenPositionIsOutTheBoundsIsDetectedAsInvalid()
        {
            var surface = new Surface(new Coordinates(5, 5));
            Assert.False(surface.IsValidPosition(new Coordinates(5, 6)));
            Assert.False(surface.IsValidPosition(new Coordinates(6, 5)));
            Assert.False(surface.IsValidPosition(new Coordinates(6, 6)));
            Assert.False(surface.IsValidPosition(new Coordinates(5, -1)));
            Assert.False(surface.IsValidPosition(new Coordinates(-1, 5)));
        }

        [Fact]
        public void WhenScentIsAddedCoordinateIsSetWithScent()
        {
            var surface = new Surface(new Coordinates(5, 5));
            surface.AddScent(new Coordinates(1, 1));
            Assert.True(surface.PositionHasScent(new Coordinates(1, 1)));
        }

    }
}
