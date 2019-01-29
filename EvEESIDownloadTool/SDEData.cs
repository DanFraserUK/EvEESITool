using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
using ESI.NET.Models.Corporation;
using ESI.NET.Models.Industry;
using ESI.NET.Models.Location;
using ESI.NET.Models.Market;
using ESI.NET.Models.SSO;
using ESI.NET.Models.Wallet;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using ESI.NET.Models.Skills;
using System.Text;
using System.Net;
using System.Net.Http;

namespace EvEESITool
{
	/// <summary>
	/// I'm doing something with this, I don't know what but there's something
	/// oh i know, make loading of the data customisable
	/// </summary>
	public class SDEData : IDisposable
	{
		public enum LoadingEnum
		{

		}

		private void CommentStore()
		{
			//AgtAgents.AddRange(ReadSDEFile<List<AgtAgents>>("agtAgents"));
			//AgtAgentTypes.AddRange(ReadSDEFile<List<AgtAgentTypes>>("agtAgentTypes"));
			//AgtResearchAgents.AddRange(ReadSDEFile<List<AgtResearchAgents>>("agtResearchAgents"));
			//CertCerts.AddRange(ReadSDEFile<List<CertCerts>>("certCerts"));
			//CertMasteries.AddRange(ReadSDEFile<List<CertMasteries>>("certMasteries"));
			//CertSkills.AddRange(ReadSDEFile<List<CertSkills>>("certSkills"));
			//ChrAncestries.AddRange(ReadSDEFile<List<ChrAncestries>>("chrAncestries"));
			//ChrAttributes.AddRange(ReadSDEFile<List<ChrAttributes>>("chrAttributes"));
			//ChrBloodlines.AddRange(ReadSDEFile<List<ChrBloodlines>>("chrBloodlines"));
			//ChrFactions.AddRange(ReadSDEFile<List<ChrFactions>>("chrFactions"));
			//ChrRaces.AddRange(ReadSDEFile<List<ChrRaces>>("chrRaces"));
			//CrpActivities.AddRange(ReadSDEFile<List<CrpActivities>>("crpActivities"));
			//CrpNPCCorporationDivisions.AddRange(ReadSDEFile<List<CrpNPCCorporationDivisions>>("crpNPCCorporationDivisions"));
			//CrpNPCCorporationResearchFields.AddRange(ReadSDEFile<List<CrpNPCCorporationResearchFields>>("crpNPCCorporationResearchFields"));
			//CrpNPCCorporations.AddRange(ReadSDEFile<List<CrpNPCCorporations>>("crpNPCCorporations"));
			//CrpNPCCorporationTrades.AddRange(ReadSDEFile<List<CrpNPCCorporationTrades>>("crpNPCCorporationTrades"));
			//CrpNPCDivisions.AddRange(ReadSDEFile<List<CrpNPCDivisions>>("crpNPCDivisions"));
			//DgmAttributeCategories.AddRange(ReadSDEFile<List<DgmAttributeCategories>>("dgmAttributeCategories"));
			//DgmAttributeTypes.AddRange(ReadSDEFile<List<DgmAttributeTypes>>("dgmAttributeTypes"));
			//DgmEffects.AddRange(ReadSDEFile<List<DgmEffects>>("dgmEffects"));
			//DgmExpressions.AddRange(ReadSDEFile<List<DgmExpressions>>("dgmExpressions"));
			//DgmTypeAttributes.AddRange(ReadSDEFile<List<DgmTypeAttributes>>("dgmTypeAttributes"));
			//DgmTypeEffects.AddRange(ReadSDEFile<List<DgmTypeEffects>>("dgmTypeEffects"));
			//EveGraphics.AddRange(ReadSDEFile<List<EveGraphics>>("eveGraphics"));
			//EveIcons.AddRange(ReadSDEFile<List<EveIcons>>("eveIcons"));
			//EveUnits.AddRange(ReadSDEFile<List<EveUnits>>("eveUnits"));
			//IndustryActivity.AddRange(ReadSDEFile<List<IndustryActivity>>("industryActivity"));
			//IndustryActivityMaterials.AddRange(ReadSDEFile<List<IndustryActivityMaterials>>("industryActivityMaterials"));
			//IndustryActivityProbabilities.AddRange(ReadSDEFile<List<IndustryActivityProbabilities>>("industryActivityProbabilities"));
			//IndustryActivityProducts.AddRange(ReadSDEFile<List<IndustryActivityProducts>>("industryActivityProducts"));
			//IndustryActivitySkills.AddRange(ReadSDEFile<List<IndustryActivitySkills>>("industryActivitySkills"));
			//IndustryBlueprints.AddRange(ReadSDEFile<List<IndustryBlueprints>>("industryBlueprints"));
			//InvCategories.AddRange(ReadSDEFile<List<InvCategories>>("invCategories"));
			//InvContrabandTypes.AddRange(ReadSDEFile<List<InvContrabandTypes>>("invContrabandTypes"));
			//InvControlTowerResourcePurposes.AddRange(ReadSDEFile<List<InvControlTowerResourcePurposes>>("invControlTowerResourcePurposes"));
			//InvControlTowerResources.AddRange(ReadSDEFile<List<InvControlTowerResources>>("invControlTowerResources"));
			//InvFlags.AddRange(ReadSDEFile<List<InvFlags>>("invFlags"));
			//InvGroups.AddRange(ReadSDEFile<List<InvGroups>>("invGroups"));
			//InvItems.AddRange(ReadSDEFile<List<InvItems>>("invItems"));
			//InvMarketGroups.AddRange(ReadSDEFile<List<InvMarketGroups>>("invMarketGroups"));
			//InvMetaGroups.AddRange(ReadSDEFile<List<InvMetaGroups>>("invMetaGroups"));
			//InvMetaTypes.AddRange(ReadSDEFile<List<InvMetaTypes>>("invMetaTypes"));
			//InvNames.AddRange(ReadSDEFile<List<InvNames>>("invNames"));
			//InvPositions.AddRange(ReadSDEFile<List<InvPositions>>("invPositions"));
			//InvTraits.AddRange(ReadSDEFile<List<InvTraits>>("invTraits"));
			//InvTypeMaterials.AddRange(ReadSDEFile<List<InvTypeMaterials>>("invTypeMaterials"));
			//InvTypeReactions.AddRange(ReadSDEFile<List<InvTypeReactions>>("invTypeReactions"));
			//InvUniqueNames.AddRange(ReadSDEFile<List<InvUniqueNames>>("invUniqueNames"));
			//InvVolumes.AddRange(ReadSDEFile<List<InvVolumes>>("invVolumes"));
			//MapConstellationJumps.AddRange(ReadSDEFile<List<MapConstellationJumps>>("mapConstellationJumps"));
			//MapConstellations.AddRange(ReadSDEFile<List<MapConstellations>>("mapConstellations"));
			//MapJumps.AddRange(ReadSDEFile<List<MapJumps>>("mapJumps"));
			//MapLocationScenes.AddRange(ReadSDEFile<List<MapLocationScenes>>("mapLocationScenes"));
			//MapLocationWormholeClasses.AddRange(ReadSDEFile<List<MapLocationWormholeClasses>>("mapLocationWormholeClasses"));
			//MapRegionJumps.AddRange(ReadSDEFile<List<MapRegionJumps>>("mapRegionJumps"));
			//MapRegions.AddRange(ReadSDEFile<List<MapRegions>>("mapRegions"));
			//MapSolarSystemJumps.AddRange(ReadSDEFile<List<MapSolarSystemJumps>>("mapSolarSystemJumps"));
			//MapSolarSystems.AddRange(ReadSDEFile<List<MapSolarSystems>>("mapSolarSystems"));
			//MapUniverse.AddRange(ReadSDEFile<List<MapUniverse>>("mapUniverse"));
			//PlanetSchematics.AddRange(ReadSDEFile<List<PlanetSchematics>>("planetSchematics"));
			//PlanetSchematicsPinMap.AddRange(ReadSDEFile<List<PlanetSchematicsPinMap>>("planetSchematicsPinMap"));
			//PlanetSchematicsTypeMap.AddRange(ReadSDEFile<List<PlanetSchematicsTypeMap>>("planetSchematicsTypeMap"));
			//RamActivities.AddRange(ReadSDEFile<List<RamActivities>>("ramActivities"));
			//RamAssemblyLineStations.AddRange(ReadSDEFile<List<RamAssemblyLineStations>>("ramAssemblyLineStations"));
			//RamAssemblyLineTypeDetailPerCategory.AddRange(ReadSDEFile<List<RamAssemblyLineTypeDetailPerCategory>>("ramAssemblyLineTypeDetailPerCategory"));
			//RamAssemblyLineTypeDetailPerGroup.AddRange(ReadSDEFile<List<RamAssemblyLineTypeDetailPerGroup>>("ramAssemblyLineTypeDetailPerGroup"));
			//RamAssemblyLineTypes.AddRange(ReadSDEFile<List<RamAssemblyLineTypes>>("ramAssemblyLineTypes"));
			//RamInstallationTypeContents.AddRange(ReadSDEFile<List<RamInstallationTypeContents>>("ramInstallationTypeContents"));
			//SkinLicense.AddRange(ReadSDEFile<List<SkinLicense>>("skinLicense"));
			//SkinMaterials.AddRange(ReadSDEFile<List<SkinMaterials>>("skinMaterials"));
			//Skins.AddRange(ReadSDEFile<List<Skins>>("skins"));
			//SkinShip.AddRange(ReadSDEFile<List<SkinShip>>("skinShip"));
			//StaOperations.AddRange(ReadSDEFile<List<StaOperations>>("staOperations"));
			//StaOperationServices.AddRange(ReadSDEFile<List<StaOperationServices>>("staOperationServices"));
			//StaServices.AddRange(ReadSDEFile<List<StaServices>>("staServices"));
			//StaStationTypes.AddRange(ReadSDEFile<List<StaStationTypes>>("staStationTypes"));
			//TrnTranslationColumns.AddRange(ReadSDEFile<List<TrnTranslationColumns>>("trnTranslationColumns"));
			//TrnTranslationLanguages.AddRange(ReadSDEFile<List<TrnTranslationLanguages>>("trnTranslationLanguages"));
			//WarCombatZones.AddRange(ReadSDEFile<List<WarCombatZones>>("warCombatZones"));
			//WarCombatZoneSystems.AddRange(ReadSDEFile<List<WarCombatZoneSystems>>("warCombatZoneSystems"));
			//public List<AgtAgents> AgtAgents = new List<AgtAgents>();
			//public List<AgtAgentTypes> AgtAgentTypes = new List<AgtAgentTypes>();
			//public List<AgtResearchAgents> AgtResearchAgents = new List<AgtResearchAgents>();
			//public List<CertCerts> CertCerts = new List<CertCerts>();
			//public List<CertMasteries> CertMasteries = new List<CertMasteries>();
			//public List<CertSkills> CertSkills = new List<CertSkills>();
			//public List<ChrAncestries> ChrAncestries = new List<ChrAncestries>();
			//public List<ChrAttributes> ChrAttributes = new List<ChrAttributes>();
			//public List<ChrBloodlines> ChrBloodlines = new List<ChrBloodlines>();
			//public List<ChrFactions> ChrFactions = new List<ChrFactions>();
			//public List<ChrRaces> ChrRaces = new List<ChrRaces>();
			//public List<CrpActivities> CrpActivities = new List<CrpActivities>();
			//public List<CrpNPCCorporationDivisions> CrpNPCCorporationDivisions = new List<CrpNPCCorporationDivisions>();
			//public List<CrpNPCCorporationResearchFields> CrpNPCCorporationResearchFields = new List<CrpNPCCorporationResearchFields>();
			//public List<CrpNPCCorporations> CrpNPCCorporations = new List<CrpNPCCorporations>();
			//public List<CrpNPCCorporationTrades> CrpNPCCorporationTrades = new List<CrpNPCCorporationTrades>();
			//public List<CrpNPCDivisions> CrpNPCDivisions = new List<CrpNPCDivisions>();
			//public List<DgmAttributeCategories> DgmAttributeCategories = new List<DgmAttributeCategories>();
			//public List<DgmAttributeTypes> DgmAttributeTypes = new List<DgmAttributeTypes>();
			//public List<DgmEffects> DgmEffects = new List<DgmEffects>();
			//public List<DgmExpressions> DgmExpressions = new List<DgmExpressions>();
			//public List<DgmTypeAttributes> DgmTypeAttributes = new List<DgmTypeAttributes>();
			//public List<DgmTypeEffects> DgmTypeEffects = new List<DgmTypeEffects>();
			//public List<EveGraphics> EveGraphics = new List<EveGraphics>();
			//public List<EveIcons> EveIcons = new List<EveIcons>();
			//public List<EveUnits> EveUnits = new List<EveUnits>();
			//public List<IndustryActivity> IndustryActivity = new List<IndustryActivity>();
			//public List<IndustryActivityMaterials> IndustryActivityMaterials = new List<IndustryActivityMaterials>();
			//public List<IndustryActivityProbabilities> IndustryActivityProbabilities = new List<IndustryActivityProbabilities>();
			//public List<IndustryActivityProducts> IndustryActivityProducts = new List<IndustryActivityProducts>();
			//public List<IndustryActivitySkills> IndustryActivitySkills = new List<IndustryActivitySkills>();
			//public List<IndustryBlueprints> IndustryBlueprints = new List<IndustryBlueprints>();
			//public List<InvCategories> InvCategories = new List<InvCategories>();
			//public List<InvContrabandTypes> InvContrabandTypes = new List<InvContrabandTypes>();
			//public List<InvControlTowerResourcePurposes> InvControlTowerResourcePurposes = new List<InvControlTowerResourcePurposes>();
			//public List<InvControlTowerResources> InvControlTowerResources = new List<InvControlTowerResources>();
			//public List<InvFlags> InvFlags = new List<InvFlags>();
			//public List<InvGroups> InvGroups = new List<InvGroups>();
			//public List<InvItems> InvItems = new List<InvItems>();
			//public List<InvMarketGroups> InvMarketGroups = new List<InvMarketGroups>();
			//public List<InvMetaGroups> InvMetaGroups = new List<InvMetaGroups>();
			//public List<InvMetaTypes> InvMetaTypes = new List<InvMetaTypes>();
			//public List<InvNames> InvNames = new List<InvNames>();
			//public List<InvPositions> InvPositions = new List<InvPositions>();
			//public List<InvTraits> InvTraits = new List<InvTraits>();
			//public List<InvTypeMaterials> InvTypeMaterials = new List<InvTypeMaterials>();
			//public List<InvTypeReactions> InvTypeReactions = new List<InvTypeReactions>();
			//public List<InvUniqueNames> InvUniqueNames = new List<InvUniqueNames>();
			//public List<InvVolumes> InvVolumes = new List<InvVolumes>();
			//public List<MapConstellationJumps> MapConstellationJumps = new List<MapConstellationJumps>();
			//public List<MapConstellations> MapConstellations = new List<MapConstellations>();
			//public List<MapJumps> MapJumps = new List<MapJumps>();
			//public List<MapLocationScenes> MapLocationScenes = new List<MapLocationScenes>();
			//public List<MapLocationWormholeClasses> MapLocationWormholeClasses = new List<MapLocationWormholeClasses>();
			//public List<MapRegionJumps> MapRegionJumps = new List<MapRegionJumps>();
			//public List<MapRegions> MapRegions = new List<MapRegions>();
			//public List<MapSolarSystemJumps> MapSolarSystemJumps = new List<MapSolarSystemJumps>();
			//public List<MapSolarSystems> MapSolarSystems = new List<MapSolarSystems>();
			//public List<MapUniverse> MapUniverse = new List<MapUniverse>();
			//public List<PlanetSchematics> PlanetSchematics = new List<PlanetSchematics>();
			//public List<PlanetSchematicsPinMap> PlanetSchematicsPinMap = new List<PlanetSchematicsPinMap>();
			//public List<PlanetSchematicsTypeMap> PlanetSchematicsTypeMap = new List<PlanetSchematicsTypeMap>();
			//public List<RamActivities> RamActivities = new List<RamActivities>();
			//public List<RamAssemblyLineStations> RamAssemblyLineStations = new List<RamAssemblyLineStations>();
			//public List<RamAssemblyLineTypeDetailPerCategory> RamAssemblyLineTypeDetailPerCategory = new List<RamAssemblyLineTypeDetailPerCategory>();
			//public List<RamAssemblyLineTypeDetailPerGroup> RamAssemblyLineTypeDetailPerGroup = new List<RamAssemblyLineTypeDetailPerGroup>();
			//public List<RamAssemblyLineTypes> RamAssemblyLineTypes = new List<RamAssemblyLineTypes>();
			//public List<RamInstallationTypeContents> RamInstallationTypeContents = new List<RamInstallationTypeContents>();
			//public List<SkinLicense> SkinLicense = new List<SkinLicense>();
			//public List<SkinMaterials> SkinMaterials = new List<SkinMaterials>();
			//public List<Skins> Skins = new List<Skins>();
			//public List<SkinShip> SkinShip = new List<SkinShip>();
			//public List<StaOperations> StaOperations = new List<StaOperations>();
			//public List<StaOperationServices> StaOperationServices = new List<StaOperationServices>();
			//public List<StaServices> StaServices = new List<StaServices>();
			//public List<StaStationTypes> StaStationTypes = new List<StaStationTypes>();
			//public List<TrnTranslationColumns> TrnTranslationColumns = new List<TrnTranslationColumns>();
			//public List<TrnTranslationLanguages> TrnTranslationLanguages = new List<TrnTranslationLanguages>();
			//public List<WarCombatZones> WarCombatZones = new List<WarCombatZones>();
			//public List<WarCombatZoneSystems> WarCombatZoneSystems = new List<WarCombatZoneSystems>();
		}
		private readonly string SourceUrl = "http://sde.zzeve.com/";
		private MainSettings Settings { get; set; } = new MainSettings();
		/// <summary>
		/// Default constructor, settings must be passed in
		/// This will load all available data.
		/// </summary>
		/// <param name="settings"></param>
		public SDEData(ref MainSettings settings)
		{
			Settings = settings;

			LoadData();
		}

