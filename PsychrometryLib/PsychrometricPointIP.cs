/**************************
 * MIT License
 * 
 * Copyright (c) 2008 Vincent Cadoret

 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in the 
 * Software without restriction, including without limitation the rights to use, copy, 
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
 * and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial 
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 **************************/

using System;
using System.Globalization;

namespace PsychrometryLib
{
    /// <summary>
    /// Class model of a psychrometric point in IP units.
    /// </summary>
    public class PsychrometricPointIP
    {
        /**************************************
        /*  Declare all protected class members.
        ***************************************/

        /// <summary>
        /// Protected class member, Altitude [ft]
        /// </summary>
        protected decimal _alt = 0;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [psia] at dry-bulb temperature [Deg. R]
        /// </summary>
        protected decimal _PwsDb;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [psia] at wet-bulb temperature [Deg. R]
        /// </summary>
        protected decimal _PwsWb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [lbH2O/lbAIR] at dry-bulb temperature [Deg. F]
        /// </summary>
        protected decimal _WsDb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [lbH2O/lbAIR] at wet-bulb temperature [Deg. F]
        /// </summary>
        protected decimal _WsWb;

        /// <summary>
        /// Protected class member, Humidity Ratio [lbH2O/lbAIR]
        /// </summary>
        protected decimal _W;

        /// <summary>
        /// Protected class member, Degree of Saturation [unitless decimal]
        /// </summary>
        protected decimal _u;

        /// <summary>
        /// Protected class member, Relative Humidity [unitless decimal]
        /// </summary>
        protected decimal _RH;

        /// <summary>
        /// Protected class member, Specific Volume [ft3/lb]
        /// </summary>
        protected decimal _v;

        /// <summary>
        /// Protected class member, Specific Enthalpy [BTU/lbDryAir]
        /// </summary>
        protected decimal _h;

        /// <summary>
        /// Protected class member, Water Vapor Partial Pressure [psia]
        /// </summary>
        protected decimal _Pw;

        /// <summary>
        /// Protected class member, Dewpoint Temperature [Deg. F]
        /// </summary>
        protected decimal _Td;

        /// <summary>
        /// Protected class member, Atmospheric Pressure [psia]
        /// </summary>
        protected decimal _P;

        /// <summary>
        /// Protected class member, Atmospheric Pressure [inHg]
        /// </summary>
        protected decimal _PinHg;

        /// <summary>
        /// Protected class member, Dry-bulb Temperature [Deg. F]
        /// </summary>
        protected decimal _DbT;

        /// <summary>
        /// Protected class member, Wet-bulb Temperature [Deg. F]
        /// </summary>
        protected decimal _WbT;

        /// <summary>
        /// Protected class member, Flow Rate [ft3/min or CFM]
        /// </summary>
        protected decimal _flowRate = 0;

        /// <summary>
        /// Protected class member, Mass [lb]
        /// </summary>
        protected decimal _m;

        #region Getters and Setters

        ///<returns>
        ///Altitude [ft]
        /// </returns>  
        public decimal AltitudeInFeet
        {
            //  Altitude only needs to be set upon instantiation
            get
            {
                return this._alt;
            }
        }

        /// <returns>
        /// Humidity Ratio [lbH2O/lbAIR]
        /// </returns>
        public decimal HumidityRatioInPoundsPerPound
        {
            get
            {
                return this._W;
            }
        }

        /// <returns>
        /// Humidity Ratio [grH2O/lbAIR]
        /// </returns>
        public decimal HumidityRatioGrainsPerPound
        {
            get
            {
                return this._W * 7000;
            }
        }

        /// <returns>
        /// Relative Humidity in percentage form
        /// </returns>
        public decimal RelativeHumidityPercentage
        {
            get
            {
                return this._RH * 100;
            }
        }

        /// <returns>
        /// Relative Humidity in decimal form
        /// </returns>
        public decimal RelativeHumidityDecimal
        {
            get
            {
                return this._RH;
            }
        }

        /// <returns>
        /// Specific Volume [ft3/lb]
        /// </returns>
        public decimal SpecificVolumeInCubicFeetPerPound
        {
            get
            {
                return this._v;
            }
        }

