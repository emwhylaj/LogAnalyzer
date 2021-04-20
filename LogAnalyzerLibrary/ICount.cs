using System;

namespace LogAnalyzerLibrary
{
    public interface ICount
    {
        public int CountFiles(string path);

        public int CountFilesByDate(string path, DateTime startDate, DateTime endDate);

        public bool DeleteFiles(string path, DateTime startDate, DateTime endDate);

        public int DuplicateFiles(string path);
    }
}