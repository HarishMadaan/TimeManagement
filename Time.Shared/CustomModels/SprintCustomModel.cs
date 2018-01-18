using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Shared.CustomModels
{
    public class SprintCustomModel
    {
        public int SprintId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string SprintNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public List<SprintMembers> MemberList { get; set; }
    }

    public class SprintMembers
    {
        public int? MemberId { get; set; }
        public string MemberName { get; set; }
        public Nullable<decimal> TotalTimeSpent { get; set; }
    }

}