		public void LoadData()
		{
			InvTypes = GetSDEData<List<InvTypes>>("invTypes");
			StaStations = GetSDEData<List<StaStations>>("staStations");
			SolarSystems = GetSDEData<List<MapSolarSystems>>("mapSolarSystems");
			Regions = GetSDEData<List<MapRegions>>("mapRegions");
			MapDenormalize = GetSDEData<List<MapJumps>>("mapDenormalize");
			MapUniverse = GetSDEData<List<MapUniverse>>("mapUniverse");

			InvItems = GetSDEData<List<InvItems>>("invItems");
			InvNames = GetSDEData<List<InvNames>>("invNames");
			InvPositions = GetSDEData<List<InvPositions>>("invPositions");
			InvUniqueNames = GetSDEData<List<InvUniqueNames>>("invUniqueNames");
			InvGroups = GetSDEData<List<InvGroups>>("invGroups");
			CrpNPCCorporations = GetSDEData<List<CrpNPCCorporations>>("crpNPCCorporations");
		}

		public T GetSDEData<T>(string fileName)
		{
			List<object> Data = new List<object>();
			if (File.Exists(Settings.SDEDirectory + $"{fileName}.json"))
			{
				string input;
				using (StreamReader myReader = new StreamReader(Settings.SDEDirectory + $"{fileName}.json"))
				{
					input = myReader.ReadToEnd();
				}
				T result = JsonConvert.DeserializeObject<T>(input);
				return result;
			}
			else
			{
				// todo change this to enable downloading of individual parts

				using (HttpClient client = new HttpClient())
				{
					var httpResult = client.GetStringAsync(SourceUrl + fileName + ".json");
					while (!httpResult.IsCompleted)
					{
						Task.Delay(50).Wait();
					}
					List<object> data = new List<object>();
					data = JsonConvert.DeserializeObject<List<object>>(httpResult.Result);
					using (StreamWriter myWriter = new StreamWriter(Settings.SDEDirectory + fileName + ".json"))
					{
						using (JsonWriter writer = new JsonTextWriter(myWriter))
						{
							Settings.serializer.Serialize(writer, data);
						}
					}
				}

				string input;
				using (StreamReader myReader = new StreamReader(Settings.SDEDirectory + $"{fileName}.json"))
				{
					input = myReader.ReadToEnd();
				}
				T result = JsonConvert.DeserializeObject<T>(input);
				return result;
			}
		}

