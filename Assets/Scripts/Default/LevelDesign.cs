namespace GameCookInterface
{
    #region  level Design Element

    public enum SmoothType
    {
        SmootherStep,
        SoSmootherStep,
        EaseOutWithSin,
        EaseInWithCos,
        Exponential
    }
    public enum GameMode
    {
        Easy,
        Hard,
    }
    public enum DirectionAxis
    {
        xDirection,
        yDirection,
        zDirection
    };
    public enum Identifier
    {
        Positive,
        Negative
    }
    public enum PlaneChildItem
    {
        None,
        Coin,
        Clockwise,
        CounterClockwise,
        Slash,
        BackSlash,
        Interation_Positive,
        Interation_Negative,
    }

    public enum PlaneItemType
    {
        Interaction,
        Consumption,
        Direction,
    }
    #endregion

    #region movement
    public enum MoverType
    {
        Lizard,
        Wolf,
    }
    public enum SensorType
    {
        Hole = 9,
        Plane = 10,
        Rotator = 11
    }
    public enum ActionState
    {
        Jumping,
        hitting,
        Waitng
    }
    #endregion
}