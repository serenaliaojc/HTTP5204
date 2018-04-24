using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sjghel_Project.Models
{
    public class NewsMetadata
    {
        [Key]
        public int news_id { get; set; }

        [Display(Name = "Post Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public System.DateTime news_post_time { get; set; }

        [Display(Name = "Last Edit")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public System.DateTime news_edit_time { get; set; }

        [Display(Name = "News Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the title.")]
        [StringLength(100, ErrorMessage = "No more than 100 characters.")]
        public string news_title { get; set; }

        [Display(Name = "News Brief")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the brief.")]
        [StringLength(255, ErrorMessage = "No more than 255 characters.")]
        public string news_brief { get; set; }

        [Display(Name = "News Content")]
        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the content.")]
        public string news_content { get; set; }

        [Display(Name = "News Picture")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No picture.")]
        public string news_pic_path { get; set; }
    }

    public class AdminMetadata
    {
        [Key]
        [Display(Name = "Admin ID")]
        public int admin_id { get; set; }

        [Display(Name = "Administrator")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name.")]
        [StringLength(50, ErrorMessage = "No more than 50 characters.")]
        public string admin_name { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password needs to be 8-16 characters long.")]
        public string admin_password { get; set; }

        [Display(Name = "Admin Role")]
        public string admin_role { get; set; }
    }

}