namespace Seed.Services.Abstract
{
    public abstract class VoidOperationResult
    {
        /// <summary>
        /// Is error flag
        /// </summary>
        public bool IsError { get; set; }
        
        /// <summary>
        /// Message to return
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Success contructor
        /// </summary>
        /// <param name="message"></param>
        public VoidOperationResult(string message)
        {
            IsError = false;
            Message = message;
        }

        /// <summary>
        /// Fail constructor
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        public VoidOperationResult(bool isError, string message)
        {
            IsError = isError;
            Message = message;
        }
    }
}
