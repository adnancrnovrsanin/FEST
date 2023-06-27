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
        public DbSet<ActorShowRoleAudition> ActorShowRoleAuditions { get; set; }
        public DbSet<Audition> Auditions { get; set; }
        public DbSet<AuditionReview> AuditionReviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ShowApplicationReview> ShowApplicationReviews { get; set; }
        public DbSet<TheatreShowSchedule> TheaterShowSchedules { get; set; }
        public DbSet<TheatreShows> TheatreShows { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActorShowRoleAudition>(a => {
                a.HasKey(aa => new {aa.ActorId, aa.AuditionId, aa.ShowRoleId});
                a.HasOne(aa => aa.Actor)
                    .WithMany(a => a.Auditions)
                    .HasForeignKey(aa => aa.ActorId);
                a.HasOne(aa => aa.Audition)
                    .WithMany(a => a.Auditioners)
                    .HasForeignKey(aa => aa.AuditionId);
                a.HasOne(aa => aa.ShowRole)
                    .WithMany(sr => sr.ShowRoleAuditions)
                    .HasForeignKey(aa => aa.ShowRoleId);
            });

            builder.Entity<ActorShowRole>(a => {
                a.HasKey(asr => new {asr.ActorId, asr.RoleId, asr.ShowId});
                a.HasOne(asr => asr.Actor)
                    .WithMany(a => a.ActingRoles)
                    .HasForeignKey(asr => asr.ActorId);
                a.HasOne(asr => asr.Role)
                    .WithMany(sr => sr.RoleActors)
                    .HasForeignKey(asr => asr.RoleId);
                a.HasOne(asr => asr.Show)
                    .WithMany(s => s.Actors)
                    .HasForeignKey(asr => asr.ShowId);
            });

            builder.Entity<TheatreShows>(ts => {
                ts.HasKey(t => new {t.TheatreId, t.ShowId});
                ts.HasOne(t => t.Theatre)
                    .WithMany(t => t.Shows)
                    .HasForeignKey(t => t.TheatreId);
                ts.HasOne(t => t.Show)
                    .WithMany(s => s.Theatres)
                    .HasForeignKey(t => t.ShowId);
            });

            builder.Entity<TheatreShowSchedule>(tss => {
                tss.HasKey(t => new {t.TheatreId, t.ShowId, t.ScheduleId});
                tss.HasOne(t => t.Theatre)
                    .WithMany(t => t.ShowSchedules)
                    .HasForeignKey(t => t.TheatreId);
                tss.HasOne(t => t.Show)
                    .WithMany(s => s.TheatreSchedules)
                    .HasForeignKey(t => t.ShowId);
                tss.HasOne(t => t.Schedule)
                    .WithMany(s => s.TheatreShows)
                    .HasForeignKey(t => t.ScheduleId);
            });

            builder.Entity<ShowApplicationReview>(sar => {
                sar.HasKey(s => new {s.ShowId, s.ReviewerId});
                sar.HasOne(s => s.Show)
                    .WithMany(s => s.ApplicationReviews)
                    .HasForeignKey(s => s.ShowId);
                sar.HasOne(s => s.Reviewer)
                    .WithMany(s => s.ShowApplications)
                    .HasForeignKey(s => s.ReviewerId);
            });

            builder.Entity<AuditionReview>(ar => {
                ar.HasKey(a => new {a.AuditionId, a.ReviewerId});
                ar.HasOne(a => a.Audition)
                    .WithMany(a => a.Reviews)
                    .HasForeignKey(a => a.AuditionId);
                ar.HasOne(a => a.Reviewer)
                    .WithMany(a => a.AuditionReviews)
                    .HasForeignKey(a => a.ReviewerId);
            });

            builder.Entity<Festival>()
                .HasOne(f => f.Organizer)
                .WithMany(t => t.FestivalsOrganized)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Schedule>()
                .HasOne(s => s.Festival)
                .WithMany(f => f.ShowSchedules)
                .HasForeignKey(s => s.FestivalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Theatre>()
                .HasOne(t => t.Manager)
                .WithOne(a => a.ManagedTheatre)
                .HasForeignKey<Theatre>(t => t.ManagerId);

            builder.Entity<AppUser>()
                .HasOne(a => a.ManagedTheatre)
                .WithOne(t => t.Manager)
                .HasForeignKey<Theatre>(t => t.ManagerId);

            builder.Entity<Festival>()
                .HasData(
                    new List<Festival>{
                        new Festival{
                            Id = Guid.NewGuid(),
                            Name = "Festival 1",
                            StartDate = DateTime.UtcNow.AddMonths(1),
                            EndDate = DateTime.UtcNow.AddMonths(2),
                            ZipCode = 36300,
                            City = "Beograd"
                        },
                        new Festival{
                            Id = Guid.NewGuid(),
                            Name = "Festival 2",
                            StartDate = DateTime.UtcNow.AddMonths(3),
                            EndDate = DateTime.UtcNow.AddMonths(4),
                            ZipCode = 36300,
                            City = "Beograd"
                        },
                        new Festival{
                            Id = Guid.NewGuid(),
                            Name = "Festival 3",
                            StartDate = DateTime.UtcNow.AddMonths(5),
                            EndDate = DateTime.UtcNow.AddMonths(6),
                            ZipCode = 36300,
                            City = "Beograd"
                        },
                        new Festival{
                            Id = Guid.NewGuid(),
                            Name = "Festival 4",
                            StartDate = DateTime.UtcNow.AddMonths(7),
                            EndDate = DateTime.UtcNow.AddMonths(8),
                            ZipCode = 36300,
                            City = "Beograd"
                        },
                        new Festival{
                            Id = Guid.NewGuid(),
                            Name = "Festival 5",
                            StartDate = DateTime.UtcNow.AddMonths(9),
                            EndDate = DateTime.UtcNow.AddMonths(10),
                            ZipCode = 36300,
                            City = "Beograd"
                        },
                    }
                );
        }
    }
}