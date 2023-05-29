using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowRole> ShowRoles { get; set; }
        public DbSet<ActorShowRole> ActorShowRoles { get; set; }
        public DbSet<ActorAudition> ActorAuditions { get; set; }
        public DbSet<Audition> Auditions { get; set; }
        public DbSet<AuditionReview> AuditionReviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ShowApplicationReview> ShowApplicationReviews { get; set; }
        public DbSet<TheaterShowSchedule> TheaterShowSchedules { get; set; }
        public DbSet<TheatreShows> TheatreShows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<ActorAudition>(a => {
            //     a.HasKey(aa => new {aa.ActorId, aa.AuditionId});
            //     a.HasOne(aa => aa.Actor)
            //         .WithMany(a => a.ActorAuditions)
            //         .HasForeignKey(aa => aa.ActorId);
            //     a.HasOne(aa => aa.Audition)
            //         .WithMany(a => a.ActorAuditions)
            //         .HasForeignKey(aa => aa.AuditionId);
            // });

            builder.Entity<Festival>()
                .HasOne(f => f.Organizer)
                .WithMany(t => t.Festivals)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}