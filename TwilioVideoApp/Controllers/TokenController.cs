using System;
using System.Configuration;
using System.Web.Mvc;
using Twilio;
using Twilio.Auth;

namespace TwilloVideoConnect.Controllers
{
    public class TokenController : Controller
    {
        // GET: /Token/
        public ActionResult Index(string username)
        {
            // Load Twilio configuration from Web.config
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var apiKey = ConfigurationManager.AppSettings["TwilioApiKey"];
            var apiSecret = ConfigurationManager.AppSettings["TwilioApiSecret"];
            var videoConfigSid = ConfigurationManager.AppSettings["TwilioConfigurationSid"];

            // Create a random identity for the client
            // this should be the member/caregiver/user GUID which needs to
            // be passed as an argument
            string identity = username;
            // Create an Access Token generator
            var token = new AccessToken(accountSid, apiKey, apiSecret);
            token.Identity = identity;
            // Create a video (Conversations SDK) grant for this token
            var grant = new ConversationsGrant();
            grant.ConfigurationProfileSid = videoConfigSid;
            token.AddGrant(grant);
            return Json(new
            {
                identity = token.Identity,
                token = token.ToJWT()
            }, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Token/
        //public ActionResult username(string username)
        //{
        //    // Load Twilio configuration from Web.config
        //    var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
        //    var apiKey = ConfigurationManager.AppSettings["TwilioApiKey"];
        //    var apiSecret = ConfigurationManager.AppSettings["TwilioApiSecret"];
        //    var videoConfigSid = ConfigurationManager.AppSettings["TwilioConfigurationSid"];

        //    // Create a random identity for the client
        //    // this should be the member/caregiver/user GUID which needs to
        //    // be passed as an argument

        //    string identity = username;
        //   // Create an Access Token generator
        //    var token = new AccessToken(accountSid, apiKey, apiSecret);
        //    token.Identity = identity;
        //    // Create a video (Conversations SDK) grant for this token
        //    var grant = new ConversationsGrant();
        //    grant.ConfigurationProfileSid = videoConfigSid;
        //    token.AddGrant(grant);
        //    return Json(new
        //    {
        //        identity=token.Identity,
        //        token = token.ToJWT()
        //    }, JsonRequestBehavior.AllowGet);
        //}

        //private  string GenerateUsername()
        //{
        //    string username = "";

        //    string[] adjective ={"Abrasive", "Brash", "Callous", "Daft", "Eccentric", "Fiesty", "Golden",
        //                "Holy", "Ignominious", "Joltin", "Killer", "Luscious", "Mushy", "Nasty",
        //                "OldSchool", "Pompous", "Quiet", "Rowdy", "Sneaky", "Tawdry",
        //                "Unique", "Vivacious", "Wicked", "Xenophobic", "Yawning", "Zesty"};
        //    string adj= adjective[new Random().Next(adjective.Length)];

        //    string[] firstName ={"Anna", "Bobby", "Cameron", "Danny", "Emmett", "Frida", "Gracie", "Hannah",
        //                "Isaac", "Jenova", "Kendra", "Lando", "Mufasa", "Nate", "Owen", "Penny",
        //                "Quincy", "Roddy", "Samantha", "Tammy", "Ulysses", "Victoria", "Wendy",
        //                "Xander", "Yolanda", "Zelda"};
        //    string fName = firstName[new Random().Next(firstName.Length)];

        //    string[] lastName ={"Anchorage", "Berlin", "Cucamonga", "Davenport", "Essex", "Fresno",
        //                "Gunsight", "Hanover", "Indianapolis", "Jamestown", "Kane", "Liberty",
        //                "Minneapolis", "Nevis", "Oakland", "Portland", "Quantico", "Raleigh",
        //                "SaintPaul", "Tulsa", "Utica", "Vail", "Warsaw", "XiaoJin", "Yale","Zimmerman"};
        //    string lName = lastName[new Random().Next(lastName.Length)];

        //    return username=adj+fName+lName;
        //}
    }
}