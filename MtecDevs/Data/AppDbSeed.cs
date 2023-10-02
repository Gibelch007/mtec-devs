using Microsoft.EntityFrameworkCore;
using MtecDevs.Models;
using Microsoft.AspNetCore.Identity;

namespace MtecDevs.Data;

    public class AppDbSeed
    {
        public AppDbSeed(ModelBuilder builder)
        {
           
            #region Popular dados Tipo Dev
            List<TipoDev> tipoDevs = new() {
                new TipoDev() {
                    Id = 1,
                    Nome = "FullStack"
                },
                new TipoDev() {
                    Id = 2,
                    Nome = "FrontEnd"
                },
                new TipoDev() {
                    Id = 3,
                    Nome = "BackEnd"
                },
                new TipoDev() {
                    Id = 4,
                    Nome = "Design"
                },
                new TipoDev() {
                    Id = 5,
                    Nome = "Jogos"
                }
            };
            builder.Entity<TipoDev>().HasData(tipoDevs);
            #endregion

            #region Popular dados Perfis de Usuários
            List<IdentityRole> perfis = new() {
                new IdentityRole() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Moderador",
                    NormalizedName = "MODERADOR"
                },
                new IdentityRole() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuário",
                    NormalizedName = "USUÁRIO"
                }
            };
            builder.Entity<IdentityRole>().HasData(perfis);
            #endregion

            #region Popular Dados de Usuário
            List<IdentityUser> users = new() {
                new IdentityUser() {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "GalloJunior",
                    NormalizedUserName = "GALLOJUNIOR",
                    Email = "gallojunior@gmail.com",
                    NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }
            };
            builder.Entity<IdentityUser>().HasData(users);
            //Criptografar a senha do IdentityUser

            //Cria o usuário

            //Definir o perfil do usuário criado
            #endregion
        }
    }
