﻿using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ELearning.Persistence
{
    public class ELearningInitializer
    {
        public static void Initialize(ELearningDbContext context)
        {
            var initializer = new ELearningInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(ELearningDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Subjects.Any())
            {
                return;
            }
            
            SeedSubject(context);

            SeedGroup(context);

            SeedUser(context);

            SeedSection(context);

            SeedExercise(context);

            SeedVariant(context);

            SeedAssignment(context);

            SeedEvaluation(context);
        }

        private void SeedSubject(ELearningDbContext context)
        {
            var subjects = new[]
            {
                new Subject { SubjectId = 1, Name = "Podstawy programowania", Abreviation = "PP" },
                new Subject { SubjectId = 2, Name = "Programowanie obiektowe", Abreviation = "PO" },
                new Subject { SubjectId = 3, Name = "Programowanie w środowisku sieciowym", Abreviation = "PWŚS" },
                new Subject { SubjectId = 4, Name = "Programowanie interfejsu użytkownika", Abreviation = "PIU" },
                new Subject { SubjectId = 5, Name = "Programowanie wieloplatformowe", Abreviation = "PW" },
                new Subject { SubjectId = 6, Name = "Grafika ruchoma", Abreviation = "GR" }
            };

            context.Subjects.AddRange(subjects);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Subjects ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Subjects OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedGroup(ELearningDbContext context)
        {
            var groups = new[]
            {
                new Group { GroupId = 1, SubjectId = 1, AcademicYear = 2018, Name = "PP2018/2019" },
                new Group { GroupId = 2, SubjectId = 2, AcademicYear = 2016, Name = "P02016/2017/1" },
                new Group { GroupId = 3, SubjectId = 2, AcademicYear = 2016, Name = "P02016/2017/2" },
                new Group { GroupId = 4, SubjectId = 3, AcademicYear = 2017, Name = "PWŚS2017/2018" },
                new Group { GroupId = 5, SubjectId = 4, AcademicYear = 2018, Name = "PIU2018/2019" },
                new Group { GroupId = 6, SubjectId = 5, AcademicYear = 2018, Name = "PW2018/2019" },
                new Group { GroupId = 7, SubjectId = 6, AcademicYear = 2018, Name = "GR2018/2019" }
            };

            context.Groups.AddRange(groups);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Groups ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Groups OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedUser(ELearningDbContext context)
        {
            var users = new[]
            {
                new User { UserId = 1, Name = "Admina", Surname = "Inez", Email = "admina.inez@student.polsl.pl", Login = "admin", Password = "admin", Role = Role.Admin },
                new User { UserId = 2, Name = "Studdent", Surname = "Dentest", Email = "studdent.dentest@student.polsl.pl", Login = "student", Password = "student", Role = Role.Student },
                new User { UserId = 3, Name = "Skipp", Surname = "Gerritzen", Email = "skipp.gerritzen@student.polsl.pl", Login = "skiger", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 4, Name = "Yelena", Surname = "Bohman", Email = "yelena.bohman@student.polsl.pl", Login = "yelboh", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 5, Name = "Fielding", Surname = "Rippingall", Email = "fielding.rippingall@student.polsl.pl", Login = "fierip", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 6, Name = "Bertrand", Surname = "Deboo", Email = "bertrand.deboo@student.polsl.pl", Login = "berdeb", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 7, Name = "Arabele", Surname = "Grouse", Email = "arabele.grouse@student.polsl.pl", Login = "aragro", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 8, Name = "Georgeanna", Surname = "Greve", Email = "georgeanna.greve@student.polsl.pl", Login = "geogre", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 9, Name = "Gilberto", Surname = "Jotcham", Email = "gilberto.jotcham@student.polsl.pl", Login = "giljot", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 10, Name = "Kimball", Surname = "Silcocks", Email = "kimball.silcocks@student.polsl.pl", Login = "kimsil", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 11, Name = "Abbye", Surname = "Poacher", Email = "abbye.poacher@student.polsl.pl", Login = "abbpoa", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 12, Name = "Reinold", Surname = "Topper", Email = "reinold.topper@student.polsl.pl", Login = "reitop", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 13, Name = "Vinny", Surname = "Dunbleton", Email = "vinny.dunbleton@student.polsl.pl", Login = "vindub", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 14, Name = "Bearnard", Surname = "Sekulla", Email = "bearnard.sekulla@student.polsl.pl", Login = "beasek", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 15, Name = "Ware", Surname = "Knuckles", Email = "ware.knuckles@student.polsl.pl", Login = "warknu", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 16, Name = "Lorita", Surname = "Whitters", Email = "lorita.whitters@student.polsl.pl", Login = "lorwhi", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 17, Name = "Melinda", Surname = "Moreinis", Email = "melinda.moreinis@student.polsl.pl", Login = "melmor", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 18, Name = "Joceline", Surname = "Clemes", Email = "joceline.clemes@student.polsl.pl", Login = "joccle", Password = "0qb0XmNhR", Role = Role.Student },
                new User { UserId = 19, Name = "Keen", Surname = "Taylder", Email = "keen.taylder@student.polsl.pl", Login = "keetay", Password = "0qb0XmNhR", Role = Role.Admin },
                new User { UserId = 20, Name = "Gardy", Surname = "Dobrowlski", Email = "gardy.dobrowlski@student.polsl.pl", Login = "gardob", Password = "0qb0XmNhR", Role = Role.Student },
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            foreach (var user in users)
            {
                var hashedPassword = passwordHasher.HashPassword(user, user.Password);
                user.Password = hashedPassword;
            }

            context.Users.AddRange(users);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Users ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Users OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedSection(ELearningDbContext context)
        {
            var sections = new[]
            {
                new Section { SectionId = 1, UserId = 2, GroupId = 1, Number = 1 },
                new Section { SectionId = 2, UserId = 2, GroupId = 5, Number = 10 },
                new Section { SectionId = 3, UserId = 3, GroupId = 1, Number = 2 },
                new Section { SectionId = 4, UserId = 4, GroupId = 1, Number = 3 },
                new Section { SectionId = 5, UserId = 5, GroupId = 2, Number = 4 },
                new Section { SectionId = 6, UserId = 5, GroupId = 3, Number = 9 },
                new Section { SectionId = 7, UserId = 6, GroupId = 1, Number = 4 },
                new Section { SectionId = 8, UserId = 7, GroupId = 1, Number = 5 },
                new Section { SectionId = 9, UserId = 8, GroupId = 1, Number = 6 },
                new Section { SectionId = 10, UserId = 9, GroupId = 1, Number = 7 },
                new Section { SectionId = 11, UserId = 10, GroupId = 1, Number = 8 },
                new Section { SectionId = 12, UserId = 11, GroupId = 1, Number = 9 },
                new Section { SectionId = 13, UserId = 12, GroupId = 1, Number = 10 },
                new Section { SectionId = 14, UserId = 13, GroupId = 2, Number = 1 },
                new Section { SectionId = 15, UserId = 14, GroupId = 2, Number = 2 },
                new Section { SectionId = 16, UserId = 15, GroupId = 2, Number = 3 },
                new Section { SectionId = 17, UserId = 16, GroupId = 3, Number = 1 },
                new Section { SectionId = 18, UserId = 17, GroupId = 3, Number = 2 },
                new Section { SectionId = 19, UserId = 18, GroupId = 3, Number = 3 },
                new Section { SectionId = 20, UserId = 20, GroupId = 3, Number = 4 },
                new Section { SectionId = 21, UserId = 3, GroupId = 5, Number = 1 },
                new Section { SectionId = 22, UserId = 4, GroupId = 5, Number = 2 },
                new Section { SectionId = 23, UserId = 6, GroupId = 5, Number = 3 },
                new Section { SectionId = 24, UserId = 7, GroupId = 5, Number = 6 },
                new Section { SectionId = 25, UserId = 8, GroupId = 5, Number = 4 },
                new Section { SectionId = 26, UserId = 9, GroupId = 5, Number = 5 },
                new Section { SectionId = 27, UserId = 10, GroupId = 5, Number = 7 },
                new Section { SectionId = 28, UserId = 11, GroupId = 5, Number = 8 },
                new Section { SectionId = 29, UserId = 12, GroupId = 5, Number = 9 },
                new Section { SectionId = 30, UserId = 3, GroupId = 6, Number = 1 },
                new Section { SectionId = 31, UserId = 2, GroupId = 6, Number = 2 },
                new Section { SectionId = 32, UserId = 4, GroupId = 6, Number = 6 },
                new Section { SectionId = 33, UserId = 6, GroupId = 6, Number = 4 },
                new Section { SectionId = 34, UserId = 7, GroupId = 6, Number = 8 },
                new Section { SectionId = 35, UserId = 8, GroupId = 6, Number = 7 },
                new Section { SectionId = 36, UserId = 9, GroupId = 6, Number = 5 },
                new Section { SectionId = 37, UserId = 10, GroupId = 6, Number = 9 },
                new Section { SectionId = 38, UserId = 11, GroupId = 6, Number = 10 },
                new Section { SectionId = 39, UserId = 12, GroupId = 6, Number = 3 },
            };

            context.Sections.AddRange(sections);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Sections ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Sections OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedExercise(ELearningDbContext context)
        {
            var exercises = new[]
            {
                new Exercise { ExerciseId = 1, Title = "Zmienne", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tortor ex, tincidunt a tempor nec, scelerisque non est. Etiam tortor massa, aliquam id efficitur quis, vestibulum nec augue. Etiam sit amet arcu in dui scelerisque ornare ac vitae nunc. Donec sed sapien at arcu congue accumsan at at dolor. Nunc quis dolor eu ligula posuere placerat eget at lorem. Donec erat erat, cursus ut tortor eget, euismod interdum dui. Proin tincidunt purus a felis varius vehicula. Nulla facilisi. Cras ultricies aliquam malesuada. Morbi egestas, eros nec placerat commodo, metus quam blandit ligula, sit amet luctus tortor tellus vel augue. Maecenas eget lectus felis. Donec rhoncus in felis ac sagittis. Nunc sit amet nunc quis metus gravida molestie eget at nisi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas." },
                new Exercise { ExerciseId = 6, Title = "Pętle While/For", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tortor ex, tincidunt a tempor nec, scelerisque non est. Etiam tortor massa, aliquam id efficitur quis, vestibulum nec augue. Etiam sit amet arcu in dui scelerisque ornare ac vitae nunc. Donec sed sapien at arcu congue accumsan at at dolor. Nunc quis dolor eu ligula posuere placerat eget at lorem. Donec erat erat, cursus ut tortor eget, euismod interdum dui. Proin tincidunt purus a felis varius vehicula. Nulla facilisi. Cras ultricies aliquam malesuada. Morbi egestas, eros nec placerat commodo, metus quam blandit ligula, sit amet luctus tortor tellus vel augue. Maecenas eget lectus felis. Donec rhoncus in felis ac sagittis. Nunc sit amet nunc quis metus gravida molestie eget at nisi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas." },
                new Exercise { ExerciseId = 8, Title = "Instrukcje warunkowa", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum nunc est, maximus eget libero quis, finibus tempor urna. Praesent molestie, ante non egestas fermentum, mauris massa gravida lorem, tincidunt ornare." },
                new Exercise { ExerciseId = 4, Title = "Dziedziczenie", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rutrum arcu felis, et consequat lorem molestie in. Vestibulum mollis hendrerit nunc, id eleifend eros congue sit amet. Praesent porttitor ornare tristique. Sed consectetur fermentum purus a interdum. Sed massa quam, volutpat eu posuere et, tincidunt." },
                new Exercise { ExerciseId = 5, Title = "Hermetyzacja", Description = "Morbi hendrerit nibh eu lectus aliquam fringilla. Integer ac consectetur nibh. Sed felis ex, sodales eget molestie interdum, vestibulum non augue. Nullam non cursus eros. Sed eleifend fermentum aliquet. Sed vitae condimentum lorem. Proin egestas ligula a massa posuere varius. Quisque tempus, tortor vitae interdum." },
                new Exercise { ExerciseId = 2, Title = "Enkapsulacja", Description = "Suspendisse posuere pulvinar lorem, eget pulvinar ligula pellentesque sed. Sed felis justo, volutpat eu justo." },
                new Exercise { ExerciseId = 7, Title = "Przeciążania" },
                new Exercise { ExerciseId = 3, Title = "Operatory" }
            };

            context.Exercises.AddRange(exercises);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Exercises ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Exercises OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedVariant(ELearningDbContext context)
        {
            var variants = new[]
            {
                new Variant { VariantId = 1, ExerciseId = 1, Number = 1, Content = "Maecenas neque ligula, viverra quis augue non, pulvinar elementum nibh. Maecenas suscipit mollis tristique. Praesent suscipit scelerisque dolor placerat venenatis. Donec ac molestie mauris, et consectetur urna. Suspendisse augue libero, semper at finibus at, placerat at leo. Fusce rutrum felis ultrices egestas posuere. Sed pharetra, purus quis tristique dignissim, odio nunc molestie ex, non venenatis elit erat aliquam turpis. In hac habitasse platea dictumst. Nunc nec eros sapien. Donec rutrum, ligula consectetur maximus pellentesque, ante nunc blandit enim, ac aliquam sapien lectus quis lorem. Nam eu libero ac tellus cursus elementum eu ac metus. Curabitur ullamcorper commodo finibus.\n\nPellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Phasellus a est quis mi rhoncus lobortis vitae et odio. Aliquam eget massa sed enim interdum sollicitudin vel a erat. In rutrum pharetra nisl, nec consectetur lacus mattis et. Quisque commodo justo sed semper cursus. Maecenas tempus porta dapibus. Mauris semper nec erat nec dignissim. Vivamus dignissim finibus massa non commodo. Nulla eu viverra felis. Nunc congue lectus diam, in malesuada leo facilisis ac.\n\nMaecenas pharetra ex sapien, ut volutpat tortor pretium at. Fusce eu ex rhoncus nisl facilisis aliquet. Aliquam sit amet aliquam diam. Maecenas gravida sapien lectus, at suscipit lorem ultricies ut. Suspendisse vestibulum lobortis scelerisque. Phasellus mauris purus, dictum sed rhoncus a, tincidunt in velit. Duis vehicula accumsan cursus. Maecenas bibendum metus vehicula lacus dignissim tincidunt. Praesent eget turpis dignissim, placerat urna accumsan, aliquet elit. Donec placerat libero ut tortor tincidunt, vitae molestie massa convallis.\n\nAliquam aliquam massa quis ex porta dapibus. Ut euismod urna suscipit dui finibus posuere. Maecenas sed varius nisl. Aenean ac fringilla justo. Curabitur felis odio, sagittis id iaculis a, dignissim in libero. Nulla neque turpis, porta eget metus ac, sollicitudin euismod purus. Praesent luctus mi a vulputate aliquam. Nunc non ligula vel sem varius pulvinar id sit amet dolor. Aliquam bibendum nibh accumsan neque interdum, nec vehicula lectus dignissim. Suspendisse leo nisi, convallis quis nunc eget, fringilla dictum tellus. Nulla facilisi. Nulla et diam nec est ornare fermentum. Proin placerat ultrices diam id porta. Quisque varius accumsan consequat. Maecenas mattis tristique purus. Maecenas lacinia finibus ligula, eget consequat ligula dictum eu.\n\nSuspendisse gravida tristique finibus. Morbi nec eros euismod, sollicitudin quam nec, consequat orci. Sed tempus cursus massa, ac semper nisi sagittis et. Donec eleifend nec ipsum sit amet vulputate. Suspendisse potenti. Etiam tincidunt orci in erat tempus auctor. Sed nec semper neque, quis viverra ipsum. Aenean accumsan, sapien sodales eleifend ultrices, turpis sapien laoreet justo, sit amet egestas dolor nunc a arcu. Vivamus nibh risus, ultrices vitae mi vel, pulvinar consectetur velit. Curabitur commodo pellentesque vulputate. Pellentesque nec pellentesque turpis, eu malesuada enim. In ut ullamcorper urna. Praesent vitae mollis nisi.\n\nMorbi a magna commodo, hendrerit nisl quis, imperdiet nulla. Nulla placerat lectus eu eros laoreet, ut pharetra nulla condimentum. Suspendisse eget commodo nunc, sed tristique diam. Sed fermentum felis sed velit pulvinar ullamcorper. Praesent elementum velit a justo scelerisque, ac tristique elit vehicula. In hac habitasse platea dictumst. Cras aliquet justo non libero egestas, sit amet sodales massa vestibulum. Phasellus ultrices lectus eu facilisis posuere. Integer maximus consequat dictum. Nullam pellentesque, nibh at faucibus blandit, justo dolor laoreet odio, a dapibus massa arcu eget leo.\n\nSed efficitur pellentesque nibh eu sagittis. Ut pellentesque sit amet mi vel tincidunt. Proin laoreet ligula in lectus suscipit tempor. Vestibulum ornare erat quis justo congue, vel porta tortor consequat. Curabitur quis leo at elit egestas dapibus metus.", CorrectOutput = "Aliquam vel euismod sem. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque urna purus, porta sed quam id, iaculis sodales massa. Proin et varius ex. Donec accumsan ultrices nulla, eget consequat magna fringilla ac. Integer nec risus a lectus tristique tempus malesuada nec neque. Nam sodales mollis metus eu egestas. Vivamus et nunc ultrices, feugiat tellus convallis, mollis ligula. Praesent dapibus, elit et consequat eleifend, turpis nunc ultricies ligula, a pretium mauris metus eu sem. Ut ultrices lorem lorem, sit amet tincidunt neque cursus a. Maecenas odio erat, commodo nec leo ut, molestie hendrerit ipsum. Sed ullamcorper nunc ac ornare venenatis. Fusce volutpat sit amet risus sit amet cursus. Morbi vitae nisi augue.", TestingCode = "Maecenas eu nunc sit amet lorem ullamcorper cursus quis a diam. Aliquam erat volutpat. Aliquam ut arcu efficitur, tristique elit non, pulvinar ante. Nulla placerat lacus turpis. Vivamus ac vulputate eros, et pharetra mi. Cras vel efficitur justo. Nunc in tempus risus, a molestie est. Maecenas vitae scelerisque metus. Vestibulum." },
                new Variant { VariantId = 2, ExerciseId = 1, Number = 2, Content = "Phasellus pellentesque, arcu et tincidunt hendrerit, elit risus mollis diam, sit amet tincidunt tellus turpis vel erat. Nullam nec feugiat sem. Nunc sit amet eros rutrum, iaculis mi et, gravida velit. Nullam in velit massa. Vestibulum vel purus tincidunt justo sodales fringilla et eu libero. Fusce vehicula scelerisque lectus non aliquet. Morbi tempus egestas est quis semper. Morbi commodo pulvinar sapien, at fermentum augue consectetur et. Donec vel neque vel eros pellentesque ullamcorper ac non metus. Quisque sed velit ut lorem pellentesque rhoncus.\n\nCurabitur faucibus sapien feugiat, viverra orci nec, varius purus. Proin blandit ac mauris sed ultrices. Ut aliquet sem nec lacus aliquam, ultricies elementum orci euismod. Fusce sit amet dictum est. Etiam dignissim, massa quis vulputate efficitur, magna leo pretium dolor, at ullamcorper justo massa non libero. Vestibulum augue nunc, elementum non risus eu, consectetur hendrerit elit. Nullam id placerat ante. Nunc posuere nisl ut faucibus fermentum. Donec consectetur libero eu facilisis pharetra. Donec aliquam elit arcu, ut fringilla augue ornare eget. Pellentesque sodales tincidunt rhoncus. Phasellus ac placerat dui. Pellentesque pulvinar augue in leo laoreet, a facilisis purus congue.\n\nPraesent sit amet sagittis nisi, id tempus ante. Aliquam tincidunt diam eu dapibus commodo. Suspendisse quam sem, eleifend at metus id, volutpat venenatis ipsum. Nullam ut accumsan urna, ut venenatis magna. Sed id lacus a lorem tempor interdum. Nulla fringilla rhoncus molestie. Vestibulum lorem leo, dictum vel tempor sit amet, cursus sed odio. Aliquam viverra vehicula nisi eget gravida. Cras lobortis pretium lorem, sit amet varius felis mollis nec. Donec elementum tempor consectetur.\n\nNam ullamcorper mollis augue, vel facilisis neque ornare nec. In hac habitasse platea dictumst. Nunc vehicula vitae risus sit amet ultricies. Proin vulputate ipsum consequat odio rhoncus, tempus mattis nulla consequat. Sed a risus arcu. Proin iaculis ornare lectus nec congue. Curabitur vitae tempor nisl. Nunc finibus eros in ipsum aliquam, quis congue turpis eleifend. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Praesent sit amet bibendum nunc, ut ullamcorper augue. Suspendisse finibus mattis ipsum eget ultrices.\n\nNam non enim in purus rhoncus auctor. Pellentesque pharetra interdum erat ac mollis. Suspendisse accumsan, diam id lacinia tincidunt, tellus ligula tempus urna, id rhoncus elit urna non sem. Nulla rutrum lorem id quam semper, vitae placerat lorem porta. Curabitur rhoncus nisl et quam maximus, at maximus eros vehicula. Aliquam suscipit et eros non hendrerit. Sed justo est, ornare at euismod ut, euismod ut sapien. Donec vehicula eu massa ut vestibulum. Proin lorem turpis, dapibus non diam nec, interdum egestas libero. Etiam tincidunt nisi est, ac pulvinar odio ultrices id. Nam gravida ligula sed neque ultricies pellentesque. Nam fermentum est sed mattis dignissim. Donec sagittis lorem sit amet elit semper, nec pharetra quam sodales. Curabitur eu auctor libero. Integer in laoreet nunc, vel dapibus quam.\n\nPraesent faucibus dolor ut purus facilisis, eu maximus urna condimentum. Cras eleifend mauris vel accumsan blandit. Suspendisse vitae justo ullamcorper, lacinia erat condimentum, consequat felis. Aliquam quis fringilla leo. Donec tempor sem nisl, ut porttitor ipsum venenatis ut. Duis ac nibh pretium, fringilla magna a, sagittis magna. Integer convallis elit sit amet porta viverra. Suspendisse malesuada a odio sit amet placerat.\n\nIn imperdiet odio sit amet metus interdum ornare. Integer vitae aliquam nunc, ut placerat massa. Vivamus at eros quam. Cras rutrum congue metus ac maximus. Nulla a metus at nisi rutrum consectetur ut sit amet augue. Aliquam id nunc quis dolor sodales ornare. In elementum sagittis volutpat. Morbi tincidunt, arcu tristique aliquet pretium, mauris velit aliquet nulla, sit amet vehicula erat nisi ac enim. Curabitur a nibh metus. Ut dignissim sagittis rhoncus. Nunc in luctus eros. Ut aliquam nisi vel sem cursus, ac convallis quam finibus. Nulla nisl erat, consectetur dapibus nisi id, eleifend dictum felis. Morbi rutrum turpis vel orci euismod dignissim.\n\nFusce facilisis tincidunt lectus quis iaculis. Phasellus vulputate elit sit amet turpis luctus dignissim. Vestibulum finibus tortor sit amet lorem tincidunt suscipit. Suspendisse tristique dapibus lacus, eu ullamcorper libero mollis ut. Aliquam neque est, pharetra ut hendrerit id, aliquam a mi. Sed molestie vulputate mi, sed bibendum neque rutrum aliquam. Pellentesque fermentum volutpat tortor, sit amet mollis turpis pellentesque ut. Nam sollicitudin ut neque sit amet sagittis. Proin bibendum tempus accumsan. Aenean iaculis venenatis justo, et dignissim velit imperdiet vitae. Etiam ac erat a diam efficitur euismod et vel nisi.\n\nSed luctus, purus vel sagittis mattis, ipsum quam commodo elit, eu eleifend elit mi sed metus. Curabitur ultricies nulla vitae tellus sodales tristique cras amet." },
                new Variant { VariantId = 3, ExerciseId = 1, Number = 3, Content = "Phasellus pellentesque, arcu et tincidunt hendrerit, elit risus mollis diam, sit amet tincidunt tellus turpis vel erat. Nullam nec feugiat sem. Nunc sit amet eros rutrum, iaculis mi et, gravida velit. Nullam in velit massa. Vestibulum vel purus tincidunt justo sodales fringilla et eu libero. Fusce vehicula scelerisque lectus non aliquet. Morbi tempus egestas est quis semper. Morbi commodo pulvinar sapien, at fermentum augue consectetur et. Donec vel neque vel eros pellentesque ullamcorper ac non metus. Quisque sed velit ut lorem pellentesque rhoncus.\n\nCurabitur faucibus sapien feugiat, viverra orci nec, varius purus. Proin blandit ac mauris sed ultrices. Ut aliquet sem nec lacus aliquam, ultricies elementum orci euismod. Fusce sit amet dictum est. Etiam dignissim, massa quis vulputate efficitur, magna leo pretium dolor, at ullamcorper justo massa non libero. Vestibulum augue nunc, elementum non risus eu, consectetur hendrerit elit. Nullam id placerat ante. Nunc posuere nisl ut faucibus fermentum. Donec consectetur libero eu facilisis pharetra. Donec aliquam elit arcu, ut fringilla augue ornare eget. Pellentesque sodales tincidunt rhoncus. Phasellus ac placerat dui. Pellentesque pulvinar augue in leo laoreet, a facilisis purus congue.\n\nPraesent sit amet sagittis nisi, id tempus ante. Aliquam tincidunt diam eu dapibus commodo. Suspendisse quam sem, eleifend at metus id, volutpat venenatis ipsum. Nullam ut accumsan urna, ut venenatis magna. Sed id lacus a lorem tempor interdum. Nulla fringilla rhoncus molestie. Vestibulum lorem leo, dictum vel tempor sit amet, cursus sed odio. Aliquam viverra vehicula nisi eget gravida. Cras lobortis pretium lorem, sit amet varius felis mollis nec. Donec elementum tempor consectetur.\n\nNam ullamcorper mollis augue, vel facilisis neque ornare nec. In hac habitasse platea dictumst. Nunc vehicula vitae risus sit amet ultricies. Proin vulputate ipsum consequat odio rhoncus, tempus mattis nulla consequat. Sed a risus arcu. Proin iaculis ornare lectus nec congue. Curabitur vitae tempor nisl. Nunc finibus eros in ipsum aliquam, quis congue turpis eleifend. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Praesent sit amet bibendum nunc, ut ullamcorper augue. Suspendisse finibus mattis ipsum eget ultrices.\n\nNam non enim in purus rhoncus auctor. Pellentesque pharetra interdum erat ac mollis. Suspendisse accumsan, diam id lacinia tincidunt, tellus ligula tempus urna, id rhoncus elit urna non sem. Nulla rutrum lorem id quam semper, vitae placerat lorem porta. Curabitur rhoncus nisl et quam maximus, at maximus eros vehicula. Aliquam suscipit et eros non hendrerit. Sed justo est, ornare at euismod ut, euismod ut sapien. Donec vehicula eu massa ut vestibulum. Proin lorem turpis, dapibus non diam nec, interdum egestas libero. Etiam tincidunt nisi est, ac pulvinar odio ultrices id. Nam gravida ligula sed neque ultricies pellentesque. Nam fermentum est sed mattis dignissim. Donec sagittis lorem sit amet elit semper, nec pharetra quam sodales. Curabitur eu auctor libero. Integer in laoreet nunc, vel dapibus quam.\n\nPraesent faucibus dolor ut purus facilisis, eu maximus urna condimentum. Cras eleifend mauris vel accumsan blandit. Suspendisse vitae justo ullamcorper, lacinia erat condimentum, consequat felis. Aliquam quis fringilla leo. Donec tempor sem nisl, ut porttitor ipsum venenatis ut. Duis ac nibh pretium, fringilla magna a, sagittis magna. Integer convallis elit sit amet porta viverra. Suspendisse malesuada a odio sit amet placerat.\n\nIn imperdiet odio sit amet metus interdum ornare. Integer vitae aliquam nunc, ut placerat massa. Vivamus at eros quam. Cras rutrum congue metus ac maximus. Nulla a metus at nisi rutrum consectetur ut sit amet augue. Aliquam id nunc quis dolor sodales ornare. In elementum sagittis volutpat. Morbi tincidunt, arcu tristique aliquet pretium, mauris velit aliquet nulla, sit amet vehicula erat nisi ac enim. Curabitur a nibh metus. Ut dignissim sagittis rhoncus. Nunc in luctus eros. Ut aliquam nisi vel sem cursus, ac convallis quam finibus. Nulla nisl erat, consectetur dapibus nisi id, eleifend dictum felis. Morbi rutrum turpis vel orci euismod dignissim.\n\nFusce facilisis tincidunt lectus quis iaculis. Phasellus vulputate elit sit amet turpis luctus dignissim. Vestibulum finibus tortor sit amet lorem tincidunt suscipit. Suspendisse tristique dapibus lacus, eu ullamcorper libero mollis ut. Aliquam neque est, pharetra ut hendrerit id, aliquam a mi. Sed molestie vulputate mi, sed bibendum neque rutrum aliquam. Pellentesque fermentum volutpat tortor, sit amet mollis turpis pellentesque ut. Nam sollicitudin ut neque sit amet sagittis. Proin bibendum tempus accumsan. Aenean iaculis venenatis justo, et dignissim velit imperdiet vitae. Etiam ac erat a diam efficitur euismod et vel nisi.\n\nSed luctus, purus vel sagittis mattis, ipsum quam commodo elit, eu eleifend elit mi sed metus. Curabitur ultricies nulla vitae tellus sodales tristique cras amet." },
            };

            context.Variants.AddRange(variants);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Variants ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Variants OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedAssignment(ELearningDbContext context)
        {
            var assignments = new[]
            {
                new Assignment { AssignmentId = 1, SectionId = 1, VariantId = 1, Date = DateTime.Parse("2018-12-04") },
                new Assignment { AssignmentId = 2, SectionId = 1, VariantId = 1, Date = DateTime.Parse("2018-11-27"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", FinalGrade = 10 },
                new Assignment { AssignmentId = 3, SectionId = 1, VariantId = 1, Date = DateTime.Parse("2018-11-20") },
                new Assignment { AssignmentId = 4, SectionId = 2, VariantId = 2, Date = DateTime.Parse("2018-11-20"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci." },
                new Assignment { AssignmentId = 5, SectionId = 3, VariantId = 3, Date = DateTime.Parse("2018-11-20"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci." },
                new Assignment { AssignmentId = 6, SectionId = 4, VariantId = 2, Date = DateTime.Parse("2018-11-20"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci." },
                new Assignment { AssignmentId = 7, SectionId = 5, VariantId = 3, Date = DateTime.Parse("2018-11-20"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci." },
                new Assignment { AssignmentId = 8, SectionId = 6, VariantId = 1, Date = DateTime.Parse("2018-11-20"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci." },
                new Assignment { AssignmentId = 9, SectionId = 7, VariantId = 2, Date = DateTime.Parse("2018-11-20"), Solution = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci.", Output = "Sed hendrerit ex a augue congue accumsan. Aliquam ac viverra arcu, condimentum mollis nibh. Etiam elementum neque sed velit tincidunt accumsan. Donec dapibus tincidunt dolor. Sed elementum condimentum nibh non fringilla. Sed non eleifend velit. Nunc sit amet sem vulputate, malesuada felis nec, fringilla nibh. Pellentesque vitae vulputate ligula. Sed lobortis ligula ut diam vestibulum, eget porttitor massa dapibus. Sed dictum vulputate malesuada. Fusce eu elit consequat, finibus leo et, vestibulum nulla. Phasellus leo ipsum, porta vitae bibendum quis, aliquet eget magna.\n\nDonec viverra ornare nibh in suscipit. Ut malesuada tempus erat, non consequat neque feugiat a. Donec fringilla velit et libero commodo lacinia. Aliquam ornare blandit sapien, ut vestibulum lacus ultricies in. Sed arcu orci, feugiat sit amet tempus et, sagittis eu lectus. Sed fringilla diam luctus, euismod nulla quis, pulvinar eros. Mauris semper, dui ut cursus porta, ligula lorem ullamcorper orci, a cursus nulla magna posuere nunc. Phasellus non fermentum ligula. Curabitur lorem quam, bibendum quis justo sit amet, lobortis convallis nisl. Donec vitae nulla lectus. Vestibulum nec vulputate ante.\n\nQuisque a dolor iaculis, consequat ex ut, hendrerit leo. In non sapien eget velit sollicitudin convallis et in purus. Nam at placerat justo. Etiam ut imperdiet turpis. Maecenas suscipit, dui eget varius vehicula, ipsum augue auctor diam, ac ornare dui felis ac tortor. Nullam tincidunt massa sit amet nisi mattis, et auctor arcu dignissim. Vivamus condimentum venenatis ligula, vel accumsan lacus laoreet quis. Suspendisse auctor lectus non odio faucibus venenatis. Phasellus aliquam lobortis accumsan. Cras metus erat, cursus ac lacus ut, hendrerit efficitur quam. Nam sit amet sodales tellus. Nulla vel dictum nisl, feugiat faucibus orci." },
                new Assignment { AssignmentId = 10, SectionId = 8, VariantId = 3, Date = DateTime.Parse("2018-11-20") },
            };

            context.Assignments.AddRange(assignments);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Assignments ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Assignments OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private void SeedEvaluation(ELearningDbContext context)
        {
            var evaluations = new[]
            {
                new Evaluation { EvaluationId = 1, AssignmentId = 4, SectionId = 3, Grade = 5 },
                new Evaluation { EvaluationId = 2, AssignmentId = 4, SectionId = 4, Grade = 8 },
                new Evaluation { EvaluationId = 3, AssignmentId = 4, SectionId = 5, Grade = 5 },
                new Evaluation { EvaluationId = 4, AssignmentId = 4, SectionId = 6, Grade = 4 },
                new Evaluation { EvaluationId = 5, AssignmentId = 4, SectionId = 7, Grade = 9 },
                new Evaluation { EvaluationId = 6, AssignmentId = 5, SectionId = 2, Grade = 4 },
                new Evaluation { EvaluationId = 7, AssignmentId = 5, SectionId = 4, Grade = 7 },
                new Evaluation { EvaluationId = 8, AssignmentId = 5, SectionId = 5, Grade = 2 },
                new Evaluation { EvaluationId = 9, AssignmentId = 5, SectionId = 6, Grade = 4 },
                new Evaluation { EvaluationId = 10, AssignmentId = 5, SectionId = 7, Grade = 3 },
                new Evaluation { EvaluationId = 11, AssignmentId = 6, SectionId = 2, Grade = 6 },
                new Evaluation { EvaluationId = 12, AssignmentId = 6, SectionId = 3, Grade = 7 },
                new Evaluation { EvaluationId = 13, AssignmentId = 6, SectionId = 5, Grade = 4 },
                new Evaluation { EvaluationId = 14, AssignmentId = 6, SectionId = 6, Grade = 8 },
                new Evaluation { EvaluationId = 15, AssignmentId = 6, SectionId = 7, Grade = 9 },
                new Evaluation { EvaluationId = 16, AssignmentId = 7, SectionId = 2, Grade = 6 },
                new Evaluation { EvaluationId = 17, AssignmentId = 7, SectionId = 3, Grade = 7 },
                new Evaluation { EvaluationId = 18, AssignmentId = 7, SectionId = 4, Grade = 4 },
                new Evaluation { EvaluationId = 19, AssignmentId = 7, SectionId = 6, Grade = 8 },
                new Evaluation { EvaluationId = 20, AssignmentId = 7, SectionId = 7, Grade = 9 },
                new Evaluation { EvaluationId = 21, AssignmentId = 8, SectionId = 2, Grade = 6 },
                new Evaluation { EvaluationId = 22, AssignmentId = 8, SectionId = 3, Grade = 7 },
                new Evaluation { EvaluationId = 23, AssignmentId = 8, SectionId = 4, Grade = 4 },
                new Evaluation { EvaluationId = 24, AssignmentId = 8, SectionId = 5, Grade = 8 },
                new Evaluation { EvaluationId = 25, AssignmentId = 8, SectionId = 7, Grade = 9 },
                new Evaluation { EvaluationId = 26, AssignmentId = 9, SectionId = 2, Grade = 6 },
                new Evaluation { EvaluationId = 27, AssignmentId = 9, SectionId = 3, Grade = 7 },
                new Evaluation { EvaluationId = 28, AssignmentId = 9, SectionId = 4, Grade = 4 },
                new Evaluation { EvaluationId = 29, AssignmentId = 9, SectionId = 5, Grade = 8 },
                new Evaluation { EvaluationId = 30, AssignmentId = 9, SectionId = 6, Grade = 9 },
            };

            context.Evaluations.AddRange(evaluations);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Evaluations ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Evaluations OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}
