namespace System.IO
{
	using Net;
	using Net.Sockets;

	/// <summary>
	/// System.IO.BinaryReader Extensions
	/// </summary>
	public static class BinaryReaderExtensions
	{
		/// <summary>
		/// System.IO.BinaryReader to Read System.Net.IPAddress
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="addressFamily"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static IPAddress ReadIPAddress(this BinaryReader reader, AddressFamily addressFamily)
		{
			byte[] buf = addressFamily switch
			{
				AddressFamily.InterNetwork => reader.ReadBytes(4),
				AddressFamily.InterNetworkV6 => reader.ReadBytes(16),
				_ => throw new InvalidOperationException($"unsupported addressFamily '{addressFamily}'"),
			};
			ByteOrder order = ByteOrder.BigEndian;
			if (reader is BinaryReaderV2 v)
				order = v.Order;
			if (order == ByteOrder.LittleEndian)
				Array.Reverse(buf);
			return new IPAddress(buf);
		}
	}
}
