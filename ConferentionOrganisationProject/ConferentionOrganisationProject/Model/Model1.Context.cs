﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConferentionOrganisationProject.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
        public partial class ConferentionOrganisationDBEntities : DbContext
        {
            private static ConferentionOrganisationDBEntities _context { get; set; }
            public ConferentionOrganisationDBEntities()
                : base("name=ConferentionOrganisationDBEntities")
            {
            }
            public static ConferentionOrganisationDBEntities GetContext()
            {
                if (_context == null)
                {
                    _context = new ConferentionOrganisationDBEntities();
                }
                return _context;
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Directions> Directions { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Event_Chains> Event_Chains { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sexes> Sexes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}