        /// <returns>
        /// Returns Enthalpy [BTU/lb]
        /// </returns>
        public decimal EnthalpyInBtuPerPound
        {
            get
            {
                return this._h;
            }
        }

        /// <returns>
        /// Dew Point Temperature [Deg. F]
        /// </returns>
        public decimal DewPointTemperatureInDegF
        {
            get
            {
                return this._Td;
            }
        }

        /// <returns>
        /// Atmospheric Pressure [psia]
        /// </returns>
        public decimal AtmosphericPressurePsia
        {
            get
            {
                return this._P;
            }
        }

        /// <returns>
        /// Dry Bulb Temperature [Deg. F]
        /// </returns>
        public decimal DryBulbTemperatureInDegF
        {
            get
            {
                return this._DbT;
            }
        }

        /// <returns>
        /// Wet Bulb Temperature [Deg. F]
        /// </returns>
        public decimal WetBulbTemperatureInDegF
        {
            get
            {
                return this._WbT;
            }
        }

        /// <returns>
        /// Mass [lb/min]
        /// </returns>
        public decimal MassicFlowInPoundsPerMinute
        {
            get
            {
                return this._m;
            }
        }

        /// <returns>
        /// Flow Rate [CFM]
        /// </returns>
        public decimal VolumetricFlowRateInCFM
        {
            get
            {
                return this._flowRate;
            }
        }

        #endregion
        #region Constructors

        /// <summary>
        /// Default Constructor. Uses a sea level altitude (0 ft) and zero flow rate [0 cfm]
        /// to initialize the object.
        /// </summary>
        public PsychrometricPointIP() { }

        /// <summary>
        /// Constructor. Uses the input supplied by the programmer to initialize it's altitude.
        /// </summary>
        /// <param name="Altitude">Programmer-supplied altitude value in feet.</param>
        public PsychrometricPointIP(decimal Altitude)
        {
            this._alt = Altitude;
        }

        /// <summary>
        /// Constructor. Uses the input supplied by the programmer to initialize altitude [ft] 
        /// and it's flow value [cfm].
        /// </summary>
        /// <param name="Altitude">Programmer-supplied altitude value in feet.</param>
        /// <param name="FlowRateCfm">Programmer-supplied Flow Rate value in CFM.</param>
        public PsychrometricPointIP(decimal Altitude, decimal FlowRateCfm)
        {
            this._alt = Altitude;
            this._flowRate = FlowRateCfm;
        }

        #endregion
        #region Interface Methods

        /***********************************
         * These are the only public methods
         ***********************************/

        /// <summary>
        /// Calculate all air properties using Dry-Bulb T [Deg. F] and Wet-Bulb T [Deg. F]
        /// </summary>
        /// <param name="DbDegF">Dry-Bulb Temperature [Deg. F]</param>
        /// <param name="WbDegF">Wet-Bulb Temperature [Deg. F]</param>
        public void CalcAllUsingDbWb(decimal DbDegF, decimal WbDegF)
        {
            if (WbDegF > DbDegF)
            {
                throw new WetBulbTemperatureCannotBeGreaterThanDryBulb();
            }
            else
            {
                this._DbT = DbDegF;
                this._WbT = WbDegF;

                this._P = CalcAtmPressurePsia(_alt);
                this._PinHg = CalcAtmPressureInHg(_alt);

                this._PwsDb = CalcPws(this._DbT);
                this._PwsWb = CalcPws(this._WbT);
                this._WsDb = CalcWs(this._PwsDb, this._P);
                this._WsWb = CalcWs(this._PwsWb, this._P);
                this._W = CalcW(this._DbT, this._WbT, this._WsWb);
                this._u = CalcU(this._W, this._WsDb);

                //  If Wb = Db then RH = 100%
                if (this._DbT == this._WbT)
                {
                    this._RH = 1;
                }
                else
                {
                    this._RH = CalcRH(this._u, this._PwsDb, this._P);
                }

                this._v = CalcV(this._DbT, this._W, this._PinHg);
                this._h = CalcH(this._DbT, this._W);
                this._Pw = CalcPw(this._P, this._W);

                //  If Wb = Db then Db = Td
                if (this._DbT == this._WbT)
                {
                    this._Td = this._DbT;
                }
                else
                {
                    this._Td = CalcTd(this._Pw, this._WbT);
                }

                this._m = CalcM(this._v, this._flowRate);
            }
        }

