using System.Collections.Generic;
using Verse;

namespace Rainbeau_s_Advanced_Bridges.AdvancedBridges
{
    public class PlaceWorker_FloorBase : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            TerrainDef terrainDef = map.terrainGrid.TerrainAt(loc);
            if (terrainDef.defName.Equals("Mud"))
            {
                return new AcceptanceReport("TerrainCannotSupport".Translate());
            }
            List<Thing> things = map.thingGrid.ThingsListAtFast(loc);
            for (int k = 0; k < things.Count; k++)
            {
                if (things[k] != thingToIgnore)
                {
                    if (things[k].def.defName.Contains("RBB_") && things[k].def.defName.Contains("Bridge"))
                    {
                        return new AcceptanceReport("RAB.NoFloorOnBridge".Translate());
                    }
                }
            }
            return true;
        }
    }
}
