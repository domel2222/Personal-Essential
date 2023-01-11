using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities
{
    public static class HelperValidator
    {
        public const string NotNullOrEmpty = "should not be null or empty";
        public const string CorrectDate = "Please insert appropriate date. Date should not be greater than actual";
        public const string ChooseAnotherEmail = "Please insert another email this is taken";
        public const string ValidEmail = "A valid email address is required";
        public const string NotExistInApplication = "not exist in application, check  name and correct it";


    }
}
