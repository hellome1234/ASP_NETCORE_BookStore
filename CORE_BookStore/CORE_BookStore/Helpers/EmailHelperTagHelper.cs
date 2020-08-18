using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Helpers
{
    public class EmailHelperTagHelper: TagHelper 
    {
        public string Email { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Name of the Tag 
            output.TagName = "a";
            //Attribute of the tag such as href, style etc
            output.Attributes.Add("href",$"mailto:{Email}");
            //content within the Tag <a>Content</a>
            output.Content.SetContent("Email:");
                        
        }
    }
}
