using AlexaSkill.Data;
using Newtonsoft.Json;
using PantrySkill.Data;
using System;
using System.Web.Http;

namespace PantrySkill.Controllers
{
    public class PantryController : ApiController
    {
        [Route("api/pantry/demo")]
        public IHttpActionResult PostPantry(AlexaRequest alexaRequest)
        {
            try
            {
                new Requests().Create(new Request
                {
                    MemberId = (alexaRequest.Session.Attributes == null) ? 0 : alexaRequest.Session.Attributes.MemberId,
                    Timestamp = alexaRequest.Request.Timestamp,
                    Intent = (alexaRequest.Request.Intent == null) ? "" : alexaRequest.Request.Intent.Name,
                    AppId = alexaRequest.Session.Application.ApplicationId,
                    RequestId = alexaRequest.Request.RequestId,
                    SessionId = alexaRequest.Session.SessionId,
                    UserId = alexaRequest.Session.User.UserId,
                    IsNew = alexaRequest.Session.New,
                    Version = alexaRequest.Version,
                    Type = alexaRequest.Request.Type,
                    Reason = alexaRequest.Request.Reason ?? "",
                    Slots = "",
                    CreatedDate = DateTime.UtcNow
                });

            }
            catch (Exception e)
            {
                return BadRequest(JsonConvert.SerializeObject(e));
            }

            return Ok(new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Today will provide you a new learning opportunity.  Stick with it and the possibilities will be endless. Can I help you with anything else?"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Pantry",
                        content = "Hello Pantry"
                    },
                    reprompt = new
                    {
                        outputSpeech = new
                        {
                            type = "PlainText",
                            text = "Can I help you with anything else?"
                        }
                    },
                    shouldEndSession = true
                }
            });
        }
    }
}