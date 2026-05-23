namespace System.IO
{
	using Net;
	using Net.Sockets;
	using System.Text;

	/// <summary>
	/// System.IO.BinaryReader Extensions
	/// </summary>
	public static class BinaryReaderExtensions
	{
		/// <summary>
		/// System.IO.BinaryReader to Read System.Net.IPAddress
		/// </summary>
		public static IPAddress ReadIPAddress(this BinaryReader reader)
		{
			Endian endian = Endian.BigEndian;
			if (reader is EndianBinaryReader v)
				endian = v.Endian;
			AddressFamily family = (AddressFamily) reader.ReadInt32();
			byte[] buf = reader.ReadBytes(family == AddressFamily.InterNetwork ? 4 : 16);
			if (endian == Endian.LittleEndian)
				Array.Reverse(buf);
			return new IPAddress(buf);
		}

		/// <summary>
		/// UTF-8 바이트 길이 + UTF-8 디코딩 바이너리 형태로 기록된 데이터를 읽습니다.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static string ReadUTF8(this BinaryReader reader)
		{
			int length = reader.ReadInt32();
			if (length < 0)
				length = 0;
			byte[] buf = new byte[length];
			byte[] valueBlock = reader.ReadBytes(length);
			return Encoding.UTF8.GetString(valueBlock);
		}
	}
}
