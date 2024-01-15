using OpenCvSharp;

namespace ConsoleApp.Utilities
{
    public class UtilitiesOpenCV
    {
        public static bool SaveFrame(Mat frame, string outputRoute,string fileName)
        {
            string outputName = System.IO.Path.Combine(outputRoute, $"frame{fileName}.png");
            try
            {
                // Guardar el frame actual como una imagen
                Cv2.ImWrite(outputName, frame);
                Console.WriteLine($"Imágen {fileName} guardada");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar: {e.Message}");
                return false;
            }
        }
    }
    
}
