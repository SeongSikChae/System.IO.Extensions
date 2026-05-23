# System.IO namesapce Extensions

* ByteOrder enum (LittleEndian, BigEndian)

## BinaryReaderV2

* constructor(Straem input, Encoding encoding, bool leaveOpen, ByteOrder order)

## BinaryWriterV2

* constructor(Stream output, Encoding encoding, bool leaveOpen, ByteOrder order)

## BinaryReader Extensions

* IPAddress ReadIPAddress()
* string ReadUTF8()

## BinaryWriter Extensions

* void Write(IPAddress address)
* void WriteUTF8(string value)

## DirectoryInfo Extensions

* DirectoryInfo GetChildDirectoryInfo(string childDirectoryPath)
* FileInfo GetFileInfo(string filePath)