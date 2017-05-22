using System;
using System.Text.RegularExpressions;

namespace ValidationEngine
{
    public class Validator
    {
        
       private string validEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public bool ValidateEmailAdress(string v)
        {

            var resultMatch = Regex.IsMatch(v, validEmail);
          
            return resultMatch;
            
        }
    }
}