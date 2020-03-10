using System.Collections.Generic;
using Verse;

namespace Rainbeau_s_Advanced_Bridges.AdvancedBridges
{
    public class PlaceWorker_Boardwalk : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing otherThing = null)
        {
            TerrainDef terrainDef = map.terrainGrid.TerrainAt(loc);
            if (terrainDef.defName.Contains("Bridge"))
            {
                return new AcceptanceReport("RAB.NoFloorOnBridge".Translate());
            }
            Thing thing = loc.GetFirstMineable(map);
            if (thing != null)
            {
                return "RAB.NoFloorOnBridge".Translate();
            }
            List<Thing> things = map.thingGrid.ThingsListAtFast(loc);
            for (int k = 0; k < things.Count; k++)
            {
                if (things[k] != thingToIgnore)
                {
                    if (things[k].def.defName.Contains("RBB_") || things[k].def.defName.Contains("Wall"))
                    {
                        return new AcceptanceReport("RAB.NoFloorOnBridge".Translate());
                    }
                }
            }
            if (terrainDef.defName.Equals("MarshyTerrain") || terrainDef.defName.Equals("Mud"))
            {
                return true;
            }
            bool waterNear = false;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int x = loc.x + i;
                    int z = loc.z + j;
                    IntVec3 newSpot = new IntVec3(x, 0, z);
                    string terrainCheck = map.terrainGrid.TerrainAt(newSpot).defName;
                    if (terrainCheck.Contains("Water") || terrainCheck.Equals("Marsh") || terrainCheck.Contains("BridgeMarsh") || terrainCheck.Contains("Mud") || terrainCheck.Contains("MarshyTerrain"))
                    {
                        waterNear = true;
                        break;
                    }
                }
            }
            if (waterNear)
            {
                for (int i = -2; i < 3; i++)
                {
                    for (int j = -2; j < 3; j++)
                    {
                        int x = loc.x + i;
                        int z = loc.z + j;
                        IntVec3 newSpot = new IntVec3(x, 0, z);
                        string terrainCheck = map.terrainGrid.TerrainAt(newSpot).defName;
                        if (terrainCheck.Contains("Water") || terrainCheck.Equals("Marsh") || terrainCheck.Contains("BridgeMarsh") || terrainCheck.Contains("Mud") || terrainCheck.Contains("MarshyTerrain"))
                        {
                            waterNear = true;
                            break;
                        }
                    }
                }
            }
            if (waterNear)
            {
                for (int i = -3; i < 4; i++)
                {
                    for (int j = -3; j < 4; j++)
                    {
                        int x = loc.x + i;
                        int z = loc.z + j;
                        IntVec3 newSpot = new IntVec3(x, 0, z);
                        string terrainCheck = map.terrainGrid.TerrainAt(newSpot).defName;
                        if (terrainCheck.Contains("Water") || terrainCheck.Equals("Marsh") || terrainCheck.Contains("BridgeMarsh") || terrainCheck.Contains("Mud") || terrainCheck.Contains("MarshyTerrain"))
                        {
                            waterNear = true;
                            break;
                        }
                    }
                }
            }
            if (waterNear)
            {
                return true;
            }
            return new AcceptanceReport("RAB.Boardwalk".Translate());
        }
    }
}
