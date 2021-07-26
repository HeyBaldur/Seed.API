namespace Seed.Services.Abstract
{
    public abstract class OperationResponse<T> : VoidOperationResult
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public OperationResponse(T result, string message) : base(message)
        {
            Result = result;
        }

        /// <summary>
        /// Fail
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        protected OperationResponse(bool isError, string message) : base(isError, message)
        {
            Message = message;
            IsError = isError;
        }

        /// <summary>
        /// Result to return
        /// </summary>
        public virtual T Result { get; private set; }
    }
}
