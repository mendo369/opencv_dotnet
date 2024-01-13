using OpenCvSharp;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicitar la ruta del video de entrada
            Console.WriteLine("Introduce la ruta del video de entrada:");
            string inputRoute = Console.ReadLine();

            // Solicitar la ruta del video de salida
            Console.WriteLine("Introduce la ruta del video de salida:");
            string outputRoute = Console.ReadLine();

            //generar el video
            var capture = new VideoCapture(inputRoute);
            //VideoCapture capture = new VideoCapture(inputRoute);


            //ejecutamos la función encargada


            FaceRecognitionService.FaceDifferences(capture, outputRoute);


            // Mostrar un mensaje de éxito
            Console.WriteLine("La ruta de entrada: "+inputRoute+" | La ruta salida: "+ outputRoute);
        }
    }
}