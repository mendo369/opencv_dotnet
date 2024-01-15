
using OpenCvSharp;
using ConsoleApp.Utilities;

namespace ConsoleApp.Services
{
    public class FaceRecognitionService
    {
        public static void FaceDifferences(VideoCapture capture, string outputRoute)
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
                // Cargar el clasificador de cascada de Haar para la detección de rostros
                string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "haarcascade_frontalface_alt_tree.xml");
                CascadeClassifier faceCascade = new CascadeClassifier(rutaArchivo);

                Mat frame = new Mat();

                int frameNumber = 0;
                bool faceDetected = false;

                while (capture.Read(frame) && !faceDetected)
                {
                    //Mostramos un mensaje de consola mientras se procesa el video
                    Console.Write("Processing... Frame {0}\r", frameNumber);

                    //Detectar las caras del frame actual
                    Rect[] faces = faceCascade.DetectMultiScale(frame);

                    if (faces.Length > 0)
                    {
                        foreach (var face in faces)
                        {
                            Cv2.Rectangle(frame, face, Scalar.Red, 2);

                            // Definir regiones de interés (ROIs) para los ojos, la nariz y la boca
                            Rect roiEyesLeft = new Rect((int)(face.X + 0.15 * face.Width), (int)(face.Y + 0.3 * face.Height), (int)(0.2 * face.Width), (int)(0.15 * face.Height));
                            Rect roiEyesRight = new Rect((int)(face.X + 0.65 * face.Width), (int)(face.Y + 0.3 * face.Height), (int)(0.2 * face.Width), (int)(0.15 * face.Height));
                            Rect roiNose = new Rect((int)(face.X + 0.4 * face.Width), (int)(face.Y + 0.5 * face.Height), (int)(0.2 * face.Width), (int)(0.1 * face.Height));
                            Rect roiMouth = new Rect((int)(face.X + 0.25 * face.Width), (int)(face.Y + 0.7 * face.Height), (int)(0.5 * face.Width), (int)(0.1 * face.Height));

                            // Dibujar cuadros alrededor de los ojos, la nariz y la boca
                            Cv2.Rectangle(frame, roiEyesLeft, Scalar.Blue, 2);
                            Cv2.Rectangle(frame, roiEyesRight, Scalar.Blue, 2);
                            Cv2.Rectangle(frame, roiNose, Scalar.Green, 2);
                            Cv2.Rectangle(frame, roiMouth, Scalar.Yellow, 2);

                            // Guardar el frame con los cuadros dibujados solo si no se ha guardado una imagen previamente
                            if (!faceDetected)
                            {
                                UtilitiesOpenCV.SaveFrame(frame, outputRoute, $"rostro");
                                faceDetected = true;  // Marcamos que ya se ha detectado y guardado una cara
                            }
                        }
                    }
                    frameNumber++;
                }

                capture.Release();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
        }
    }
}
