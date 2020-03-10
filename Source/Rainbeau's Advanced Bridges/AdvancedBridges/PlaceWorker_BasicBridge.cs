using System.Collections.Generic;
using Verse;

namespace Rainbeau_s_Advanced_Bridges.AdvancedBridges
{
    public class PlaceWorker_BasicBridge : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            TerrainDef terrainDef = map.terrainGrid.TerrainAt(loc);
            if (terrainDef.defName == "MarshyTerrain" || terrainDef.defName == "WaterMovingChestDeep")
            {
                return new AcceptanceReport("RAB.BasicBridge".Translate());
            }
            List<Thing> things = map.thingGrid.ThingsListAtFast(loc);
            for (int j = 0; j < things.Count; j++)
            {
                if (things[j] != thingToIgnore)
                {
                    if (things[j].def.defName == "RBB_FishingSpot")
                    {
                        return new AcceptanceReport("RAB.NotOnFS".Translate());
                    }
                }
            }
            return true;
        }
    }
}
