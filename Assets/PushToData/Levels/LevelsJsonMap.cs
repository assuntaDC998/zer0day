using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class LevelsJsonMap
{
    public List<Level> levels;

    public Level getLevelbyID(int levelID)
    {
        foreach (Level l in levels)
        {
            if (l.levelID == levelID)
            {
                return l;
            }
        }
        return null;
    }


}

[Serializable]
public class Level
{
    public int levelID;
    public int dataToComplete;
    public int initalCoins;

}
