using OpenCvSharp;

namespace ConsoleApp.Services
{
    public class FrameSplitService
    {
        public static void SaveFrames(VideoCapture capture, string outputRoute)
        {
            try
            {
                // Verificar si el VideoCapture está abierto
                if (!capture.IsOpened())
                {
                    Console.WriteLine("Error: No se pudo abrir el video.");
                    return;
                }

                // Crear el directorio de salida si no existe
                if (!System.IO.Directory.Exists(outputRoute))
                {
                    Console.WriteLine($"Error: La ruta de salida '{outputRoute}' no existe.");
                    return;
                }

                // Creamos el frame
                Mat frame = new Mat();

                // Iniciamos el contador para identificar cada frame
                int frameNumber = 0;

                while (capture.Read(frame))
                {
                    SaveFrame(frame, System.IO.Path.Combine(outputRoute, $"frame{frameNumber}.png"));
                    frameNumber++;
                }

                // Cerrar el VideoCapture
                capture.Release();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public static void SaveFrame(Mat frame, string fileName)
        {
            try
            {
                // Guardar el frame actual como una imagen
                Cv2.ImWrite(fileName, frame);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
