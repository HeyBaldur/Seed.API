using Seed.Services.Models;

namespace Seed.Services.ErrorHandling
{
    public class SeedContentHandler
    {
        /// <summary>
        /// Response to return in all controllers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ContentHandler<T> HandleResponse<T>(T response, bool isError, string message)
        {
            var responseToReturn = new ContentHandler<T>
            {
                IsError = isError,
                PropertyToReturn = response,
                Message = message
            };

            return responseToReturn;
        }
    }
}
