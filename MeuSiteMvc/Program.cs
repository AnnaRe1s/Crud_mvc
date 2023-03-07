using MeuSiteMvc.Data;
using MeuSiteMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddDbContext<ContextContacts>
            //    (options => options.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;"));

            builder.Services.AddDbContext<ContextContacts>
               (options => options.UseMySql("server=localhost;initial catalog=teste;Uid=root;Pwd=MySql4nn@!;", ServerVersion.Parse("8.0.32-mysql")));

            object value = builder.Services.AddSwaggerGen();



            var app = builder.Build();

            app.UseSwagger();





            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //add
            app.MapPost("Contacts", async (ContactsModel contacts, ContextContacts context) =>
            {
                context.Contacts.Add(contacts);
               return  await context.SaveChangesAsync();
            });

            //list
            app.MapPost("AllContacts", async (ContextContacts contact) =>
            {
               return await contact.Contacts.ToListAsync();


            });

            // get one

            app.MapGet("Contact/{id}", async (int id, ContextContacts contacts) =>
            {
                var contact = await contacts.Contacts.FirstOrDefaultAsync(app => app.Id == id);
                return contact;
                //contacts.Add(contact);
            });

            //delete
            app.MapDelete("Delete/{id}", async (int id, ContextContacts contact) =>
            {
                var deleteContact = await contact.Contacts.FirstOrDefaultAsync(app => app.Id == id);

                if (deleteContact != null)
                {
                    contact.Contacts.Remove(deleteContact);
                    await contact.SaveChangesAsync();

                }
            });

            app.UseSwaggerUI();
            app.Run();
        }
    }
}