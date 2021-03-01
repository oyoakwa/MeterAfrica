using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Services
{

    public interface IResponseService
    {
        ServiceResponseModel<T> ErroResponse<T>(string message) where T : class;
        ServiceResponseModel<T> SuccessResponse<T>(string message, T data) where T : class;
        ServiceResponseModel<T> ExceptionResponse<T>(Exception exception) where T : class;
    }

    public class ResponseService : IResponseService
    {
        public ServiceResponseModel<T> ErroResponse<T>(string message)
            where T : class => new ServiceResponseModel<T>
            {
                Message = message,
                Status = false,
                Data = null
            };

        public ServiceResponseModel<T> ExceptionResponse<T>(Exception exception)
            where T : class => new ServiceResponseModel<T>
            {
                Message = exception.Message,
                Status = false,
                Data = null
            };

        public ServiceResponseModel<T> SuccessResponse<T>(string message, T data)
            where T : class => new ServiceResponseModel<T>
            {
                Message = message,
                Status = true,
                Data = data
            };
    }
}
