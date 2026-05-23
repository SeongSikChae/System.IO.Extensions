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
        /// <param name="childDirectoryPath"></param>
        /// <returns></returns>
        public static DirectoryInfo CombineDirectoryInfo(this DirectoryInfo directoryInfo, string childDirectoryPath)
		{
			if (OperatingSystem.IsWindows())
				return new DirectoryInfo($"{directoryInfo.FullName}\\{childDirectoryPath}");
			else
				return new DirectoryInfo($"{directoryInfo.FullName}/{childDirectoryPath}");
		}

		/// <summary>
		/// Get File Info
		/// </summary>
		/// <param name="directoryInfo"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static FileInfo CombineFileInfo(this DirectoryInfo directoryInfo, string filePath)
		{
			if (OperatingSystem.IsWindows())
				return new FileInfo($"{directoryInfo.FullName}\\{filePath}");
			else
				return new FileInfo($"{directoryInfo.FullName}/{filePath}");
		}
	}
}
