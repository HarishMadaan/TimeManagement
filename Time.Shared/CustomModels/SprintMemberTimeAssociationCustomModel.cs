﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Shared.CustomModels
{
    public class SprintMemberTimeAssociationCustomModel
    {
        public int TimeId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> SprintId { get; set; }
        public Nullable<decimal> TimeSpend { get; set; }
        public Nullable<System.DateTime> DDate { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
