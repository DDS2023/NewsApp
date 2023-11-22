using Microsoft.EntityFrameworkCore;
using NewsApp.Alerts;
using NewsApp.BusquedaNoticia;
using NewsApp.List;
using NewsApp.Newss;
using NewsApp.RelationNewThemes;
using NewsApp.Searches;
using NewsApp.Themes;
using NewsApp.Users;
using Scriban.Runtime.Accessors;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace NewsApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class NewsAppDbContext :
    AbpDbContext<NewsAppDbContext>,
    IIdentityDbContext,                      
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<ApplicationUser> Usuario { get; set; } 
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region Dbset Entidades de dominio

    public DbSet<Theme> Themes { get; set; }

    public DbSet<Alert> Alerts { get; set; }
    public DbSet<New> News { get; set; }
    public DbSet<Search> Searches { get; set; }
    public DbSet<SearchNews> SearchNews { get; set; }

    public DbSet<Lista> Lists { get; set; }

    #endregion

    public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(NewsAppConsts.DbTablePrefix + "YourEntities", NewsAppConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    b.xxxx.HasMaxLength(128)        Estamos diciendo que es requido es decir que no puede ser nula y tiene un largo maximo de 128
        //    //...
        //});



        # region Entidad Theme
        builder.Entity<Theme>(b =>  /* Si queremos definir a mas grado de detalle el mapeo entre lo que es la informacion de la entidad con lo que
        //va a persistir en la base de datos, se define aca */
        {
            b.ToTable(NewsAppConsts.DbTablePrefix + "Themes", NewsAppConsts.DbSchema);//aca definimos que la tabla tiene un prefijo que es app para diferenciar las tablas de la aplicacion con las tablas del framework
            b.ConfigureByConvention(); //se configura por convencion.
            b.Property(x => x.Etiqueta).IsRequired();
            b.Property(x => x.Descripcion).HasMaxLength(300);

        });

        #endregion

        #region Entidad New
        builder.Entity<New>(b =>
        {
            b.ToTable(NewsAppConsts.DbTablePrefix + "News", NewsAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Titular).IsRequired().HasMaxLength(128);
            b.Property(x => x.Cuerpo).IsRequired();
            b.Property(x => x.Idioma).IsRequired().HasMaxLength(10);
            b.Property(x => x.Fecha).IsRequired().HasMaxLength(20);
        });

        //Relacion con tema
        builder.Entity<New>()
               .HasOne<Theme>(sc => sc.Tema)
               .WithMany(s => s.Noticias)
               .HasForeignKey(sc => sc.TemaId);

        //Relacion con lista
        builder.Entity<New>()
               .HasOne<Lista>(sc => sc.Lista)
               .WithMany(s => s.ListaNoticias)
               .HasForeignKey(sc => sc.ListaId);

        //Relacion con ApiNews

        #endregion

        /*
                #region Entidad NewThemes       REPRESENTA RELACION MUCHOS A MUCHOS ENTRE TEMA Y NOTICIAS, POR EL MOMENTO QUEDA 1 A *

                //Atributos NewThemes
                builder.Entity<NewThemes>().HasKey(sc => new { sc.NoticiaId, sc.TemaId });

                //Relacion NewThemes con New
                builder.Entity<NewThemes>()
                       .HasOne<New>(sc => sc.Noticia)
                       .WithMany(s => s.NoticiaTemas)
                       .HasForeignKey(sc => sc.NoticiaId);

                //Relacion NewThemes con Theme
                builder.Entity<NewThemes>()
                       .HasOne<Theme>(sc => sc.Tema)
                       .WithMany(s => s.NoticiaTemas)
                       .HasForeignKey(sc => sc.TemaId);

                #endregion

      */


        #region Entidad Alert
        builder.Entity<Alert>(b =>
        {
            b.ToTable(NewsAppConsts.DbTablePrefix + "Alerts", NewsAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Hora).IsRequired();
            b.Property(x => x.Estado).IsRequired();
        });

        #endregion

        #region Entidad Search
        builder.Entity<Search>(b =>
        {
            b.ToTable(NewsAppConsts.DbTablePrefix + "Searches", NewsAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.FechaBusqueda).IsRequired().HasMaxLength(128);
            b.Property(x => x.Resultado).IsRequired();
            b.Property(x => x.Cadena).IsRequired();
        });

        //Relación busqueda con alerta
        builder.Entity<Search>()
           .HasOne<Alert>(ad => ad.Alerta)
           .WithOne(s => s.Busqueda)
           .HasForeignKey<Alert>(a => a.AlertaBusquedaId)
           .IsRequired(false);

        //Relacion busqueda con usuario
        builder.Entity<Search>()
           .HasOne<ApplicationUser>(ad => ad.Usuario)
           .WithMany(s => s.Busquedas)
           .HasForeignKey(a => a.UsuarioID)
           .IsRequired();

        #endregion

        #region Entidad SearchNews

        //Atributos SearchNews
        builder.Entity<SearchNews>().HasKey(sc => new { sc.BusquedaId, sc.NoticiaId });

        //Relacion SearchNews con Search
        builder.Entity<SearchNews>()
               .HasOne<Search>(sc => sc.Busqueda)
               .WithMany(s => s.BusquedaNoticias)
               .HasForeignKey(sc => sc.BusquedaId);

        //Relacion SearchNews con New
        builder.Entity<SearchNews>()
               .HasOne<New>(sc => sc.Noticia)
               .WithMany(s => s.BusquedaNoticias)
               .HasForeignKey(sc => sc.NoticiaId);

        #endregion



        #region Lista

        builder.Entity<Lista>(b =>
        {
            b.ToTable(NewsAppConsts.DbTablePrefix + "List", NewsAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Nombre).IsRequired().HasMaxLength(128);
            //Listas con sublistas
            b.HasMany(x => x.SubLista)
             .WithOne(x => x.ListaPadre)
             .HasForeignKey(x => x.ListaPadreId)
             .IsRequired(false);
        });

        #endregion 
    }
}
