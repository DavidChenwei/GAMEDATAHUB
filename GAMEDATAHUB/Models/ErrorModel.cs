using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models
{
    public class ErrorModel
    {
        public ErrorModel() {
            Errors = new List<Error>();
        }
        public List<Error> Errors;
        public void AddError(string reason)
        {
            Errors.Add(new Error { Reason = reason });
        }
    }

    public class Error {
        public string Reason { get; set; }
    }
}