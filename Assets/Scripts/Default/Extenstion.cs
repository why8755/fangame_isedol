using UnityEngine;
namespace GameCookInterface
{
    public static class EnumTypeExtension
    {
        public static int SceneToIndex(this SceneLevel scene)
        {
            switch (scene)
            {
                default:
                    return 0;
                case SceneLevel.Intro:
                    return 1;

            }
        }
        public static int AxisToIndex(this DirectionAxis axis)
        {
            switch (axis)
            {
                case DirectionAxis.xDirection:
                    return 0;
                case DirectionAxis.yDirection:
                    return 1;
                case DirectionAxis.zDirection:
                    return 2;
                default:
                    Debug.LogWarning("invaild axis values");
                    return -1;
            }
        }

        public static int CanvasTypeToIndex(this CanvasType canvasType)
        {
            switch (canvasType)
            {
                default:
                    return 0;
                case CanvasType.Login:
                    return 1;
                case CanvasType.Intro:
                    return 2;
                case CanvasType.Lobby:
                    return 3;
                case CanvasType.Options:
                    return 4;
                case CanvasType.Score:
                    return 5;
                case CanvasType.Credits:
                    return 6;
                case CanvasType.Pause:
                    return 7;
                case CanvasType.Play:
                    return 8;
                case CanvasType.Success:
                    return 9;
                case CanvasType.Failure:
                    return 10;
                case CanvasType.Ending:
                    return 11;
            }
        }

        public static int MusicTypeToIndex(this MusicType musicType)
        {
            switch (musicType)
            {
                default:
                    return 0;
                case MusicType.Login:
                    return 1;
                case MusicType.Intro:
                    return 2;
                case MusicType.Lobby:
                    return 3;
                case MusicType.Play:
                    return 4;
                case MusicType.Success:
                    return 5;
                case MusicType.Failure:
                    return 6;
            }
        }
        public static int SoundTypeToIndex(this SoundType soundType)
        {
            switch (soundType)
            {
                default:
                    return 0;
                case SoundType.ButtonNext:
                    return 1;
                case SoundType.ButtonBack:
                    return 2;
                case SoundType.ButtonError:
                    return 3;
                case SoundType.Access:
                    return 4;
                case SoundType.Success:
                    return 5;
                case SoundType.Switch:
                    return 6;
                case SoundType.SoundCheck:
                    return 7;
                case SoundType.Click:
                    return 8;
            }
        }
        public static int SoundEffectTypeToIndex(this SoundEffectType soundEffectType)
        {
            switch (soundEffectType)
            {
                default:
                    return 0;
                case SoundEffectType.GameReady:
                    return 1;
                case SoundEffectType.Failure:
                    return 2;
                case SoundEffectType.Success:
                    return 3;
                case SoundEffectType.ClickPositive:
                    return 4;
                case SoundEffectType.ClickNegative:
                    return 5;
                case SoundEffectType.MoverSpawn:
                    return 6;
                case SoundEffectType.MoverTurn:
                    return 7;
                case SoundEffectType.MoverJump:
                    return 8;
                case SoundEffectType.MoverEnter:
                    return 9;
                case SoundEffectType.MoverCrash:
                    return 10;
                case SoundEffectType.ItemTouch:
                    return 11;
                case SoundEffectType.InformSign:
                    return 12;
                case SoundEffectType.ItemDrop:
                    return 13;
                case SoundEffectType.CoinPickup:
                    return 14;
                case SoundEffectType.CoinDrop:
                    return 15;
                case SoundEffectType.BlockDrop:
                    return 16;
            }
        }
    }
}