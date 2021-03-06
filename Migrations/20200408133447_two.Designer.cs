// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportMSSajib.Data;

namespace TransportMSSajib.Migrations
{
    [DbContext(typeof(dataContext))]
    [Migration("20200408133447_two")]
    partial class two
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransportMSSajib.Models.AdminInfo", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("aCPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aNPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aUName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Admin_Info");
                });

            modelBuilder.Entity("TransportMSSajib.Models.FacultyInfo", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fCPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fDesignation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fNPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fUName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Faculty_Info");
                });

            modelBuilder.Entity("TransportMSSajib.Models.NotificationInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NComingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NComingTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NHId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nfrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("TransportMSSajib.Models.RegistrationFacultyInfo", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fCPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fDesignation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fNPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fUName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Registration_faculty");
                });

            modelBuilder.Entity("TransportMSSajib.Models.TransportInfo", b =>
                {
                    b.Property<string>("TransportNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("route")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransportNumber");

                    b.ToTable("Transport");
                });
#pragma warning restore 612, 618
        }
    }
}
