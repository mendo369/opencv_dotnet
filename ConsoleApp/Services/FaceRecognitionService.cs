
using OpenCvSharp;
using ConsoleApp.Services;

namespace ConsoleApp.Services
{
    public class FaceRecognitionService
    {
        public static void FaceDifferences(VideoCapture capture, string outputRoute)
        {
            // Cargar el clasificador de cascada de Haar para la detección de rostros
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "haarcascade_frontalface_alt_tree.xml");
            CascadeClassifier faceCascade = new CascadeClassifier(rutaArchivo);

            //// Cargar el predictor de puntos de referencia faciales
            //string facemarkModel = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "shape_predictor_68_face_landmarks.dat");
            //FacemarkLBF facemark = FacemarkLBF.Create();

            //// Cargar el modelo entrenado (reemplaza con la ruta correcta)
            //facemark.LoadModel(facemarkModel);


            // Convertir el fotograma a escala de grises para mejorar la detección
            Mat frame = new Mat();
            int frameNumber = 0;

            while (capture.Read(frame))
            {
                // Detectar los rostros en el cuadro actual
                //Rect[] faces = faceCascade.DetectMultiScale(frame);

                Rect[] faces = faceCascade.DetectMultiScale(frame);

                if (faces.Length > 0)
                {
                    double[] differences = CalculateFacialDifferences(frame, faces[0]);

                    foreach (var face in faces)
                    {
                        Mat faceROI = new Mat(frame, face);
                        // Convertir la región de la cara a escala de grises
                        Mat grayFace = new Mat();
                        Cv2.CvtColor(faceROI, grayFace, ColorConversionCodes.BGR2GRAY);


                        Cv2.Rectangle(frame, face, Scalar.Red, 2);
                    }
                    foreach (var diff in differences)
                    {
                        Console.WriteLine(diff);
                    }
                    // Guardar el fotograma solo si se detecta al menos una cara
                    //FrameSplitService.SaveFrame(frame, System.IO.Path.Combine(outputRoute, $"frame{frameNumber}.png"));
                    //frameNumber++;
                }
            }
            capture.Release();

            //while (capture.Read(frame))
            //{

            //    // Detectar caras en el fotograma
            //    var faces = faceCascade.DetectMultiScale(frame);

            //    if (faces.Length > 0)
            //    {
            //        foreach (var face in faces)
            //        {
            //            Mat faceROI = new Mat(frame, face);
            //            // Convertir la región de la cara a escala de grises
            //            Mat grayFace = new Mat();
            //            Cv2.CvtColor(faceROI, grayFace, ColorConversionCodes.BGR2GRAY);


            //            Cv2.Rectangle(frame, face, Scalar.Red, 2);
            //        }

            //        // Guardar el fotograma solo si se detecta al menos una cara
            //        FrameSplitService.SaveFrame(frame, System.IO.Path.Combine(outputRoute, $"frame{frameNumber}.png"));
            //        frameNumber++;
            //    }
            //}
        }

        static double[] CalculateFacialDifferences(Mat frame, Rect face)
        {
            // Calcular las diferencias entre las características faciales
            double[] differences = new double[5];

            // Diferencia entre la posición de los ojos
            differences[0] = (face.X + face.Width / 2) - (face.Y + face.Height / 2);

            // Diferencia entre el ancho y el alto de la cara
            differences[1] = face.Width - face.Height;

            // Diferencia entre la distancia entre los ojos y la distancia entre la nariz y la boca
            differences[2] = (face.Y + face.Height / 2) - (face.X + face.Width / 4);

            // Diferencia entre la anchura de la nariz y la anchura de la boca
            differences[3] = face.Width / 4 - face.Width / 8;

            // Diferencia entre la altura de la nariz y la altura de la boca
            differences[4] = face.Height / 2 - face.Height / 4;

            return differences;
        }
    }
}

