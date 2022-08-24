using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InfrastructuresFeatures
{
	public abstract class InfrastructureFeature : Feature
	{	public enum FeatureType 
        {
			FT_MAX_ANTIVIRUS,
            FT_MAX_FIREWALL,
            FT_MAX_IDPS,
            FT_MAX_BACKUP
		}

		public InfrastructureFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
		{
		}
	}

	public class MaxAntiVirusInfrastructureFeature : InfrastructureFeature
    {
        public MaxAntiVirusInfrastructureFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
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
    public class MaxFirewallInfrastructureFeature : InfrastructureFeature
    {
        public MaxFirewallInfrastructureFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
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
    public class MaxIDPSInfrastructureFeature : InfrastructureFeature
    {
        public MaxIDPSInfrastructureFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
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
    public class MaxBackupInfrastructureFeature : InfrastructureFeature
    {
        public MaxBackupInfrastructureFeature(System.Object baseValue, FeatureType featureName) : base(baseValue, featureName)
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