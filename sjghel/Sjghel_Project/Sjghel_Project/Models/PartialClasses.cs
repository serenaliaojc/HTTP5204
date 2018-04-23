using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sjghel_Project.Models
{
    [MetadataType(typeof(NewsMetadata))]
    public partial class News
    {
    }

    [MetadataType(typeof(AdminMetadata))]
    public partial class Admin
    {
    }
}