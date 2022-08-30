using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class LevelsJsonMap
{
    public List<Level> levels;

    public Level GetLevelByID(int id)
    {
        foreach (Level l in levels)
        {
            if (l.levelID == id) {
                return l;
            }
        }
        
        return null;
    }


    public override String ToString() {
        String str = "";
        foreach(Level l in levels)
            str += l.ToString() + "\n"; 
        return str;
    }


}

[Serializable]
public class Level
{
    public int levelID;
    public int targetGB;
    public int initialCoins;
    public int maxBackups;


    public override string ToString()
    {
        return "LID: " + levelID + " - TargetGB: " + targetGB + " - Coins: " + initialCoins + " - Backup: " + maxBackups;
    }

}
