using System;
using OpenCvSharp;


namespace ConsoleApp.Services
{
    public class FaceRecognitionService
    {
        public static void FaceDifferences(VideoCapture capture, string outputRoute)
        {
            // Cargar el clasificador de cascada de Haar para la detección de rostros
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "haarcascade_frontalface_alt_tree.xml");
            CascadeClassifier faceCascade = new CascadeClassifier(rutaArchivo);

            // Convertir el fotograma a escala de grises para mejorar la detección
            Mat frame = new Mat();
            int frameNumber = 0;

            while (capture.Read(frame))
            {

                // Detectar caras en el fotograma
                var faces = faceCascade.DetectMultiScale(frame);

                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        Cv2.Rectangle(frame, face, Scalar.Red, 2);
                    }

                    // Guardar el fotograma solo si se detecta al menos una cara
                    FrameSplitService.SaveFrame(frame, System.IO.Path.Combine(outputRoute, $"frame{frameNumber}.png"));
                    frameNumber++;
                }
            }
        }
    }
}

