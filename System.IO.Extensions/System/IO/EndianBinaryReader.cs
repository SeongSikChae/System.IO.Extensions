namespace System.IO
{
	using Buffers.Binary;
	using Reflection;
	using Text;

	/// <summary>
	/// Reads a primitive data type as a binary value in a specific encoding, based on Endian.
	/// </summary>
	/// <param name="input"></param>
	/// <param name="encoding"></param>
	/// <param name="leaveOpen"></param>
	/// <param name="endian"></param>
	public sealed class EndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen, Endian endian) : BinaryReader(input, encoding, leaveOpen)
	{
		/// <summary>
		/// Specify only stream and Endian
		/// </summary>
		/// <param name="input"></param>
		/// <param name="endian"></param>
		public EndianBinaryReader(Stream input, Endian endian = Endian.LittleEndian) : this(input, Encoding.UTF8, endian) { }

		/// <summary>
		/// Specify only stream, encoding, and Endian
		/// </summary>
		/// <param name="input"></param>
		/// <param name="encoding"></param>
		/// <param name="endian"></param>
		public EndianBinaryReader(Stream input, Encoding encoding, Endian endian = Endian.LittleEndian) : this(input, encoding, false, endian) { }

		/// <summary>
		/// Byte Endian
		/// </summary>
		public Endian Endian => endian;

		/// <summary>
		/// BinaryReaderV2 Override ReadInt16
		/// </summary>
		/// <returns></returns>
		public override short ReadInt16()
		{
			Span<byte> buf = stackalloc byte[sizeof(short)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
                Endian.BigEndian => BinaryPrimitives.ReadInt16BigEndian(buf),
				_ => BinaryPrimitives.ReadInt16LittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadUInt16
		/// </summary>
		/// <returns></returns>
		public override ushort ReadUInt16()
		{
			Span<byte> buf = stackalloc byte[sizeof(ushort)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadUInt16BigEndian(buf),
				_ => BinaryPrimitives.ReadUInt16LittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadInt32
		/// </summary>
		/// <returns></returns>
		public override int ReadInt32()
		{
			Span<byte> buf = stackalloc byte[sizeof(int)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadInt32BigEndian(buf),
				_ => BinaryPrimitives.ReadInt32LittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadUInt32
		/// </summary>
		/// <returns></returns>
		public override uint ReadUInt32()
		{
			Span<byte> buf = stackalloc byte[sizeof(uint)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadUInt32BigEndian(buf),
				_ => BinaryPrimitives.ReadUInt32LittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadInt64
		/// </summary>
		/// <returns></returns>
		public override long ReadInt64()
		{
			Span<byte> buf = stackalloc byte[sizeof(long)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadInt64BigEndian(buf),
				_ => BinaryPrimitives.ReadInt64LittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadInt64
		/// </summary>
		/// <returns></returns>
		public override ulong ReadUInt64()
		{
			Span<byte> buf = stackalloc byte[sizeof(ulong)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadUInt64BigEndian(buf),
				_ => BinaryPrimitives.ReadUInt64LittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadHalf
		/// </summary>
		/// <returns></returns>
		public override Half ReadHalf()
		{
			Span<byte> buf = stackalloc byte[sizeof(ushort)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadHalfBigEndian(buf),
				_ => BinaryPrimitives.ReadHalfLittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadSingle
		/// </summary>
		/// <returns></returns>
		public override float ReadSingle()
		{
			Span<byte> buf = stackalloc byte[sizeof(float)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadSingleBigEndian(buf),
				_ => BinaryPrimitives.ReadSingleLittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadDouble
		/// </summary>
		/// <returns></returns>
		public override double ReadDouble()
		{
			Span<byte> buf = stackalloc byte[sizeof(double)];
			BaseStream.ReadExactly(buf);
			return Endian switch
			{
				Endian.BigEndian => BinaryPrimitives.ReadDoubleBigEndian(buf),
				_ => BinaryPrimitives.ReadDoubleLittleEndian(buf),
			};
		}

		/// <summary>
		/// BinaryReaderV2 Override ReadDecimal (OverHead Existence by Reflection)
		/// </summary>
		/// <returns></returns>
		public override decimal ReadDecimal()
		{
			Span<byte> buf = stackalloc byte[sizeof(decimal)];
			BaseStream.ReadExactly(buf);
			ReadOnlySpan<byte> span = buf;
			int lo;
			int mid;
			int hi;
			int flags;
			switch (Endian)
			{
				case Endian.BigEndian:
					flags = BinaryPrimitives.ReadInt32BigEndian(span);
					hi = BinaryPrimitives.ReadInt32BigEndian(span[4..]);
					mid = BinaryPrimitives.ReadInt32BigEndian(span[8..]);
					lo = BinaryPrimitives.ReadInt32BigEndian(span[12..]);
					break;
				default:
					lo = BinaryPrimitives.ReadInt32LittleEndian(span);
					mid = BinaryPrimitives.ReadInt32LittleEndian(span[4..]);
					hi = BinaryPrimitives.ReadInt32LittleEndian(span[8..]);
					flags = BinaryPrimitives.ReadInt32LittleEndian(span[12..]);
					break;
			}
			Type type = typeof(decimal);
			ConstructorInfo? ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, [typeof(int), typeof(int), typeof(int), typeof(int)], null);
			ArgumentNullException.ThrowIfNull(ctor);
			return (decimal)ctor.Invoke([lo, mid, hi, flags]);
		}
	}
}
