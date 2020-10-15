using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

    public static class Stream
    {

            public static string ReadCS()
            {

                using (var streamReader = File.OpenText(Application.StartupPath + "\\conn.txt"))//Enter FileName
                {
                    var lines = streamReader.ReadToEnd();
                    return lines;
                }
            }

            public static string ReadIP()
            {

                using (var streamReader = File.OpenText(Application.StartupPath + "\\Server.txt"))//Enter FileName
                {
                    var lines = streamReader.ReadToEnd();
                    return lines;
                }
            }
        }
