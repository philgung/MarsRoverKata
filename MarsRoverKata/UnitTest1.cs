using FluentAssertions;
using Xunit;
using static MarsRoverKata.DirectionEnum;

namespace MarsRoverKata
{
    public class Tests
    {
        [Theory]
        [InlineData(North, 2, 3)]
        [InlineData(South, 2, 1)]
        [InlineData(East, 3, 2)]
        [InlineData(West, 1, 2)]
        public void MoveForward(DirectionEnum directionEnum, int x, int y)
        {
            var rover = new Rover(new Point(2, 2), new Direction(directionEnum));

            rover.Move(new[] {"f"});

            rover.GetPosition().Should().Be(new Point(x, y));
        }

        [Theory]
        [InlineData(North, 2, 1)]
        [InlineData(South, 2, 3)]
        [InlineData(East, 1, 2)]
        [InlineData(West, 3, 2)]
        public void MoveBackward(DirectionEnum directionEnum, int x, int y)
        {
            var rover = new Rover(new Point(2, 2), new Direction(directionEnum));

            rover.Move(new[] {"b"});

            rover.GetPosition().Should().Be(new Point(x, y));
        }

        [Theory]
        [InlineData(North, West)]
        [InlineData(West, South)]
        [InlineData(South, East)]
        [InlineData(East, North)]
        public void TurnLeft(DirectionEnum direction, DirectionEnum expectedDirection)
        {
            var rover = new Rover(new Point(1, 1), new Direction(direction));
            
            rover.Move(new []{ "l" });

            rover.GetDirection().Should().Be(new Direction(expectedDirection));
        }

        [Theory]
        [InlineData(North, East)]
        [InlineData(West, South)]
        [InlineData(South, West)]
        [InlineData(East, North)]
        public void TurnRight(DirectionEnum direction, DirectionEnum expectedDirection)
        {
            var rover = new Rover(new Point(1, 1), new Direction(direction));
            
            rover.Move(new []{ "r" });

            rover.GetDirection().Should().Be(new Direction(expectedDirection));
        }

        [Theory]
        [InlineData("f", 1, 1, West)]
        [InlineData("b", 1, 1, East)]
        public void ConnectLeftEdge(string command, int x, int y, DirectionEnum direction)
        {
            var rover = new Rover(new Point(x, y), new Direction(direction));
            
            rover.Move(new [] {command});

            rover.GetPosition().Should().Be(new Point(5, 1));
        }

        [Theory]
        [InlineData("f", 5, 1, East)]
        [InlineData("b", 5, 1, West)]
        public void ConnectRightEdge(string command, int x, int y, DirectionEnum direction)
        {
            var rover = new Rover(new Point(x, y), new Direction(direction));
            
            rover.Move(new []{ command });

            rover.GetPosition().Should().Be(new Point(1, 1));
        }
        

        [Theory]
        [InlineData("f", 1, 5, North)]
        [InlineData("b", 1, 5, South)]
        public void ConnectTopEdge(string command, int x, int y, DirectionEnum direction)
        {
            var rover = new Rover(new Point(x, y), new Direction(direction));
            
            rover.Move(new []{ command });

            rover.GetPosition().Should().Be(new Point(1, 1));
        }

        [Theory]
        [InlineData("f", 1, 1, South)]
        [InlineData("b", 1, 1, North)]
        public void ConnectBottomEdge(string command, int x, int y, DirectionEnum direction)
        {
            var rover = new Rover(new Point(x, y), new Direction(direction));
            
            rover.Move(new []{ command });

            rover.GetPosition().Should().Be(new Point(1, 5));
        }
    }
}