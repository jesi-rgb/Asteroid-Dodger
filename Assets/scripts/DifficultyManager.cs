using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager
{
    static float maxDifficultyTime = 60; //seconds

    public static float getDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / maxDifficultyTime);
    }


}