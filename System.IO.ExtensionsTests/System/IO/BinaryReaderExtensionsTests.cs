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
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.LittleEndian);
				using EndianBinaryWriter writer = new EndianBinaryWriter(memory, Endian.LittleEndian);
				writer.Write(IPAddress.Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new EndianBinaryReader(memory, Endian.BigEndian);
				using EndianBinaryWriter writer = new EndianBinaryWriter(memory, Endian.BigEndian);
				writer.Write(IPAddress.IPv6Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.IPv6Loopback, address);
			}
		}
	}
}