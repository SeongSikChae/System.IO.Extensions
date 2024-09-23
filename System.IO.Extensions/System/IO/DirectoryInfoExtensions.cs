namespace System.IO
{
	/// <summary>
	/// System.IO.DirectoryInfo Extensions
	/// </summary>
	public static class DirectoryInfoExtensions
	{
		/// <summary>
		/// Get Child Directory Info
		/// </summary>
		/// <param name="directoryInfo"></param>
		/// <param name="childDirenctPath"></param>
		/// <returns></returns>
		public static DirectoryInfo GetChildDirectoryInfo(this DirectoryInfo directoryInfo, string childDirenctPath)
		{
			if (OperatingSystem.IsWindows())
				return new DirectoryInfo($"{directoryInfo.FullName}\\{childDirenctPath}");
			else
				return new DirectoryInfo($"{directoryInfo.FullName}/{childDirenctPath}");
		}

		/// <summary>
		/// Get File Info
		/// </summary>
		/// <param name="directoryInfo"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static FileInfo GetFileInfo(this DirectoryInfo directoryInfo, string filePath)
		{
			if (OperatingSystem.IsWindows())
				return new FileInfo($"{directoryInfo.FullName}\\{filePath}");
			else
				return new FileInfo($"{directoryInfo.FullName}/{filePath}");
		}
	}
}
