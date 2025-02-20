using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Matematikaiegyenlet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonElsofoku_Click(object sender, EventArgs e)
        {
            try
            {
                // Beírt értékek beolvasása
                double a = Convert.ToDouble(textBoxSzambeker.Text);
                double b = Convert.ToDouble(textBoxSzambeker1.Text);

                // Egyenlet megoldása
                if (a == 0)
                {
                    if (b == 0)
                        textBoxVegsoeredmeny.Text = "Végtelen sok megoldás!";
                    else
                        textBoxVegsoeredmeny.Text = "Nincs megoldás!";
                }
                else
                {
                    double x = -b / a;
                    textBoxVegsoeredmeny.Text = $"Megoldás: x = {x}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Kérlek, adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnMasodfoku_Click(object sender, EventArgs e)
        {
            try
            {
                // Beolvasás és ellenőrzés
                if (!double.TryParse(textBoxSzambeker.Text, out double a) ||
                    !double.TryParse(textBoxSzambeker1.Text, out double b) ||
                    !double.TryParse(textBoxSzambeker2.Text, out double c))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                // Ellenőrizzük, hogy a ≠ 0 (különben nem másodfokú egyenlet)
                if (a == 0)
                {
                    textBoxVegsoeredmeny1.Text = "Ez nem másodfokú egyenlet!";
                    return;
                }

                // Diszkrimináns kiszámítása
                double D = (b * b) - (4 * a * c);

                if (D > 0)
                {
                    // Két különböző valós gyök
                    double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    textBoxKet.Text = $"Két valós megoldás:\nx1 = {x1}\nx2 = {x2}";
                }
                else if (D == 0)
                {
                    // Egy valós gyök
                    double x = -b / (2 * a);
                    textBoxEgy.Text = $"Egy valós megoldás: x = {x}";
                }
                else
                {
                    // Komplex megoldások
                    double realPart = -b / (2 * a);
                    double imaginaryPart = Math.Sqrt(-D) / (2 * a);
                    textBoxVegsoeredmeny1.Text = $"Komplex megoldások:\nx1 = {realPart} + {imaginaryPart}i; \nx2 = {realPart} - {imaginaryPart}i;";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void btnHarmad_Click(object sender, EventArgs e)
        {
            try
            {
                // Beolvasás és ellenőrzés
                if (!double.TryParse(textBoxSzambeker.Text, out double a) ||
                !double.TryParse(textBoxSzambeker1.Text, out double b) ||
                !double.TryParse(textBoxSzambeker2.Text, out double c) ||
                    !double.TryParse(textBoxSzambeker3.Text, out double d))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                // Newton-Raphson módszer az első gyök megtalálásához
                double x0 = 0; // Kezdeti tipp (kezdhetjük 0-val vagy más számmal)
                double tolerance = 1e-6; // A kívánt pontosság
                double maxIterations = 1000; // Maximális iterációk száma
                double root = NewtonRaphson(a, b, c, d, x0, tolerance, maxIterations);

                // Az eredmény kiírása
                textBoxVegsoeredmeny2.Text = $"Talált gyök: x = {root}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private double NewtonRaphson(double a, double b, double c, double d, double x0, double tolerance, double maxIterations)
        {
            double x = x0;
            int iteration = 0;

            while (iteration < maxIterations)
            {
                // f(x) = ax^3 + bx^2 + cx + d
                double fx = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;

                // f'(x) = 3ax^2 + 2bx + c
                double fxPrime = 3 * a * Math.Pow(x, 2) + 2 * b * x + c;

                // Newton-Raphson lépés
                double xNext = x - fx / fxPrime;

                // Ellenőrizzük, hogy a változás kicsi-e (pontosság)
                if (Math.Abs(xNext - x) < tolerance)
                {
                    return xNext;
                }

                x = xNext;
                iteration++;
            }

            // Ha nem talál gyököt a maximális iterációkon belül, akkor hibát jelez
            throw new Exception("A gyök nem található a megadott iterációk számán belül.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Beviteli mezők és eredmény törlése
            textBoxSzambeker.Text = "";
            textBoxSzambeker1.Text = "";
            textBoxSzambeker2.Text = "";
            textBoxSzambeker3.Text = "";
            textBoxVegsoeredmeny.Text = "";
            textBoxVegsoeredmeny1.Text = "";
            textBoxVegsoeredmeny2.Text = "";
            textBoxEgy.Text = "";
            textBoxKet.Text = "";

            // Fókusz visszaállítása
            textBoxSzambeker.Focus();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                // Szög beolvasása
                if (!double.TryParse(textBoxSzam.Text, out double szam))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számot adj meg");
                    return;
                }

                //Szög fokból radiánba alakítása
                double radians = szam * (Math.PI / 180);

                //Trigonometriai értékek számítása
                double sinValue = Math.Sin(radians);
                double cosValue = Math.Cos(radians);
                double tanValue = Math.Tan(radians);
                if (Math.Abs(cosValue) < 1e-10)
                {
                    textBoxTan.Text = "tan: Nincs értelme (nem definiált)";
                }
                else
                {
                    textBoxTan.Text = $"tan: {tanValue}";
                }

                //Eredmény kiírása
                textBoxCos.Text = $"cos: {cosValue}";
                textBoxSin.Text = $"sin: {sinValue}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt" + ex.Message);
            }
        }

        private void buttonReset2_Click(object sender, EventArgs e)
        {
            textBoxSzam.Text = "";
            textBoxSin.Text = "sin: ";
            textBoxCos.Text = "cos: ";
            textBoxTan.Text = "tan: ";
            textBoxSzam.Focus();
        }

        private void btnOssze_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam1.Text, out double number1) || !double.TryParse(textBoxSzam2.Text, out double number2))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double sum = number1 + number2;

                textBoxVegsoeredmeny3.Text = $"Eredmény: {sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnKivon_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam1.Text, out double number1) || !double.TryParse(textBoxSzam2.Text, out double number2))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double sum = number1 - number2;
                textBoxVegsoeredmeny3.Text = $"Eredmény: {sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnSzorzas_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam1.Text, out double number1) || !double.TryParse(textBoxSzam2.Text, out double number2))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double sum = number1 * number2;
                textBoxVegsoeredmeny3.Text = $"Eredmény: {sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnOsztas_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam1.Text, out double number1) || !double.TryParse(textBoxSzam2.Text, out double number2))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double sum = number1 / number2;
                textBoxVegsoeredmeny3.Text = $"Eredmény: {sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Beviteli mezők és eredmény törlése
            textBoxSzam1.Text = "";
            textBoxSzam2.Text = "";
            textBoxVegsoeredmeny3.Text = "";

            // Beviteli mezők és eredmény törlése
            textBoxSzam1.Focus();
        }

        private void btnNewton_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam3.Text, out double m) || !double.TryParse(textBoxSzam4.Text, out double a))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double F = m *a;
                textBoxVegsoeredmeny4.Text = $"A testre ható erő: {F} N";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnOhm_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam3.Text, out double I) || !double.TryParse(textBoxSzam4.Text, out double R))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double V = I * R;
                textBoxVegsoeredmeny4.Text = $"A feszültség: {V} V";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnBernoulli_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam3.Text, out double P1) || !double.TryParse(textBoxSzam3.Text, out double v1) || !double.TryParse(textBoxSzam3.Text, out double h1) || !double.TryParse(textBoxSzam4.Text, out double P2) || !double.TryParse(textBoxSzam4.Text, out double v2) || !double.TryParse(textBoxSzam4.Text, out double h2))                    
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                const double g = 9.81; // Gravitációs gyorsulás (m/s²)
                const double rho = 1000; // Víz sűrűsége (kg/m³)

                double energiakulonbseg = (P1 - P2) / rho + (v1 * v1 - v2 * v2) / 2 + g * (h1 - h2);
                textBoxVegsoeredmeny4.Text = $"Energia különbség: {energiakulonbseg} J/kg";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnHooke_Click(object sender, EventArgs e)
        {
            try
            {
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam3.Text, out double k) || !double.TryParse(textBoxSzam4.Text, out double x))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double F = k * x;
                textBoxVegsoeredmeny4.Text = $"A rugóra ható erő: {F} N";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnIdealis_Click(object sender, EventArgs e)
        {            
            try
            {
                const double R = 8.314;
                // Számok beolvasása
                if (!double.TryParse(textBoxSzam3.Text, out double P) || !double.TryParse(textBoxSzam4.Text, out double V) || !double.TryParse(textBoxSzam5.Text, out double n))
                {
                    MessageBox.Show("Hibás bevitel! Kérlek, számokat adj meg.");
                    return;
                }

                double T = (P * V) / (n * R);
                textBoxVegsoeredmeny4.Text = $"Az ideális gáz hőmérséklete: {T} K";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel!");
            }
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            textBoxSzam3.Text = "";
            textBoxSzam4.Text = "";
            textBoxSzam5.Text = "";
            textBoxVegsoeredmeny4.Text = "";
            textBoxSzam3.Focus();
        }

        private void btnNegyzet_Click(object sender, EventArgs e)
        {
            try
            {
                // Beírt szám beolvasása
                double szam = Convert.ToDouble(textBoxSzam6.Text);

                // Szám négyzetre emelése
                double negyzet = Math.Pow(szam, 2);

                // Eredmény kiírása
                textBoxVegsoeredmeny5.Text = negyzet.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Kérlek, adj meg egy számot.\n" + ex.Message);
            }
        }

        private void btnReset4_Click(object sender, EventArgs e)
        {
            textBoxSzam6.Text = "";
            textBoxVegsoeredmeny5.Text = "";
            textBoxSzam6.Focus();
        }

        private void btnNegyzetgyok_Click(object sender, EventArgs e)
        {
            try
            {
                // Beírt szám beolvasása
                double szam = Convert.ToDouble(textBoxSzam7.Text);

                // Ellenőrzés: Csak nem negatív számokra van valós gyök
                if (szam < 0)
                {
                    textBoxNegyzetgyok.Text = "Nincs valós megoldás!";
                    return;
                }

                // Négyzetgyök kiszámítása
                double gyok = Math.Sqrt(szam);

                // Eredmény kiírása
                textBoxNegyzetgyok.Text = gyok.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Kérlek, adj meg egy számot.\n" + ex.Message);
            }
        }

        private void btnGyokoktetsz_Click(object sender, EventArgs e)
        {
            try
            {
                double szam = Convert.ToDouble(textBoxSzam7.Text);
                double n = Convert.ToDouble(textBoxFok.Text); // Gyök fokszáma

                if (n == 0)
                {
                    textBoxGyok.Text = "Nem értelmezhető!";
                    return;
                }

                double eredmeny = Math.Pow(szam, 1.0 / n);
                textBoxGyok.Text = eredmeny.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat!\n" + ex.Message);
            }
        }

        private void btnKomplex_Click(object sender, EventArgs e)
        {       
            try
            {
                double szam = Convert.ToDouble(textBoxSzam7.Text);

                if (szam >= 0)
                {
                    // Ha a szám nem negatív, egyszerűen kiszámítjuk a gyököt
                    double eredmeny = Math.Sqrt(szam);
                    textBoxKomplex.Text = eredmeny.ToString();
                }
                else
                {
                    // Ha negatív, akkor komplex számot kezelünk (i * sqrt(abs(szam)))
                    double absGyok = Math.Sqrt(Math.Abs(szam));
                    textBoxKomplex.Text = $"0 + {absGyok}i";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számot!\n" + ex.Message);
            }
        }

        private void btnReset5_Click(object sender, EventArgs e)
        {
            textBoxSzam7.Text = "";
            textBoxNegyzetgyok.Text = "";
            textBoxGyok.Text = "";
            textBoxKomplex.Text = "";
            textBoxSzam7.Focus();
        }

        private void btnSzamitas_Click(object sender, EventArgs e)
        {
            try
            {
                string alakzat = comboBoxAlakzat.SelectedItem.ToString();
                double r = Convert.ToDouble(textBoxSugar.Text);
                double h = 0;

                // Magasság bekérése, ha szükséges
                if (alakzat == "Henger" || alakzat == "Kúp" || alakzat == "Téglatest")
                {
                    h = Convert.ToDouble(textBoxMagassag.Text);
                    if (h <= 0)
                    {
                        textBoxHibas.Text = "A magasság nem lehet negatív vagy nulla!";
                        return;
                    }
                }

                if (r <= 0)
                {
                    textBoxHibas.Text = "A sugár nem lehet negatív vagy nulla!";
                    return;
                }                

                if (r <= 0)
                {
                    textBoxHibas.Text = "A sugár nem lehet negatív vagy nulla!";
                    return;
                }

                if (alakzat == "Gömb")
                {
                    double terfogat = (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);
                    double felszin = 4 * Math.PI * Math.Pow(r, 2);
                    textBoxTerfogat.Text = $"Térfogat: {terfogat: F2}";
                    textBoxFelszin.Text = $"Felszín: {felszin: F2}";
                }
                
                else if (alakzat == "Kör")
                {
                    double terulet = Math.PI * Math.Pow(r, 2);
                    double kerulet = 2 * Math.PI * r;
                    textBoxTerulet.Text = $"Terület: {terulet: F2}";
                    textBoxKerulet.Text = $"Kerület: {kerulet: F2}";
                }

                else if (alakzat == "Henger" || alakzat == "Kúp")
                {
                    h = Convert.ToDouble(textBoxMagassag.Text);

                    if (h <= 0)
                    {
                        textBoxHibas.Text = "A magasság nem lehet negatív vagy nulla!";
                        return;
                    }

                    if (alakzat == "Henger")
                    {
                        double terfogat = Math.PI * Math.Pow(r, 2) * h;
                        double felszin = 2 * Math.PI * r * (r + h);
                        textBoxTerfogat.Text = $"Térfogat: {terfogat: F2}";
                        textBoxFelszin.Text = $"Felszín: {felszin: F2}";
                    }
                    else if (alakzat == "Kúp")
                    {
                        double terfogat = (1.0 / 3.0) * Math.PI * Math.Pow(r, 2) * h;
                        double felszin = Math.PI * r * (r + Math.Sqrt(h * h + r * r));
                        textBoxTerfogat.Text = $"Térfogat: {terfogat: F2}";
                        textBoxFelszin.Text = $"Felszín: {felszin: F2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnReset6_Click(object sender, EventArgs e)
        {            
            textBoxSugar.Text = "";
            textBoxMagassag.Text = "";
            textBoxHibas.Text = "";
            textBoxTerfogat.Text = "";
            textBoxFelszin.Text = "";
        }

        private void btnEgyszeru_Click(object sender, EventArgs e)
        {
            try
            {
                // Vektorok beolvasása
                double x1 = Convert.ToDouble(textBoxVektor1X.Text);
                double y1 = Convert.ToDouble(textBoxVektor1Y.Text);
                double x2 = Convert.ToDouble(textBoxVektor2X.Text);
                double y2 = Convert.ToDouble(textBoxVektor2Y.Text);

                // Vektorösszeg
                double osszegX = x1 + x2;
                double osszegY = y1 + y2;

                // Skaláris szorzat
                double skalarszorzat = x1 * x2 + y1 * y2;

                // Eredmények kiírása
                textBoxEredmeny.Text = $"Összeg: ({osszegX}, {osszegY})\nSkaláris szorzat: {skalarszorzat}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnVektormuvelet_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = Convert.ToDouble(textBoxVektor1X.Text);
                double y1 = Convert.ToDouble(textBoxVektor1Y.Text);
                double z1 = Convert.ToDouble(textBoxVektor1Z.Text);
                double x2 = Convert.ToDouble(textBoxVektor2X.Text);
                double y2 = Convert.ToDouble(textBoxVektor2Y.Text);
                double z2 = Convert.ToDouble(textBoxVektor2Z.Text);

                double cx = y1 * z2 - z1 * y2;
                double cy = z1 * x2 - x1 * z2;
                double cz = x1 * y2 - y1 * x2;

                textBoxEredmeny2.Text = $"Keresztszorzat: ({cx}, {cy}, {cz})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnMatrixossz_Click(object sender, EventArgs e)
        {
            try
            {
                double[,] A = { { 1, 2 }, { 3, 4 } };
                double[,] B = { { 5, 6 }, { 7, 8 } };
                double[,] C = new double[2, 2];

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                    }
                }

                textBoxEredmeny3.Text = $"[{C[0, 0]}, {C[0, 1]}]\n[{C[1, 0]}, {C[1, 1]}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!\n" + ex.Message);
            }
        }

        private void btnMatrixszor_Click(object sender, EventArgs e)
        {
            try
            {
                double[,] A = { { 1, 2 }, { 3, 4 } };
                double[,] B = { { 5, 6 }, { 7, 8 } };
                double[,] C = new double[2, 2];

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        C[i, j] = 0;
                        for (int k = 0; k < 2; k++)
                        {
                            C[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }

                textBoxEredmeny4.Text = $"[{C[0, 0]}, {C[0, 1]}]\n[{C[1, 0]}, {C[1, 1]}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!\n" + ex.Message);
            }
        }

        private void btnReset8_Click(object sender, EventArgs e)
        {
            textBoxVektor1X.Text = "";
            textBoxVektor1Y.Text = "";
            textBoxVektor2X.Text = "";
            textBoxVektor2Y.Text = "";
            textBoxVektor1Z.Text = "";
            textBoxVektor2Z.Text = "";            
            textBoxEredmeny.Text = "";
            textBoxEredmeny2.Text = "";
            textBoxEredmeny3.Text = "";
            textBoxEredmeny4.Text = "";
        }

        private void btnAltalanos_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBoxA.Text);
                double b = Convert.ToDouble(textBoxB.Text);
                double c = Convert.ToDouble(textBoxC.Text);

                double R = Math.Sqrt(a * a + b * b);
                double alpha = Math.Atan2(b, a);

                if (Math.Abs(c) > R)
                {
                    textBoxVegso.Text = "Nincs megoldás, mert |c| > R";
                    return;
                }

                double x1 = Math.Asin(c / R) - alpha;
                double x2 = Math.PI - Math.Asin(c / R) - alpha;

                textBoxVegso.Text = $"x1 = {x1 * 180 / Math.PI}°; \nx2 = {x2 * 180 / Math.PI}°";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnSzogHaromszog_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBoxOldal.Text);
                double theta = Convert.ToDouble(textBoxSzog.Text) * Math.PI / 180; // fok → radián

                double h = a * Math.Sin(theta);

                textBoxVegso2.Text = $"Magasság: {h:F2} egység";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnHullam_Click(object sender, EventArgs e)
        {
            try
            {
                double A = Convert.ToDouble(textBoxAmplitudo.Text);
                double f = Convert.ToDouble(textBoxFrekvencia.Text);
                double phi = Convert.ToDouble(textBoxFazis.Text) * Math.PI / 180;
                double t = Convert.ToDouble(textBoxIdo.Text);

                double omega = 2 * Math.PI * f;
                double y = A * Math.Sin(omega * t + phi);

                textBoxVegso3.Text = $"Jel értéke: {y:F4}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnGomb_Click(object sender, EventArgs e)
        {
            try
            {
                double r = Convert.ToDouble(textBoxR.Text);
                double theta = Convert.ToDouble(textBoxTheta.Text) * Math.PI / 180; // fok → radián
                double phi = Convert.ToDouble(textBoxPhi.Text) * Math.PI / 180;

                double x = r * Math.Sin(theta) * Math.Cos(phi);
                double y = r * Math.Sin(theta) * Math.Sin(phi);
                double z = r * Math.Cos(theta);

                textBoxVegso4.Text = $"x = {x:F2}, y = {y:F2}, z = {z:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnReset9_Click(object sender, EventArgs e)
        {
            textBoxA.Text = "";
            textBoxB.Text = "";
            textBoxC.Text = "";
            textBoxVegso.Text = "";
            textBoxOldal.Text = "";
            textBoxSzog.Text = "";
            textBoxVegso2.Text = "";
            textBoxAmplitudo.Text = "";
            textBoxFrekvencia.Text = "";
            textBoxFazis.Text = "";
            textBoxIdo.Text = "";
            textBoxVegso3.Text = "";
            textBoxR.Text = "";
            textBoxTheta.Text = "";
            textBoxPhi.Text = "";
            textBoxVegso4.Text = "";
            textBoxA.Focus();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBoxAA.Text);
                double b = Convert.ToDouble(textBoxBB.Text);
                double c = Convert.ToDouble(textBoxCC.Text);

                if (a == 0 || c <= 0)
                {
                    textBoxVegso5.Text = "Nincs megoldás (a ≠ 0 és c > 0 kell legyen).";
                    return;
                }

                double x = Math.Log(c / a) / b;
                textBoxVegso5.Text = $"Megoldás: x = {x:F4}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double b = Convert.ToDouble(textBoxAlap.Text);
                double c = Convert.ToDouble(textBoxErtek.Text);

                if (b <= 0 || b == 1)
                {
                    textBoxVegso6.Text = "Az alapnak pozitívnak és nem lehet 1.";
                    return;
                }

                double x = Math.Pow(b, c);
                textBoxVegso6.Text = $"Megoldás: x = {x:F4}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnKamat_Click(object sender, EventArgs e)
        {
            try
            {
                double P = Convert.ToDouble(textBoxToke.Text);
                double r = Convert.ToDouble(textBoxKamatlab.Text) / 100;
                int n = Convert.ToInt32(textBoxKamatozasSzama.Text);
                double t = Convert.ToDouble(textBoxIdotartam.Text);

                double A = P * Math.Pow(1 + r / n, n * t);
                textBoxVegso8.Text = $"Végösszeg: {A:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnDecibelSzamitas_Click(object sender, EventArgs e)
        {
            try
            {
                double I = Convert.ToDouble(textBoxIntenzitas.Text);
                double I0 = Convert.ToDouble(textBoxReferencia.Text);

                if (I0 <= 0 || I <= 0)
                {
                    textBoxVegso9.Text = "Az intenzitásoknak pozitívnak kell lenniük.";
                    return;
                }

                double L = 10 * Math.Log10(I / I0);
                textBoxVegso9.Text = $"Decibelszint: {L:F2} dB";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void buttonReset10_Click(object sender, EventArgs e)
        {
            textBoxAA.Text = "";
            textBoxBB.Text = "";
            textBoxCC.Text = "";
            textBoxVegso5.Text = "";
            textBoxAlap.Text = "";
            textBoxErtek.Text = "";
            textBoxVegso6.Text = "";
            textBoxKezdeti.Text = "";
            textBoxBomlasiAllando.Text = "";
            textBoxIdo.Text = "";
            textBoxVegso7.Text = "";
            textBoxToke.Text = "";
            textBoxKamatlab.Text = "";
            textBoxKamatozasSzama.Text = "";
            textBoxIdotartam.Text = "";
            textBoxVegso8.Text = "";
            textBoxIntenzitas.Text = "";
            textBoxReferencia.Text = "";
            textBoxVegso9.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double N0 = Convert.ToDouble(textBoxKezdeti.Text);
                double lambda = Convert.ToDouble(textBoxBomlasiAllando.Text);
                double t = Convert.ToDouble(textBoxIdo1.Text);

                double N = N0 * Math.Exp(-lambda * t);
                textBoxVegso7.Text = $"Fennmaradó mennyiség: {N:F4}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnEuler_Click(object sender, EventArgs e)
        {
            try
            {
                double x0 = Convert.ToDouble(textBoxX0.Text);
                double y0 = Convert.ToDouble(textBoxY0.Text);
                double h = Convert.ToDouble(textBoxStepSize.Text);
                double xEnd = Convert.ToDouble(textBoxStepSize.Text);

                List<string> results = new List<string>();
                double x = x0, y = y0;

                while (x < xEnd)
                {
                    y += h * Fuggveny(x, y);
                    x += h;
                    results.Add($"x: {x:F2}, y: {y:F4}");
                }

                textBoxVegso10.Text = string.Join("\r\n", results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }
        private double Fuggveny(double x, double y)
        {
            return x + y;
        }

        private void btnRK4_Click(object sender, EventArgs e)
        {
            try
            {
                double x0 = Convert.ToDouble(textBoxX01.Text);
                double y0 = Convert.ToDouble(textBoxY01.Text);
                double h = Convert.ToDouble(textBoxStepSize1.Text);
                double xEnd = Convert.ToDouble(textBoxXEnd1.Text);

                List<string> results = new List<string>();
                double x = x0, y = y0;

                while (x < xEnd)
                {
                    double k1 = h * Fuggveny(x, y);
                    double k2 = h * Fuggveny(x + h / 2, y + k1 / 2);
                    double k3 = h * Fuggveny(x + h / 2, y + k2 / 2);
                    double k4 = h * Fuggveny(x + h, y + k3);

                    y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    x += h;
                    results.Add($"x: {x:F2}, y: {y:F4}");
                }

                textBoxVegso11.Text = string.Join("\r\n", results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }
        }

        private void btnSecondOrder_Click(object sender, EventArgs e)
        {
            try
            {
                double x0 = Convert.ToDouble(textBoxX02.Text);
                double y0 = Convert.ToDouble(textBoxY02.Text);
                double v0 = Convert.ToDouble(textBoxV02.Text); // Kezdeti derivált
                double h = Convert.ToDouble(textBoxStepSize2.Text);
                double xEnd = Convert.ToDouble(textBoxXEnd2.Text);

                List<string> results = new List<string>();
                double x = x0, y = y0, v = v0;

                while (x < xEnd)
                {
                    double k1y = h * v;
                    double k1v = h * FuggvenyMasod(x, y, v);

                    double k2y = h * (v + k1v / 2);
                    double k2v = h * FuggvenyMasod(x + h / 2, y + k1y / 2, v + k1v / 2);

                    double k3y = h * (v + k2v / 2);
                    double k3v = h * FuggvenyMasod(x + h / 2, y + k2y / 2, v + k2v / 2);

                    double k4y = h * (v + k3v);
                    double k4v = h * FuggvenyMasod(x + h, y + k3y, v + k3v);

                    y += (k1y + 2 * k2y + 2 * k3y + k4y) / 6;
                    v += (k1v + 2 * k2v + 2 * k3v + k4v) / 6;
                    x += h;

                    results.Add($"x: {x:F2}, y: {y:F4}");
                }

                textBoxVegso12.Text = string.Join("\r\n", results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hibás bevitel! Adj meg számokat.\n" + ex.Message);
            }            
        }
        private double FuggvenyMasod(double x, double y, double v)
        {
            return -9.81; // Gravitációs gyorsulás
        }

        private void btnReset11_Click(object sender, EventArgs e)
        {
            textBoxX0.Text = "";
            textBoxY0.Text = "";
            textBoxStepSize.Text = "";
            textBoxXEnd.Text = "";
            textBoxVegso10.Text = "";
            textBoxX01.Text = "";
            textBoxY01.Text = "";
            textBoxStepSize1.Text = "";
            textBoxXEnd1.Text = "";
            textBoxVegso11.Text = "";
            textBoxX02.Text = "";
            textBoxY02.Text = "";
            textBoxV02.Text = "";
            textBoxStepSize2.Text = "";
            textBoxXEnd2.Text = "";
            textBoxVegso12.Text = "";
        }
    }
}