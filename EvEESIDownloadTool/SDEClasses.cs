using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EvEESIDownloadTool
{
	public class SDEDataBaseClass
	{
		public string Lines()
		{
			return this.ToString();
		}
	}
	public class AgtAgents : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "agentID")]
		public int AgentID { get; set; }
		[JsonProperty(PropertyName = "divisionID")]
		public int DivisionID { get; set; }
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "locationID")]
		public int LocationID { get; set; }
		[JsonProperty(PropertyName = "level")]
		public int Level { get; set; }
		[JsonProperty(PropertyName = "quality")]
		public int Quality { get; set; }
		[JsonProperty(PropertyName = "agentTypeID")]
		public int AgentTypeID { get; set; }
		[JsonProperty(PropertyName = "isLocator")]
		public int IsLocator { get; set; }
	}
	public class AgtAgentTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "agentTypeID")]
		public int AgentTypeID { get; set; }
		[JsonProperty(PropertyName = "agentType")]
		public string AgentType { get; set; }
	}
	public class AgtResearchAgents : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "agentID")]
		public int AgentID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
	}
	public class CertCerts : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "certID")]
		public int CertID { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "groupID")]
		public int GroupID { get; set; }
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
	public class CertMasteries : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "masteryLevel")]
		public int MasteryLevel { get; set; }
		[JsonProperty(PropertyName = "certID")]
		public int CertID { get; set; }
	}
	public class CertSkills : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "certID")]
		public int CertID { get; set; }
		[JsonProperty(PropertyName = "skillID")]
		public int SkillID { get; set; }
		[JsonProperty(PropertyName = "certLevelInt")]
		public int CertLevelInt { get; set; }
		[JsonProperty(PropertyName = "skillLevel")]
		public int SkillLevel { get; set; }
		[JsonProperty(PropertyName = "certLevelText")]
		public string CertLevelText { get; set; }
	}
	public class ChrAncestries : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "ancestryID")]
		public int AncestryID { get; set; }
		[JsonProperty(PropertyName = "ancestryName")]
		public string AncestryName { get; set; }
		[JsonProperty(PropertyName = "bloodlineID")]
		public int BloodlineID { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "perception")]
		public int Perception { get; set; }
		[JsonProperty(PropertyName = "willpower")]
		public int Willpower { get; set; }
		[JsonProperty(PropertyName = "charisma")]
		public int Charisma { get; set; }
		[JsonProperty(PropertyName = "memory")]
		public int Memory { get; set; }
		[JsonProperty(PropertyName = "intelligence")]
		public int Intelligence { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "shortDescription")]
		public string ShortDescription { get; set; }
	}
	public class ChrAttributes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "attributeID")]
		public int AttributeID { get; set; }
		[JsonProperty(PropertyName = "attributeName")]
		public string AttributeName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "shortDescription")]
		public string ShortDescription { get; set; }
		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }
	}
	public class ChrBloodlines : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "bloodlineID")]
		public int BloodlineID { get; set; }
		[JsonProperty(PropertyName = "bloodlineName")]
		public string BloodlineName { get; set; }
		[JsonProperty(PropertyName = "raceID")]
		public int RaceID { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "maleDescription")]
		public string MaleDescription { get; set; }
		[JsonProperty(PropertyName = "femaleDescription")]
		public string FemaleDescription { get; set; }
		[JsonProperty(PropertyName = "shipTypeID")]
		public int ShipTypeID { get; set; }
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "perception")]
		public int Perception { get; set; }
		[JsonProperty(PropertyName = "willpower")]
		public int Willpower { get; set; }
		[JsonProperty(PropertyName = "charisma")]
		public int Charisma { get; set; }
		[JsonProperty(PropertyName = "memory")]
		public int Memory { get; set; }
		[JsonProperty(PropertyName = "intelligence")]
		public int Intelligence { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "shortDescription")]
		public string ShortDescription { get; set; }
		[JsonProperty(PropertyName = "shortMaleDescription")]
		public string ShortMaleDescription { get; set; }
		[JsonProperty(PropertyName = "shortFemaleDescription")]
		public string ShortFemaleDescription { get; set; }
	}
	public class ChrFactions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "factionID")]
		public int FactionID { get; set; }
		[JsonProperty(PropertyName = "factionName")]
		public string FactionName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "raceIDs")]
		public int RaceIDs { get; set; }
		[JsonProperty(PropertyName = "solarSystemID")]
		public int SolarSystemID { get; set; }
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "sizeFactor")]
		public int SizeFactor { get; set; }
		[JsonProperty(PropertyName = "stationCount")]
		public int StationCount { get; set; }
		[JsonProperty(PropertyName = "stationSystemCount")]
		public int StationSystemCount { get; set; }
		[JsonProperty(PropertyName = "militiaCorporationID")]
		public int? MilitiaCorporationID { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
	}
	public class ChrRaces : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "raceID")]
		public int RaceID { get; set; }
		[JsonProperty(PropertyName = "raceName")]
		public string RaceName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "shortDescription")]
		public string ShortDescription { get; set; }
	}
	public class CrpActivities : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "activityName")]
		public string ActivityName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
	}
	public class CrpNPCCorporationDivisions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "divisionID")]
		public int DivisionID { get; set; }
		[JsonProperty(PropertyName = "size")]
		public int Size { get; set; }
	}
	public class CrpNPCCorporationResearchFields : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "skillID")]
		public int SkillID { get; set; }
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
	}
	public class CrpNPCCorporations : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "size")]
		public string Size { get; set; }
		[JsonProperty(PropertyName = "extent")]
		public string Extent { get; set; }
		[JsonProperty(PropertyName = "solarSystemID")]
		public int? SolarSystemID { get; set; }
		[JsonProperty(PropertyName = "investorID1")]
		public int? InvestorID1 { get; set; }
		[JsonProperty(PropertyName = "investorShares1")]
		public int InvestorShares1 { get; set; }
		[JsonProperty(PropertyName = "investorID2")]
		public int? InvestorID2 { get; set; }
		[JsonProperty(PropertyName = "investorShares2")]
		public int InvestorShares2 { get; set; }
		[JsonProperty(PropertyName = "investorID3")]
		public int? InvestorID3 { get; set; }
		[JsonProperty(PropertyName = "investorShares3")]
		public int InvestorShares3 { get; set; }
		[JsonProperty(PropertyName = "investorID4")]
		public int? InvestorID4 { get; set; }
		[JsonProperty(PropertyName = "investorShares4")]
		public int InvestorShares4 { get; set; }
		[JsonProperty(PropertyName = "friendID")]
		public int? FriendID { get; set; }
		[JsonProperty(PropertyName = "enemyID")]
		public int? EnemyID { get; set; }
		[JsonProperty(PropertyName = "publicShares")]
		public int PublicShares { get; set; }
		[JsonProperty(PropertyName = "initialPrice")]
		public int InitialPrice { get; set; }
		[JsonProperty(PropertyName = "minSecurity")]
		public int MinSecurity { get; set; }
		[JsonProperty(PropertyName = "scattered")]
		public int Scattered { get; set; }
		[JsonProperty(PropertyName = "fringe")]
		public int Fringe { get; set; }
		[JsonProperty(PropertyName = "corridor")]
		public int Corridor { get; set; }
		[JsonProperty(PropertyName = "hub")]
		public int Hub { get; set; }
		[JsonProperty(PropertyName = "border")]
		public int Border { get; set; }
		[JsonProperty(PropertyName = "factionID")]
		public int? FactionID { get; set; }
		[JsonProperty(PropertyName = "sizeFactor")]
		public float? SizeFactor { get; set; }
		[JsonProperty(PropertyName = "stationCount")]
		public int? StationCount { get; set; }
		[JsonProperty(PropertyName = "stationSystemCount")]
		public int? StationSystemCount { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
	}
	public class CrpNPCCorporationTrades : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
	}
	public class CrpNPCDivisions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "divisionID")]
		public int DivisionID { get; set; }
		[JsonProperty(PropertyName = "divisionName")]
		public string DivisionName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "leaderType")]
		public string LeaderType { get; set; }
	}
	public class DgmAttributeCategories : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty(PropertyName = "categoryName")]
		public string CategoryName { get; set; }
		[JsonProperty(PropertyName = "categoryDescription")]
		public string CategoryDescription { get; set; }
	}
	public class DgmAttributeTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "attributeID")]
		public int AttributeID { get; set; }
		[JsonProperty(PropertyName = "attributeName")]
		public string AttributeName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "defaultValue")]
		public float? DefaultValue { get; set; }
		[JsonProperty(PropertyName = "published")]
		public int Published { get; set; }
		[JsonProperty(PropertyName = "displayName")]
		public string DisplayName { get; set; }
		[JsonProperty(PropertyName = "unitID")]
		public int? UnitID { get; set; }
		[JsonProperty(PropertyName = "stackable")]
		public int Stackable { get; set; }
		[JsonProperty(PropertyName = "highIsGood")]
		public int HighIsGood { get; set; }
		[JsonProperty(PropertyName = "categoryID")]
		public int? CategoryID { get; set; }
	}
	public class DgmEffects : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "effectID")]
		public int EffectID { get; set; }
		[JsonProperty(PropertyName = "effectName")]
		public string EffectName { get; set; }
		[JsonProperty(PropertyName = "effectCategory")]
		public int EffectCategory { get; set; }
		[JsonProperty(PropertyName = "preExpression")]
		public int PreExpression { get; set; }
		[JsonProperty(PropertyName = "postExpression")]
		public int PostExpression { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "guid")]
		public string Guid { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "isOffensive")]
		public int IsOffensive { get; set; }
		[JsonProperty(PropertyName = "isAssistance")]
		public int IsAssistance { get; set; }
		[JsonProperty(PropertyName = "durationAttributeID")]
		public int? DurationAttributeID { get; set; }
		[JsonProperty(PropertyName = "trackingSpeedAttributeID")]
		public int? TrackingSpeedAttributeID { get; set; }
		[JsonProperty(PropertyName = "dischargeAttributeID")]
		public int? DischargeAttributeID { get; set; }
		[JsonProperty(PropertyName = "rangeAttributeID")]
		public int? RangeAttributeID { get; set; }
		[JsonProperty(PropertyName = "falloffAttributeID")]
		public int? FalloffAttributeID { get; set; }
		[JsonProperty(PropertyName = "disallowAutoRepeat")]
		public int DisallowAutoRepeat { get; set; }
		[JsonProperty(PropertyName = "published")]
		public int Published { get; set; }
		[JsonProperty(PropertyName = "displayName")]
		public string DisplayName { get; set; }
		[JsonProperty(PropertyName = "isWarpSafe")]
		public int IsWarpSafe { get; set; }
		[JsonProperty(PropertyName = "rangeChance")]
		public int RangeChance { get; set; }
		[JsonProperty(PropertyName = "electronicChance")]
		public int ElectronicChance { get; set; }
		[JsonProperty(PropertyName = "propulsionChance")]
		public int PropulsionChance { get; set; }
		[JsonProperty(PropertyName = "distribution")]
		public int? Distribution { get; set; }
		[JsonProperty(PropertyName = "sfxName")]
		public object SfxName { get; set; }
		[JsonProperty(PropertyName = "npcUsageChanceAttributeID")]
		public object NpcUsageChanceAttributeID { get; set; }
		[JsonProperty(PropertyName = "npcActivationChanceAttributeID")]
		public object NpcActivationChanceAttributeID { get; set; }
		[JsonProperty(PropertyName = "fittingUsageChanceAttributeID")]
		public object FittingUsageChanceAttributeID { get; set; }
		[JsonProperty(PropertyName = "modifierInfo")]
		public string ModifierInfo { get; set; }
	}
	public class DgmExpressions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "expressionID")]
		public int ExpressionID { get; set; }
		[JsonProperty(PropertyName = "operandID")]
		public int OperandID { get; set; }
		[JsonProperty(PropertyName = "arg1")]
		public int? Arg1 { get; set; }
		[JsonProperty(PropertyName = "arg2")]
		public int? Arg2 { get; set; }
		[JsonProperty(PropertyName = "expressionValue")]
		public string ExpressionValue { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "expressionName")]
		public string ExpressionName { get; set; }
		[JsonProperty(PropertyName = "expressionTypeID")]
		public int? ExpressionTypeID { get; set; }
		[JsonProperty(PropertyName = "expressionGroupID")]
		public int? ExpressionGroupID { get; set; }
		[JsonProperty(PropertyName = "expressionAttributeID")]
		public int? ExpressionAttributeID { get; set; }
	}
	public class DgmTypeAttributes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "attributeID")]
		public int AttributeID { get; set; }
		[JsonProperty(PropertyName = "valueInt")]
		public int? ValueInt { get; set; }
		[JsonProperty(PropertyName = "valueFloat")]
		public float? ValueFloat { get; set; }
	}
	public class DgmTypeEffects : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "effectID")]
		public int EffectID { get; set; }
		[JsonProperty(PropertyName = "isDefault")]
		public int IsDefault { get; set; }
	}
	public class EveGraphics : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "graphicID")]
		public int GraphicID { get; set; }
		[JsonProperty(PropertyName = "sofFactionName")]
		public string SofFactionName { get; set; }
		[JsonProperty(PropertyName = "graphicFile")]
		public string GraphicFile { get; set; }
		[JsonProperty(PropertyName = "sofHullName")]
		public string SofHullName { get; set; }
		[JsonProperty(PropertyName = "sofRaceName")]
		public string SofRaceName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
	}
	public class EveIcons : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "iconFile")]
		public string IconFile { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
	}
	public class EveUnits : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "unitID")]
		public int UnitID { get; set; }
		[JsonProperty(PropertyName = "unitName")]
		public string UnitName { get; set; }
		[JsonProperty(PropertyName = "displayName")]
		public string DisplayName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
	}
	public class IndustryActivity : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "time")]
		public int Time { get; set; }
	}
	public class IndustryActivityMaterials : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "materialTypeID")]
		public int MaterialTypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
	public class IndustryActivityProbabilities : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "productTypeID")]
		public int ProductTypeID { get; set; }
		[JsonProperty(PropertyName = "probability")]
		public float Probability { get; set; }
	}
	public class IndustryActivityProducts : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "productTypeID")]
		public int ProductTypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
	public class IndustryActivitySkills : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "skillID")]
		public int SkillID { get; set; }
		[JsonProperty(PropertyName = "level")]
		public int Level { get; set; }
	}
	public class IndustryBlueprints : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "maxProductionLimit")]
		public int MaxProductionLimit { get; set; }
	}
	public class InvCategories : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty(PropertyName = "categoryName")]
		public string CategoryName { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "published")]
		public int Published { get; set; }
	}
	public class InvContrabandTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "factionID")]
		public int FactionID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "standingLoss")]
		public float StandingLoss { get; set; }
		[JsonProperty(PropertyName = "confiscateMinSec")]
		public float? ConfiscateMinSec { get; set; }
		[JsonProperty(PropertyName = "fineByValue")]
		public float FineByValue { get; set; }
		[JsonProperty(PropertyName = "attackMinSec")]
		public float AttackMinSec { get; set; }
	}
	public class InvControlTowerResourcePurposes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "purpose")]
		public int Purpose { get; set; }
		[JsonProperty(PropertyName = "purposeText")]
		public string PurposeText { get; set; }
	}
	public class InvControlTowerResources : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "controlTowerTypeID")]
		public int ControlTowerTypeID { get; set; }
		[JsonProperty(PropertyName = "resourceTypeID")]
		public int ResourceTypeID { get; set; }
		[JsonProperty(PropertyName = "purpose")]
		public int Purpose { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
		[JsonProperty(PropertyName = "minSecurityLevel")]
		public float? MinSecurityLevel { get; set; }
		[JsonProperty(PropertyName = "factionID")]
		public int? FactionID { get; set; }
	}
	public class InvFlags : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "flagID")]
		public int FlagID { get; set; }
		[JsonProperty(PropertyName = "flagName")]
		public string FlagName { get; set; }
		[JsonProperty(PropertyName = "flagText")]
		public string FlagText { get; set; }
		[JsonProperty(PropertyName = "orderID")]
		public int OrderID { get; set; }
	}
	public class InvGroups : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "groupID")]
		public int GroupID { get; set; }
		[JsonProperty(PropertyName = "categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty(PropertyName = "groupName")]
		public string GroupName { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "useBasePrice")]
		public int UseBasePrice { get; set; }
		[JsonProperty(PropertyName = "anchored")]
		public int Anchored { get; set; }
		[JsonProperty(PropertyName = "anchorable")]
		public int Anchorable { get; set; }
		[JsonProperty(PropertyName = "fittableNonSingleton")]
		public int FittableNonSingleton { get; set; }
		[JsonProperty(PropertyName = "published")]
		public int Published { get; set; }
	}
	public class InvItems : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "itemID")]
		public int ItemID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "ownerID")]
		public int OwnerID { get; set; }
		[JsonProperty(PropertyName = "locationID")]
		public int LocationID { get; set; }
		[JsonProperty(PropertyName = "flagID")]
		public int FlagID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
	public class InvMarketGroups : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "marketGroupID")]
		public int MarketGroupID { get; set; }
		[JsonProperty(PropertyName = "parentGroupID")]
		public int? ParentGroupID { get; set; }
		[JsonProperty(PropertyName = "marketGroupName")]
		public string MarketGroupName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "hasTypes")]
		public int HasTypes { get; set; }
	}
	public class InvMetaGroups : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "metaGroupID")]
		public int MetaGroupID { get; set; }
		[JsonProperty(PropertyName = "metaGroupName")]
		public string MetaGroupName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
	}
	public class InvMetaTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "parentTypeID")]
		public int ParentTypeID { get; set; }
		[JsonProperty(PropertyName = "metaGroupID")]
		public int MetaGroupID { get; set; }
	}
	public class InvNames : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "itemID")]
		public int ItemID { get; set; }
		[JsonProperty(PropertyName = "itemName")]
		public string ItemName { get; set; }
	}
	public class InvPositions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "itemID")]
		public int ItemID { get; set; }
		[JsonProperty(PropertyName = "x")]
		public double X { get; set; }
		[JsonProperty(PropertyName = "y")]
		public double Y { get; set; }
		[JsonProperty(PropertyName = "z")]
		public double Z { get; set; }
		[JsonProperty(PropertyName = "yaw")]
		public object Yaw { get; set; }
		[JsonProperty(PropertyName = "pitch")]
		public object Pitch { get; set; }
		[JsonProperty(PropertyName = "roll")]
		public object Roll { get; set; }
	}
	public class InvTraits : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "traitID")]
		public int TraitID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "skillID")]
		public int SkillID { get; set; }
		[JsonProperty(PropertyName = "bonus")]
		public float? Bonus { get; set; }
		[JsonProperty(PropertyName = "bonusText")]
		public string BonusText { get; set; }
		[JsonProperty(PropertyName = "unitID")]
		public int? UnitID { get; set; }
	}
	public class InvTypeMaterials : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "materialTypeID")]
		public int MaterialTypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
	public class InvTypeReactions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "reactionTypeID")]
		public int ReactionTypeID { get; set; }
		[JsonProperty(PropertyName = "input")]
		public int Input { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
	public class InvTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "groupID")]
		public int GroupID { get; set; }
		[JsonProperty(PropertyName = "typeName")]
		public string TypeName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "mass")]
		public float Mass { get; set; }
		[JsonProperty(PropertyName = "volume")]
		public float Volume { get; set; }
		[JsonProperty(PropertyName = "capacity")]
		public float Capacity { get; set; }
		[JsonProperty(PropertyName = "portionSize")]
		public int PortionSize { get; set; }
		[JsonProperty(PropertyName = "raceID")]
		public int? RaceID { get; set; }
		[JsonProperty(PropertyName = "basePrice")]
		public long? BasePrice { get; set; }
		[JsonProperty(PropertyName = "published")]
		public int Published { get; set; }
		[JsonProperty(PropertyName = "marketGroupID")]
		public int? MarketGroupID { get; set; }
		[JsonProperty(PropertyName = "iconID")]
		public int? IconID { get; set; }
		[JsonProperty(PropertyName = "soundID")]
		public int? SoundID { get; set; }
		[JsonProperty(PropertyName = "graphicID")]
		public int GraphicID { get; set; }
	}
	public class InvUniqueNames : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "itemID")]
		public int ItemID { get; set; }
		[JsonProperty(PropertyName = "itemName")]
		public string ItemName { get; set; }
		[JsonProperty(PropertyName = "groupID")]
		public int GroupID { get; set; }
	}
	public class InvVolumes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "volume")]
		public int Volume { get; set; }
	}
	public class MapConstellationJumps : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "fromRegionID")]
		public int FromRegionID { get; set; }
		[JsonProperty(PropertyName = "fromConstellationID")]
		public int FromConstellationID { get; set; }
		[JsonProperty(PropertyName = "toConstellationID")]
		public int ToConstellationID { get; set; }
		[JsonProperty(PropertyName = "toRegionID")]
		public int ToRegionID { get; set; }
	}
	public class MapConstellations : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "regionID")]
		public int RegionID { get; set; }
		[JsonProperty(PropertyName = "constellationID")]
		public int ConstellationID { get; set; }
		[JsonProperty(PropertyName = "constellationName")]
		public string ConstellationName { get; set; }
		[JsonProperty(PropertyName = "x")]
		public double X { get; set; }
		[JsonProperty(PropertyName = "y")]
		public double Y { get; set; }
		[JsonProperty(PropertyName = "z")]
		public double Z { get; set; }
		[JsonProperty(PropertyName = "xMin")]
		public double XMin { get; set; }
		[JsonProperty(PropertyName = "xMax")]
		public double XMax { get; set; }
		[JsonProperty(PropertyName = "yMin")]
		public double YMin { get; set; }
		[JsonProperty(PropertyName = "yMax")]
		public double YMax { get; set; }
		[JsonProperty(PropertyName = "zMin")]
		public double ZMin { get; set; }
		[JsonProperty(PropertyName = "zMax")]
		public double ZMax { get; set; }
		[JsonProperty(PropertyName = "factionID")]
		public int? FactionID { get; set; }
		[JsonProperty(PropertyName = "radius")]
		public long Radius { get; set; }
	}
	public class MapJumps : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "stargateID")]
		public int StargateID { get; set; }
		[JsonProperty(PropertyName = "destinationID")]
		public int DestinationID { get; set; }
	}
	public class MapLocationScenes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "locationID")]
		public int LocationID { get; set; }
		[JsonProperty(PropertyName = "graphicID")]
		public int GraphicID { get; set; }
	}
	public class MapLocationWormholeClasses : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "locationID")]
		public int LocationID { get; set; }
		[JsonProperty(PropertyName = "wormholeClassID")]
		public int WormholeClassID { get; set; }
	}
	public class MapRegionJumps : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "fromRegionID")]
		public int FromRegionID { get; set; }
		[JsonProperty(PropertyName = "toRegionID")]
		public int ToRegionID { get; set; }
	}
	public class MapRegions : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "regionID")]
		public int RegionID { get; set; }
		[JsonProperty(PropertyName = "regionName")]
		public string RegionName { get; set; }
		[JsonProperty(PropertyName = "x")]
		public double X { get; set; }
		[JsonProperty(PropertyName = "y")]
		public double Y { get; set; }
		[JsonProperty(PropertyName = "z")]
		public double Z { get; set; }
		[JsonProperty(PropertyName = "xMin")]
		public double XMin { get; set; }
		[JsonProperty(PropertyName = "xMax")]
		public double XMax { get; set; }
		[JsonProperty(PropertyName = "yMin")]
		public double YMin { get; set; }
		[JsonProperty(PropertyName = "yMax")]
		public double YMax { get; set; }
		[JsonProperty(PropertyName = "zMin")]
		public double ZMin { get; set; }
		[JsonProperty(PropertyName = "zMax")]
		public double ZMax { get; set; }
		[JsonProperty(PropertyName = "factionID")]
		public int? FactionID { get; set; }
		[JsonProperty(PropertyName = "radius")]
		public object Radius { get; set; }
	}
	public class MapSolarSystemJumps : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "fromRegionID")]
		public int FromRegionID { get; set; }
		[JsonProperty(PropertyName = "fromConstellationID")]
		public int FromConstellationID { get; set; }
		[JsonProperty(PropertyName = "fromSolarSystemID")]
		public int FromSolarSystemID { get; set; }
		[JsonProperty(PropertyName = "toSolarSystemID")]
		public int ToSolarSystemID { get; set; }
		[JsonProperty(PropertyName = "toConstellationID")]
		public int ToConstellationID { get; set; }
		[JsonProperty(PropertyName = "toRegionID")]
		public int ToRegionID { get; set; }
	}
	public class MapSolarSystems : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "regionID")]
		public int RegionID { get; set; }
		[JsonProperty(PropertyName = "constellationID")]
		public int ConstellationID { get; set; }
		[JsonProperty(PropertyName = "solarSystemID")]
		public int SolarSystemID { get; set; }
		[JsonProperty(PropertyName = "solarSystemName")]
		public string SolarSystemName { get; set; }
		[JsonProperty(PropertyName = "x")]
		public double X { get; set; }
		[JsonProperty(PropertyName = "y")]
		public double Y { get; set; }
		[JsonProperty(PropertyName = "z")]
		public double Z { get; set; }
		[JsonProperty(PropertyName = "xMin")]
		public double XMin { get; set; }
		[JsonProperty(PropertyName = "xMax")]
		public double XMax { get; set; }
		[JsonProperty(PropertyName = "yMin")]
		public double YMin { get; set; }
		[JsonProperty(PropertyName = "yMax")]
		public double YMax { get; set; }
		[JsonProperty(PropertyName = "zMin")]
		public double ZMin { get; set; }
		[JsonProperty(PropertyName = "zMax")]
		public double ZMax { get; set; }
		[JsonProperty(PropertyName = "luminosity")]
		public float Luminosity { get; set; }
		[JsonProperty(PropertyName = "border")]
		public int Border { get; set; }
		[JsonProperty(PropertyName = "fringe")]
		public int Fringe { get; set; }
		[JsonProperty(PropertyName = "corridor")]
		public int Corridor { get; set; }
		[JsonProperty(PropertyName = "hub")]
		public int Hub { get; set; }
		[JsonProperty(PropertyName = "international")]
		public int International { get; set; }
		[JsonProperty(PropertyName = "regional")]
		public int Regional { get; set; }
		[JsonProperty(PropertyName = "constellation")]
		public object Constellation { get; set; }
		[JsonProperty(PropertyName = "security")]
		public float Security { get; set; }
		[JsonProperty(PropertyName = "factionID")]
		public int? FactionID { get; set; }
		[JsonProperty(PropertyName = "radius")]
		public long Radius { get; set; }
		[JsonProperty(PropertyName = "sunTypeID")]
		public int? SunTypeID { get; set; }
		[JsonProperty(PropertyName = "securityClass")]
		public string SecurityClass { get; set; }
	}
	public class MapUniverse : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "universeID")]
		public int UniverseID { get; set; }
		[JsonProperty(PropertyName = "universeName")]
		public string UniverseName { get; set; }
		[JsonProperty(PropertyName = "x")]
		public double X { get; set; }
		[JsonProperty(PropertyName = "y")]
		public double Y { get; set; }
		[JsonProperty(PropertyName = "z")]
		public double Z { get; set; }
		[JsonProperty(PropertyName = "xMin")]
		public double XMin { get; set; }
		[JsonProperty(PropertyName = "xMax")]
		public double XMax { get; set; }
		[JsonProperty(PropertyName = "yMin")]
		public double YMin { get; set; }
		[JsonProperty(PropertyName = "yMax")]
		public double YMax { get; set; }
		[JsonProperty(PropertyName = "zMin")]
		public double ZMin { get; set; }
		[JsonProperty(PropertyName = "zMax")]
		public double ZMax { get; set; }
		[JsonProperty(PropertyName = "radius")]
		public float Radius { get; set; }
	}
	public class PlanetSchematics : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "schematicID")]
		public int SchematicID { get; set; }
		[JsonProperty(PropertyName = "schematicName")]
		public string SchematicName { get; set; }
		[JsonProperty(PropertyName = "cycleTime")]
		public int CycleTime { get; set; }
	}
	public class PlanetSchematicsPinMap : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "schematicID")]
		public int SchematicID { get; set; }
		[JsonProperty(PropertyName = "pinTypeID")]
		public int PinTypeID { get; set; }
	}
	public class PlanetSchematicsTypeMap : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "schematicID")]
		public int SchematicID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
		[JsonProperty(PropertyName = "isInput")]
		public int IsInput { get; set; }
	}
	public class RamActivities : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "activityName")]
		public string ActivityName { get; set; }
		[JsonProperty(PropertyName = "iconNo")]
		public string IconNo { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "published")]
		public int Published { get; set; }
	}
	public class RamAssemblyLineStations : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "stationID")]
		public int StationID { get; set; }
		[JsonProperty(PropertyName = "assemblyLineTypeID")]
		public int AssemblyLineTypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
		[JsonProperty(PropertyName = "stationTypeID")]
		public int StationTypeID { get; set; }
		[JsonProperty(PropertyName = "ownerID")]
		public int OwnerID { get; set; }
		[JsonProperty(PropertyName = "solarSystemID")]
		public int SolarSystemID { get; set; }
		[JsonProperty(PropertyName = "regionID")]
		public int RegionID { get; set; }
	}
	public class RamAssemblyLineTypeDetailPerCategory : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "assemblyLineTypeID")]
		public int AssemblyLineTypeID { get; set; }
		[JsonProperty(PropertyName = "categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty(PropertyName = "timeMultiplier")]
		public float TimeMultiplier { get; set; }
		[JsonProperty(PropertyName = "materialMultiplier")]
		public float MaterialMultiplier { get; set; }
		[JsonProperty(PropertyName = "costMultiplier")]
		public int CostMultiplier { get; set; }
	}
	public class RamAssemblyLineTypeDetailPerGroup : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "assemblyLineTypeID")]
		public int AssemblyLineTypeID { get; set; }
		[JsonProperty(PropertyName = "groupID")]
		public int GroupID { get; set; }
		[JsonProperty(PropertyName = "timeMultiplier")]
		public float TimeMultiplier { get; set; }
		[JsonProperty(PropertyName = "materialMultiplier")]
		public float MaterialMultiplier { get; set; }
		[JsonProperty(PropertyName = "costMultiplier")]
		public int CostMultiplier { get; set; }
	}
	public class RamAssemblyLineTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "assemblyLineTypeID")]
		public int AssemblyLineTypeID { get; set; }
		[JsonProperty(PropertyName = "assemblyLineTypeName")]
		public string AssemblyLineTypeName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "baseTimeMultiplier")]
		public float BaseTimeMultiplier { get; set; }
		[JsonProperty(PropertyName = "baseMaterialMultiplier")]
		public float BaseMaterialMultiplier { get; set; }
		[JsonProperty(PropertyName = "baseCostMultiplier")]
		public float BaseCostMultiplier { get; set; }
		[JsonProperty(PropertyName = "volume")]
		public int Volume { get; set; }
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "minCostPerHour")]
		public float? MinCostPerHour { get; set; }
	}
	public class RamInstallationTypeContents : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "installationTypeID")]
		public int InstallationTypeID { get; set; }
		[JsonProperty(PropertyName = "assemblyLineTypeID")]
		public int AssemblyLineTypeID { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
	public class SkinLicense : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "licenseTypeID")]
		public int LicenseTypeID { get; set; }
		[JsonProperty(PropertyName = "duration")]
		public int Duration { get; set; }
		[JsonProperty(PropertyName = "skinID")]
		public int SkinID { get; set; }
	}
	public class SkinMaterials : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "skinMaterialID")]
		public int SkinMaterialID { get; set; }
		[JsonProperty(PropertyName = "displayNameID")]
		public int DisplayNameID { get; set; }
		[JsonProperty(PropertyName = "materialSetID")]
		public int MaterialSetID { get; set; }
	}
	public class Skins : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "skinID")]
		public int SkinID { get; set; }
		[JsonProperty(PropertyName = "internalName")]
		public string InternalName { get; set; }
		[JsonProperty(PropertyName = "skinMaterialID")]
		public int SkinMaterialID { get; set; }
	}
	public class SkinShip : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "skinID")]
		public int SkinID { get; set; }
		[JsonProperty(PropertyName = "typeID")]
		public int TypeID { get; set; }
	}
	public class StaOperations : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "activityID")]
		public int ActivityID { get; set; }
		[JsonProperty(PropertyName = "operationID")]
		public int OperationID { get; set; }
		[JsonProperty(PropertyName = "operationName")]
		public string OperationName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "fringe")]
		public int Fringe { get; set; }
		[JsonProperty(PropertyName = "corridor")]
		public int Corridor { get; set; }
		[JsonProperty(PropertyName = "hub")]
		public int Hub { get; set; }
		[JsonProperty(PropertyName = "border")]
		public int Border { get; set; }
		[JsonProperty(PropertyName = "ratio")]
		public int Ratio { get; set; }
		[JsonProperty(PropertyName = "caldariStationTypeID")]
		public int? CaldariStationTypeID { get; set; }
		[JsonProperty(PropertyName = "minmatarStationTypeID")]
		public int? MinmatarStationTypeID { get; set; }
		[JsonProperty(PropertyName = "amarrStationTypeID")]
		public int? AmarrStationTypeID { get; set; }
		[JsonProperty(PropertyName = "gallenteStationTypeID")]
		public int? GallenteStationTypeID { get; set; }
		[JsonProperty(PropertyName = "joveStationTypeID")]
		public int? JoveStationTypeID { get; set; }
	}
	public class StaOperationServices : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "operationID")]
		public int OperationID { get; set; }
		[JsonProperty(PropertyName = "serviceID")]
		public int ServiceID { get; set; }
	}
	public class StaServices : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "serviceID")]
		public int ServiceID { get; set; }
		[JsonProperty(PropertyName = "serviceName")]
		public string ServiceName { get; set; }
		[JsonProperty(PropertyName = "description")]
		public object Description { get; set; }
	}
	public class StaStations : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "stationID")]
		public int StationID { get; set; }
		[JsonProperty(PropertyName = "security")]
		public float Security { get; set; }
		[JsonProperty(PropertyName = "dockingCostPerVolume")]
		public int DockingCostPerVolume { get; set; }
		[JsonProperty(PropertyName = "maxShipVolumeDockable")]
		public int MaxShipVolumeDockable { get; set; }
		[JsonProperty(PropertyName = "officeRentalCost")]
		public int OfficeRentalCost { get; set; }
		[JsonProperty(PropertyName = "operationID")]
		public int OperationID { get; set; }
		[JsonProperty(PropertyName = "stationTypeID")]
		public int StationTypeID { get; set; }
		[JsonProperty(PropertyName = "corporationID")]
		public int CorporationID { get; set; }
		[JsonProperty(PropertyName = "solarSystemID")]
		public int SolarSystemID { get; set; }
		[JsonProperty(PropertyName = "constellationID")]
		public int ConstellationID { get; set; }
		[JsonProperty(PropertyName = "regionID")]
		public int RegionID { get; set; }
		[JsonProperty(PropertyName = "stationName")]
		public string StationName { get; set; }
		[JsonProperty(PropertyName = "x")]
		public long X { get; set; }
		[JsonProperty(PropertyName = "y")]
		public long Y { get; set; }
		[JsonProperty(PropertyName = "z")]
		public long Z { get; set; }
		[JsonProperty(PropertyName = "reprocessingEfficiency")]
		public float ReprocessingEfficiency { get; set; }
		[JsonProperty(PropertyName = "reprocessingStationsTake")]
		public float ReprocessingStationsTake { get; set; }
		[JsonProperty(PropertyName = "reprocessingHangarFlag")]
		public int ReprocessingHangarFlag { get; set; }
	}
	public class StaStationTypes : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "stationTypeID")]
		public int StationTypeID { get; set; }
		[JsonProperty(PropertyName = "dockEntryX")]
		public float DockEntryX { get; set; }
		[JsonProperty(PropertyName = "dockEntryY")]
		public float DockEntryY { get; set; }
		[JsonProperty(PropertyName = "dockEntryZ")]
		public float DockEntryZ { get; set; }
		[JsonProperty(PropertyName = "dockOrientationX")]
		public float DockOrientationX { get; set; }
		[JsonProperty(PropertyName = "dockOrientationY")]
		public float DockOrientationY { get; set; }
		[JsonProperty(PropertyName = "dockOrientationZ")]
		public float DockOrientationZ { get; set; }
		[JsonProperty(PropertyName = "operationID")]
		public object OperationID { get; set; }
		[JsonProperty(PropertyName = "officeSlots")]
		public object OfficeSlots { get; set; }
		[JsonProperty(PropertyName = "reprocessingEfficiency")]
		public object ReprocessingEfficiency { get; set; }
		[JsonProperty(PropertyName = "conquerable")]
		public int Conquerable { get; set; }
	}
	public class TrnTranslationColumns : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "tcGroupID")]
		public int TcGroupID { get; set; }
		[JsonProperty(PropertyName = "tcID")]
		public int TcID { get; set; }
		[JsonProperty(PropertyName = "tableName")]
		public string TableName { get; set; }
		[JsonProperty(PropertyName = "columnName")]
		public string ColumnName { get; set; }
		[JsonProperty(PropertyName = "masterID")]
		public string MasterID { get; set; }
	}
	public class TrnTranslationLanguages : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "numericLanguageID")]
		public int NumericLanguageID { get; set; }
		[JsonProperty(PropertyName = "languageID")]
		public string LanguageID { get; set; }
		[JsonProperty(PropertyName = "languageName")]
		public string LanguageName { get; set; }
	}
	public class WarCombatZones : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "combatZoneID")]
		public int CombatZoneID { get; set; }
		[JsonProperty(PropertyName = "combatZoneName")]
		public string CombatZoneName { get; set; }
		[JsonProperty(PropertyName = "factionID")]
		public int FactionID { get; set; }
		[JsonProperty(PropertyName = "centerSystemID")]
		public int CenterSystemID { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
	}
	public class WarCombatZoneSystems : SDEDataBaseClass
	{
		[JsonProperty(PropertyName = "solarSystemID")]
		public int SolarSystemID { get; set; }
		[JsonProperty(PropertyName = "combatZoneID")]
		public int CombatZoneID { get; set; }
	}
}
