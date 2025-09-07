using Microsoft.EntityFrameworkCore;
using ProjetMVC.Enums;
using ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetMVC.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Utilisateurs (оставляем без изменений)
            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur
                {
                    Id = "1",
                    UserName = "user1@example.com",
                    NormalizedUserName = "USER1@EXAMPLE.COM",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    FirstName = "John",
                    LastName = "Doe",
                },
                new Utilisateur
                {
                    Id = "2",
                    UserName = "user2@example.com",
                    NormalizedUserName = "USER2@EXAMPLE.COM",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new Utilisateur
                {
                    Id = "3",
                    UserName = "user3@example.com",
                    NormalizedUserName = "USER3@EXAMPLE.COM",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    FirstName = "Pierre",
                    LastName = "Doe"
                },
                new Utilisateur
                {
                    Id = "4",
                    UserName = "user4@example.com",
                    NormalizedUserName = "USER4@EXAMPLE.COM",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    FirstName = "Paul",
                    LastName = "Doe"
                },
                new Utilisateur
                {
                    Id = "5",
                    UserName = "user5@example.com",
                    NormalizedUserName = "USER5@EXAMPLE.COM",
                    Email = "user5@example.com",
                    NormalizedEmail = "USER5@EXAMPLE.COM",
                    FirstName = "Richard",
                    LastName = "Doe"
                }
            );


            // Seed Adresses
            modelBuilder.Entity<Adresse>().HasData(
            new Adresse { AdresseId = 1, NoCivique = "200", Rue = "Rue Morier", Ville = "Sainte-Madeleine", CodePostal = "J0H 1S0", Province = 9, Latitude = 45.5900834, Longitude = -73.093208 },
            new Adresse { AdresseId = 2, NoCivique = "300", Rue = "Rue Saint-Jean", Ville = "Québec", CodePostal = "G1R 1P4", Province = 9, Latitude = 46.8138783, Longitude = -71.2079809 },
            new Adresse { AdresseId = 3, NoCivique = "500", Rue = "Avenue du Parc", Ville = "Montréal", CodePostal = "H2W 1S4", Province = 9, Latitude = 45.519280, Longitude = -73.589379 },
            new Adresse { AdresseId = 4, NoCivique = "600", Rue = "Boulevard Laurier", Ville = "Québec", CodePostal = "G1V 4H3", Province = 9, Latitude = 46.776030, Longitude = -71.271308 },
            new Adresse { AdresseId = 5, NoCivique = "700", Rue = "Rue Saint-Denis", Ville = "Montréal", CodePostal = "H2X 3K2", Province = 9, Latitude = 45.512145, Longitude = -73.563442 },
            new Adresse { AdresseId = 6, NoCivique = "800", Rue = "Rue Sherbrooke", Ville = "Montréal", CodePostal = "H3A 1G3", Province = 9, Latitude = 45.504859, Longitude = -73.574925 },
            new Adresse { AdresseId = 7, NoCivique = "900", Rue = "Rue Sainte-Catherine", Ville = "Montréal", CodePostal = "H3B 1A4", Province = 9, Latitude = 45.498315, Longitude = -73.566754 },
            new Adresse { AdresseId = 8, NoCivique = "1000", Rue = "Boulevard René-Lévesque", Ville = "Québec", CodePostal = "G1R 5P1", Province = 9, Latitude = 46.805805, Longitude = -71.225489 },
            new Adresse { AdresseId = 9, NoCivique = "1100", Rue = "Boulevard Charest", Ville = "Québec", CodePostal = "G1N 2E5", Province = 9, Latitude = 46.798438, Longitude = -71.236394 },
            new Adresse { AdresseId = 10, NoCivique = "1200", Rue = "Chemin Sainte-Foy", Ville = "Québec", CodePostal = "G1S 4R1", Province = 9, Latitude = 46.775084, Longitude = -71.297024 },
            new Adresse { AdresseId = 11, NoCivique = "222", Rue = "Boulevard Laurier", Ville = "Québec", Province = 9, CodePostal = "G1V 2M2", Latitude = 46.7676, Longitude = -71.2823 },
            new Adresse { AdresseId = 12, NoCivique = "333", Rue = "Chemin Sainte-Foy", Ville = "Québec", Province = 9, CodePostal = "G1S 2J4", Latitude = 46.7896, Longitude = -71.2541 },
            new Adresse { AdresseId = 13, NoCivique = "444", Rue = "Avenue Cartier", Ville = "Québec", Province = 9, CodePostal = "G1R 2S3", Latitude = 46.8076, Longitude = -71.2225 },
            new Adresse { AdresseId = 14, NoCivique = "555", Rue = "Rue de la Couronne", Ville = "Québec", Province = 9, CodePostal = "G1K 6E2", Latitude = 46.8150, Longitude = -71.2134 },
            new Adresse { AdresseId = 15, NoCivique = "666", Rue = "Rue Saint-Joseph Est", Ville = "Québec", Province = 9, CodePostal = "G1K 3A5", Latitude = 46.8126, Longitude = -71.2169 },
            new Adresse { AdresseId = 16, NoCivique = "777", Rue = "Rue Saint-Dominique", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6N3", Latitude = 46.3452, Longitude = -72.5477 },
            new Adresse { AdresseId = 17, NoCivique = "888", Rue = "Rue des Forges", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 5H9", Latitude = 46.3381, Longitude = -72.5400 },
            new Adresse { AdresseId = 18, NoCivique = "999", Rue = "Boulevard des Récollets", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6B1", Latitude = 46.3477, Longitude = -72.5484 },
            new Adresse { AdresseId = 19, NoCivique = "1010", Rue = "Rue Saint-Maurice", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 3P6", Latitude = 46.3325, Longitude = -72.5487 },
            new Adresse { AdresseId = 20, NoCivique = "1111", Rue = "Rue Notre-Dame Centre", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 4J6", Latitude = 46.3358, Longitude = -72.5393 },
            new Adresse { AdresseId = 21, NoCivique = "1212", Rue = "Rue Royale", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 4H8", Latitude = 46.3413, Longitude = -72.5458 },
            new Adresse { AdresseId = 22, NoCivique = "1313", Rue = "Boulevard Sainte-Madeleine", Ville = "Trois-Rivières", Province = 9, CodePostal = "G8Y 4E4", Latitude = 46.3401, Longitude = -72.5489 },
            new Adresse { AdresseId = 23, NoCivique = "1414", Rue = "Boulevard du Saint-Maurice", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6T5", Latitude = 46.5649, Longitude = -72.7463 },
            new Adresse { AdresseId = 24, NoCivique = "1515", Rue = "Boulevard des Hêtres", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6M9", Latitude = 46.5648, Longitude = -72.7445 },
            new Adresse { AdresseId = 25, NoCivique = "1616", Rue = "Boulevard du Capitaine", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6R6", Latitude = 46.5669, Longitude = -72.7452 },
            new Adresse { AdresseId = 26, NoCivique = "1717", Rue = "Rue de l'Anse", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6E7", Latitude = 46.5670, Longitude = -72.7413 },
            new Adresse { AdresseId = 27, NoCivique = "1818", Rue = "Rue de l'Église", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6M3", Latitude = 46.5646, Longitude = -72.7430 },
            new Adresse { AdresseId = 28, NoCivique = "1919", Rue = "Rue Saint-Joseph", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6N4", Latitude = 46.5665, Longitude = -72.7460 },
            new Adresse { AdresseId = 29, NoCivique = "2020", Rue = "Avenue Saint-Charles", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6G3", Latitude = 46.5647, Longitude = -72.7462 },
            new Adresse { AdresseId = 30, NoCivique = "2121", Rue = "Rue des Érables", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6J4", Latitude = 46.5650, Longitude = -72.7487 },
            new Adresse { AdresseId = 31, NoCivique = "2222", Rue = "Rue du Centre", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6L3", Latitude = 46.5662, Longitude = -72.7434 },
            new Adresse { AdresseId = 32, NoCivique = "2323", Rue = "Rue Saint-Marc", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6N9", Latitude = 46.5667, Longitude = -72.7420 },
            new Adresse { AdresseId = 33, NoCivique = "2424", Rue = "Rue des Pins", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6J8", Latitude = 46.5659, Longitude = -72.7437 },
            new Adresse { AdresseId = 34, NoCivique = "2525", Rue = "Rue Saint-Jean-Baptiste", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6E5", Latitude = 46.5668, Longitude = -72.7465 },
            new Adresse { AdresseId = 35, NoCivique = "2626", Rue = "Boulevard Saint-Michel", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6T9", Latitude = 46.5672, Longitude = -72.7469 },
            new Adresse { AdresseId = 36, NoCivique = "2727", Rue = "Rue Saint-Pierre", Ville = "Shawinigan", Province = 9, CodePostal = "G9N 6M6", Latitude = 46.5654, Longitude = -72.7471 },
            new Adresse { AdresseId = 37, NoCivique = "2828", Rue = "Rue Notre-Dame", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6M3", Latitude = 46.3380, Longitude = -72.5489 },
            new Adresse { AdresseId = 38, NoCivique = "2929", Rue = "Boulevard des Chenaux", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6T8", Latitude = 46.3358, Longitude = -72.5497 },
            new Adresse { AdresseId = 39, NoCivique = "3030", Rue = "Rue de la Commune", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6N5", Latitude = 46.3348, Longitude = -72.5402 },
            new Adresse { AdresseId = 40, NoCivique = "3131", Rue = "Boulevard des Forges", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6S7", Latitude = 46.3407, Longitude = -72.5475 },
            new Adresse { AdresseId = 41, NoCivique = "3232", Rue = "Boulevard du Saint-Laurent", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6T2", Latitude = 46.3384, Longitude = -72.5407 },
            new Adresse { AdresseId = 42, NoCivique = "3333", Rue = "Rue Saint-Roch", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6J3", Latitude = 46.3329, Longitude = -72.5453 },
            new Adresse { AdresseId = 43, NoCivique = "3434", Rue = "Boulevard des Récollets", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6T4", Latitude = 46.3470, Longitude = -72.5485 },
            new Adresse { AdresseId = 44, NoCivique = "3535", Rue = "Boulevard des Récollets", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6K7", Latitude = 46.3475, Longitude = -72.5471 },
            new Adresse { AdresseId = 45, NoCivique = "3636", Rue = "Boulevard des Chenaux", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6N7", Latitude = 46.3340, Longitude = -72.5404 },
            new Adresse { AdresseId = 46, NoCivique = "3737", Rue = "Boulevard des Récollets", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6S8", Latitude = 46.3406, Longitude = -72.5490 },
            new Adresse { AdresseId = 47, NoCivique = "3838", Rue = "Boulevard des Récollets", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6J6", Latitude = 46.3409, Longitude = -72.5483 },
            new Adresse { AdresseId = 48, NoCivique = "3939", Rue = "Boulevard du Saint-Maurice", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6N1", Latitude = 46.3393, Longitude = -72.5480 },
            new Adresse { AdresseId = 49, NoCivique = "4040", Rue = "Rue de la Commune", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6K8", Latitude = 46.3354, Longitude = -72.5416 },
            new Adresse { AdresseId = 50, NoCivique = "4141", Rue = "Boulevard des Chenaux", Ville = "Trois-Rivières", Province = 9, CodePostal = "G9A 6M8", Latitude = 46.3394, Longitude = -72.5409 }
        );

            // Seed Bornes
            // Liste d’IDs d’adresses pour pouvoir générer les bornes
            List<int> adresseIds = new List<int> {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50
            };

            Random rand = new Random();
            for (int i = 1; i <= 50; i++)
            {
                int userId = rand.Next(1, 3);

                // Pour pouvoir sélectionner une adresse aléatoirement et la retirer pour que 1 borne = 1 adresse
                int index = rand.Next(adresseIds.Count);
                int adresseId = adresseIds[index];
                adresseIds.RemoveAt(index);

                TypeConnecteur type = rand.Next(2) == 0 ? TypeConnecteur.NACS : TypeConnecteur.J1772;

                modelBuilder.Entity<Borne>().HasData(
                    new Borne
                    {
                        BorneId = i,
                        TypeConnecteur = type,
                        PuissanceKW = rand.Next(10, 101),
                        DateCreation = DateTime.Now,
                        AdresseId = adresseId,

                    }
                );
            }

          
            // Seed BorneUtilisateur
            var randNote = new Random();
            var userIds = new[] { "1", "2", "3", "4", "5" };
            int evaluationId = 1;
            var usedCombinations = new HashSet<string>(); // Для отслеживания уникальных комбинаций

            for (int borneId = 1; borneId <= 50; borneId++)
            {
                // Берем 3 случайных пользователя для каждой станции
                var selectedUserIds = userIds.OrderBy(u => Guid.NewGuid()).Take(3).ToList();

                foreach (var userId in selectedUserIds)
                {
                    // Создаем уникальный ключ для проверки дубликатов
                    string combinationKey = $"{borneId}-{userId}";

                    // Проверяем, что комбинация еще не использовалась
                    if (!usedCombinations.Contains(combinationKey))
                    {
                        usedCombinations.Add(combinationKey);

                        modelBuilder.Entity<BorneUtilisateur>().HasData(
                            new BorneUtilisateur
                            {
                                Id = evaluationId++,
                                UtilisateurId = userId,
                                BorneId = borneId,
                                Note = randNote.Next(1, 6),
                                Commentaire = $"Évaluation pour la borne {borneId} par utilisateur {userId}",
                                DateEvaluation = DateTime.Now.AddDays(-randNote.Next(1, 30)),
                                EstFavoris = randNote.Next(2) == 1,
                                DateAjoutFavori = randNote.Next(2) == 1 ? DateTime.Now.AddDays(-randNote.Next(1, 15)) : null
                            }
                        );
                    }
                }
            }
        }
    }
}