		public List<InvTypes> InvTypes { get; private set; } = null;
		public List<StaStations> StaStations { get; private set; } = null;
		public List<MapSolarSystems> SolarSystems { get; private set; } = null;
		public List<MapRegions> Regions { get; private set; } = null;
		public List<MapJumps> MapDenormalize { get; private set; } = null;
		public List<MapUniverse> MapUniverse { get; private set; } = null;
		public List<InvItems> InvItems { get; private set; } = null;
		public List<InvNames> InvNames { get; private set; } = null;
		public List<InvPositions> InvPositions { get; private set; } = null;
		public List<InvUniqueNames> InvUniqueNames { get; private set; } = null;
		public List<InvGroups> InvGroups { get; private set; } = null;
		public List<CrpNPCCorporations> CrpNPCCorporations { get; private set; } = null;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
				if (Settings != null)
				{
					Settings.Dispose();
					Settings = null;
				}
				// Dispose remaining objects,
			}
		}
	}
	public enum SDEFlags
	{
		agtAgents,
		agtAgentTypes,
		agtResearchAgents,
		certCerts,
		certMasteries,
		certSkills,
		chrAncestries,
		chrAttributes,
		chrBloodlines,
		chrFactions,
		chrRaces,
		crpActivities,
		crpNPCCorporationDivisions,
		crpNPCCorporationResearchFields,
		crpNPCCorporations,
		crpNPCCorporationTrades,
		crpNPCDivisions,
		dgmAttributeCategories,
		dgmAttributeTypes,
		dgmEffects,
		dgmExpressions,
		dgmTypeAttributes,
		dgmTypeEffects,
		eveGraphics,
		eveIcons,
		eveUnits,
		industryActivity,
		industryActivityMaterials,
		industryActivityProbabilities,
		industryActivityProducts,
		industryActivityRaces,
		industryActivitySkills,
		industryBlueprints,
		invCategories,
		invContrabandTypes,
		invControlTowerResourcePurposes,
		invControlTowerResources,
		invFlags,
		invGroups,
		invItems,
		invMarketGroups,
		invMetaGroups,
		invMetaTypes,
		invNames,
		invPositions,
		invTraits,
		invTypeMaterials,
		invTypeReactions,
		invTypes,
		invUniqueNames,
		invVolumes,
		mapConstellationJumps,
		mapConstellations,
		mapJumps,
		mapLandmarks,
		mapLocationScenes,
		mapLocationWormholeClasses,
		mapRegionJumps,
		mapRegions,
		mapSolarSystemJumps,
		mapSolarSystems,
		mapUniverse,
		planetSchematics,
		planetSchematicsPinMap,
		planetSchematicsTypeMap,
		ramActivities,
		ramAssemblyLineStations,
		ramAssemblyLineTypeDetailPerCategory,
		ramAssemblyLineTypeDetailPerGroup,
		ramAssemblyLineTypes,
		ramInstallationTypeContents,
		skinLicense,
		skinMaterials,
		skins,
		skinShip,
		staOperations,
		staOperationServices,
		staServices,
		staStations,
		staStationTypes,
		translationTables,
		trnTranslationColumns,
		trnTranslationLanguages,
		warCombatZones,
		warCombatZoneSystems
	}
}
