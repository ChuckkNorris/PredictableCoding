using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NamingIsHard_Code.Foundation;
namespace NamingIsHard_Code.Feature
{
    public class EmailSignup:IEmailSignup
    {
        public Response AddUserToList() {
            var request = RequestFactory.Create_AddUserToList_Request("email", "list");
            if (RequestValidator.IsRequestValid(request)) {
                var EmailSrvc = new EmailService();
                var response = EmailSrvc.AddContactToList(request);
                //log if needed
                //return View if MVC, or JSON if AJAX
                return response;
            }
            else
            {
                return null;
            }
            
        }
    }
}