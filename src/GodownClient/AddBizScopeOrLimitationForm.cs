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
using AppModels.basicsetting;
using AppModels.godown;
using AutoMapper;
using GodownClient.ViewModels;

namespace GodownClient
{
    public partial class AddBizScopeOrLimitationForm : Form
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;
        private readonly bool bizScopeOrLimitation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bizScopeOrLimitation">BizScope=true; Limitation=false</param>
        public AddBizScopeOrLimitationForm(bool bizScopeOrLimitation)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["DesktopClientApiGatewayUrl"]);
            mapper = Program.MapperConfiguration.CreateMapper();

            InitializeComponent();
            this.bizScopeOrLimitation = bizScopeOrLimitation;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            HttpResponseMessage? resp = null;

            var productIds = new List<Guid>();
            foreach (BasicInfoModel item in checkedListBox1.CheckedItems)
            {
                productIds.Add(item.Id);
            }

            if (bizScopeOrLimitation)
            {
                var input = new BizScopeSaveInput
                {
                    BizEntityId = (Guid)comboBox3.SelectedValue,
                    ProductIds = productIds.ToArray()
                };

                resp = await httpClient.PostAsJsonAsync("/api/basicsetting/BizScope/Save", input);
            }
            else
            {
                var input = new LimitationSaveInput
                {
                    CompanyId = (Guid)comboBox3.SelectedValue,
                };
                foreach (var pid in productIds)
                {
                    input.Details.Add(new LimitationDetailDto
                    {
                        ProductId = pid,
                        Amount = 0
                    });
                }

                resp = await httpClient.PostAsJsonAsync("/api/basicsetting/Limitation/Save", input);
            }

            if (resp.IsSuccessStatusCode)
            {
                MessageBox.Show("Success");
                Close();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private async void AddBizScopeForm_Load(object sender, EventArgs e)
        {
            var items = new List<BasicInfoModel>();

            var listProductReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Product/List");
            var listProductRes = await httpClient.SendAsync(listProductReq);
            var outputProductList = await listProductRes.Content.ReadFromJsonAsync<ProductListOutput>();
            foreach (var item in outputProductList.Items)
            {
                checkedListBox1.Items.Add(new BasicInfoModel
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            var listCompanyReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Company/List");
            var listCompanyRes = await httpClient.SendAsync(listCompanyReq);
            var outputCompanyList = await listCompanyRes.Content.ReadFromJsonAsync<CompanyListOutput>();
            foreach (var item in outputCompanyList.Items)
            {
                items.Add(new BasicInfoModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            if (bizScopeOrLimitation)
            {
                var listProviderReq = new HttpRequestMessage(HttpMethod.Post, "/api/basicinfo/Provider/List");
                var listProviderRes = await httpClient.SendAsync(listProviderReq);
                var outputProviderList = await listProviderRes.Content.ReadFromJsonAsync<ProviderListOutput>();
                foreach (var item in outputProviderList.Items)
                {
                    items.Add(new BasicInfoModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            comboBox3.DataSource = items;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";

            label3.Text = bizScopeOrLimitation ? "Biz Entities" : "Companies";
        }
    }
}
