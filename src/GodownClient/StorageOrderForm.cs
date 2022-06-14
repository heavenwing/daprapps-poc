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
using AppModels.godown;
using AutoMapper;
using GodownClient.ViewModels;

namespace GodownClient
{
    public partial class StorageOrderForm : Form
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;

        private readonly Guid id;
        private readonly List<ProductModel> details;

        public StorageOrderForm(Guid id, List<ProductModel> details)
            :this()
        {
            this.id = id;
            this.details = details;
        }

        public StorageOrderForm()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["DesktopClientApiGatewayUrl"]);
            mapper = Program.MapperConfiguration.CreateMapper();


            InitializeComponent();
        }

        private void StorageOrderForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = id.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var input = new StorageOrderCreateInput
            {
                ReceiptOrderId = id,
                WarehouseId = new Guid(textBox2.Text),
            };
            foreach (var item in details)
            {
                input.Details.Add(new StorageOrderDetailDto
                {
                    BinlocationId = textBox3.Text,
                    ProductId = item.ProductId,
                    ProductAmount = item.ProductAmount,
                });
            }

            var createRes = await httpClient.PostAsJsonAsync("/api/godown/StorageOrder/Create", input);
            var json = await createRes.Content.ReadAsStringAsync();
            var outputCreate = await createRes.Content.ReadFromJsonAsync<StorageOrderCreateOutput>();
            if (outputCreate.Success)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
