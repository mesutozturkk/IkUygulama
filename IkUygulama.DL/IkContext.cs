namespace IkUygulama.DL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using static IkUygulama.ENT.Entities;

    public class IkContext : DbContext
    {
        // Your context has been configured to use a 'IkContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IkUygulama.DL.IkContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'IkContext' 
        // connection string in the application configuration file.
        public IkContext()
            : base("Baglanti")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }
        public virtual DbSet<Egitim> Egitim { get; set; }
        public virtual DbSet<Il> Il { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<Bolum> Bolum { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}