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
    public partial class ReceiptOrderForm : Form
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;

        private readonly ReceiptOrderModel model;

        public ReceiptOrderForm(ReceiptOrderModel model)
            : this()
        {
            this.model = model;
        }

        public ReceiptOrderForm()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["DesktopClientApiGatewayUrl"]);
            mapper = Program.MapperConfiguration.CreateMapper();

            InitializeComponent();
        }

        private void ReceiptOrderForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = model.Details;
            textBox1.Text = model.ApplicationOrderId.ToString();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            var input = new ReceiptOrderCreateInput
            {
                ApplicationOrderId = model.ApplicationOrderId,
            };
            foreach (var p in model.Details)
            {
                input.Details.Add(new ReceiptOrderDetailDto
                {
                    ProductId = p.ProductId,
                    ProductAmount = p.ProductAmount,
                });
            }

            var createRes = await httpClient.PostAsJsonAsync("/api/godown/ReceiptOrder/Create", input);
            var json = await createRes.Content.ReadAsStringAsync();
            var outputCreate = await createRes.Content.ReadFromJsonAsync<ReceiptOrderCreateOutput>();
            if (outputCreate.Success)
            {
                MessageBox.Show("Success");
                textBox2.Text = outputCreate.Id;
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Failed");
                textBox2.Text = "";
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new StorageOrderForm(new Guid(textBox2.Text),model.Details);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
