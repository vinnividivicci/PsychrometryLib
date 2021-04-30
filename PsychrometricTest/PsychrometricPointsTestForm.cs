using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PsychrometryLib;

namespace PsychrometricTest
{
    public partial class PsychrometricPointsTestForm : Form
    {
        public PsychrometricPointsTestForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPanel1_btnCalc_Click(object sender, EventArgs e)
        {
            //  Collect input data
            double altitude = double.Parse(tabPanel1_txtAltitude.Text);
            double Db = double.Parse(tabPanel1_txtDb.Text);
            double Wb = double.Parse(tabPanel1_txtWb.Text);

            //  Decide if IP or SI
            if (checkBox1.Checked == false)
            {
                //  IP units
                PsychrometricPointIP p1 = new PsychrometricPointIP(altitude);
                p1.CalcAllUsingDbWb(Db, Wb);

                tabPanel1_txtRH.Text = p1.RelativeHumidityPercentage.ToString();
                tabPanel1_txtTd.Text = p1.DewPointTemperatureInDegF.ToString();
                tabPanel1_txtW.Text = p1.HumidityRatioInPoundsPerPound.ToString();
                tabPanel1_txtWgrains.Text = p1.HumidityRatioGrainsPerPound.ToString();
                tabPanel1_txtV.Text = p1.SpecificVolumeInCubicFeetPerPound.ToString();
                tabPanel1_txtH.Text = p1.EnthalpyInBtuPerPound.ToString();
                tabPanel1_txtP.Text = p1.AtmosphericPressurePsia.ToString();
            }
            else if(checkBox1.Checked == true)
            {
                //  SI Units
                PsychrometricPointSI p2 = new PsychrometricPointSI(altitude);
                p2.CalcAllUsingDbWb(Db, Wb);

                tabPanel1_txtRH.Text = p2.RelativeHumidityPercentage.ToString();
                tabPanel1_txtTd.Text = p2.DewPointTemperature.ToString();
                tabPanel1_txtW.Text = p2.HumidityRatio.ToString();
                tabPanel1_txtWgrains.Text = p2.HumidityRatioGramsPerKilogram.ToString();
                tabPanel1_txtV.Text = p2.SpecificVolume.ToString();
                tabPanel1_txtH.Text = p2.Enthalpy.ToString();
                tabPanel1_txtP.Text = p2.AtmosphericPressureKPa.ToString();
            }
        }

        private void tabPanel2_btnCalc_Click(object sender, EventArgs e)
        {
            //  Collect input data
            double altitude = double.Parse(tabPanel2_txtAltitude.Text);
            double Db = double.Parse(tabPanel2_txtDb.Text);
            double RH = double.Parse(tabPanel2_txtRH.Text);

            //  Decide if IP or SI
            if (checkBox1.Checked == false)
            {
                //  IP Units
                PsychrometricPointIP p1 = new PsychrometricPointIP(altitude);
                p1.CalcAllUsingDbRH(Db, RH);

                tabPanel2_txtWb.Text = p1.WetBulbTemperatureInDegF.ToString();
                tabPanel2_txtTd.Text = p1.DewPointTemperatureInDegF.ToString();
                tabPanel2_txtW.Text = p1.HumidityRatioInPoundsPerPound.ToString();
                tabPanel2_txtWgrains.Text = p1.HumidityRatioGrainsPerPound.ToString();
                tabPanel2_txtV.Text = p1.SpecificVolumeInCubicFeetPerPound.ToString();
                tabPanel2_txtH.Text = p1.EnthalpyInBtuPerPound.ToString();
                tabPanel2_txtP.Text = p1.AtmosphericPressurePsia.ToString();
            }
            else if (checkBox1.Checked == true)
            {
                //  SI Units
                PsychrometricPointSI p2 = new PsychrometricPointSI(altitude);
                p2.CalcAllUsingDbRH(Db, RH);

                tabPanel2_txtWb.Text = p2.WetBulbTemperature.ToString();
                tabPanel2_txtTd.Text = p2.DewPointTemperature.ToString();
                tabPanel2_txtW.Text = p2.HumidityRatio.ToString();
                tabPanel2_txtWgrains.Text = p2.HumidityRatioGramsPerKilogram.ToString();
                tabPanel2_txtV.Text = p2.SpecificVolume.ToString();
                tabPanel2_txtH.Text = p2.Enthalpy.ToString();
                tabPanel2_txtP.Text = p2.AtmosphericPressureKPa.ToString();
            }
        }

