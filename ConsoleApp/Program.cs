using Emgu.CV;
//using static System.Net.Mime.MediaTypeNames;
using ConsoleApp.Services;

namespace ConsoleApp
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

            //generar el video
            VideoCapture capture = new VideoCapture(rutaEntrada);

            //private readonly framesSplit = new FrameSplitService();

            //ejecutamos la función encargada
            FrameSplitService.SaveFrames(capture, rutaSalida);
            

            // Mostrar un mensaje de éxito
            Console.WriteLine("La ruta de entrada: "+rutaEntrada+" | La ruta salida: "+ rutaSalida);
        }
    }
}