using RimWorld;
using Verse;

namespace Rainbeau_s_Advanced_Bridges.AdvancedBridges
{
    public class Building_WatergazingSpot : Building_WorkTable
    {
        public IntVec3 gazingSpotCell = new IntVec3(0, 0, 0);
        public override void TickRare()
        {
            base.TickRare();
            gazingSpotCell = this.Position + new IntVec3(0, 0, 0).RotatedBy(this.Rotation);
            TerrainDef terrainDef = base.Map.terrainGrid.TerrainAt(this.gazingSpotCell);
            if (!terrainDef.defName.Contains("Water") && !terrainDef.defName.Equals("Marsh") && !terrainDef.defName.Contains("Ice"))
            {
                this.Destroy();
            }
            else
            {
                TerrainDef terrainDefIS = base.Map.terrainGrid.TerrainAt(this.InteractionCell);
                if (terrainDefIS.defName.Contains("Water") || terrainDefIS.defName.Equals("Marsh"))
                {
                    if (!terrainDefIS.defName.Contains("Bridge"))
                    {
                        this.Destroy();
                    }
                }
            }
        }
    }
}