        /// <summary>
        /// Calculate all air properties using Dry-Bulb T [Deg. F] and Relative Humidity [Unitless Decimal]
        /// </summary>
        /// <param name="DbDegF">Dry-Bulb Temperature [Deg. F]</param>
        /// <param name="RH">Relative Humidity [Unitless Decimal]</param>
        public void CalcAllUsingDbRH(decimal DbDegF, decimal RH)
        {
            if (RH > 1 || RH < 0)
            {
                throw new RHOutOfRangeException();
            }
            else
            {
                this._DbT = DbDegF;
                this._RH = RH;

                this._P = CalcAtmPressurePsia(_alt);
                this._PinHg = CalcAtmPressureInHg(_alt);

                this._PwsDb = CalcPws(this._DbT);
                this._Pw = this._RH * this._PwsDb;
                this._W = CalcWs(this._Pw, this._P);
                this._WsDb = CalcWs(this._PwsDb, this._P);
                this._u = CalcU(this._W, this._WsDb);
                this._v = CalcV(this._DbT, this._W, this._PinHg);
                this._h = CalcH(this._DbT, this._W);

                //  If RH = 1 then Dewpoint = Dry-bulb and Wet-bulb = Dry-bulb
                if (this._RH == 1)
                {
                    this._Td = this._DbT;
                    this._WbT = this._DbT;
                }
                else
                {
                    this._Td = CalcTd(this._Pw, this._WbT);
                    this._WbT = FindWbT(this._DbT, this._Td, this._W, this._P);
                }

                this._m = CalcM(this._v, this._flowRate);
            }
        }

        /// <summary>
        /// Calculate all air properties using Dry-Bulb T [Deg. F] and Dew-Point T [Deg. F]
        /// </summary>
        /// <param name="DbDegF">Dry-Bulb Temperature [Deg. F]</param>
        /// <param name="TdDegF">Dew-Point Temperature [Deg. F]</param>
        public void CalcAllUsingDbTd(decimal DbDegF, decimal TdDegF)
        {
            if (TdDegF > DbDegF)
            {
                throw new DewpointCannotBeHigherThanDryBulbTemperature();
            }
            else
            {
                this._DbT = DbDegF;
                this._Td = TdDegF;

                this._P = CalcAtmPressurePsia(this._alt);
                this._PinHg = CalcAtmPressureInHg(this._alt);

                // Pw = Pws(Td)
                this._Pw = CalcPws(TdDegF);
                this._W = CalcWs(this._Pw, this._P);
                this._PwsDb = CalcPws(DbDegF);
                this._WsDb = CalcWs(this._PwsDb, this._P);
                this._u = CalcU(this._W, this._WsDb);

                //  If Dry-bulb = Dewpoint then RH = 1
                if (this._DbT == this._Td)
                {
                    this._RH = 1;
                }
                else
                {
                    this._RH = CalcRH(this._u, this._PwsDb, this._P);
                }

                this._v = CalcV(this._DbT, this._W, this._PinHg);
                this._h = CalcH(this._DbT, this._W);

                //  If Dry-bulb = Dewpoint then Wet-bulb = Dry-bulb
                if (this._DbT == this._Td)
                {
                    this._WbT = this._DbT;
                }
                else
                {
                    this._WbT = FindWbT(this._DbT, this._Td, this._W, this._P);
                }

                this._m = CalcM(this._v, this._flowRate);
            }

        }

