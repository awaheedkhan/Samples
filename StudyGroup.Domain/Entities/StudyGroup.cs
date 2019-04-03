using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup.Domain.Entities
{
    public class StudyGroup
    {
        public IEnumerable<string> GroupMembers { get; set; }
    }
}
