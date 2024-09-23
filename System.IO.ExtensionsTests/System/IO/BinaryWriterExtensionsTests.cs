namespace System.IO.Tests
{
	using Net;
	using Net.Sockets;

	[TestClass]
	public class BinaryWriterExtensionsTests
	{
		[TestMethod]
		public void WriteTest()
		{
			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReader(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(IPAddress.Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress(AddressFamily.InterNetwork);
				Assert.AreEqual(IPAddress.Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReader(memory);
				using BinaryWriter writer = new BinaryWriter(memory);
				writer.Write(IPAddress.IPv6Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress(AddressFamily.InterNetworkV6);
				Assert.AreEqual(IPAddress.IPv6Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				using BinaryWriter writer = new BinaryWriterV2(memory);
				writer.Write(IPAddress.Loopback);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress(AddressFamily.InterNetwork);
				Assert.AreEqual(IPAddress.Loopback, address);
			}
		}
	}
}