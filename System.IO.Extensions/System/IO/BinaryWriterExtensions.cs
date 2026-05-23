namespace System.IO
{
	using Net;
	using Text;

	/// <summary>
	/// System.IO.BinaryWriter Extensions
	/// </summary>
	public static class BinaryWriterExtensions
	{
		/// <summary>
		/// System.IO.BinaryWriter Write System.Net.IPAddress
		/// </summary>
		public static void Write(this BinaryWriter writer, IPAddress address)
		{
            Endian endian = Endian.BigEndian;
			if (writer is EndianBinaryWriter v)
				endian = v.Endian;
			writer.Write((int)address.AddressFamily);
			byte[] buf = address.GetAddressBytes();
			if (endian == Endian.LittleEndian)
				Array.Reverse(buf);
			writer.Write(buf);
		}

		/// <summary>
		/// 문자열을 BinaryWrtier에 문자열의 UTF-8 바이트 길이 + UTF-8 디코딩 바이너리 형태로 기록합니다.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteUTF8(this BinaryWriter writer, string value)
		{
			byte[] valueBlock = Encoding.UTF8.GetBytes(value);
			writer.Write(valueBlock.Length);
			writer.Write(valueBlock);
		}
	}
}
