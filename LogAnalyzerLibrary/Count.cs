using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogAnalyzerLibrary
{
    public class Count : ICount
    {
        public int CountFiles(string path)
        {
            return Directory.EnumerateFiles(path).Count();
        }

        public int CountFilesByDate(string path, DateTime startDate, DateTime endDate)
        {
            var files = Directory.EnumerateFiles(path);
            var filesWithinPeriod = new List<string>();
            var date1 = startDate.Date;
            var date2 = endDate.Date;

            foreach (var file in files)
            {
                var dateModified = File.GetLastWriteTime(file).Date;
                if (dateModified >= date1 && dateModified <= date2)
                {
                    filesWithinPeriod.Add(file);
                }
            }

            return filesWithinPeriod.Count;
        }

        public bool DeleteFiles(string path, DateTime startDate, DateTime endDate)
        {
            var files = Directory.EnumerateFiles(path);

            var date1 = startDate.Date;
            var date2 = endDate.Date;

            foreach (var file in files)
            {
                var dateModified = File.GetLastWriteTime(file).Date;

                if (!(dateModified >= date1 && dateModified <= date2)) return false; // If not files can be found return false else it moves on to delete the file

                File.Delete(file);
            }
            return true;
        }

        public int DuplicateFiles(string path)
        {
            var file = Directory.EnumerateFiles(path).Distinct();
            return file.Count();
        }
    }
}