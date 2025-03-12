using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaloriaCalculator
{
    public partial class Calculator : Form
    {
        // Mozgások és kalóriaégetés testsúly alapján
        Dictionary<string, double> kaloriaErtekek = new Dictionary<string, double>()
        {
            { "Gyaloglás (5 km/h)", 0.04 },
            { "Biciklizés (20 km/h)", 0.12 },
            { "Alvás", 50.0 / 60 },
            { "Futás", 10.5 },
            { "Úszás", 9.5 },
            { "Edzés", 6.5},
        };

        public Calculator()
        {
            InitializeComponent();
            FeltoltListBox();
        }

        private void FeltoltListBox()
        {
            listBoxSzoveg.Items.AddRange(kaloriaErtekek.Keys.ToArray()); // Hozzáadja a sportokat
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy a ListBox-ban van-e kiválasztott érték
            if (listBoxSzoveg.SelectedItem == null)
            {
                MessageBox.Show("Válassz ki egy tevékenységet a listából!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiválasztott tevékenység
            string kivalasztottTevekenyseg = listBoxSzoveg.SelectedItem.ToString().Trim();

            // Validálás
            if (double.TryParse(textBoxWeight.Text, out double userWeight) &&
                double.TryParse(textBoxGoalWeight.Text, out double goalWeight) &&
                int.TryParse(textBoxWorkoutsPerWeek.Text, out int workoutsPerWeek) &&
                double.TryParse(textBoxCaloriesIntake.Text, out double dailyCalories) &&
                double.TryParse(textBoxAlvas.Text, out double alvasOra) &&
                double.TryParse(textBoxBiciklizes.Text, out double biciklizesPerc) &&
                double.TryParse(textBoxOszKaloria.Text, out double osszKaloria))
            {
                // Kalória deficit számítása
                double calorieDeficit = (userWeight - goalWeight) * 7700;
                double weeklyCaloriesBurned = workoutsPerWeek * 300;
                double totalCalories = dailyCalories * 7;

                // A kiválasztott tevékenység alapján számított kalóriaégetés
                double activityCaloriesBurned = 0;
                if (kaloriaErtekek.ContainsKey(kivalasztottTevekenyseg))
                {
                    activityCaloriesBurned = kaloriaErtekek[kivalasztottTevekenyseg] * biciklizesPerc;
                }
                else
                {
                    MessageBox.Show("Hiba történt! Az adott tevékenység nem található az adatbázisban.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Az összes elégetett kalória összegzése
                double totalCaloriesBurned = activityCaloriesBurned + weeklyCaloriesBurned;

                // Eredmények kiírása
                MessageBox.Show($"A napi kalóriabevitel: {totalCalories} kcal\n" +
                                $"Heti kalória deficit: {calorieDeficit} kcal\n" +
                                $"A(z) {kivalasztottTevekenyseg}-sel elégetett kalóriák: {activityCaloriesBurned} kcal\n" +
                                $"Összes elégetett kalória: {totalCaloriesBurned} kcal",
                                "Eredmények");
            }
            else
            {
                MessageBox.Show("Kérlek, adj meg érvényes számokat minden mezőben!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxWeight.Text = "";
            textBoxGoalWeight.Text = "";
            textBoxWorkoutsPerWeek.Text = "";
            textBoxCaloriesIntake.Text = "";
            textBoxDuration.Text = "";
            textBoxAlvas.Text = "";
            textBoxBiciklizes.Text = "";
            textBoxOszKaloria.Text = "";
            textBoxWeight.Focus();
        }
    }
}
