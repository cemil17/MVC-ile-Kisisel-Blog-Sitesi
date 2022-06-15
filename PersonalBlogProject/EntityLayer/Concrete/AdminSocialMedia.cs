using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    class AdminSocialMedia
    {
        public int ASocialMediaID { get; set; }
        public string SocialMedia { get; set; }
        public string SocialMediaIcon { get; set; }
        public string Link { get; set; }
        public bool State { get; set; }
    }
}
