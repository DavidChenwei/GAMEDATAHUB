using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models
{
    public class ResponseModel
    {
        public ResponseModel() {
            Errors = new List<Error>();
        }
        public List<Error> Errors;
        public string ReturnText { get; set; }
        public bool IsValid { get; set; } = true;
        public void AddError(string reason)
        {
            Errors.Add(new Error { Reason = reason });
        }
    }

    public class Error {
        public string Reason { get; set; }
    }
}