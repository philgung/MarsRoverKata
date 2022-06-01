namespace MarsRoverKata
{
    public record Point(int x, int y)
    {
        private const int MaxEdge = 5;
        private const int MinEdge = 1;

        public Point MoveBackward(Direction direction)
        {
            if (direction == Direction.South)
            {
                return new Point(x, Increment(y));
            }

            if (direction == Direction.East)
            {
                return new Point(Decrement(x), y);
            }

            if (direction == Direction.West)
            {
                return new Point(Increment(x), y);
            }

            return new Point(x, Decrement(y));
        }

        public Point MoveForward(Direction direction)
        {
            if (direction == Direction.South)
            {
                return new Point(x, Decrement(y));
            }

            if (direction == Direction.East)
            {
                return new Point(Increment(x), y);
            }

            if (direction == Direction.West)
            {
                return new Point(Decrement(x), y);
            }

            return new Point(x, Increment(y));
        }

        private int Increment(int value) => value + 1 == MaxEdge + 1 ? MinEdge : value + 1;
        private int Decrement(int value) => value - 1 == MinEdge - 1 ? MaxEdge : value - 1;
    }
}