using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SaveSystemFramework.Providers;
using SaveSystemFramework.Core;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.Http; 

namespace ErasmusBudgetTracker
{
  

    public partial class Form1 : Form
    {
        // 1. DEĞİŞKENLER
        private ISaveManager _saveManager;
        private ErasmusData _appData;
        private const string SAVE_FILE_NAME = "erasmus_budget_v1";
        private decimal _currentEuroRate = 0; // Anlık kur
        public Form1()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            // Framework Başlatma
            _saveManager = new JsonSaveProvider("ErasmusTrackerData");

            // Veri Başlatma
            _appData = new ErasmusData();

            // !!! YENİ KISIM: Hedef kutusuna mevcut hedefi yaz !!!
            // Eğer kayıtlı veri yoksa varsayılan 3000 gelir, varsa kayıtlı olan gelir.
            numTargetGoal.Value = _appData.TargetBudget;

            // Limitleri kodla da garantiye alalım
            numTargetGoal.Maximum = 100000;
            numAmount.Maximum = 100000;

            FetchEuroRate();
            UpdateUI();
        }

        // 2. ARAYÜZ GÜNCELLEME
        private void UpdateUI()
        {
            // BU SATIRI SİL veya YORUM YAP (Çünkü lblTargetAmount artık yok):
            // lblTargetAmount.Text = $"{_appData.TargetBudget} €"; 

            // Geri kalanlar aynı kalsın...
            lblCurrentBalance.Text = $"{_appData.CurrentBalance} €";

            // Renk mantığı aynen devam...
            if (_appData.CurrentBalance >= _appData.TargetBudget)
                lblCurrentBalance.ForeColor = Color.Green;
            else
                lblCurrentBalance.ForeColor = Color.OrangeRed;

            // Liste güncelleme kodları aynı...
            lstTransactions.Items.Clear();
            var reversedHistory = _appData.TransactionHistory.AsEnumerable().Reverse();
            foreach (var item in reversedHistory)
            {
                lstTransactions.Items.Add(item);
            }

            UpdateTryEquivalent();
        }

        private void btnUpdateGoal_Click(object sender, EventArgs e)
        {
            // 1. Kutudaki yeni değeri alıp verimize işliyoruz
            _appData.TargetBudget = numTargetGoal.Value;

            // 2. Ekranı yeniliyoruz (Renklendirmeler ve kalan bütçe güncellensin diye)
            UpdateUI();

            // 3. Kullanıcıya minik bir bildirim (Opsiyonel ama şık durur)
            MessageBox.Show("Target goal updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. DÖVİZ KURU ÇEKME (EKSTRA ÖZELLİK)
        private async void FetchEuroRate()
        {
            lblLiveRate.Text = "Rate: Updating...";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // API'ye istek at (Frankfurter API - Ücretsiz ve Kayıtsız)
                    string url = "https://api.frankfurter.app/latest?from=EUR&to=TRY";
                    string response = await client.GetStringAsync(url);

                    // JSON Parse (Basit string işlemi ile)
                    // Gelen veri örneği: {..."rates":{"TRY":34.52}...}
                    if (response.Contains("TRY"))
                    {
                        // 1. Kuru metnin içinden çekip alıyoruz
                        int index = response.IndexOf("TRY") + 5;
                        string rateStr = response.Substring(index).Replace("}", "").Replace("]", "");

                        // 2. Sayıya çeviriyoruz (CultureInfo.InvariantCulture önemli, nokta/virgül hatasını önler)
                        if (decimal.TryParse(rateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rate))
                        {
                            _currentEuroRate = rate; // Kuru hafızaya al

                            // 3. Ekrana yazdır
                            lblLiveRate.Text = $"1 EUR = {_currentEuroRate:F2} ₺";

                            // 4. Eğer halihazırda paramız varsa hemen TL karşılığını güncelle
                            UpdateTryEquivalent();
                        }
                    }
                }
            }
            catch
            {
                lblLiveRate.Text = "Rate: Offline";
                lblTryEquivalent.Text = "(Offline)";
            }
        }

        // TL Karşılığını Hesaplayan Yardımcı Metod
        private void UpdateTryEquivalent()
        {
            if (_currentEuroRate > 0)
            {
                decimal tryValue = _appData.CurrentBalance * _currentEuroRate;
                lblTryEquivalent.Text = $"(≈ {tryValue:N2} ₺)";
            }
        }

        // 4. BUTONLAR
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            decimal amount = numAmount.Value;

            if (string.IsNullOrEmpty(description) || amount == 0)
            {
                MessageBox.Show("Please enter a valid description and amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _appData.CurrentBalance += amount;

            string log = $"[{DateTime.Now.ToShortDateString()}] {description}: {amount} €";
            _appData.TransactionHistory.Add(log);

            txtDescription.Clear();
            numAmount.Value = 0;
            UpdateUI();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Saving...";
            btnSave.Enabled = false;

            try
            {
                bool success = await _saveManager.SaveAsync(SAVE_FILE_NAME, _appData);

                if (success)
                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Critical Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Text = "Save";
                btnSave.Enabled = true;
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Text = "Loading...";
            btnLoad.Enabled = false;

            try
            {
                bool exists = await _saveManager.SaveExistsAsync(SAVE_FILE_NAME);

                if (exists)
                {
                    var loadedData = await _saveManager.LoadAsync<ErasmusData>(SAVE_FILE_NAME);

                    if (loadedData != null)
                    {
                        _appData = loadedData;
                        UpdateUI();
                        MessageBox.Show("Data loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No save file found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoad.Text = "Load";
                btnLoad.Enabled = true;
            }
        }
    }
}