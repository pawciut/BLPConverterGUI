using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLPConverterGUI
{
    public struct ConversionResult
    {
        public string sourcePath;
        public string outputPath;
        public bool success;
        public string errorDetails;
    }
}
