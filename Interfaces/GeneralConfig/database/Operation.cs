using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.GeneralConfig.database
{

    public interface IOperation
    {
        bool isSuccess { get; }
        object result { get; set; }
        object error { get; set; }
        HttpStatusCode status { get; set; }
        void GetSuccessOperation(Object result);
        void GetErrorOperation(Exception message, HttpStatusCode status = HttpStatusCode.InternalServerError);
    }

    public class Operation : IOperation
    {
        private HttpStatusCode _status = HttpStatusCode.OK;
        public HttpStatusCode status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        private IEnumerable<HttpStatusCode> Success = new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted,
            HttpStatusCode.NonAuthoritativeInformation,
            HttpStatusCode.NoContent,
            HttpStatusCode.ResetContent,
            HttpStatusCode.PartialContent,
        };

        public bool isSuccess
        {
            get
            {
                return (Success.Contains(status));
            }
        }

        private Object _result;
        public Object result
        {
            get
            {
                if (isSuccess)
                    return _result;
                else
                    return null;
            }
            set { _result = value; }
        }

        private Object _error;
        public Object error
        {
            get
            {
                if (!isSuccess)
                    return _error;
                else
                    return null;
            }
            set { _error = value; }
        }

        public void GetSuccessOperation(object result)
        {
            if (result == null)
            {
                this.status = HttpStatusCode.NoContent;
            }
            else
            {
                this.status = HttpStatusCode.OK;
                this.result = result;
            }
        }

        public void GetErrorOperation(Exception message, HttpStatusCode status = HttpStatusCode.InternalServerError)
        {
            var handled_error = message.InnerException == null ? message.Message : message.InnerException.Message;
            if (message.GetType() == typeof(DbEntityValidationException))
            {

                var errorMessages = ((DbEntityValidationException)message).EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                handled_error = string.Concat("Se encontraron los siguientes errores en la validación del modelo : ", fullErrorMessage);
            }


            this.status = OperationError(message, status);
            this.error = handled_error;
        }

        public static HttpStatusCode OperationError(Exception ex, HttpStatusCode status)
        {
            if (ex.Message.Contains("Timeout"))
            {
                status = System.Net.HttpStatusCode.RequestTimeout;
            }
            else if (ex.Message.Contains("No HTTP resource was found"))
            {
                status = HttpStatusCode.NotFound;
            }
            else if (ex.Message.Contains("ORA"))
            {
                status = HttpStatusCode.InternalServerError;
            }
            return status;
        }
    }
}
