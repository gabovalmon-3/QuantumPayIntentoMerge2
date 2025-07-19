using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BaseManager
{
    public class FaceRecognitionManager
    {
        private readonly AmazonRekognitionClient _rekognitionClient;

        public FaceRecognitionManager(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
        {
            _rekognitionClient = new AmazonRekognitionClient(awsAccessKeyId, awsSecretAccessKey, region);
        }

        ///
        /// Compara dos imágenes (selfie y foto del ID) y devuelve true si la similitud es mayor al umbral.
        /// </summary>
        /// <param name="selfieImageBytes">Bytes de la imagen selfie.</param>
        /// <param name="idImageBytes">Bytes de la imagen del ID.</param>
        /// <param name="similarityThreshold">Umbral mínimo de similitud (ej. 90f).</param>
        /// <returns></returns>
        public async Task<bool> VerifyFaceAsync(byte[] selfieImageBytes, byte[] idImageBytes, float similarityThreshold = 90f)
        {
            var request = new CompareFacesRequest
            {
                SourceImage = new Amazon.Rekognition.Model.Image { Bytes = new System.IO.MemoryStream(selfieImageBytes) },
                TargetImage = new Amazon.Rekognition.Model.Image { Bytes = new System.IO.MemoryStream(idImageBytes) },
                SimilarityThreshold = similarityThreshold
            };

            try
            {
                var response = await _rekognitionClient.CompareFacesAsync(request);

                if (response.FaceMatches.Count > 0)
                {
                    var faceMatch = response.FaceMatches[0];
                    Console.WriteLine($"Similitud: {faceMatch.Similarity}");

                    return faceMatch.Similarity >= similarityThreshold;
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna cara coincidente.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al comparar caras: {ex.Message}");
                return false;
            }
        }
    }
}
