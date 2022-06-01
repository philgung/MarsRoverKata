using System.Linq;

namespace MarsRoverKata
{
    public class Rover
    {
        private Point _currentPosition;
        private Direction _direction;

        public Rover(Point initialStartingPosition, Direction direction)
        {
            _currentPosition = initialStartingPosition;
            _direction = direction;
        }

        public Point GetPosition() => _currentPosition;

        public Direction GetDirection() => _direction;

        public void Move(string[] commands)
        {
            if (!commands.Any())
            {
                return;
            }

            switch (commands.First())
            {
                case "b":
                    _currentPosition = _currentPosition.MoveBackward(_direction);
                    break;
                case "l":
                    _direction = _direction.TurnLeft();
                    break;
                case "r":
                    _direction = _direction.TurnRight();
                    break;
                default:
                    _currentPosition = _currentPosition.MoveForward(_direction);
                    break;
            }
        }
    }
}