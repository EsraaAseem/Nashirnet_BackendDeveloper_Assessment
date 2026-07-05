using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Models.Common
{
    public class GenericResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public T? Data { get; set; }
        public string Message { get; set; } = "";
        public static GenericResponse<T> SuccessResponseWithDataAndMsg(T data, string message)
        {
            var response = new GenericResponse<T>()
            {
                Data = data,
                Message = message
            };

            return response;
        }
        public static GenericResponse<T> SuccessResponseWithData(T data)
        {
            var response = new GenericResponse<T>()
            {
                Data = data,
            };

            return response;
        }
        public static GenericResponse<T> SuccessResponseWithMessage(string message)
        {
            var response = new GenericResponse<T>()
            {
                Message = message
            };

            return response;
        }
        public static GenericResponse<T> FailedResponse(HttpStatusCode statusCode, string message)
        {
            var response = new GenericResponse<T>()
            {
                StatusCode = statusCode,
                IsSuccess = false,
                Message = message
            };

            return response;
        }
        public static GenericResponse<T> NotFoundResponse(string message)
        {
            var response = new GenericResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                IsSuccess = false,
                Message = message
            };

            return response;
        }
        public static GenericResponse<T> BadRequestResponse(string message)
        {
            var response = new GenericResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = message
            };

            return response;
        }
    }
}

