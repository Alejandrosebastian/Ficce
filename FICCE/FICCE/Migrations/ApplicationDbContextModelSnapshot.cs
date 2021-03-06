﻿// <auto-generated />
using FICCE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FICCE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FICCE.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FICCE.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activo");

                    b.Property<int>("EmpresaId");

                    b.Property<int>("EstantesId");

                    b.Property<string>("imagen");

                    b.HasKey("CompraId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EstantesId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("FICCE.Models.Edificio", b =>
                {
                    b.Property<int>("EdificioId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventoId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.HasKey("EdificioId");

                    b.HasIndex("EventoId");

                    b.ToTable("Edificio");
                });

            modelBuilder.Entity("FICCE.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<string>("Telefono_convencional")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<string>("telefono_movil")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("EmpleadoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("FICCE.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<int>("TipoempresaId");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<string>("extenencion_telefono")
                        .HasMaxLength(7);

                    b.Property<string>("persona_responsable")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<string>("telefono_contacto")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("telefono_convencional")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("EmpresaId");

                    b.HasIndex("TipoempresaId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("FICCE.Models.Estantes", b =>
                {
                    b.Property<int>("EstantesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ancho")
                        .HasMaxLength(10);

                    b.Property<int>("EventoId");

                    b.Property<int>("Largo")
                        .HasMaxLength(10);

                    b.Property<int>("PlantaId");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("EstantesId");

                    b.HasIndex("EventoId");

                    b.HasIndex("PlantaId");

                    b.ToTable("Estantes");
                });

            modelBuilder.Entity("FICCE.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ciudad");

                    b.Property<DateTime>("dia_fin");

                    b.Property<DateTime>("dia_inicio");

                    b.Property<int>("precio_estan");

                    b.HasKey("EventoId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("FICCE.Models.Planta", b =>
                {
                    b.Property<int>("PlantaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EdificioId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PlantaId");

                    b.HasIndex("EdificioId");

                    b.ToTable("Planta");
                });

            modelBuilder.Entity("FICCE.Models.Tipoempresa", b =>
                {
                    b.Property<int>("TipoempresaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.HasKey("TipoempresaId");

                    b.ToTable("Tipoempresa");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FICCE.Models.Compra", b =>
                {
                    b.HasOne("FICCE.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FICCE.Models.Estantes", "Estantes")
                        .WithMany()
                        .HasForeignKey("EstantesId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FICCE.Models.Edificio", b =>
                {
                    b.HasOne("FICCE.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FICCE.Models.Empleado", b =>
                {
                    b.HasOne("FICCE.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FICCE.Models.Empresa", b =>
                {
                    b.HasOne("FICCE.Models.Tipoempresa", "Tipoempresa")
                        .WithMany()
                        .HasForeignKey("TipoempresaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FICCE.Models.Estantes", b =>
                {
                    b.HasOne("FICCE.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FICCE.Models.Planta", "Planta")
                        .WithMany()
                        .HasForeignKey("PlantaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FICCE.Models.Planta", b =>
                {
                    b.HasOne("FICCE.Models.Edificio", "Edificio")
                        .WithMany()
                        .HasForeignKey("EdificioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FICCE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FICCE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FICCE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FICCE.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
