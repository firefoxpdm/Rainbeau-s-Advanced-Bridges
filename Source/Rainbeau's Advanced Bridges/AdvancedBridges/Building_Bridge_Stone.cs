using Verse;

namespace Rainbeau_s_Advanced_Bridges.AdvancedBridges
{
    public class Building_Bridge_Stone : Building
    {
        public string TerrainTypeAtBaseCellDefAsString;
        public override void Destroy(DestroyMode mode = 0)
        {
            base.Map.snowGrid.SetDepth(base.Position, 0f);
            if (this.TerrainTypeAtBaseCellDefAsString != null)
            {
                base.Map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named(this.TerrainTypeAtBaseCellDefAsString));
            }
            base.Destroy(mode);
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<string>(ref this.TerrainTypeAtBaseCellDefAsString, "TerrainTypeAtBaseCellDefAsString", null, false);
        }
        public override void SpawnSetup(Map map, bool flag)
        {
            base.SpawnSetup(map, flag);
            TerrainDef terrainDef = map.terrainGrid.TerrainAt(base.Position);
            if (!terrainDef.defName.Contains("Bridge") && !terrainDef.defName.Contains("Floor") && !terrainDef.defName.Contains("Carpet")
              && !terrainDef.defName.Contains("Tile") && !terrainDef.defName.Contains("Flagstone") && !terrainDef.defName.Contains("Concrete"))
            {
                this.TerrainTypeAtBaseCellDefAsString = terrainDef.ToString();
                if (terrainDef == TerrainDef.Named("WaterShallow"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterShallow"));
                }
                else if (terrainDef == TerrainDef.Named("WaterOceanShallow"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterOceanShallow"));
                }
                else if (terrainDef == TerrainDef.Named("WaterMovingShallow"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterMovingShallow"));
                }
                else if (terrainDef == TerrainDef.Named("WaterMovingChestDeep"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterMovingChestDeep"));
                }
                else if (terrainDef == TerrainDef.Named("WaterDeep"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterDeep"));
                }
                else if (terrainDef == TerrainDef.Named("WaterOceanDeep"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterOceanDeep"));
                }
                else if (terrainDef == TerrainDef.Named("Marsh"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeMarsh"));
                }
                else if (terrainDef == TerrainDef.Named("Mud"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeMud"));
                }
                else if (terrainDef == TerrainDef.Named("Sand"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeSand"));
                }
                else if (terrainDef == TerrainDef.Named("MarshyTerrain"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeMarshyTerrain"));
                }
                else if (terrainDef == TerrainDef.Named("Ice"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeIce"));
                }
                else if (terrainDef.defName == "IceST" || terrainDef.defName == "IceS")
                {
                    this.TerrainTypeAtBaseCellDefAsString = "WaterShallow";
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterShallow"));
                }
                else if (terrainDef.defName == "IceDT" || terrainDef.defName == "IceD")
                {
                    this.TerrainTypeAtBaseCellDefAsString = "WaterDeep";
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterDeep"));
                }
                else if (terrainDef.defName == "IceSMT" || terrainDef.defName == "IceSM")
                {
                    this.TerrainTypeAtBaseCellDefAsString = "WaterMovingShallow";
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterMovingShallow"));
                }
                else if (terrainDef.defName == "IceDMT" || terrainDef.defName == "IceDM")
                {
                    this.TerrainTypeAtBaseCellDefAsString = "WaterMovingChestDeep";
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeWaterMovingChestDeep"));
                }
                else if (terrainDef.defName == "IceMarshT" || terrainDef.defName == "IceMarsh")
                {
                    this.TerrainTypeAtBaseCellDefAsString = "Marsh";
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeMarsh"));
                }
                else if (terrainDef.defName.Contains("Water"))
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("BridgeWaterShallow"));
                }
                else
                {
                    map.terrainGrid.SetTerrain(base.Position, TerrainDef.Named("StoneBridgeLand"));
                }
            }
        }
    }
}
