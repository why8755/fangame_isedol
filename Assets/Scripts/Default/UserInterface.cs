namespace GameCookInterface
{
    #region  UserInterface Element
    public enum SceneLevel
    {
        Intro,
        Title,
        PlayerSelect,
        Ine,
        JingBurger,
        Lilpa,
        Jururu,
        Gosegu,
        Vichan
    }

    public enum CharacterType
    {
        Ine,
        JingBurger,
        Lilpa,
        Jururu,
        Gosegu,
        Vichan
    }
    
    public enum CanvasType
    {
        Extra,
        Login,
        Intro,
        Lobby,
        Options,
        Dialogs,
        Score,
        Credits,
        Pause,
        Play,
        Success,
        Failure,
        Ending
    }

    public enum AudioSourceType
    {
        BGM, 
        Effect, 
        SoundEnd
    }
    public enum MusicType
    {
        None,
        Login,
        Intro,
        Lobby,
        Play,
        Success,
        Failure
    }
    public enum SoundType
    {
        None,
        ButtonNext,
        ButtonBack,
        ButtonError,
        Access,
        Success,
        Switch,
        SoundCheck,
        Click
    }
    public enum SFXType
    {
        None,
        GameStart,
        Failure,
        Success,
        HoleClickOn,
        HoleClickOff,
        HoleTeleport,
        HoleInverse,
        MoverSpawn,
        MoverCrash,
        ItemTouch,
        ItemSwitch,
        RotationPlane,
        RotationEdge,
    }
    public enum SoundEffectType
    {
        None,
        GameReady,
        Failure,
        Success,
        ClickPositive,
        ClickNegative,
        MoverSpawn,
        MoverTurn,
        MoverJump,
        MoverEnter,
        MoverCrash,
        ItemTouch,
        InformSign,
        ItemDrop,
        CoinPickup,
        CoinDrop,
        BlockDrop
    }
    #endregion
}