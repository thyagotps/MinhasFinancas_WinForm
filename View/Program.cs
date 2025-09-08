using Application.Interfaces;
using Application.Services;
using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloContaPadrao;
using Controller.ModuloFaturaEmAberto;
using Controller.ModuloMovimentoFinanceiro;
using Controller.ModuloPagamento;
using Controller.ModuloRelatorios;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloContaPadrao;
using Model.ModuloFaturaEmAberto;
using Model.ModuloMovimentoFinanceiro;
using Model.ModuloPagamento;
using Model.ModuloRelatorios;
using View.ModuloCartao;
using View.ModuloCategoria;
using View.ModuloContaPadrao;
using View.ModuloFaturaEmAberto;
using View.ModuloMovimentoFinanceiro;
using View.ModuloPagamento;
using View.ModuloRelatorios;


namespace View
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);
            ConfigureServices();
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<MovimentoFinanceiroView>());

        }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddScoped<IAdo, Ado>();

            services.AddTransient(typeof(IBaseRepositoryEF<>), typeof(BaseRepositoryEF<>));


            services.AddTransient<ICartaoController, CartaoController>();
            services.AddTransient<ICartaoRepository, CartaoRepository>();
            services.AddTransient<CartaoView>();
            services.AddTransient<CartaoForm>();

            services.AddTransient<IMovimentoFinanceiroController, MovimentoFinanceiroController>();
            services.AddTransient<IMovimentoFinanceiroRepository, MovimentoFinanceiroRepository>();
            services.AddTransient<MovimentoFinanceiroView>();
            services.AddTransient<MovimentoFinanceiroForm>();

            services.AddTransient<IContaPadraoController, ContaPadraoController>();
            services.AddTransient<IContaPadraoRepository, ContaPadraoRepository>();
            services.AddTransient<ContaPadraoView>();
            services.AddTransient<ContaPadraoForm>();

            services.AddTransient<IFaturaEmAbertoController, FaturaEmAbertoController>();
            services.AddTransient<IFaturaEmAbertoRepository, FaturaEmAbertoRepository>();
            services.AddTransient<FaturaEmAbertoView>();
            services.AddTransient<FaturaEmAbertoForm>();

            services.AddTransient<ICategoriaController, CategoriaController>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<CategoriaView>();
            services.AddTransient<CategoriaForm>();

            services.AddTransient<IPagamentoController, PagamentoController>();
            services.AddTransient<IPagamentoRepository, PagamentoRepository>();
            services.AddTransient<PagamentoView>();
            services.AddTransient<PagamentoForm>();

            services.AddTransient<IRelatorioController, RelatorioController>();
            services.AddTransient<IRelatorioRepository, RelatorioRepository>();
            services.AddTransient<RelatoriosView>();

            var myHandlers = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));


            services.AddScoped<ICartaoService, CartaoService>();


            services.AddTransient<DbContext, AppDbContext>();

            



            var config = GetConfigurationBuilder();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();
            });

            ServiceProvider = services.BuildServiceProvider();
        }

        static IConfigurationRoot GetConfigurationBuilder()
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

            return configuration;
        }

        public static T? GetService<T>() where T : class
        {
            return (T?)ServiceProvider.GetService(typeof(T));
        }

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            MessageBox.Show(t.Exception.Message, "Erro interno!", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }


    }
}