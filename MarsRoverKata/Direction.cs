namespace MarsRoverKata
{
    public record Direction
    {
        private readonly DirectionEnum _direction;
        public static Direction North = new(DirectionEnum.North);
        public static Direction South = new(DirectionEnum.South);
        public static Direction West = new(DirectionEnum.West);
        public static Direction East = new(DirectionEnum.East);

        public Direction(DirectionEnum direction)
        {
            _direction = direction;
        }

        public Direction TurnRight()
        {
            return _direction switch
            {
                DirectionEnum.North => East,
                DirectionEnum.West => South,
                DirectionEnum.South => West,
                _ => North
            };
        }

        public Direction TurnLeft()
        {
            return _direction switch
            {
                DirectionEnum.North => West,
                DirectionEnum.West => South,
                DirectionEnum.South => East,
                _ => North
            };
        }
    }
}