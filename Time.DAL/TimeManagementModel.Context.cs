﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Time.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TimeManagementEntities : DbContext
    {
        public TimeManagementEntities()
            : base("name=TimeManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblApplicationUser> tblApplicationUsers { get; set; }
        public virtual DbSet<tblMember> tblMembers { get; set; }
        public virtual DbSet<tblMemberSkillAssociation> tblMemberSkillAssociations { get; set; }
        public virtual DbSet<tblProject> tblProjects { get; set; }
        public virtual DbSet<tblProjectMemberAssociation> tblProjectMemberAssociations { get; set; }
        public virtual DbSet<tblProjectMemberTimeAssociation> tblProjectMemberTimeAssociations { get; set; }
        public virtual DbSet<tblProjectSprint> tblProjectSprints { get; set; }
        public virtual DbSet<tblSkill> tblSkills { get; set; }
        public virtual DbSet<tblSprintMemberAssociation> tblSprintMemberAssociations { get; set; }
        public virtual DbSet<tblUserTypeMaster> tblUserTypeMasters { get; set; }
        public virtual DbSet<tblSprintMemberTimeAssociation> tblSprintMemberTimeAssociations { get; set; }
    }
}
