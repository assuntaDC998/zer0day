using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PacketsFeatures
{
    public abstract class PacketFeature : Feature
    {
        public enum FeatureType
        {
            FT_VALUE,
            FT_WEIGHT
        }

        public PacketFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {
        }
    }

    public class ValuePacketFeature : PacketFeature
    {
        public ValuePacketFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {

        }

        public override void performeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue + int.Parse(m.m_fFactor);

        }

        public override void removeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue - int.Parse(m.m_fFactor);

        }
        public override void applyFactor(System.Object factor)
        {
            this.currentValue = (int)this.baseValue + (int)factor;
        }

        public override System.Object updateFactor(System.Object factor)
        {
            return (int)factor + (int)currentValue;
        }

        public override System.Object initializeFactor()
        {
            return 0;
        }
    }
    public class WeightPacketFeature : PacketFeature
    {
        public WeightPacketFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
        {
        }

        public override void performeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue + int.Parse(m.m_fFactor);

        }

        public override void removeModifier(Modifier m)
        {
            this.currentValue = (int)currentValue - int.Parse(m.m_fFactor);

        }
        public override void applyFactor(System.Object factor)
        {
            this.currentValue = (int)this.baseValue + (int)factor;
        }

        public override System.Object updateFactor(System.Object factor)
        {
            return (int)factor + (int)currentValue;
        }

        public override System.Object initializeFactor()
        {
            return 0;
        }
    }
  

}