﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace InsuranceApi.Core.Infrastructure.Http
{
    public class RestClient
    {
        private readonly HttpClient httpClient;


        private string _mediaTypeAccept;
        private Encoding _encoding;

        public RestClient()
        {
            _mediaTypeAccept = "application/json";
        }
        public RestClient(HttpClient _httpClient)
        {
            httpClient = _httpClient;
            _mediaTypeAccept = "application/json";
        }

        private enum RequestVerb
        {
            Post,
            Put,
            Delete,
            Post2
        }

        private CookieContainer _cookies;
        public CookieContainer Cookies
        {
            get
            {
                return _cookies;
            }
        }


        public async Task<TResponse> GetAsync<TResponse>(string requestUri)
        where TResponse : BaseResponse, new()
        {
            return await GetAsync<BaseRequest, TResponse>(requestUri, default, true);
        }
        public async Task<TResponse> GetAsync<TRequest, TResponse>(string requestUri, TRequest request)
            where TResponse : BaseResponse, new()
            where TRequest : BaseRequest
        {
            return await GetAsync<TRequest, TResponse>(requestUri, request, true);
        }
        public async Task<TResponse> GetAsync<TRequest, TResponse>(string requestUri, TRequest request, bool autoFormat)
            where TResponse : BaseResponse, new()
            where TRequest : BaseRequest
        {
            return await GetAsync<TRequest, TResponse>(requestUri, request, true, 0);
        }
        public async Task<TResponse> GetAsync<TRequest, TResponse>(string requestUri, TRequest request, bool autoFormat, int timeOut)
         where TResponse : BaseResponse, new()
         where TRequest : BaseRequest
        {
            if (timeOut > 0 && httpClient.Timeout != TimeSpan.FromMilliseconds(timeOut))
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeOut);
            if (request != null)
            {
                AddRequestHeaders(request, httpClient);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "Keep-Alive");
                if (autoFormat)
                {
                    var querystring = new StringBuilder();
                    var jsonObject = Newtonsoft.Json.Linq.JObject.FromObject(request);
                    foreach (var obj in jsonObject)
                    {
                        if (obj.Value != null && (obj.Value.Type == JTokenType.String || obj.Value.Type == JTokenType.Integer))
                            querystring.Append(string.Format("{0}={1}&", obj.Key, HttpUtility.UrlEncode(obj.Value.ToString())));
                        else if (obj.Value != null && obj.Value.Type == JTokenType.Boolean)
                            querystring.Append(string.Format("{0}={1}&", obj.Key, obj.Value.Value<bool>() == true ? "1" : "0"));
                    }
                    if (querystring.Length > 0)
                        requestUri += (requestUri.Contains("?") ? "&" : "?") + querystring.Remove(querystring.Length - 1, 1).ToString();
                }
            }
            HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);

            string responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            TResponse response = new TResponse();
            try
            {

                //-- Caso seja um RawResponse devolve os dados sem deserializar, pois senão dá erro.
                //-- Caso por exemplo dos motivos de endosso, que são retornados como array de string e não o objeto padrão
                if (typeof(TResponse) != typeof(RawResponse))
                {
                    var converter = new JsonConverter();
                    if (converter != null)
                    {
                        response = JsonConvert.DeserializeObject<TResponse>(responseContent, converter);
                    }
                    else
                    {
                        response = JsonConvert.DeserializeObject<TResponse>(responseContent);
                    }
                }
                //response.RequestHeader = httpClient.DefaultRequestHeaders;
            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Exception:{0}", ex.Message);
                builder.AppendLine();
                builder.AppendFormat("Type:{0}", typeof(TResponse).FullName);
                builder.AppendLine();
                builder.AppendFormat("Content:{0}", responseContent);
                response.Erro += builder.ToString();
            }
            response.Conteudo = responseContent;
            response.StatusCode = responseMessage.StatusCode;
            response.ResponseHeader = responseMessage.Headers.ToString();
            response.RequestHeader = httpClient.DefaultRequestHeaders.ToString();
            response.Method = responseMessage.RequestMessage.Method.ToString();
            response.RequestUri = responseMessage.RequestMessage.RequestUri.ToString();

            AddResponseHeaders<TResponse>(response, responseMessage);
            return VerifyError(response, responseMessage, responseContent);

        }
        public async Task<TResponse> PostFromUrLCodeAsync<TRequest, TResponse>(string requestUri, TRequest body)
         where TResponse : BaseResponse, new()
         where TRequest : BaseRequest
        {
            return await DoRequestFromUrLCodeAsync<TRequest, TResponse>(requestUri, body, RequestVerb.Post, 0);
        }
        private async Task<TResponse> DoRequestFromUrLCodeAsync<TRequest, TResponse>(string requestUri, TRequest body, RequestVerb verb, int timeOut)
          where TResponse : BaseResponse, new()
          where TRequest : BaseRequest
        {

            AddRequestHeaders(body, httpClient);
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            switch (verb)
            {
                case RequestVerb.Post:
                    responseMessage = await httpClient.PostAsync(requestUri, body.BodyObjectURLCode);
                    break;
            }

            string responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            TResponse response = new TResponse();
            try
            {
                if (!string.IsNullOrEmpty(responseContent))
                    response = JsonConvert.DeserializeObject<TResponse>(responseContent, new JsonConverter());

            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Exception:{0}", ex.Message);
                builder.AppendLine();
                builder.AppendFormat("Type:{0}", typeof(TResponse).FullName);
                builder.AppendLine();
                builder.AppendFormat("Content:{0}", responseContent);
                response.Erro += builder.ToString();

            }
            response.Conteudo = responseContent;
            response.StatusCode = responseMessage.StatusCode;
            response.ResponseHeader = responseMessage.Headers.ToString();
            response.RequestHeader = httpClient.DefaultRequestHeaders.ToString();
            response.Method = responseMessage.RequestMessage.Method.ToString();
            response.RequestUri = responseMessage.RequestMessage.RequestUri.ToString();

            AddResponseHeaders<TResponse>(response, responseMessage);
            return VerifyError(response, responseMessage, responseContent);

        }
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest body)
        where TResponse : BaseResponse, new()
        where TRequest : BaseRequest
        {
            return await DoRequestAsync<TRequest, TResponse>(requestUri, body, RequestVerb.Post, 0);
        }
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest body, int timeOut)
            where TResponse : BaseResponse, new()
            where TRequest : BaseRequest
        {
            return await DoRequestAsync<TRequest, TResponse>(requestUri, body, RequestVerb.Post, timeOut);
        }
        private async Task<TResponse> DoRequestAsync<TRequest, TResponse>(string requestUri, TRequest body, RequestVerb verb, int timeOut)
          where TResponse : BaseResponse, new()
          where TRequest : BaseRequest
        {
            string jsonObject = JsonConvert.SerializeObject(body.BodyObject, new JsonConverter());
            if (timeOut > 0 && httpClient.Timeout != TimeSpan.FromMilliseconds(timeOut))
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeOut);

            AddRequestHeaders(body, httpClient);

            HttpResponseMessage responseMessage = new HttpResponseMessage();
            StringContent stringContentJson = null;
            if (_encoding == null)
            {
                stringContentJson = new StringContent(jsonObject);
                stringContentJson.Headers.ContentType = new MediaTypeWithQualityHeaderValue(_mediaTypeAccept);
            }
            else
            {
                stringContentJson = new StringContent(jsonObject, Encoding.UTF8, _mediaTypeAccept);
            }

            switch (verb)
            {
                case RequestVerb.Post:
                    responseMessage = await httpClient.PostAsync(requestUri, stringContentJson);
                    break;
                case RequestVerb.Put:
                    responseMessage = await httpClient.PutAsync(requestUri, stringContentJson);
                    break;
                case RequestVerb.Delete:
                    responseMessage = await httpClient.DeleteAsync(requestUri);
                    break;
            }

            string responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            TResponse response = new TResponse();
            try
            {
                if (!string.IsNullOrEmpty(responseContent))
                    response = JsonConvert.DeserializeObject<TResponse>(responseContent, new JsonConverter());

            }
            catch (Exception ex)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Exception:{0}", ex.Message);
                builder.AppendLine();
                builder.AppendFormat("Type:{0}", typeof(TResponse).FullName);
                builder.AppendLine();
                builder.AppendFormat("Content:{0}", responseContent);
                response.Erro += builder.ToString();

            }
            response.Conteudo = responseContent;
            response.StatusCode = responseMessage.StatusCode;
            response.ResponseHeader = responseMessage.Headers.ToString();
            response.RequestHeader = httpClient.DefaultRequestHeaders.ToString();
            response.Method = responseMessage.RequestMessage.Method.ToString();
            response.RequestUri = responseMessage.RequestMessage.RequestUri.ToString();

            AddResponseHeaders<TResponse>(response, responseMessage);
            return VerifyError(response, responseMessage, responseContent);

        }

        public static class JsonSerializerConfig
        {
            private static string jsonFormatDate = "";// Configuration.AppSettings["JsonFormatDate"];
            private static string jsonCultureInfo = "";//Configuration.AppSettings["JsonCultureInfo"];

            public static string JsonFormatDate
            {
                get
                {
                    if (string.IsNullOrEmpty(jsonFormatDate))
                    {
                        return DateTimeConfig.DATE_TIME_FORMAT;
                    }

                    return jsonFormatDate;
                }
            }
            public static string JsonCultureInfo
            {
                get
                {
                    if (string.IsNullOrEmpty(jsonCultureInfo))
                    {
                        return DateTimeConfig.CULTURE_INFO;
                    }

                    return jsonCultureInfo;
                }
            }
        }

        public static class DateTimeConfig
        {
            public const string DATE_TIME_FORMAT = "yyyy-MM-ddTHH:mm:ssZ";//"dd/MM/yyyy HH:mm:ss";
            public const string CULTURE_INFO = "en-US"; //"pt-BR";
        }
        public class JsonConverter : DateTimeConverterBase
        {
            private string formatDate = JsonSerializerConfig.JsonFormatDate;
            private string cultureInfo = JsonSerializerConfig.JsonCultureInfo;
            private CultureInfo culture;

            public JsonConverter()
            {
                culture = CultureInfo.CreateSpecificCulture(cultureInfo);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value != null)
                {
                    return DateTime.Parse(reader.Value.ToString(), culture);
                }

                return null;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value != null)
                {
                    writer.WriteValue(((DateTime)value).ToString(formatDate));
                }
            }
        }

        private void AddRequestHeaders<TRequest>(TRequest request, HttpClient httpClient)
          where TRequest : BaseRequest
        {
            request.DefaultRequestHeaders.ToList().ForEach(keyValue =>
            {
                if (!string.IsNullOrEmpty(keyValue.Value))
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(keyValue.Key, keyValue.Value);
                }
            });
        }
        private void AddResponseHeaders<TResponse>(TResponse response, HttpResponseMessage responseMessage)
          where TResponse : BaseResponse, new()
        {
            string[] headersDefaults = new string[] { "Cache-Control", "Date", "Expires", "Pragma", "Content-Length", "Content-Type", "Server", "X-AspNet-Version", "X-Powered-By", "X-SourceFiles" };
            if (responseMessage.Headers != null)
            {
                responseMessage.Headers.ToList().ForEach(keyValue =>
                {
                    if (!headersDefaults.Contains(keyValue.Key))
                    {
                        List<string> keyValuesList = keyValue.Value.ToList();
                        if (keyValuesList.Count > 1)
                        {
                            response.DefaultResponseHeaders.Add(keyValue.Key, string.Join(",", keyValue.Value.ToArray()));
                        }
                        else
                        {
                            if (keyValuesList.Count > 0)
                            {
                                response.DefaultResponseHeaders.Add(keyValue.Key, keyValue.Value.Single());
                            }
                        }
                    }
                });
            }
        }
        private void AddErrorMessage(string codigo, string conteudo, BaseResponse response)
        {
            response.Erro += string.Concat(codigo, conteudo);
        }
        private TResponse VerifyError<TResponse>(TResponse response, HttpResponseMessage responseMessage, string responseContent)
       where TResponse : BaseResponse
        {
            switch (responseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    AddErrorMessage("HTTP-400", "Request mal formado.", response);
                    break;
                case System.Net.HttpStatusCode.Forbidden:
                    AddErrorMessage("HTTP-403", "Request proibido. O servidor recusou a requisição. ", response);
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    AddErrorMessage("HTTP-500", "Ocorreu um erro interno ao servidor." + responseMessage.ReasonPhrase + ". Retorno: " + responseContent, response);
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    AddErrorMessage("HTTP-404", "Recurso não encontrado no servidor.", response);
                    break;
                case System.Net.HttpStatusCode.ServiceUnavailable:
                    AddErrorMessage("HTTP-503", "Serviço indisponível.", response);
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    AddErrorMessage("HTTP-401", "O acesso a este recurso não está autorizado.", response);
                    break;
            }
            return response;
        }
    }
}
