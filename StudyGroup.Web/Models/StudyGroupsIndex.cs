using System.ComponentModel.DataAnnotations;

namespace StudyGroup.Web.Models
{
    public class StudyGroupsIndex
    {
        [Required]
        public string[,] TestResults { get; set; }

        public string[][] StudyGroups { get; set; }
    }
}