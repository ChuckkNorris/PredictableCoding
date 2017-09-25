using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NamingIsHard_Code.Foundation;
namespace NamingIsHard_Code.Foundation
{
	public class EmailService
	{
        private Client _client;
        public Response AddContactToList(Request request)
        {
            var contactResponse = new Response();
            if (_client != null)
            {
                var response = _client.addOrUpdateContacts(request);
                return response;
            }
            else
            {
                contactResponse.Messages.Add("Client is null. Did you forget to Log in?");
                contactResponse.Errors.Add(-1);
            }

            return contactResponse;
        }
    }
}