        /// <summary>
        /// Calculate all air properties using Dry-Bulb T [Deg. F] and Absolute water content of air [grains(a)/lb(da)]
        /// </summary>
        /// <param name="DbDegF">Dry-Bulb Temperature [Deg. F]</param>
        /// <param name="grains">Absolute water content of air [grains(a)/lb(da)]</param>
        public void CalcAllUsingDbGrains(decimal DbDegF, decimal grains)
        {
            decimal RH = 0;
            decimal W = grains / 7000;
            decimal P = CalcAtmPressurePsia(this._alt);
            decimal PwsDb = CalcPws(DbDegF);
            decimal Ws = CalcWs(PwsDb, P);
            decimal u = CalcU(W, Ws);
            RH = CalcRH(u, PwsDb, P);

            CalcAllUsingDbRH(DbDegF, RH);
        }
        #endregion
        #region Supporting Methods.

        /// <summary>
        /// Calculate Pressure of Saturated Pure Water(Pws) [psia]
        /// </summary>
        /// <param name="TDegF">Temperature [Deg. F]</param>
        /// <returns>Pressure of Saturated Pure Water(Pws) [psia]</returns>
        protected static decimal CalcPws(decimal TDegF)
        {
            //See ASHRAE Fundamentals 2005 Chapter 6

            //declare ASHRAE 2005 constants 
            decimal C1 = Convert.ToDecimal(-1.0214165e4);
            decimal C2 = Convert.ToDecimal(-4.8932428e0);
            decimal C3 = Convert.ToDecimal(-5.3765794e-3);
            decimal C4 = Convert.ToDecimal(1.9202377e-7);
            decimal C5 = Convert.ToDecimal(3.5575832e-10);
            decimal C6 = Convert.ToDecimal(-9.0344688e-14);
            decimal C7 = Convert.ToDecimal(4.1635019e0);

            decimal C8 = Convert.ToDecimal(-1.0440397e4);
            decimal C9 = Convert.ToDecimal(-1.1294650e1);
            decimal C10 = Convert.ToDecimal(-2.7022355e-2);
            decimal C11 = Convert.ToDecimal(1.2890360e-5);
            decimal C12 = Convert.ToDecimal(-2.4780681e-9);
            decimal C13 = Convert.ToDecimal(6.5459673e0);

            //local variables
            decimal Pws = 0;
            decimal lnPws = 0;

            //Convert into absolute temperature
            decimal TDegR = DegFahrToR(TDegF);

            if (TDegR >= Convert.ToDecimal(311.67) && TDegR <= Convert.ToDecimal(491.67))
            {
                //ASHRAE Eq.(5)

                lnPws = (C1 / TDegR) + C2 + (C3 * TDegR) + (C4 * (decimal)Math.Pow((double)TDegR, 2)) +
                    (C5 * (decimal)Math.Pow((double)TDegR, 3)) + (C6 * (decimal)Math.Pow((double)TDegR, 4)) + (C7 * (decimal)Math.Log((double)TDegR));

                Pws = (decimal)Math.Exp((double)lnPws);

                return Pws;
            }
            else if (TDegR > Convert.ToDecimal(491.67) && TDegR <= Convert.ToDecimal(851.67))
            {
                //ASHRAE Eq. (6)
                lnPws = (C8 / TDegR) + C9 + (C10 * TDegR) + (C11 * (decimal)Math.Pow((double)TDegR, 2)) +
                    (C12 * (decimal)Math.Pow((double)TDegR, 3)) + (C13 * (decimal)Math.Log((double)TDegR));

                Pws = (decimal)Math.Exp((double)lnPws);

                return Pws;
            }
            else
            {
                throw new TemperatureOutOfRangeException();
            }
        }

        /// <summary>
        /// Calculate Humidity Ratio of Moist air at saturation (Ws or Ws*)  [lbH2O/lbAIR]
        /// using Pressure of Saturated Pure Water (Pws(t) or Pws(t*)) [psia] and pressure [psia]
        /// </summary>
        /// <param name="PwsPsia">Pressure of Saturated Pure Water(Pws) [psia]</param>
        /// <param name="PInPsia">Pressure [psia]</param>
        /// <returns>Humidity Ratio of Moist air at saturation (Ws) [lbH2O/lbAIR]</returns>
        protected static decimal CalcWs(decimal PwsPsia, decimal PInPsia)
        {
            //ASHRAE Eq. (23)
            decimal Ws;
            Ws = (Convert.ToDecimal(0.621945) * ((PwsPsia) / (PInPsia - PwsPsia)));

            if (Ws <= 0)
            {
                throw new WsOutOfRangeException();
            }
            else
            {
                return Ws;
            }
        }

