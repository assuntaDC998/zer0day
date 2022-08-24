using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ModifierJsonMap  
{
    public List<ModifierItem> modifiers;    


    public Modifier getModifierbyCID(String CID)
    {
        foreach (ModifierItem modifieritem in modifiers)
        {
            if ((!modifieritem.infinite && !modifieritem.oneshot && (modifieritem.duration <= 0))||(modifieritem.oneshot && modifieritem.infinite))
                throw new DataException("Invalid MODIFIER "+modifieritem.CID);

            if (modifieritem.CID.ToString().Equals(CID))
            {
                Debug.Log("Found MODIFIER :" + modifieritem.ToString());

                return new Modifier(modifieritem.CID, modifieritem.m_type, modifieritem.m_fFactor,modifieritem.duration,modifieritem.infinite,modifieritem.oneshot);
            }
        }
        throw new DataException("Modifier with CID " + CID + " not found");
    }
    public List<Modifier> getMoreModifiersbyCIDs(List<String> cids)
    {
        List<Modifier> newmodifiers = new List<Modifier>();

        foreach (String cid in cids)
        {
            foreach (ModifierItem modifieritem in modifiers)
            {
                if (((!modifieritem.infinite && !modifieritem.oneshot && (modifieritem.duration <= 0))) || (modifieritem.oneshot && modifieritem.infinite))
                    throw new DataException("Invalid MODIFIER with CID " + modifieritem.CID);

                if (modifieritem.CID.ToString().Equals(cid))
                {
                    Debug.Log("Found MODIFIER :" + modifieritem.ToString());


                    newmodifiers.Add( new Modifier(modifieritem.CID, modifieritem.m_type, modifieritem.m_fFactor, modifieritem.duration, modifieritem.infinite, modifieritem.oneshot));
                }
            }
        }
        if(modifiers.Count>=0)
            return newmodifiers;
        throw new DataException("no MODIFIERS were found with CIDs " + cids);
    }

    [Serializable]
    public class ModifierItem
    {
        public String CID;
        public String m_type;
        public String m_fFactor;
        public float duration;
        public bool infinite;
        public bool oneshot;

        public override string ToString()
        {
            return "CID "+CID+" TYPE "+m_type + " FACTOR "+m_fFactor+" DURATION "+duration;
        }
    }
}