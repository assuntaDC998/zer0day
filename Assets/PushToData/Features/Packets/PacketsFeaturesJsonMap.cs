using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MalwaresFeatures;
using PacketsFeatures;

[Serializable]
public class PacketsFeaturesJsonMap : Dictionable
{

    public int FT_VALUE;
    public int FT_WEIGHT;

    public Dictionary<System.Object, Feature> todict()
    {

        if (FT_VALUE < 0) throw new DataException("Packet value could not be negative");
        if (FT_WEIGHT < 0) throw new DataException("Packet weight could not be negative");


        Dictionary<System.Object, Feature> newDict = new Dictionary<System.Object, Feature>();
        newDict.Add(PacketFeature.FeatureType.FT_VALUE, new ValuePacketFeature(FT_VALUE, PacketFeature.FeatureType.FT_VALUE));
        newDict.Add(PacketFeature.FeatureType.FT_WEIGHT, new WeightPacketFeature(FT_WEIGHT, PacketFeature.FeatureType.FT_WEIGHT));
        
        return newDict;
    }

}
