namespace System.IO
{
	using Net;

	/// <summary>
	/// System.IO.BinaryWriter Extensions
	/// </summary>
	public static class BinaryWriterExtensions
	{
		/// <summary>
		/// System.IO.BinaryWriter Write System.Net.IPAddress
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="address"></param>
		public static void Write(this BinaryWriter writer, IPAddress address)
		{
			ByteOrder order = ByteOrder.BigEndian;
			if (writer is BinaryWriterV2 v)
				order = v.Order;
			byte[] buf = address.GetAddressBytes();
			if (order == ByteOrder.LittleEndian)
				Array.Reverse(buf);
			writer.Write(buf);
		}
	}
}
