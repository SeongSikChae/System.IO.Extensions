# System.IO namesapce Extensions

* Endian enum (LittleEndian, BigEndian)

## EndianBinaryReader

* constructor(Straem input, Encoding encoding, bool leaveOpen, Endian order)

## EndianBinaryWriter

* constructor(Stream output, Encoding encoding, bool leaveOpen, Endian order)

## BinaryReader Extensions

* IPAddress ReadIPAddress()
* string ReadUTF8()

## BinaryWriter Extensions

* void Write(IPAddress address)
* void WriteUTF8(string value)

## DirectoryInfo Extensions

* DirectoryInfo GetChildDirectoryInfo(string childDirectoryPath)
* FileInfo GetFileInfo(string filePath)