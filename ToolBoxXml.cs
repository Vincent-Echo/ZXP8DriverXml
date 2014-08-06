using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZXP8DriverXml
{
    class ToolBoxXml
    {
        [DllImport(@"C:\Program Files\Zebra ZMotif\ZXPToolBox\MFCW.dll")]
        public static extern unsafe bool ZMWSaveDEVMODEToXML(char* printername, char* xmlname);

        [DllImport(@"C:\Program Files\Zebra ZMotif\ZXPToolBox\MFCW.dll")]
        public static extern unsafe bool ZMWRestoreDEVMODEFromXML(char* printername, char* xmlname);
    }
}
