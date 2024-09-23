namespace System.IO.Tests
{
	[TestClass]
	public class BinaryReaderV2Tests
	{
		[TestMethod]
		public void ReadInt16Test()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				memory.Write([0x01, 0x00]);
				memory.Position = 0;
				short value = reader.ReadInt16();
				Assert.AreEqual(1, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write([0x00, 0x01]);
				memory.Position = 0;
				short value = reader.ReadInt16();
				Assert.AreEqual(1, value);
			}
		}

		[TestMethod]
		public void ReadUInt16Test()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				memory.Write([0xfe, 0xff]);
				memory.Position = 0;
				ushort value = reader.ReadUInt16();
				Assert.AreEqual(65534, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write([0xff, 0xfe]);
				memory.Position = 0;
				ushort value = reader.ReadUInt16();
				Assert.AreEqual(65534, value);
			}
		}

		[TestMethod]
		public void ReadInt32Test()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				memory.Write([0x01, 0x00, 0x00, 0x00]);
				memory.Position = 0;
				int value = reader.ReadInt32();
				Assert.AreEqual(1, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write([0x00, 0x00, 0x00, 0x01]);
				memory.Position = 0;
				int value = reader.ReadInt32();
				Assert.AreEqual(1, value);
			}
		}

		[TestMethod]
		public void ReadUInt32Test()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				memory.Write([0xfe, 0xff, 0xff, 0xff]);
				memory.Position = 0;
				uint value = reader.ReadUInt32();
				Assert.AreEqual(4294967294, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write([0xff, 0xff, 0xff, 0xfe]);
				memory.Position = 0;
				uint value = reader.ReadUInt32();
				Assert.AreEqual(4294967294, value);
			}
		}

		[TestMethod]
		public void ReadInt64Test()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				memory.Write([0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
				memory.Position = 0;
				long value = reader.ReadInt64();
				Assert.AreEqual(1, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write([0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01]);
				memory.Position = 0;
				long value = reader.ReadInt64();
				Assert.AreEqual(1, value);
			}
		}

		[TestMethod]
		public void ReadUInt64Test()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				memory.Write([0xfe, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff]);
				memory.Position = 0;
				ulong value = reader.ReadUInt64();
				Assert.AreEqual(ulong.MaxValue - 1, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write([0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe]);
				memory.Position = 0;
				ulong value = reader.ReadUInt64();
				Assert.AreEqual(ulong.MaxValue - 1, value);
			}
		}

		[TestMethod]
		public void ReadHalfTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write((Half)1.1);
				memory.Position = 0;
				Half half = reader.ReadHalf();
				Assert.AreEqual((Half)1.1, half);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write((Half)1.1);
				byte[] buf = memory.ToArray();
				Array.Reverse(buf);
				memory.Position = 0;
				memory.Write(buf, 0, buf.Length);
				memory.Position = 0;
				Half half = reader.ReadHalf();
				Assert.AreEqual((Half)1.1, half);
			}
		}

		[TestMethod]
		public void ReadSingleTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(1.1f);
				memory.Position = 0;
				float value = reader.ReadSingle();
				Assert.AreEqual(1.1f, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(1.1f);
				byte[] buf = memory.ToArray();
				Array.Reverse(buf);
				memory.Position = 0;
				memory.Write(buf, 0, buf.Length);
				memory.Position = 0;
				float value = reader.ReadSingle();
				Assert.AreEqual(1.1f, value);
			}
		}

		[TestMethod]
		public void ReadDoubleTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(1.1);
				memory.Position = 0;
				double value = reader.ReadDouble();
				Assert.AreEqual(1.1, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(1.1);
				byte[] buf = memory.ToArray();
				Array.Reverse(buf);
				memory.Position = 0;
				memory.Write(buf, 0, buf.Length);
				memory.Position = 0;
				double value = reader.ReadDouble();
				Assert.AreEqual(1.1, value);
			}
		}

		[TestMethod]
		public void ReadDecimalTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write((decimal)1);
				memory.Position = 0;
				decimal value = reader.ReadDecimal();
				Assert.AreEqual(1, value);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write((decimal)1);
				byte[] buf = memory.ToArray();
				Array.Reverse(buf);
				memory.Position = 0;
				memory.Write(buf, 0, buf.Length);
				memory.Position = 0;
				decimal value = reader.ReadDecimal();
				Assert.AreEqual(1, value);
			}
		}
	}
}