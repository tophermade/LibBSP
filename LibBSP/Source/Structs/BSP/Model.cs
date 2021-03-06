using System;
using System.Collections.Generic;
using System.Reflection;

namespace LibBSP {

	/// <summary>
	/// A class containing all data needed for the models lump in any given BSP.
	/// </summary>
	public struct Model : ILumpObject {

		/// <summary>
		/// The <see cref="ILump"/> this <see cref="ILumpObject"/> came from.
		/// </summary>
		public ILump Parent { get; private set; }

		/// <summary>
		/// Array of <c>byte</c>s used as the data source for this <see cref="ILumpObject"/>.
		/// </summary>
		public byte[] Data { get; private set; }

		/// <summary>
		/// The <see cref="LibBSP.MapType"/> to use to interpret <see cref="Data"/>.
		/// </summary>
		public MapType MapType {
			get {
				if (Parent == null || Parent.Bsp == null) {
					return MapType.Undefined;
				}
				return Parent.Bsp.version;
			}
		}

		/// <summary>
		/// The version number of the <see cref="ILump"/> this <see cref="ILumpObject"/> came from.
		/// </summary>
		public int LumpVersion {
			get {
				if (Parent == null) {
					return 0;
				}
				return Parent.LumpInfo.version;
			}
		}

		[Index("nodes")] public int headNode {
			get {
				switch (MapType) {
					case MapType.Quake:
					case MapType.Quake2:
					case MapType.Daikatana:
					case MapType.SiN:
					case MapType.SoF:
					case MapType.Source17:
					case MapType.Source18:
					case MapType.Source19:
					case MapType.Source20:
					case MapType.Source21:
					case MapType.Source22:
					case MapType.Source23:
					case MapType.Source27:
					case MapType.L4D2:
					case MapType.TacticalInterventionEncrypted:
					case MapType.Vindictus: {
						return BitConverter.ToInt32(Data, 36);
					}
					case MapType.DMoMaM: {
						return BitConverter.ToInt32(Data, 40);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.Quake:
					case MapType.Quake2:
					case MapType.Daikatana:
					case MapType.SiN:
					case MapType.SoF:
					case MapType.Source17:
					case MapType.Source18:
					case MapType.Source19:
					case MapType.Source20:
					case MapType.Source21:
					case MapType.Source22:
					case MapType.Source23:
					case MapType.Source27:
					case MapType.L4D2:
					case MapType.TacticalInterventionEncrypted:
					case MapType.Vindictus: {
						bytes.CopyTo(Data, 36);
						break;
					}
					case MapType.DMoMaM: {
						bytes.CopyTo(Data, 40);
						break;
					}
				}
			}
		}

		[Index("leaves")] public int firstLeaf {
			get {
				switch (MapType) {
					case MapType.Nightfire: {
						return BitConverter.ToInt32(Data, 40);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.Nightfire: {
						bytes.CopyTo(Data, 40);
						break;
					}
				}
			}
		}

		[Count("leaves")] public int numLeaves {
			get {
				switch (MapType) {
					case MapType.Nightfire: {
						return BitConverter.ToInt32(Data, 44);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.Nightfire: {
						bytes.CopyTo(Data, 44);
						break;
					}
				}
			}
		}

		[Index("brushes")] public int firstBrush {
			get {
				switch (MapType) {
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						return BitConverter.ToInt32(Data, 32);
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.CoD4: {
						return BitConverter.ToInt32(Data, 40);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						bytes.CopyTo(Data, 32);
						break;
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.CoD4: {
						bytes.CopyTo(Data, 40);
						break;
					}
				}
			}
		}

		[Count("brushes")] public int numBrushes {
			get {
				switch (MapType) {
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						return BitConverter.ToInt32(Data, 36);
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.CoD4: {
						return BitConverter.ToInt32(Data, 44);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						bytes.CopyTo(Data, 36);
						break;
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.CoD4: {
						bytes.CopyTo(Data, 44);
						break;
					}
				}
			}
		}

		[Index("faces")] public int firstFace {
			get {
				switch (MapType) {
					case MapType.CoD4: {
						return BitConverter.ToInt16(Data, 24);
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						return BitConverter.ToInt32(Data, 24);
					}
					case MapType.Quake2:
					case MapType.Daikatana:
					case MapType.SiN:
					case MapType.SoF:
					case MapType.Source17:
					case MapType.Source18:
					case MapType.Source19:
					case MapType.Source20:
					case MapType.Source21:
					case MapType.Source22:
					case MapType.Source23:
					case MapType.Source27:
					case MapType.L4D2:
					case MapType.TacticalInterventionEncrypted:
					case MapType.Vindictus: {
						return BitConverter.ToInt32(Data, 40);
					}
					case MapType.DMoMaM: {
						return BitConverter.ToInt32(Data, 44);
					}
					case MapType.Nightfire: {
						return BitConverter.ToInt32(Data, 48);
					}
					case MapType.Quake: {
						return BitConverter.ToInt32(Data, 56);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.CoD4: {
						Data[24] = bytes[0];
						Data[25] = bytes[1];
						break;
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						bytes.CopyTo(Data, 24);
						break;
					}
					case MapType.Quake2:
					case MapType.Daikatana:
					case MapType.SiN:
					case MapType.SoF:
					case MapType.Source17:
					case MapType.Source18:
					case MapType.Source19:
					case MapType.Source20:
					case MapType.Source21:
					case MapType.Source22:
					case MapType.Source23:
					case MapType.Source27:
					case MapType.L4D2:
					case MapType.TacticalInterventionEncrypted:
					case MapType.Vindictus: {
						bytes.CopyTo(Data, 40);
						break;
					}
					case MapType.DMoMaM: {
						bytes.CopyTo(Data, 44);
						break;
					}
					case MapType.Nightfire: {
						bytes.CopyTo(Data, 48);
						break;
					}
					case MapType.Quake: {
						bytes.CopyTo(Data, 56);
						break;
					}
				}
			}
		}

		[Count("faces")] public int numFaces {
			get {
				switch (MapType) {
					case MapType.CoD4: {
						return BitConverter.ToInt16(Data, 28);
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						return BitConverter.ToInt32(Data, 28);
					}
					case MapType.Quake2:
					case MapType.Daikatana:
					case MapType.SiN:
					case MapType.SoF:
					case MapType.Source17:
					case MapType.Source18:
					case MapType.Source19:
					case MapType.Source20:
					case MapType.Source21:
					case MapType.Source22:
					case MapType.Source23:
					case MapType.Source27:
					case MapType.L4D2:
					case MapType.TacticalInterventionEncrypted:
					case MapType.Vindictus: {
						return BitConverter.ToInt32(Data, 44);
					}
					case MapType.DMoMaM: {
						return BitConverter.ToInt32(Data, 48);
					}
					case MapType.Nightfire: {
						return BitConverter.ToInt32(Data, 52);
					}
					case MapType.Quake: {
						return BitConverter.ToInt32(Data, 60);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.CoD4: {
						Data[28] = bytes[0];
						Data[29] = bytes[1];
						break;
					}
					case MapType.CoD:
					case MapType.CoD2:
					case MapType.STEF2:
					case MapType.STEF2Demo:
					case MapType.Quake3:
					case MapType.MOHAA:
					case MapType.Raven:
					case MapType.FAKK: {
						bytes.CopyTo(Data, 28);
						break;
					}
					case MapType.Quake2:
					case MapType.Daikatana:
					case MapType.SiN:
					case MapType.SoF:
					case MapType.Source17:
					case MapType.Source18:
					case MapType.Source19:
					case MapType.Source20:
					case MapType.Source21:
					case MapType.Source22:
					case MapType.Source23:
					case MapType.Source27:
					case MapType.L4D2:
					case MapType.TacticalInterventionEncrypted:
					case MapType.Vindictus: {
						bytes.CopyTo(Data, 44);
						break;
					}
					case MapType.DMoMaM: {
						bytes.CopyTo(Data, 48);
						break;
					}
					case MapType.Nightfire: {
						bytes.CopyTo(Data, 52);
						break;
					}
					case MapType.Quake: {
						bytes.CopyTo(Data, 60);
						break;
					}
				}
			}
		}

		[Index("markSurfaces")]
		public int firstLeafPatch {
			get {
				switch (MapType) {
					case MapType.CoD:
					case MapType.CoD2: {
						return BitConverter.ToInt32(Data, 32);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.CoD:
					case MapType.CoD2: {
						bytes.CopyTo(Data, 32);
						break;
					}
				}
			}
		}

		[Count("markSurfaces")] public int numLeafPatches {
			get {
				switch (MapType) {
					case MapType.CoD:
					case MapType.CoD2: {
						return BitConverter.ToInt32(Data, 36);
					}
					default: {
						return -1;
					}
				}
			}
			set {
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType) {
					case MapType.CoD:
					case MapType.CoD2: {
						bytes.CopyTo(Data, 36);
						break;
					}
				}
			}
		}

		/// <summary>
		/// Creates a new <see cref="Model"/> object from a <c>byte</c> array.
		/// </summary>
		/// <param name="data"><c>byte</c> array to parse.</param>
		/// <param name="parent">The <see cref="ILump"/> this <see cref="Model"/> came from.</param>
		/// <exception cref="ArgumentNullException"><paramref name="data"/> was <c>null</c>.</exception>
		public Model(byte[] data, ILump parent = null) {
			if (data == null) {
				throw new ArgumentNullException();
			}

			Data = data;
			Parent = parent;
		}

		/// <summary>
		/// Factory method to parse a <c>byte</c> array into a <see cref="Lump{Model}"/>.
		/// </summary>
		/// <param name="data">The data to parse.</param>
		/// <param name="bsp">The <see cref="BSP"/> this lump came from.</param>
		/// <param name="lumpInfo">The <see cref="LumpInfo"/> associated with this lump.</param>
		/// <returns>A <see cref="Lump{Model}"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="data"/> parameter was <c>null</c>.</exception>
		public static Lump<Model> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo) {
			if (data == null) {
				throw new ArgumentNullException();
			}
			
			return new Lump<Model>(data, GetStructLength(bsp.version, lumpInfo.version), bsp, lumpInfo);
		}

		/// <summary>
		/// Gets the length of this struct's data for the given <paramref name="mapType"/> and <paramref name="lumpVersion"/>.
		/// </summary>
		/// <param name="mapType">The <see cref="LibBSP.MapType"/> of the BSP.</param>
		/// <param name="lumpVersion">The version number for the lump.</param>
		/// <returns>The length, in <c>byte</c>s, of this struct.</returns>
		/// <exception cref="ArgumentException">This struct is not valid or is not implemented for the given <paramref name="mapType"/> and <paramref name="lumpVersion"/>.</exception>
		public static int GetStructLength(MapType mapType, int lumpVersion = 0) {
			switch (mapType) {
				case MapType.Titanfall: {
					return 32;
				}
				case MapType.Quake3:
				case MapType.Raven:
				case MapType.STEF2:
				case MapType.STEF2Demo:
				case MapType.MOHAA:
				case MapType.FAKK: {
					return 40;
				}
				case MapType.Quake2:
				case MapType.Daikatana:
				case MapType.CoD:
				case MapType.CoD2:
				case MapType.CoD4:
				case MapType.SiN:
				case MapType.SoF:
				case MapType.Source17:
				case MapType.Source18:
				case MapType.Source19:
				case MapType.Source20:
				case MapType.Source21:
				case MapType.Source22:
				case MapType.Source23:
				case MapType.Source27:
				case MapType.L4D2:
				case MapType.TacticalInterventionEncrypted:
				case MapType.Vindictus: {
					return 48;
				}
				case MapType.DMoMaM: {
					return 52;
				}
				case MapType.Nightfire: {
					return 56;
				}
				case MapType.Quake: {
					return 64;
				}
				default: {
					throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType + " or has not been implemented.");
				}
			}
		}

		/// <summary>
		/// Gets the index for this lump in the BSP file for a specific map format.
		/// </summary>
		/// <param name="type">The map type.</param>
		/// <returns>Index for this lump, or -1 if the format doesn't have this lump.</returns>
		public static int GetIndexForLump(MapType type) {
			switch (type) {
				case MapType.Raven:
				case MapType.Quake3: {
					return 7;
				}
				case MapType.MOHAA:
				case MapType.FAKK:
				case MapType.Quake2:
				case MapType.SiN:
				case MapType.Daikatana:
				case MapType.SoF: {
					return 13;
				}
				case MapType.Quake:
				case MapType.Nightfire:
				case MapType.Vindictus:
				case MapType.TacticalInterventionEncrypted:
				case MapType.Source17:
				case MapType.Source18:
				case MapType.Source19:
				case MapType.Source20:
				case MapType.Source21:
				case MapType.Source22:
				case MapType.Source23:
				case MapType.Source27:
				case MapType.L4D2:
				case MapType.DMoMaM:
				case MapType.Titanfall: {
					return 14;
				}
				case MapType.STEF2:
				case MapType.STEF2Demo: {
					return 15;
				}
				case MapType.CoD: {
					return 27;
				}
				case MapType.CoD2: {
					return 35;
				}
				case MapType.CoD4: {
					return 37;
				}
				default: {
					return -1;
				}
			}
		}

	}
}
