using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Jobs
{
   public class jobschulde
    {
        public Type _jobtype{ get; set; }
        public string _cronExpression{ get; set; }
        public jobschulde(Type jobtype, string cronExpression)
        {
            _jobtype = jobtype;
            _cronExpression = cronExpression;
        }
    }
}
