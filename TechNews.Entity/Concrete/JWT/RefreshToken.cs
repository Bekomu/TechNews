using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Entities.Abstract;

namespace TechNews.Entity.Concrete.JWT
{
    public class RefreshToken : BaseEntity
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? RevokedDate { get; set; }
        public string CreateIp { get; set; }
        public bool IsExpired => DateTime.Now >= ExpirationDate;
        public bool IsActive => RevokedDate == null && !IsExpired;
    }
}
