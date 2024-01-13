using OpenCvSharp;
using System;

namespace ConsoleApp.Services
{
    public class FrameSplitService
    {
        public static void SaveFrames(VideoCapture capture, string rutaSalida)
        {
            //Creamos el frame
            Mat frame = new Mat();

            //iniciamos el contador para identificar cada frame
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

            // Guardar el frame actual como una imagen
            Cv2.ImWrite(fileName, frame);

            // Mostrar el frame actual
            Console.WriteLine("Frame guardado");
        }
    }
}
