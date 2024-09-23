namespace System.IO
{
	using Buffers.Binary;
	using Reflection;
	using Text;

	/// <summary>
	/// Writes the basic format of binary files to a stream according to ByteOrder and supports writing strings in a specific encoding.
	/// </summary>
	/// <param name="output"></param>
	/// <param name="encoding"></param>
	/// <param name="leaveOpen"></param>
	/// <param name="order"></param>
	public sealed class BinaryWriterV2(Stream output, Encoding encoding, bool leaveOpen, ByteOrder order) : BinaryWriter(output, encoding, leaveOpen)
	{
		/// <summary>
		/// Specific streams and ByteOrder
		/// </summary>
		/// <param name="output"></param>
		/// <param name="order"></param>
		public BinaryWriterV2(Stream output, ByteOrder order = ByteOrder.LittleEndian) : this(output, Encoding.UTF8, order) { }

		/// <summary>
		/// Specific streams and encodings and ByteOrder
		/// </summary>
		/// <param name="output"></param>
		/// <param name="encoding"></param>
		/// <param name="order"></param>
		public BinaryWriterV2(Stream output, Encoding encoding, ByteOrder order = ByteOrder.LittleEndian) : this(output, encoding, false, order) { }

		/// <summary>
		/// Byte Order
		/// </summary>
		public ByteOrder Order => order;

		/// <summary>
		/// BinaryWriterV2 Override Write Int16
		/// </summary>
		/// <param name="value"></param>
		public override void Write(short value)
		{
			Span<byte> buffer = stackalloc byte[sizeof(short)];
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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
			switch (Order)
			{
				case ByteOrder.BigEndian:
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