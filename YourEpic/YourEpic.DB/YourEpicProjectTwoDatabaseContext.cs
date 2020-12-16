using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YourEpic.DB
{
    public partial class YourEpicProjectTwoDatabaseContext : DbContext
    {
        public YourEpicProjectTwoDatabaseContext()
        {
        }

        public YourEpicProjectTwoDatabaseContext(DbContextOptions<YourEpicProjectTwoDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Epic> Epics { get; set; }
        public virtual DbSet<EpicCategory> EpicCategories { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "ProjTwo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("Chapter", "ProjTwo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EpicId).HasColumnName("EpicID");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Epic)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.EpicId)
                    .HasConstraintName("FK_ChapterEpicID");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "ProjTwo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Comment");

                entity.Property(e => e.CommenterId).HasColumnName("CommenterID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EpicId).HasColumnName("EpicID");

                entity.HasOne(d => d.Commenter)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentCommenterID");

                entity.HasOne(d => d.Epic)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.EpicId)
                    .HasConstraintName("FK_CommentEpicID");
            });

            modelBuilder.Entity<Epic>(entity =>
            {
                entity.ToTable("Epic", "ProjTwo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WriterId).HasColumnName("WriterID");

                entity.HasOne(d => d.Writer)
                    .WithMany(p => p.Epics)
                    .HasForeignKey(d => d.WriterId)
                    .HasConstraintName("FK_EpicWriterID");
            });

            modelBuilder.Entity<EpicCategory>(entity =>
            {
                entity.HasKey(e => new { e.EpicId, e.CategoryId })
                    .HasName("PK_EpicIDCategoryID");

                entity.ToTable("EpicCategory", "ProjTwo");

                entity.Property(e => e.EpicId).HasColumnName("EpicID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.EpicCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_EpicCategoryCategoryID");

                entity.HasOne(d => d.Epic)
                    .WithMany(p => p.EpicCategories)
                    .HasForeignKey(d => d.EpicId)
                    .HasConstraintName("FK_EpicCategoryEpicID");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating", "ProjTwo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EpicId).HasColumnName("EpicID");

                entity.Property(e => e.RaterId).HasColumnName("RaterID");

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.HasOne(d => d.Epic)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.EpicId)
                    .HasConstraintName("FK_RatingEpicID");

                entity.HasOne(d => d.Rater)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.RaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingRaterID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "ProjTwo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => new { e.WriterId, e.SubscriberId })
                    .HasName("PK_WriterIDSubscriberID");

                entity.ToTable("Subscription", "ProjTwo");

                entity.Property(e => e.WriterId).HasColumnName("WriterID");

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");

                entity.Property(e => e.HasNewContent).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.SubscriptionSubscribers)
                    .HasForeignKey(d => d.SubscriberId)
                    .HasConstraintName("FK_SubscriptionSubscriberID");

                entity.HasOne(d => d.Writer)
                    .WithMany(p => p.SubscriptionWriters)
                    .HasForeignKey(d => d.WriterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionWriterID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "ProjTwo");

                entity.HasIndex(e => e.Email, "UQ__User__A9D10534467F9AD1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PASSWORD");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_UserRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
