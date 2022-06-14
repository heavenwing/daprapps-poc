using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppModels.basicinfo;
using AppModels.godown;
using AutoMapper;
using GodownClient.ViewModels;

namespace GodownClient
{
    public partial class ApplicationLoadForm : Form
    {
        private readonly string id;

        public ApplicationLoadForm(string id)
            : this()
        {
            this.id = id;
        }

        private readonly HttpClient httpClient;
        private readonly IMapper mapper;

        public ApplicationLoadForm()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["DesktopClientApiGatewayUrl"]);
            mapper = Program.MapperConfiguration.CreateMapper();

            InitializeComponent();
        }

        ApplicationOrderLoadOutput loadOutput;
        ProductListOutput outputProductList;
        private async void ApplicationShowForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var listProductReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Product/List");
                var listProductRes = await httpClient.SendAsync(listProductReq);
                outputProductList = await listProductRes.Content.ReadFromJsonAsync<ProductListOutput>();

                var listProviderReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Provider/List");
                var listProviderRes = await httpClient.SendAsync(listProviderReq);
                var outputProviderList = await listProviderRes.Content.ReadFromJsonAsync<ProviderListOutput>();

                var input = new ApplicationWorkflowInput { Id = id };
                var resLoad = await httpClient.PostAsJsonAsync("/api/godown/ApplicationOrder/Load", input);
                loadOutput = await resLoad.Content.ReadFromJsonAsync<ApplicationOrderLoadOutput>();

                var sb = new StringBuilder();
                sb.AppendLine("Provider: " + outputProviderList.Items.FirstOrDefault(p => p.Id == loadOutput.ProviderId).Name);
                sb.AppendLine();
                sb.AppendLine("Products:");
                foreach (var d in loadOutput.Details)
                {
                    sb.AppendLine(outputProductList.Items.FirstOrDefault(p => p.Id == d.ProductId).Name
                        + " : " + d.ProductAmount);
                }
                txtInfo.Text = sb.ToString();

                if (loadOutput.IsComplete)
                    btnTake.Enabled = true;
                else
                    btnTake.Enabled = false;
            }
        }

        private async void btnTake_Click(object sender, EventArgs e)
        {
            var model = new ReceiptOrderModel
            {
                ApplicationOrderId = new Guid(id),
            };
            foreach (var item in loadOutput.Details)
            {
                model.Details.Add(new ProductModel
                {
                    ProductId = item.ProductId,
                    ProductName = outputProductList.Items.FirstOrDefault(p => p.Id == item.ProductId).Name,
                    AllowAmount = item.ProductAmount,
                });
            }
            var frm = new ReceiptOrderForm(model);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
