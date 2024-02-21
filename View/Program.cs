using AutoMapper;
using Base.Ninject;
using View.ModuloCategoria;
using View.ModuloMovimentoFinanceiro;


namespace View
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            NinjectKernel.Wire(new NinjectBinds());
            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);

            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            var view = NinjectKernel.Resolve<MovimentoFinanceiroView>();
            Application.Run(view);

        }

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            MessageBox.Show(t.Exception.Message, "Erro interno!", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }


    }
}