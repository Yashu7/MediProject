using MediProjectWebApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediProjectWebApp.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public bool ProjectEnabled { get; set; } = true;
        public bool AcceptNewVisits { get; set; } = false;
        public ImageTypeEnum SupportedImageType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Project()
        {

        }
        public Project(long id, string projectName, bool enabled, bool accept, ImageTypeEnum imageType, DateTime createdAt)
        {
            Id = id;
            ProjectName = projectName;
            ProjectEnabled = enabled;
            AcceptNewVisits = accept;
            SupportedImageType = imageType;
            CreatedAt = createdAt;
        }
    }
}