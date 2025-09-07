using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetTopologySuite.IO;
using ProjetMVC.Data;
using ProjetMVC.Enums;
using ProjetMVC.Models;

public class MyDbContext : IdentityDbContext<Utilisateur, IdentityRole, string>
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    public DbSet<Borne> Borne { get; set; }
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Adresse> Adresses { get; set; }
    public DbSet<BorneUtilisateur> BorneUtilisateurs { get; set; }
    public DbSet<Disponibilite> Disponibilites{ get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedData.Seed(modelBuilder);

        // Configure relationships and constraints
        modelBuilder.Entity<Borne>()
            .HasOne(b => b.Adresse)
            .WithOne(a => a.Borne)
            .HasForeignKey<Borne>(b => b.AdresseId);

        modelBuilder.Entity<Disponibilite>()
            .HasOne(d => d.Borne)
            .WithMany(b => b.Disponibilites)
            .HasForeignKey(d => d.BorneId);

        //modelBuilder.Entity<Disponibilite>()
        //    .HasOne(d => d.Utilisateur)
        //    .WithMany(u => u.Disponibilites)
        //    .HasForeignKey(d => d.UtilisateurId);

        modelBuilder.Entity<Adresse>()
            .HasIndex(a => new { a.NoCivique, a.Rue, a.Ville, a.CodePostal, a.Province })
            .IsUnique();

        // Configure composite primary key for BorneUtilisateur if necessary
        modelBuilder.Entity<BorneUtilisateur>()
            .HasKey(bu => new { bu.BorneId, bu.UtilisateurId });

      
        // Additional configurations
        modelBuilder.Entity<Borne>()
            .Property(b => b.DateCreation)
            .HasDefaultValueSql("GETDATE()");

        
    }



   

}

