using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace FBManager
{
    public class FacebookService
    {
        private readonly FacebookClient _facebookClient = new FacebookClient();
        public string AccessToken { get; set; }

        public async Task<string> GetUserName()
        {
            Debug.WriteLine("Entering GetUserName function");
            if (AccessToken == null)
                throw new Exception("Access Token is not set");

            var result = await _facebookClient.GetAsync<dynamic>(
                AccessToken, "me", "fields=name");
            

            string res = result.name == null ? "" : result.name;
            return res;
        }
    }
}
