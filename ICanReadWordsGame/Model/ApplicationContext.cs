using Microsoft.EntityFrameworkCore;

namespace ICanReadWordsGame.Model
{
    
    public class MyApplicationContext : DbContext
    {
        
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<LevelWord> LevelWords { get; set; }
        public MyApplicationContext(DbContextOptions options):base(options)
        {
          //  SQLitePCL.Batteries_V2.Init();

            //   this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LevelWord>()
                .HasKey(sc => new { sc.LevelId, sc.WordId });

            modelBuilder.Entity<LevelWord>()
                .HasOne<Level>(sc => sc.Level);
            modelBuilder.Entity<LevelWord>()
                .HasOne<Word>(sc => sc.Word);

            modelBuilder.Entity<GameType>()
                        .HasMany(m => m.Levels)
                        .WithOne(m => m.GameType)
                        .HasForeignKey(m => m.GameTypeId);

            modelBuilder.Entity<Level>()
                        .HasMany(m => m.Words)
                        .WithMany(w => w.Levels)
                        .UsingEntity<LevelWord>(b => b.HasOne(e => e.Word).WithMany().HasForeignKey(e => e.WordId),
                                                b => b.HasOne(e => e.Level).WithMany().HasForeignKey(e => e.LevelId));
            modelBuilder.Entity<Level>()
                        .HasOne(m => m.GameType)
                        .WithMany(gt => gt.Levels);


            modelBuilder.Entity<Word>()
                        .HasMany(word => word.Levels)
                        .WithMany(level => level.Words);
            modelBuilder.Entity<Word>()
                .HasOne(word => word.Entity)
                .WithMany(entity => entity.Words);


            //                       


            modelBuilder.Entity<Entity>()
                        .HasMany(m => m.Words)
                        .WithOne(m => m.Entity) 
                        .HasForeignKey(m => m.EntityId) 
                        .OnDelete(DeleteBehavior.Cascade);

            




            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne<Course>(sc => sc.Course)
            //    .WithMany(s => s.StudentCourses)
            //    .HasForeignKey(sc => sc.CId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
