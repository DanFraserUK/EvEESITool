﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ESI.NET.Models.Universe;

namespace EvEESITool
{
    public class UniverseData : DataClassesBase
    {
        public Structure GetStructure(long structureID)
        {
            return DownloadData("Structure", Settings.EsiClient.Universe.Structure(structureID));
        }

        public IDLookup Search(List<string> names)
        {
            return DownloadData("Search", Settings.EsiClient.Universe.IDs(names));
        }
		public ESI.NET.Models.Universe.Type TypeInformation(int typeID)
		{
			return DownloadData(Settings.EsiClient.Universe.Type(typeID));
		}
        /// <summary>
        /// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
        /// </summary>
        [JsonConstructor]
        internal UniverseData()
        {
        }
        internal UniverseData(ref ProfileSettings settings) : base(ref settings)
        {
        }
        protected override void Download()
        {
            Console.WriteLine();
            SaveToFile();
        }
        protected override bool ReadInData()
        {
            throw new NotImplementedException();
        }
    }
}