        private void tabPanel3_btnCalc_Click(object sender, EventArgs e)
        {
            //  Collect input data
            double altitude = double.Parse(tabPanel3_txtAltitude.Text);
            double Db = double.Parse(tabPanel3_txtDb.Text);
            double Td = double.Parse(tabPanel3_txtTd.Text);

            //  Decide if IP or SI
            if (checkBox1.Checked == false)
            {
                //  IP units
                PsychrometricPointIP p1 = new PsychrometricPointIP(altitude);
                p1.CalcAllUsingDbTd(Db, Td);

                tabPanel3_txtWb.Text = p1.WetBulbTemperatureInDegF.ToString();
                tabPanel3_txtRH.Text = p1.RelativeHumidityPercentage.ToString();
                tabPanel3_txtW.Text = p1.HumidityRatioInPoundsPerPound.ToString();
                tabPanel3_txtWgrains.Text = p1.HumidityRatioGrainsPerPound.ToString();
                tabPanel3_txtV.Text = p1.SpecificVolumeInCubicFeetPerPound.ToString();
                tabPanel3_txtH.Text = p1.EnthalpyInBtuPerPound.ToString();
                tabPanel3_txtP.Text = p1.AtmosphericPressurePsia.ToString();
            }
            else if (checkBox1.Checked == true)
            {
                //  SI units
                PsychrometricPointSI p2 = new PsychrometricPointSI(altitude);
                p2.CalcAllUsingDbTd(Db, Td);

                tabPanel3_txtWb.Text = p2.WetBulbTemperature.ToString();
                tabPanel3_txtRH.Text = p2.RelativeHumidityPercentage.ToString();
                tabPanel3_txtW.Text = p2.HumidityRatio.ToString();
                tabPanel3_txtWgrains.Text = p2.HumidityRatioGramsPerKilogram.ToString();
                tabPanel3_txtV.Text = p2.SpecificVolume.ToString();
                tabPanel3_txtH.Text = p2.Enthalpy.ToString();
                tabPanel3_txtP.Text = p2.AtmosphericPressureKPa.ToString();
            }
        }

        private void tabPanel4_btnCalculate_Click(object sender, EventArgs e)
        {
            //  Collect input data
            double altitude = double.Parse(tabPanel4_txtAltitude.Text);
            double Db = double.Parse(tabPanel4_txtDb.Text);
            double W = double.Parse(tabPanel4_txtHumidityRatio.Text);

            //  Decide if IP or SI
            if (checkBox1.Checked == false)
            {
                //  IP units
                PsychrometricPointIP p1 = new PsychrometricPointIP(altitude);
                p1.CalcAllUsingDbGrains(Db, W);

                tabPanel4_txtWb.Text = p1.WetBulbTemperatureInDegF.ToString();
                tabPanel4_txtRH.Text = p1.RelativeHumidityPercentage.ToString();
                tabPanel4_txtW.Text = p1.HumidityRatioInPoundsPerPound.ToString();
                tabPanel4_txtW2.Text = p1.HumidityRatioGrainsPerPound.ToString();
                tabPanel4_txtV.Text = p1.SpecificVolumeInCubicFeetPerPound.ToString();
                tabPanel4_txtEnthalpy.Text = p1.EnthalpyInBtuPerPound.ToString();
                tabPanel4_txtPressure.Text = p1.AtmosphericPressurePsia.ToString();
            }
            else if (checkBox1.Checked == true)
            {
                //  SI units
                PsychrometricPointSI p2 = new PsychrometricPointSI(altitude);
                p2.CalcAllUsingDbGrams(Db, W);

                tabPanel4_txtWb.Text = p2.WetBulbTemperature.ToString();
                tabPanel4_txtRH.Text = p2.RelativeHumidityPercentage.ToString();
                tabPanel4_txtW.Text = p2.HumidityRatio.ToString();
                tabPanel4_txtW2.Text = p2.HumidityRatioGramsPerKilogram.ToString();
                tabPanel4_txtV.Text = p2.SpecificVolume.ToString();
                tabPanel4_txtEnthalpy.Text = p2.Enthalpy.ToString();
                tabPanel4_txtPressure.Text = p2.AtmosphericPressureKPa.ToString();
            }
        }
    }
}