        /// <summary>
        /// Calculate Air Humidity Ratio (W) [lbH2O/lbAIR]
        /// </summary>
        /// <param name="DbDegF">Dry Bulb Temperature [Deg. F]</param>
        /// <param name="WbDegF">Wet Bulb Temperature [Deg. F]</param>
        /// <param name="WsWb">Humidity Ratio of Moist air at saturation for 
        /// Wet Bulb Temperature [lbH2O/lbAIR]</param>
        /// <returns>Air Humidity Ratio (W) [lbH2O/lbAIR]</returns>
        protected static decimal CalcW(decimal DbDegF, decimal WbDegF, decimal WsWb)
        {
            //ASHRAE Eq. (35)
            return (((1093 - (Convert.ToDecimal(0.556) * WbDegF)) * WsWb) - (Convert.ToDecimal(0.240) * (DbDegF - WbDegF))) /
                (1093 + (Convert.ToDecimal(0.444) * DbDegF) - WbDegF);
        }

        /// <summary>
        /// Calculate Degree of Saturation (u) using Ws and W
        /// </summary>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <param name="WsDb">Humidity Ratio of Moist air at saturation for 
        /// Wet Bulb Temperature [lbH2O/lbAIR]</param>
        /// <returns>Degree of Saturation (u) [unitless decimal]</returns>
        protected static decimal CalcU(decimal W, decimal WsDb)
        {
            //ASHRAE Eq. (12)
            decimal u;
            u = W / WsDb;
            if (u <= 0)
            {
                throw new DegreeOfSaturationOutOfRangeException();
            }
            else if (u > 1)
            {
                //  Instead of throwing an exception when u > 1 simply return u = 1.
                u = 1;
                return u;
            }
            else
            {
                return u;
            }
        }

        /// <summary>
        /// Calculate Relative Humidity [decimal form] using u and Pws and P
        /// </summary>
        /// <param name="u">Degree of Saturation (u) [unitless decimal]</param>
        /// <param name="PwsDb">Pressure of Saturated Pure Water(Pws) [psia] at Dry Bulb Temperature</param>
        /// <param name="PInPsia">Atmospheric Pressure (p) [psia]</param>
        /// <returns>Relative Humidity [decimal form]</returns>
        protected static decimal CalcRH(decimal u, decimal PwsDb, decimal PInPsia)
        {
            //ASHRAE Eq. (25)
            decimal RH;
            RH = u / (1 - ((1 - u) * (PwsDb / PInPsia)));

            if (RH < 0 || RH > 1)
            {
                throw new RHOutOfRangeException();
            }
            else
            {
                return RH;
            }
        }

        /// <summary>
        /// Calculate Specific Volume [ft3/lb] using Dry Bulb Temperature (DbDegF) [Deg. F] 
        /// and Air Humidity Ratio (W) [lbH2O/lbAIR]
        /// </summary>
        /// <param name="DbDegF">Dry Bulb Temperature (DbDegF) [Deg. F]</param>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <param name="PInHg">Atmospheric Pressure [inHg]</param>
        /// <returns>Specific Volume (v) [ft3/lb]</returns>
        protected static decimal CalcV(decimal DbDegF, decimal W, decimal PInHg)
        {
            decimal v;
            v = (Convert.ToDecimal(0.7543) * (DbDegF + Convert.ToDecimal(459.67)) * (1 + (Convert.ToDecimal(1.6078) * W))) / PInHg;
            if (v <= 0)
            {
                throw new ImpossibleSpecificVolume();
            }
            else
            {
                return v;
            }
        }

