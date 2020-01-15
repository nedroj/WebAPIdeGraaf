using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIdeGraaf.Models
{
    public partial class degraafContext : DbContext
    {
        public degraafContext()
        {

        }

        public degraafContext(DbContextOptions<degraafContext> options) : base(options) { }

        public virtual DbSet<MainCourses> MainCourses { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Receipts> Receipts { get; set; }
        public virtual DbSet<ReservationTables> ReservationTables { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SubCourses> SubCourses { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<MainCourses>(entity =>
            {
                entity.ToTable("main_courses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_orders_products");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ReceiptId)
                    .HasConstraintName("FK_orders_receipts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_orders_users");
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email)
                    .HasName("password_resets_email_index");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SubCourseId).HasColumnName("sub_course_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.SubCourse)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubCourseId)
                    .HasConstraintName("FK_products_sub_courses");
            });

            modelBuilder.Entity<Receipts>(entity =>
            {
                entity.ToTable("receipts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountRecieved).HasColumnName("amount_recieved");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasMaxLength(191);

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ReservationTables>(entity =>
            {
                entity.HasKey(e => new { e.ReservationId, e.TableId });

                entity.ToTable("reservation_tables");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationTables)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservation_tables_reservations");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.ReservationTables)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservation_tables_tables");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.ToTable("reservations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(191);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.People).HasColumnName("people");

                entity.Property(e => e.ReservationType)
                    .HasColumnName("reservation_type")
                    .HasMaxLength(191);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsedReservation).HasColumnName("used_reservation");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_reservations_users");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(191);

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_reviews_users");
            });

            modelBuilder.Entity<SubCourses>(entity =>
            {
                entity.ToTable("sub_courses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.MainCourseId).HasColumnName("main_course_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MainCourse)
                    .WithMany(p => p.SubCourses)
                    .HasForeignKey(d => d.MainCourseId)
                    .HasConstraintName("FK_sub_courses_main_courses");
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.ToTable("tables");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");

                entity.Property(e => e.MinCapacity).HasColumnName("min_capacity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(191);

                entity.Property(e => e.Blocked).HasColumnName("blocked");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(191);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnName("email_verified_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Infix)
                    .HasColumnName("infix")
                    .HasMaxLength(191);

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(191);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(191);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(191);

                entity.Ignore(e => e.Token);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
