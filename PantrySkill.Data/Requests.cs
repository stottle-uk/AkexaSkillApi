using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantrySkill.Data
{
    public class Requests
    {
        public Request Create(Request request)
        {
            using (var db = new pantrydemo_dbEntities())
            {
                var member = db.Members.FirstOrDefault(m => m.AlexaUserId == request.UserId);

                if (member == null)
                {
                    request.Member = new Member { AlexaUserId = request.UserId, CreatedDate = DateTime.Now, LastRequestDate = DateTime.Now, RequestCount = 1 };

                    db.Requests.Add(request);
                }
                else
                {
                    member.Requests.Add(request);
                }

                db.SaveChanges();
            }

            return request;
        }

    }
}
