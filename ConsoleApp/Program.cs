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

            //el usuario decide qué proceso quiere realizar con el video
            Console.WriteLine("Ingresa 1 para tranformar un video a frames");
            Console.WriteLine("Ingresa 2 para obtener las diferencias de un rostro");
            int option = Convert.ToInt32(Console.ReadLine());

            //generar el video
            var capture = new VideoCapture(inputRoute);


            //ejecutamos la funci´´on según las preferencias del usuario
            if (option == 2)
            {
                FaceRecognitionService.FaceDifferences(capture, outputRoute);
            }
            FrameSplitService.SaveFrames(capture, outputRoute);


            // Mostrar un mensaje de éxito
            Console.WriteLine("La ruta de entrada: " + inputRoute + " | La ruta salida: " + outputRoute);
        }
    }
}