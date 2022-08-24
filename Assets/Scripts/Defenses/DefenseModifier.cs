using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseModifier 
{
    public float efficiency;
    public float falsePositives;
    public int duration;
    public int cost;

    public DefenseModifier(float efficiency, float falsePositives, int duration, int cost)
    {
        this.efficiency=efficiency;
        this.falsePositives=falsePositives;
        this.duration=duration;
        this.cost=cost;
    }

    public float getEfficiecy(){
        return efficiency;
    }
    public float getFalsePositives(){
        return falsePositives;
    }
    public int getDuration(){
        return duration;
    }
    public int getCost(){
        return cost;
    }

}
