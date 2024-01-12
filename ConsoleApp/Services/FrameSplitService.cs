using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class FrameSplitService
    {
        public static void SaveFrames(VideoCapture capture, string rutaSalida)
        {
            Mat frame = new Mat();

            int frameNumber = 0;

            while (capture.Read(frame))
            {
                SaveFrame(frame, System.IO.Path.Combine(rutaSalida, $"frame{frameNumber}.png"));
                frameNumber++;
            }

            // Cerrar el VideoCapture
            capture.Dispose();
        }

        public static void SaveFrame(Mat frame, string fileName)
        {
            int frameNumber = 10;

            // Crear un Image para almacenar el frame actual
            //Image image = new Image(frame);
            CvInvoke.Imwrite(fileName, frame);

            // Mostrar el frame actual
            Console.WriteLine("Frame {0} guardado", frameNumber);
        }
    }
}
