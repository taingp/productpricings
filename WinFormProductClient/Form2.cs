using ProductLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProductClient
{
    public partial class Form2 : Form
    {
        private BindingSource bs = new();
        public Form2(string productCode)
        {
            InitializeComponent();
            txtCode.Text = productCode;

            bs.DataSource = new List<PricingResponse>();
            dgvPricings.DataSource = bs;
            dgvPricings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPricings.Columns["ProductCode"].Visible = false;
            btnBrowse.Click += DoClickBrowse;
            btnCreateSubmit.Click += DoClickCreateSubmit;
            btnUpdateSubmit.Click += DoClickUpdateSubmit;
            btnDelete.Click += DoClickDelete;
            bs.PositionChanged += DoPricingPositionChanged;
            DoClickBrowse(null, EventArgs.Empty);
        }

        private async void DoClickDelete(object? sender, EventArgs e)
        {
            if (bs.Current == null) return;
            var key = (bs.Current as PricingResponse)!.Id;
            var endpoint = $"api/pricings/{key}";
            var result = await Program.RestClient.DeleteAsync<Result<string?>>(endpoint);   
            if (result!.Succeded)
            {
                bs.RemoveCurrent();
            }
        }

        private void DoPricingPositionChanged(object? sender, EventArgs e)
        {
            if (bs.Current == null)
            {
                txtUpdateValue.Text = "";
            }
            else
            {
                txtUpdateValue.Text = (bs.Current as PricingResponse)!.Value.ToString();
            }

        }

        private async void DoClickUpdateSubmit(object? sender, EventArgs e)
        {
            if (bs.Current == null) return;
            if (double.TryParse(txtUpdateValue.Text, out double price))
            {
                var curPricingResponse = bs.Current as PricingResponse;
                var req = new PricingUpdateReq()
                {
                    Id = curPricingResponse!.Id ?? "",
                    ProductKey = curPricingResponse!.ProductCode,
                    Value = price
                };
                var endpoint = "api/pricings";
                var result = await Program.RestClient.PutAsync<PricingUpdateReq, Result<string?>>(endpoint, req);
                if (result!.Succeded)
                {
                    curPricingResponse.Value = req.Value;
                    bs.ResetBindings(false);
                }
            }

        }

        private async void DoClickCreateSubmit(object? sender, EventArgs e)
        {
            if (double.TryParse(txtCreateValue.Text, out double price))
            {
                var req = new PricingCreateReq()
                {
                    ProductKey = txtCode.Text,
                    Value = price,
                    EffectedFrom = dtpCreateEff.Value
                };
                var endpoint = "api/pricings";
                var result = await Program.RestClient.PostAsync<PricingCreateReq, Result<string?>>(endpoint, req);
                if (result!.Succeded)
                {
                    var response = new PricingResponse()
                    {
                        Id = result!.Data,
                        ProductCode = req.ProductKey,
                        Value = req.Value,
                        EffectedFrom = req.EffectedFrom

                    };
                    (bs.DataSource as List<PricingResponse>)?.Add(response);
                    bs.ResetBindings(false);
                }
            }
        }

        private async void DoClickBrowse(object? sender, EventArgs e)
        {
            var endpoint = "api/pricings";
            var result = await Program.RestClient.GetAsync<Result<List<PricingResponse>>>(endpoint);
            if (result!.Succeded)
            {
                var pricings = result!.Data!.Where(p => p.ProductCode.ToLower() == txtCode.Text.Trim().ToLower()).ToList() ?? new();
                bs.DataSource = pricings;
                bs.ResetBindings(false);
            }
            else
            {
                MessageBox.Show(result!.Message);
            }
        }
    }
}