        /// <summary>
        /// Calculate Enthalpy of Moist Air [Btu/lb]
        /// </summary>
        /// <param name="DbDegF">Dry Bulb Temperature (DbDegF) [Deg. F]</param>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <returns>Enthalpy of Moist Air (h) [Btu/lb]</returns>
        protected static decimal CalcH(decimal DbDegF, decimal W)
        {
            //ASHRAE Eq. (32)
            // NOTE: This is relative enthalpy so it can be negative.
            return (Convert.ToDecimal(0.240) * DbDegF) + (W * (1061 + (Convert.ToDecimal(0.444) * DbDegF)));
        }

        /// <summary>
        /// Calculate Partial Pressure of Water Vapor in moist air [psia] using 
        /// Atmospheric Pressure (p) [psia] and Air Humidity Ratio (W) [lbH2O/lbAIR]
        /// </summary>
        /// <param name="PInPsia">Atmospheric Pressure (p) [psia]</param>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <returns>Partial Pressure of Water Vapor in moist air (Pw) [psia]</returns>
        protected static decimal CalcPw(decimal PInPsia, decimal W)
        {
            //ASHRAE Eq. (36)
            decimal Pw;
            Pw = (PInPsia * W) / (Convert.ToDecimal(0.62198) + W);

            if (Pw < 0)
            {
                throw new PwOutOfRangeException();
            }
            else
            {
                return Pw;
            }
        }

        /// <summary>
        /// Calculate Dew-Point Temperature [Deg. F] using Wet Bulb Temperature [Deg. F] 
        /// and Partial Pressure of Water Vapor in moist air (Pw) [psia]
        /// </summary>
        /// <param name="Pw">Partial Pressure of Water Vapor in moist air (Pw) [psia]</param>
        /// <param name="WbDegF">Wet Bulb Temperature [Deg. F]</param>
        /// <returns>Dew Point Temperature [Deg. F]</returns>
        protected static decimal CalcTd(decimal Pw, decimal WbDegF)
        {
            /* Although not exact, the following control statement aims to select
             * the appropriate formula to calculate the dew point
             * */
            decimal a = (decimal)Math.Log((double)Pw);

            if (WbDegF >= 32 && WbDegF <= 200)
            {
                //ASHRAE Eq. (37)
                //ASHRAE Constants
                decimal C14 = Convert.ToDecimal(100.45);
                decimal C15 = Convert.ToDecimal(33.193);
                decimal C16 = Convert.ToDecimal(2.319);
                decimal C17 = Convert.ToDecimal(0.17074);
                decimal C18 = Convert.ToDecimal(1.2063);

                return C14 + (C15 * a) + (C16 * (decimal)Math.Pow((double)a, 2))
                    + (C17 * (decimal)Math.Pow((double)a, 3)) + (C18 * (decimal)Math.Pow((double)Pw, 0.1984));
            }
            else if (WbDegF < 32)
            {
                return Convert.ToDecimal(90.12) + (Convert.ToDecimal(26.412) * a) + (Convert.ToDecimal(0.8927) * (decimal)Math.Pow((double)a, 2));
            }
            else
            {
                throw new DewpointCannotBeCalculatedWithInputTemperature();
            }
        }

