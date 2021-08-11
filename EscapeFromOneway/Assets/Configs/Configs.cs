using UnityEngine;

class Config
{
    // Todo: Edit
    public static float DefaultMainCameraPositionZ = -10f;
}

class PlayerControlConfig
{
    public static float PlayerFallingGravity = 7.5f;
}

class GameConstructorConfig
{
    public static float TileSizeOffset = 3f;
    public static float DelayTimeOnSuccess = 1f;
    public static float DelayTimeOnFalling = 0.5f;
    public static float DelayTimeOnFailed = 1.7f;

    public static byte[] MainCameraBackgroundColor = {90, 140, 190, 255};
}

class MapConstructorConfig
{
    public static int xStackLimit = 4;
    public static int yStackLimit = 10;
    public static string DefaultParentGameObjectName = "MapObjects";
    public static bool CanGenBackwardPath = false; // RandomCanGenBackwardPath
    public static float TileTransparentParam = 0.35f;
    public static float TileMoveDownParam = 0.15f;

}

class StageConstructorConfig
{
    public static float ButtonSize = 100f;
    public static float ButtonMargin = 50f;
    public static string[] DefaultUnlockedStages = {"1"};
}

class AudioSourceConfig
{
    public static float DefaultWindSound = 0.1f;
    public static float MaxWindSound = 0.2f;
    public static float DeltaWindSoundRange = 0.01f;

    public static float PlayerOnFallingSoundVolume = 0.3f;
    public static float PlayerOnDieSoundVolume = 0.3f;
    public static float PlayerOnSuccessVolume = 0.3f;
    public static float PlayerOnMoveSoundVolume = 0.2f;
    public static float PlayerOnDieSoundTiming = 0.5f;

    public static float TransformDefaultPositionZ = 0;
}
