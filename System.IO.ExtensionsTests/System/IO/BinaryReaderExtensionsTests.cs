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
				memory.Write(IPAddress.Loopback.GetAddressBytes());
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReader(memory);
				memory.Write(IPAddress.IPv6Loopback.GetAddressBytes());
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.IPv6Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory);
				byte[] buf = IPAddress.Loopback.GetAddressBytes();
				Array.Reverse(buf);
				memory.Write(buf);
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.Loopback, address);
			}

			{
				using MemoryStream memory = new MemoryStream();
				using BinaryReader reader = new BinaryReaderV2(memory, ByteOrder.BigEndian);
				memory.Write(IPAddress.Loopback.GetAddressBytes());
				memory.Position = 0;
				IPAddress address = reader.ReadIPAddress();
				Assert.AreEqual(IPAddress.Loopback, address);
			}
		}
	}
}