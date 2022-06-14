using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppModels.basicinfo;
using AppModels.basicsetting;
using AppModels.godown;
using AutoMapper;
using GodownClient.ViewModels;

namespace GodownClient
{
    public partial class ApplicationCreateForm : Form
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;

        public ApplicationCreateForm()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["DesktopClientApiGatewayUrl"]);
            mapper = Program.MapperConfiguration.CreateMapper();

            InitializeComponent();
        }


        private async void ApplicationFormForm_Load(object sender, EventArgs e)
        {
            var model = await LoadData();
            bindingSource1.DataSource = model;
        }

        private async Task<ApplicationOrderModel> LoadData()
        {
            var listProductReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Product/List");
            var listProductRes = await httpClient.SendAsync(listProductReq);
            var outputProductList = await listProductRes.Content.ReadFromJsonAsync<ProductListOutput>();

            var listCompanyReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Company/List");
            var listCompanyRes = await httpClient.SendAsync(listCompanyReq);
            //var json = await listCompanyRes.Content.ReadAsStringAsync();
            var outputCompanyList = await listCompanyRes.Content.ReadFromJsonAsync<CompanyListOutput>();

            var listProviderReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Provider/List");
            var listProviderRes = await httpClient.SendAsync(listProviderReq);
            var outputProviderList = await listProviderRes.Content.ReadFromJsonAsync<ProviderListOutput>();

            var model = new ApplicationOrderModel();
            //var model = (ApplicationOrderModel)bindingSource1.DataSource;
            InitListData(outputProductList, outputProviderList, outputCompanyList, model);
            //productListBindingSource.DataSource = model.ProductList;
            //providerListBindingSource.DataSource = model.ProviderList;
            //productsBindingSource.DataSource = model.Details;
            return model;
        }

        private void InitListData(ProductListOutput? productList, ProviderListOutput? providerList, CompanyListOutput? companyList, ApplicationOrderModel model)
        {
            model.AllProducts = productList.Items;

            //model.ProductList.AddRange(mapper.Map<List<BasicInfoModel>>(productList.Items));
            model.CompanyList.AddRange(mapper.Map<List<BasicInfoModel>>(companyList.Items));
            model.ProviderList.AddRange(mapper.Map<List<BasicInfoModel>>(providerList.Items));
            //model.ProductList.Add(new BasicInfoModel() { Id = Guid.Empty, Name = "Select ..." });
            //model.ProviderList.Add(new BasicInfoModel() { Id = Guid.Empty, Name = "Select ..." });
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            productsBindingSource.EndEdit();
            bindingSource1.EndEdit();

            var model = (ApplicationOrderModel)bindingSource1.DataSource;
            var input = new ApplicationOrderCreateInput
            {
                BuyerId = Guid.NewGuid(),
                CompanyId = model.CompanyId,
                ProviderId = model.ProviderId,
            };
            foreach (var p in model.Details)
            {
                input.Details.Add(new ApplicationOrderDetailDto
                {
                    ProductId = p.ProductId,
                    ProductAmount = p.ProductAmount
                });
            }

            var createRes = await httpClient.PostAsJsonAsync("/api/godown/ApplicationOrder/Create", input);
            var json = await createRes.Content.ReadAsStringAsync();
            var outputCreate = await createRes.Content.ReadFromJsonAsync<ApplicationOrderCreateOutput>();
            if (outputCreate.Success)
            {
                MessageBox.Show("Success");
                textBox1.Text = outputCreate.Id;
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var model = (ApplicationOrderModel)bindingSource1.DataSource;
            var id = (Guid)comboBox2.SelectedValue;
            if (id != Guid.Empty)
            {
                var input = new LimitationGetAmountInput
                {
                    CompanyId = model.CompanyId,
                    ProductIds = new[] { id },
                };
                var resp = await httpClient.PostAsJsonAsync("/api/basicsetting/Limitation/GetAmount", input);
                var output = await resp.Content.ReadFromJsonAsync<LimitationGetAmountOutput>();

                var item = new ProductModel
                {
                    ProductId = id,
                    ProductName = model.ProductList.Find(p => p.Id == id).Name,
                    AllowAmount = output.Items[id]
                };
                model.Details.Add(item);
            }
            dataGridView1.DataSource = model.Details;
        }

        private async void btnLoadProducts_Click(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            var model = (ApplicationOrderModel)bindingSource1.DataSource;

            var input = new BizScopeGetAllowableInput
            {
                CompanyId = model.CompanyId,
                ProviderId = model.ProviderId,
            };

            var resp = await httpClient.PostAsJsonAsync("/api/basicsetting/BizScope/GetAllowable", input);
            var output = await resp.Content.ReadFromJsonAsync<BizScopeGetAllowableOutput>();

            model.ProductList.Clear();
            model.ProductList.Add(new BasicInfoModel() { Id = Guid.Empty, Name = "Select ..." });
            foreach (var id in output.Items)
            {
                var item = new BasicInfoModel
                {
                    Id = id,
                    Name = model.AllProducts.FirstOrDefault(p => p.Id == id).Name,
                };
                model.ProductList.Add(item);
            }
            comboBox2.DataSource = model.ProductList;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }
    }
}
