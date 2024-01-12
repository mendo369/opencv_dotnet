using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using static System.Net.Mime.MediaTypeNames;

namespace VideoConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicitar la ruta del video de entrada
            Console.WriteLine("Introduce la ruta del video de entrada:");
            string rutaEntrada = Console.ReadLine();

            // Solicitar la ruta del video de salida
            Console.WriteLine("Introduce la ruta del video de salida:");
            string rutaSalida = Console.ReadLine();

            

            VideoCapture capture = new VideoCapture(rutaEntrada);

            SaveFrames(capture, rutaSalida);

            // Mostrar un mensaje de éxito
            Console.WriteLine("La ruta de entrada: "+rutaEntrada+" | La ruta salida: "+ rutaSalida);
        }

        static void SaveFrames(VideoCapture capture, string rutaSalida)
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

        static void SaveFrame(Mat frame, string fileName)
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