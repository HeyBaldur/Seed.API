namespace Seed.Services.Abstract
{
    public class ResultOperationResponse<T>: OperationResponse<T>
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public ResultOperationResponse(T result, string message): base(result, message) { }

        /// <summary>
        /// Fail
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        public ResultOperationResponse(bool isError, string message) : base(isError, message) { }
    }
}
