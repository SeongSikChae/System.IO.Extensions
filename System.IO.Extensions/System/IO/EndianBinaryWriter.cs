namespace System.IO
{
	using Buffers.Binary;
	using Reflection;
	using Text;

	/// <summary>
	/// Writes the basic format of binary files to a stream according to Endian and supports writing strings in a specific encoding.
	/// </summary>
	/// <param name="output"></param>
	/// <param name="encoding"></param>
	/// <param name="leaveOpen"></param>
	/// <param name="endian"></param>
	public sealed class EndianBinaryWriter(Stream output, Encoding encoding, bool leaveOpen, Endian endian) : BinaryWriter(output, encoding, leaveOpen)
	{
		/// <summary>
		/// Specific streams and Endian
		/// </summary>
		/// <param name="output"></param>
		/// <param name="endian"></param>
		public EndianBinaryWriter(Stream output, Endian endian = Endian.LittleEndian) : this(output, Encoding.UTF8, endian) { }

		/// <summary>
		/// Specific streams and encodings and Endian
		/// </summary>
		/// <param name="output"></param>
		/// <param name="encoding"></param>
		/// <param name="endian"></param>
		public EndianBinaryWriter(Stream output, Encoding encoding, Endian endian = Endian.LittleEndian) : this(output, encoding, false, endian) { }

		/// <summary>
		/// Byte endian
		/// </summary>
		public Endian Endian => endian;

		/// <summary>
		/// BinaryWriterV2 Override Write Int16
		/// </summary>
		/// <param name="value"></param>
		public override void Write(short value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(short)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteInt16BigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteInt16LittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write UInt16
		/// </summary>
		/// <param name="value"></param>
		public override void Write(ushort value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(ushort)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteUInt16LittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write Int32
		/// </summary>
		/// <param name="value"></param>
		public override void Write(int value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(int)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteInt32BigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteInt32LittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write UInt32
		/// </summary>
		/// <param name="value"></param>
		public override void Write(uint value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(uint)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteUInt32LittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write Int64
		/// </summary>
		/// <param name="value"></param>
		public override void Write(long value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(long)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteInt64BigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteInt64LittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write UInt64
		/// </summary>
		/// <param name="value"></param>
		public override void Write(ulong value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(ulong)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteUInt64LittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write Half
		/// </summary>
		/// <param name="value"></param>
		public override void Write(Half value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(ushort)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteHalfBigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteHalfLittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write Single
		/// </summary>
		/// <param name="value"></param>
		public override void Write(float value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(float)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteSingleBigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteSingleLittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write Double
		/// </summary>
		/// <param name="value"></param>
		public override void Write(double value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(double)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
					break;
				default:
					BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
					break;
			}
			OutStream.Write(buffer);
		}

		/// <summary>
		/// BinaryWriterV2 Override Write Decimal
		/// </summary>
		/// <param name="value"></param>
		public override void Write(decimal value)
		{
			Type decimalType = typeof(decimal);
			PropertyInfo? lowProperty = decimalType.GetProperty("Low", BindingFlags.NonPublic | BindingFlags.Instance);
			ArgumentNullException.ThrowIfNull(lowProperty);
			uint? Low = (uint?)lowProperty.GetValue(value);

			PropertyInfo? midProperty = decimalType.GetProperty("Mid", BindingFlags.NonPublic | BindingFlags.Instance);
			ArgumentNullException.ThrowIfNull(midProperty);
			uint? Mid = (uint?)midProperty.GetValue(value);

			PropertyInfo? highProperty = decimalType.GetProperty("High", BindingFlags.NonPublic | BindingFlags.Instance);
			ArgumentNullException.ThrowIfNull(highProperty);
			uint? High = (uint?)highProperty.GetValue(value);

			FieldInfo? _flagsField = decimalType.GetField("_flags", BindingFlags.NonPublic | BindingFlags.Instance);
			ArgumentNullException.ThrowIfNull(_flagsField);
			int? _flags = (int?)_flagsField.GetValue(value);

			ArgumentNullException.ThrowIfNull(Low);
			ArgumentNullException.ThrowIfNull(Mid);
			ArgumentNullException.ThrowIfNull(High);
			ArgumentNullException.ThrowIfNull(_flags);

			Span<byte> buffer = stackalloc byte[sizeof(decimal)];
			switch (endian)
			{
				case Endian.BigEndian:
					BinaryPrimitives.WriteInt32BigEndian(buffer, _flags.Value);
					BinaryPrimitives.WriteInt32BigEndian(buffer[4..], (int)High.Value);
					BinaryPrimitives.WriteInt32BigEndian(buffer[8..], (int)Mid.Value);
					BinaryPrimitives.WriteInt32BigEndian(buffer[12..], (int)Low.Value);
					break;
				default:
					BinaryPrimitives.WriteInt32LittleEndian(buffer, (int)Low.Value);
					BinaryPrimitives.WriteInt32LittleEndian(buffer[4..], (int)Mid.Value);
					BinaryPrimitives.WriteInt32LittleEndian(buffer[8..], (int)High.Value);
					BinaryPrimitives.WriteInt32LittleEndian(buffer[12..], _flags.Value);
					break;
			}
			OutStream.Write(buffer);
		}
	}
}