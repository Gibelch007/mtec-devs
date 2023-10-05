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
           //Criptografar a senha do IdentityUser
           foreach (var user in users)
           {
                PasswordHasher<IdentityUser> password = new();
                user.PasswordHash = password.HashPassword(user, "@Etec123");
           } 
           builder.Entity<IdentityUser>().HasData(users);

            //Cria o usuário
            List<Usuario> usuarios = new(){
                new Usuario() {
                    UserId = users[0].Id,
                    Nome = "Daniel Moura Pereira de Souza",
                    DataNascimento = DateTime.Parse("23/03/2007"),
                    Foto = "/img/usuarios/1.jpeg",
                    TipoDevId = 2
                }
            };
            builder.Entity<Usuario>().HasData(usuarios);

            //Definir o perfil do usuário criado
            List<IdentityUserRole<string>> userRoles = new(){
                new IdentityUserRole<string>() {
                    UserId = users[0].Id,
                    RoleId = perfis[0].Id
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
        }
    }