        /// <summary>
        /// Estimates Td using sequencial iteration (very precise)
        /// </summary>
        /// <param name="DbDegF">Dry Bulb Temperature [Deg. F]</param>
        /// <param name="TdDegF">Dew Point Temperature [Deg. F]</param>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <param name="PInPsia">Atmospheric Pressure (p) [psia]</param>
        /// <returns>Wet Bulb Temperature [Deg. F]</returns>
        protected static decimal FindWbT(decimal DbDegF, decimal TdDegF, decimal W, decimal PInPsia)
        {
            if (TdDegF > DbDegF)
            {
                throw new DewpointCannotBeHigherThanDryBulbTemperature();
            }
            else
            {
                decimal TdPrime = 0;
                decimal PwsWbPrime;
                decimal WsWbPrime;
                decimal WPrime = 0;
                decimal PwPrime;

                decimal ProposedTemp;
                ProposedTemp = TdDegF;

                decimal incrementFactor = 1;

                while ((W - WPrime) > 0)
                {
                    incrementFactor = (decimal)Math.Max(Math.Abs(((double)DbDegF - (double)TdPrime) / 1000), 0.0001);

                    PwsWbPrime = CalcPws(ProposedTemp);
                    WsWbPrime = CalcWs(PwsWbPrime, PInPsia);
                    WPrime = CalcW(DbDegF, ProposedTemp, WsWbPrime);

                    while (WPrime < 0)
                    {
                        incrementFactor = (decimal)Math.Max(Math.Abs(((double)DbDegF - (double)TdPrime) / 100), 0.001);

                        PwsWbPrime = CalcPws(ProposedTemp);
                        WsWbPrime = CalcWs(PwsWbPrime, PInPsia);
                        WPrime = CalcW(DbDegF, ProposedTemp, WsWbPrime);

                        ProposedTemp += incrementFactor;

                        //  The Wet-bulb temperature cannot be greater than the dry-bulb temperature
                        if (ProposedTemp > DbDegF)
                        {
                            ProposedTemp = DbDegF;
                            break;
                        }
                    }

                    PwPrime = CalcPw(PInPsia, WPrime);
                    TdPrime = CalcTd(PwPrime, ProposedTemp);

                    ProposedTemp += incrementFactor;

                    //  The Wet-bulb temperature cannot be greater than the dry-bulb temperature
                    if (ProposedTemp > DbDegF)
                    {
                        ProposedTemp = DbDegF;
                        break;
                    }
                }

                decimal WbT = ProposedTemp - incrementFactor;

                if (WbT > DbDegF)
                {
                    //WbT = DbDegF;
                    //return WbT;

                    throw new WetBulbTemperatureCannotBeGreaterThanDryBulb();
                }
                else
                {
                    return WbT;
                }
            }
        }

        /// <summary>
        /// Calculates mass of point.
        /// </summary>
        /// <param name="SpecificVolume">Specific Volume [ft3/lb]</param>
        /// <param name="FlowRate">Flow Rate [ft3/min]</param>
        /// <returns>Mass [lb/min]</returns>
        protected static decimal CalcM(decimal SpecificVolume, decimal FlowRate)
        {
            if (SpecificVolume <= 0)
            {
                throw new ImpossibleSpecificVolume();
            }
            else
            {
                return FlowRate / SpecificVolume;
            }
        }

        /// <summary>
        /// Calculate Atmospheric Pressure [psia] based on Altitude [ft]
        /// </summary>
        /// <param name="AltitudeInFt">Altitude [ft]</param>
        /// <returns>Atmospheric Pressure (p) [psia]</returns>
        protected static decimal CalcAtmPressurePsia(decimal AltitudeInFt)
        {
            //NASA 1976
            decimal PinHg;
            PinHg = (decimal)29.92 * (decimal)(Math.Pow((1 - (6.8753e-6 * (double)AltitudeInFt)), 5.2559));

            if (PinHg < 0)
            {
                throw new ImpossibleAbsolutePressureValue();
            }
            else
            {
                //To psia
                return PinHg * Convert.ToDecimal(0.491154);
            }
        }

        /// <summary>
        /// Calculate Atmospheric Pressure [inHg] based on Altitude [ft]
        /// </summary>
        /// <param name="AltitudeInFt">Altitude [ft]</param>
        /// <returns>Atmospheric Pressure [inHg]</returns>
        protected static decimal CalcAtmPressureInHg(decimal AltitudeInFt)
        {
            // NASA 1976
            decimal P;
            P = (decimal)29.92 * (decimal)(Math.Pow((1 - ((6.8753e-6) * (double)AltitudeInFt)), 5.2559));

            if (P < 0)
            {
                throw new ImpossibleAbsolutePressureValue();
            }
            else
            {
                return P;
            }
        }

        /// <summary>
        /// Converts Degrees Fahrenheit to Rankines
        /// </summary>
        /// <param name="DegF">Degrees Fahrenheit</param>
        /// <returns>Rankines</returns>
        protected static decimal DegFahrToR(decimal DegF)
        {
            return DegF + (decimal)459.67;
        }

        #endregion
    }
}