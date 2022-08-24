using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using InfrastructuresFeatures;

[Serializable]
public class InfrastructuresFeaturesJsonMap:Dictionable
{

    public int FT_MAX_ANTIVIRUS;
    public int FT_MAX_FIREWALL;
    public int FT_MAX_IDPS;
    public int FT_MAX_BACKUP;


    public Dictionary<System.Object, Feature> todict()
    {

        if (FT_MAX_BACKUP < 0 ) throw new DataException("Max backups number couldn't be negative");
        if (FT_MAX_ANTIVIRUS < 0 ) throw new DataException("Max antiviruses number couldn't be negative");
        if (FT_MAX_IDPS < 0 ) throw new DataException("Max IDPS number couldn't be negative");
        if (FT_MAX_FIREWALL < 0 ) throw new DataException("Max firewalls number couldn't be negative");


        Dictionary<System.Object, Feature> newDict = new Dictionary<System.Object, Feature>();
        newDict.Add(InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS, new MaxAntiVirusInfrastructureFeature(FT_MAX_ANTIVIRUS, InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS));
        newDict.Add(InfrastructureFeature.FeatureType.FT_MAX_FIREWALL, new MaxFirewallInfrastructureFeature(FT_MAX_FIREWALL, InfrastructureFeature.FeatureType.FT_MAX_FIREWALL));
        newDict.Add(InfrastructureFeature.FeatureType.FT_MAX_IDPS, new MaxIDPSInfrastructureFeature(FT_MAX_IDPS, InfrastructureFeature.FeatureType.FT_MAX_IDPS));
        newDict.Add(InfrastructureFeature.FeatureType.FT_MAX_BACKUP, new MaxBackupInfrastructureFeature(FT_MAX_ANTIVIRUS, InfrastructureFeature.FeatureType.FT_MAX_ANTIVIRUS));

        return newDict;
    }

}
