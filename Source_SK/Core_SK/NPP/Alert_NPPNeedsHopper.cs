using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
namespace SK_NPP
{
	public class Alert_NPPNeedsHopper : Alert_High
	{
		public override AlertReport Report
		{
			get
			{
				foreach (Building_NPP current in Find.ListerBuildings.AllBuildingsColonistOfClass<Building_NPP>())
				{
					bool flag = false;
                    ThingDef thingDef = ThingDef.Named("NuclearFeeder");
					using (IEnumerator<IntVec3> enumerator2 = GenAdj.CellsAdjacentCardinal(current).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							Thing edifice = GridsUtility.GetEdifice(enumerator2.Current);
							if (edifice != null && edifice.def == thingDef)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return AlertReport.CulpritIs(current);
					}
				}
                return AlertReport.Inactive;
			}
		}
		public Alert_NPPNeedsHopper()
		{
			this.baseLabel = Translator.Translate("NeedNuclearFeeder");
            this.baseExplanation = Translator.Translate("NeedNuclearFeederDesc");
		}
	}
}
