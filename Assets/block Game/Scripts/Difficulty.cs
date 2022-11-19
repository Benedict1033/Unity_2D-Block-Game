using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public static class Difficulty
{
    static float seccondsToMaxDiffulty =60;

    public static float GetDiffcultyPercent ( )
    {
        return Mathf. Clamp01 ( Time.timeSinceLevelLoad/seccondsToMaxDiffulty );
    }

}
