using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrastructureModifier 
{
    public int maxAntiVirus;
    public int maxFirewall;
    public int maxIDPS;
    public int maxBackup;


    public InfrastructureModifier(int maxAntiVirus, int maxFirewall, int maxIDPS, int maxBackup)
    {
        this.maxAntiVirus=maxAntiVirus;
        this.maxFirewall=maxFirewall;
        this.maxIDPS=maxIDPS;
        this.maxBackup=maxBackup;
    }

    public int getMaxAntivirus(){
        return maxAntiVirus;
    }

    public int getMaxFirewall(){
        return maxFirewall;
    }

    public int getMaxIDPS(){
        return maxIDPS;
    }

    public int getMaxBackups(){
        return maxBackup;
    }
}
