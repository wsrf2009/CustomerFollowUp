using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary.DataStructure
{
    public class CustomerFollowUpLog
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public string Time { get; set; }
        public string Briefing { get; set; }
        public string Content { get; set; }
        public string State { get; set; }
        public string Modify { get; set; }
        public string BelongsTo { get; set; }
        public int CustomerInfoId { get; set; }
    }
}
