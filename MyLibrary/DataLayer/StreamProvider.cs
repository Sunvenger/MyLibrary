using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MyLibrary.DataLayer
{

    public class StreamProvider
    {
        public MemoryStream StreamSnapshot { get; set; }

        public StreamProvider()
        {

            StreamSnapshot = new MemoryStream();
            

        }

        public void LoadStream(string filename = "Library.xml")
        {
            StreamSnapshot.Seek(0, SeekOrigin.Begin);
            StreamSnapshot.SetLength(0);
            FileStream libraryFile = new FileStream(filename, FileMode.Open);
            CopyStream(libraryFile, StreamSnapshot);
            libraryFile.Close();
            StreamSnapshot.Position = 0;
        }

        public String GetRawData()
        {
            String rawData;


            using (StreamReader sr = new StreamReader(StreamSnapshot))
            {
                rawData = sr.ReadToEnd();
            }
            return rawData;
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}
