namespace System.IO.Tests
{
	[TestClass]
	public class EndianBinaryWriterTests
	{
		[TestMethod]
		public void WriteTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(short.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(short.MaxValue, reader.ReadInt16());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(short.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(short.MaxValue, reader.ReadInt16());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(ushort.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(ushort.MaxValue, reader.ReadUInt16());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(ushort.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(ushort.MaxValue, reader.ReadUInt16());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(int.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(int.MaxValue, reader.ReadInt32());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(int.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(int.MaxValue, reader.ReadInt32());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(uint.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(uint.MaxValue, reader.ReadUInt32());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(uint.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(uint.MaxValue, reader.ReadUInt32());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(long.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(long.MaxValue, reader.ReadInt64());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(long.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(long.MaxValue, reader.ReadInt64());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(ulong.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(ulong.MaxValue, reader.ReadUInt64());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(ulong.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(ulong.MaxValue, reader.ReadUInt64());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(Half.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(Half.MaxValue, reader.ReadHalf());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(Half.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(Half.MaxValue, reader.ReadHalf());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(float.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(float.MaxValue, reader.ReadSingle());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(float.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(float.MaxValue, reader.ReadSingle());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(double.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(double.MaxValue, reader.ReadDouble());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(double.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(double.MaxValue, reader.ReadDouble());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory);
				using BinaryWriter writer = new EndianBinaryWriter(memory);
				writer.Write(decimal.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(decimal.MaxValue, reader.ReadDecimal());
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using BinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(decimal.MaxValue);
				memory.Position = 0;
				Assert.AreEqual(decimal.MaxValue, reader.ReadDecimal());
			}
		}
	}
}