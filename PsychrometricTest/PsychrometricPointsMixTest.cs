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
    public partial class PsychrometricPointsMixTest : Form
    {
        public PsychrometricPointsMixTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Collect Input Data
            decimal point1_Db = decimal.Parse(point1_txtDb.Text);
            decimal point1_Wb = decimal.Parse(point1_txtWb.Text);
            decimal point1_Flow = decimal.Parse(point1_txtFlowRate.Text);

            decimal altitude = decimal.Parse(point1_txtAltitude.Text);

            decimal point2_Db = decimal.Parse(point2_txtDb.Text);
            decimal point2_Wb = decimal.Parse(point2_txtWb.Text);
            decimal point2_Flow = decimal.Parse(point2_txtFlowRate.Text);

            //  Decide if IP or SI
            if (checkBox1.Checked == false)
            {
                //  IP Units

                //  Create two psychrometric points
                PsychrometricPointIP p1 = new PsychrometricPointIP(altitude,point1_Flow);
                p1.CalcAllUsingDbWb(point1_Db, point1_Wb);
                PsychrometricPointIP p2 = new PsychrometricPointIP(altitude,point2_Flow);
                p2.CalcAllUsingDbWb(point2_Db, point2_Wb);

                //  Create the psychrometric mix point
                PsychrometricAirMixtureIP mix = new PsychrometricAirMixtureIP(p1, p2);

                //  Fill text boxes
                mix_txtDb.Text = mix.DryBulbTemperatureInDegF.ToString();
                mix_txtWb.Text = mix.WetBulbTemperatureInDegF.ToString();
                mix_txtRH.Text = mix.RelativeHumidityPercentage.ToString();
                mix_txtTd.Text = mix.DewPointTemperatureInDegF.ToString();
                mix_txtW.Text = mix.HumidityRatioInPoundsPerPound.ToString();
                mix_txtWgrains.Text = mix.HumidityRatioGrainsPerPound.ToString();
                mix_txtV.Text = mix.SpecificVolumeInCubicFeetPerPound.ToString();
                mix_txtH.Text = mix.EnthalpyInBtuPerPound.ToString();
                mix_txtP.Text = mix.AtmosphericPressurePsia.ToString();
            }
            else if (checkBox1.Checked == true)
            {
                //  SI Units

                //  Create two psychrometric points
                PsychrometricPointSI p1 = new PsychrometricPointSI(altitude, point1_Flow);
                p1.CalcAllUsingDbWb(point1_Db, point1_Wb);
                PsychrometricPointSI p2 = new PsychrometricPointSI(altitude, point2_Flow);
                p2.CalcAllUsingDbWb(point2_Db, point2_Wb);

                // Create psychrometric mix point
                PsychrometricAirMixtureSI mix = new PsychrometricAirMixtureSI(p1, p2);

                //  Fill text boxes
                mix_txtDb.Text = mix.DryBulbTemperature.ToString();
                mix_txtWb.Text = mix.WetBulbTemperature.ToString();
                mix_txtRH.Text = mix.RelativeHumidityPercentage.ToString();
                mix_txtTd.Text = mix.DewPointTemperature.ToString();
                mix_txtW.Text = mix.HumidityRatio.ToString();
                mix_txtWgrains.Text = mix.HumidityRatioGramsPerKilogram.ToString();
                mix_txtV.Text = mix.SpecificVolume.ToString();
                mix_txtH.Text = mix.Enthalpy.ToString();
                mix_txtP.Text = mix.AtmosphericPressureKPa.ToString();
            }
        }
    }
}
