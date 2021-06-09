using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ThanksCardAPI.Models
{
    public class Branch
    {
        public long Id { get; set; }
        public string Name { get; set; }

        // Parent には親部署が入る
        // Children には子部署リストが入る
        // 1対多: Department エンティティには複数の User エンティティが属する
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}