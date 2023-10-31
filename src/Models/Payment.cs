using Newtonsoft.Json;
using System.Text;

namespace AppCodeReview.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string TypeDescription { get; set; }

        public int Type { get; set; }

        public PaymentDetailsCredit PaymentDetailsCredit { get; set; }
        public PaymentDetailsPix PaymentDetailsPix { get; set; }

        public bool SendPaymenteOfCard(PaymentDetailsCredit paymentdetailscredit)
        {
            string apiUrl = "https://exemplo.com/api/credit";

            string jsonPayload = JsonConvert.SerializeObject(paymentdetailscredit);

            // Cria uma instância do HttpClient
            using (var client = new HttpClient())
            {
                // Configura o cabeçalho Content-Type para indicar que você está enviando JSON
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // Realiza a solicitação POST com o JSON como conteúdo
                HttpResponseMessage response = client.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json")).Result;

                // Verifica se a solicitação foi bem-sucedida
                return response.IsSuccessStatusCode;

            }
        }

        public bool SendPaymentPix(PaymentDetailsPix PAYMENTDETAILSPIX)
        {
            string apiUrl = "https://exemplo.com/api/pix";

            string jsonPayload = JsonConvert.SerializeObject(PAYMENTDETAILSPIX);

            // Cria uma instância do HttpClient
            using (var client = new HttpClient())
            {
                // Configura o cabeçalho Content-Type para indicar que você está enviando JSON
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // Realiza a solicitação POST com o JSON como conteúdo
                HttpResponseMessage response = client.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json")).Result;

                // Verifica se a solicitação foi bem-sucedida
                return response.IsSuccessStatusCode;
            }
        }

    }

    public class PaymentDetailsCredit
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Validity { get; set; }
        public string SecurityCode { get; set; }

    }

    public class PaymentDetailsPix
    {
        public string KeyPix { get; set; }
        public string Val { get; set; }
        public string Value { get; set; }

    }
}
