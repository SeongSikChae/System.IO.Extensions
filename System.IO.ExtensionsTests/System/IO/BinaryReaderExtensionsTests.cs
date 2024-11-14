namespace System.IO.Tests
{
	using Net;
	using Net.Sockets;

	[TestClass]
	public class BinaryReaderExtensionsTests
	{
		[TestMethod]
		public void ReadIPAddressTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReader(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(IPAddress.Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReader(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(IPAddress.IPv6Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.IPv6Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.LittleEndian);
				using BinaryWriterV2 writer = new BinaryWriterV2(memory, ByteOrder.LittleEndian);
				writer.Write(IPAddress.Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				using BinaryWriterV2 writer = new BinaryWriterV2(memory, ByteOrder.BigEndian);
				writer.Write(IPAddress.IPv6Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.IPv6Loopback, address);
			}
		}
	}
}