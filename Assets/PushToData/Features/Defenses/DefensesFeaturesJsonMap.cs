using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DefensesFeatures;

[Serializable]
public class DefensesFeaturesJsonMap: Dictionable
{

    public float FT_EFFICIENCY;
    public float FT_FALSE_POSITIVES;
    public int FT_DURATION;
    public int FT_COST;

    public Dictionary<System.Object, Feature> todict()
    {

        if (FT_EFFICIENCY < 0) throw new DataException("Efficiency could not be negative");
        if (FT_FALSE_POSITIVES < 0) throw new DataException("False Positives rate could not be negative");
        if (FT_DURATION < 0) throw new DataException("Duration could not be negative ");
        if (FT_COST < 0) throw new DataException("Cost could not be negative ");


        Dictionary<System.Object, Feature> newDict = new Dictionary<System.Object, Feature>();
        newDict.Add(DefenseFeature.FeatureType.FT_EFFICIENCY, new EfficiencyDefenseFeature(FT_EFFICIENCY, DefenseFeature.FeatureType.FT_EFFICIENCY));
        newDict.Add(DefenseFeature.FeatureType.FT_FALSE_POSITIVES, new FalsePositivesDefenseFeature(FT_FALSE_POSITIVES, DefenseFeature.FeatureType.FT_FALSE_POSITIVES));
        newDict.Add(DefenseFeature.FeatureType.FT_DURATION, new DurationDefenseFeature(FT_DURATION, DefenseFeature.FeatureType.FT_DURATION));
        newDict.Add(DefenseFeature.FeatureType.FT_COST, new CostDefenseFeature(FT_COST, DefenseFeature.FeatureType.FT_COST));

        return newDict;
    }

}
