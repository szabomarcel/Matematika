using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tem__USDtoFT__miTOkm__MGP_L100__LtoGallon
{
    public partial class USAvsHUNvsROvsRUvsEUROvsTÜRKISvsGÖRÖG : Form
    {
        // Árfolyamok USD-re váltáshoz
        private Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
            { "USD", 1.0 },    // Dollár
            { "EUR", 1.09 },   // Euro -> USD
            { "HUF", 305.0 },  // 1 USD = 305 HUF
            { "GBP", 0.82 },   // Font -> USD
            { "RON", 4.5 },    // Román Leu -> USD
            { "TRY", 32.5 },   // Török Lira -> USD
            { "RUB", 92.5 },   // Orosz Rubel -> USD
            { "JPY", 150.3 },  // Japán Jeny -> USD
            { "CNY", 7.2 },    // Kínai Yuan -> USD
            { "SEK", 10.5 }    // Svéd Korona -> USD
        };

        // Tiltott kulcsszavak (pl. $ vagy egyéb szöveges jelek)
        string[] forbiddenKeywords = {
            "$", "ft", "euro", "eur", "usd", "huf", "gbp", "lei", "ron", "₺", "try", "₯",
            "₽", "¥", "cny", "sk", "czk", "dm", "₧", "₣", "sek", "itl"
        };

        private bool IsValidCurrency(string currency)
        {
            return exchangeRates.ContainsKey(currency.ToUpper().Trim());
        }

        // Változó a régi összeg tárolására
        double lastAmount = -1;

        public USAvsHUNvsROvsRUvsEUROvsTÜRKISvsGÖRÖG()
        {
            InitializeComponent();
        }
    
        private void btnValtas1_Click(object sender, EventArgs e)
        {
           
            if (double.TryParse(textBoxFahrenheit.Text, out double fahrenheit))
            {
                double celsius = (fahrenheit - 32) * 5 / 9;
                textBoxCelsius.Text = $"Result: {celsius.ToString("F2")}";

                // Add result to ListBox                
                listBoxResults1.Items.Add($"{fahrenheit} F° = {celsius:F2} C°");
            }
            else
            {
                MessageBox.Show("Érvénytelen bemenet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValtas2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxCelsius1.Text, out double celsius))
            {
                double fahrenheit = celsius * 9 / 5 + 32;
                textBoxFahrenheit1.Text = $"Result: { fahrenheit.ToString("F2")}";
                // Add result to ListBox
                listBoxResults1.Items.Add($"{celsius} C° = {fahrenheit:F2} F°");
            }
            else
            {
                MessageBox.Show("Érvénytelen bemenet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxCelsius.Text = "";
            textBoxFahrenheit.Text = "";
            textBoxCelsius1.Text = "";
            textBoxFahrenheit1.Text = "";
            textBoxFahrenheit.Focus();
        }

        private void btnKm_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMe.Text, out double miles))
            {
                double km = miles / 0.621371;
                textBoxKm1.Text = $"Result: {km.ToString("F2")}";

                // Add result to ListBox
                listBoxResults1.Items.Add($"{miles} mi = {km:F2} km");               
            }
            else
            {
                MessageBox.Show("Érvénytelen bemenet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMe_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxKm.Text, out double km))
            {
                double miles = km * 0.621371;
                textBoxMe1.Text = $"Result: {miles.ToString("F2")}";
                // Add result to ListBox
                listBoxResults1.Items.Add($"{km} km = {miles:F2} mi");
            }
            else
            {
                MessageBox.Show("Érvénytelen bemenet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            textBoxKm.Text = "";
            textBoxKm1.Text = "";
            textBoxMe.Text = "";
            textBoxMe1.Text = "";
            textBoxMe.Focus();
        }

        private void btnMGP_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxLiter100.Text, out double l100km) && l100km > 0)
            {
                double mpg = 235.214 / l100km;
                textBoxMPG.Text = $"Result: {mpg.ToString("F2")}";

                // Add result to ListBox
                listBoxResults1.Items.Add($"{l100km} L/100km = {mpg:F2} MPG");
            }
            else
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLiter_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMgp.Text, out double mpg) && mpg > 0)
            {
                double l100km = 235.214 / mpg;
                textBoxLiter1.Text = $"Result: {l100km.ToString("F2")}";

                // Add result to ListBox
                listBoxResults1.Items.Add($"{mpg} MPG = {l100km:F2} L/100km");
            }
            else
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            textBoxLiter1.Text = "";
            textBoxLiter100.Text = "";
            textBoxMgp.Text = "";
            textBoxMPG.Text = "";
            textBoxLiter1.Focus();
        }

        private void btnGallon_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxLiter.Text, out double liters) && liters > 0)
            {
                double gallons = liters * 0.264172;
                textBoxGallon2.Text = gallons.ToString("F2");

                // Add result to ListBox
                listBoxResults1.Items.Add($"{liters} L = {gallons:F2} gallons");
            }
            else
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLiter1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxGallon.Text, out double gallons) && gallons > 0)
            {
                double liters = gallons * 3.78541;
                textBoxLiter2.Text = liters.ToString("F2");

                // Add result to ListBox
                listBoxResults1.Items.Add($"{gallons} gallons = {liters:F2} L");
            }
            else
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset4_Click(object sender, EventArgs e)
        {
            textBoxLiter.Text = "";
            textBoxLiter2.Text = "";
            textBoxGallon.Text = "";
            textBoxGallon2.Text = "";
            textBoxLiter.Focus();
        }

        private void btnDollar_Click(object sender, EventArgs e)
        {
            try
            {
                // Ellenőrzés: üres mezők ne legyenek
                if (string.IsNullOrWhiteSpace(textBoxNumber.Text) || string.IsNullOrWhiteSpace(textBoxNumber1.Text))
                {
                    MessageBox.Show("Mindkét mezőt ki kell tölteni!");
                    return;
                }

                // Próbáljuk meg konvertálni a számot
                double amount;
                if (!double.TryParse(textBoxNumber.Text, out amount))
                {
                    MessageBox.Show("Kérlek, számot adj meg az összeg mezőben!");
                    return;
                }

                // Ha az új összeg különbözik az előzőtől, töröljük az előző eredményt
                if (amount != lastAmount)
                {
                    listBoxResults.Items.Clear(); // Csak akkor töröljük, ha az új összeg eltér az előzőtől
                }

                // Pénznem beolvasása
                string fromCurrency = textBoxNumber1.Text.Trim().ToUpper();

                // 🔥 Most már a valid pénznemeket nézzük, nem a tiltottakat! 🔥
                if (!IsValidCurrency(fromCurrency))
                {
                    MessageBox.Show($"A(z) {fromCurrency} pénznem nem található az árfolyamok között.");
                    return;
                }

                // Ha a pénznem ugyanaz, mint a cél pénznem (pl. USD -> USD, EUR -> EUR), ne végezzen átváltást
                if (fromCurrency == "USD")
                {
                    return; // Ha USD-ról USD-ra vált, nem csinálunk semmit
                }

                // Árfolyam ellenőrzés és váltás
                double fromRate = exchangeRates[fromCurrency];
                double convertedAmount = amount / fromRate;

                // Eredmény kiírása
                listBoxResults.Items.Add($"{amount} {fromCurrency} = {convertedAmount:F2} USD");

                // Az utolsó összeget frissítjük
                lastAmount = amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }        

        private void btnEuro_Click(object sender, EventArgs e)
        {
            try
            {
                // Ellenőrzés: üres mezők ne legyenek
                if (string.IsNullOrWhiteSpace(textBoxNumber.Text) || string.IsNullOrWhiteSpace(textBoxNumber1.Text))
                {
                    MessageBox.Show("Minden mezőt ki kell tölteni!");
                    return;
                }

                // Próbáljuk meg konvertálni a számot
                if (!double.TryParse(textBoxNumber.Text, out double amount))
                {
                    MessageBox.Show("Kérlek, számot adj meg az összeg mezőben!");
                    return;
                }

                // Ha az új összeg különbözik az előzőtől, töröljük az előző eredményt
                if (amount != lastAmount)
                {
                    listBoxResults.Items.Clear(); // Csak akkor töröljük, ha az új összeg eltér az előzőtől
                }

                // Pénznem beolvasása
                string fromCurrency = textBoxNumber1.Text.Trim().ToUpper();

                // Ellenőrizzük, hogy a pénznem létezik-e az árfolyamok között
                if (!exchangeRates.ContainsKey(fromCurrency))
                {
                    MessageBox.Show("A kiválasztott pénznem nem támogatott.");
                    return;
                }

                // Ha már EUR az eredeti pénznem, akkor nem kell átváltani
                if (fromCurrency == "EUR")
                {                    
                    return;
                }

                // EUR-ra váltás (USD közvetítés nélkül) vagy más pénznemek esetén
                double fromRate = exchangeRates[fromCurrency];
                double eurRate = exchangeRates["EUR"];
                double convertedAmount = (amount / fromRate) * eurRate;

                // Eredmény kiírása
                listBoxResults.Items.Add($"{amount} {fromCurrency} = {convertedAmount:F2} EUR");
                lastAmount = amount; // Frissítjük az utolsó összeg értékét
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }
    }
}
