using AppModels.basicinfo;
using AppModels.godown;
using AutoMapper;
using GodownClient.ViewModels;

namespace GodownClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitMapper();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        public static MapperConfiguration MapperConfiguration;
        private static void InitMapper()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, BasicInfoModel>().ReverseMap();
                cfg.CreateMap<CompanyDto, BasicInfoModel>().ReverseMap();
                cfg.CreateMap<ProviderDto, BasicInfoModel>().ReverseMap();
                cfg.CreateMap<ProductModel, ApplicationOrderDetailDto>().ReverseMap();
                cfg.CreateMap<ApplicationOrderLoadOutput, ApplicationOrderModel>().ReverseMap();
            });
        }
    }
}
