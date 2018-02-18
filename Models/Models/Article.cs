using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Article
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public string WebPublicationDate { get; set; }
        public string WebTitle { get; set; }
        public string WebURL { get; set; }
        public string ApiURL { get; set; }
        public bool IsHosted { get; set; }
        public string PillarId { get; set; }
        public string PillarName { get; set; }
    }
}
