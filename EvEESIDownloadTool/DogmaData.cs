using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESI.NET.Models.Dogma;
using Newtonsoft.Json;

namespace EvEESITool
{
	public class DogmaData : DataClassesBase
	{
		public List<int> GetAttributes()
		{
			return DownloadData<List<int>>("Attributes", Settings.EsiClient.Dogma.Attributes()); // /dogma/attributes/:public
		}
		public ESI.NET.Models.Dogma.Attribute GetAttribute(int attributeID)
		{
			return DownloadData<ESI.NET.Models.Dogma.Attribute>("Attribute", Settings.EsiClient.Dogma.Attribute(attributeID)); // /dogma/attributes/{attribute_id}/:public
		}
		public List<int> GetEffects()
		{
			return DownloadData<List<int>>("NAME", Settings.EsiClient.Dogma.Effects()); // /dogma/effects/:public
		}
		public Effect GetEffect(int effectID)
		{
			return DownloadData<Effect>("NAME", Settings.EsiClient.Dogma.Effect(effectID)); // /dogma/effects/{effect_id}/:public
		}

		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal DogmaData() : base()
		{
		}
		internal DogmaData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}


		public override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
