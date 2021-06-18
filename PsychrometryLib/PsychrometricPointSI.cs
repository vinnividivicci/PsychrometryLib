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

namespace PsychrometryLib
{
    /// <summary>
    /// Class model of a psychrometric point in SI units.
    /// </summary>
    public class PsychrometricPointSI
    {
        /*************************************
        //Declare all protected class members.
         *************************************/

        /// <summary>
        /// Protected class member, Altitude [m]
        /// </summary>
        protected double _alt = 0;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [Pa] at dry-bulb temperature [Deg. C]
        /// </summary>
        protected double _PwsDb;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [Pa] at wet-bulb temperature [Deg. C]
        /// </summary>
        protected double _PwsWb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [kgH2O/kgAIR] at dry-bulb temperature [Deg. C]
        /// </summary>
        protected double _WsDb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [kgH2O/kgAIR] at wet-bulb temperature [Deg. C]
        /// </summary>
        protected double _WsWb;

        /// <summary>
        /// Protected class member, Humidity Ratio [kgH2O/kgAIR]
        /// </summary>
        protected double _W;

        /// <summary>
        /// Protected class member, Degree of Saturation [unitless decimal]
        /// </summary>
        protected double _u;

        /// <summary>
        /// Protected class member, Relative Humidity [unitless decimal]
        /// </summary>
        protected double _RH;

        /// <summary>
        /// Protected class member, Specific Volume [m3/kg]
        /// </summary>
        protected double _v;

        /// <summary>
        /// Protected class member, Specific Enthalpy [kJ/kgDryAir]
        /// </summary>
        protected double _h;

        /// <summary>
        /// Protected class member, Water Vapor Partial Pressure [kPa]
        /// </summary>
        protected double _Pw;

        /// <summary>
        /// Protected class member, Dewpoint Temperature [Deg. C]
        /// </summary>
        protected double _Td;

        /// <summary>
        /// Protected class member, Atmospheric Pressure [kPa]
        /// </summary>
        protected double _P;

        /// <summary>
        /// Protected class member, Dry-bulb Temperature [Deg. C]
        /// </summary>
        protected double _DbT;

        /// <summary>
        /// Protected class member, Wet-bulb Temperature [Deg. C]
        /// </summary>
        protected double _WbT;

        /// <summary>
        /// Protected class member, Flow Rate [L/s]
        /// </summary>
        protected double _flowRate = 0;

        /// <summary>
        /// Protected class member, Mass [kg]
        /// </summary>
        protected double _m;

        #region Getters and Setters

        ///<summary>
        ///Altitude [m]
        /// </summary>
        public double AltitudeInMeters
        {
            //  Altitude only needs to be set upon instantiation
            get
            {
                return this._alt;
            }
        }

        /// <summary>
        /// Humidity Ratio (W) [kgH2O/kgAIR]
        /// </summary>
        public double HumidityRatio
        {
            get
            {
                return this._W;
            }
        }

        /// <summary>
        /// Humidity Ratio (W) [gH2O/kgAIR]
        /// </summary>
        public double HumidityRatioGramsPerKilogram
        {
            get
            {
                return this._W * 1000;
            }
        }

        /// <summary>
        /// Relative Humidity in percentage form
        /// </summary>
        public double RelativeHumidityPercentage
        {
            get
            {
                return this._RH * 100;
            }
        }

        /// <summary>
        /// Relative Humidity in decimal form
        /// </summary>
        public double RelativeHumidityDecimal
        {
            get
            {
                return this._RH;
            }
        }

        /// <summary>
        /// Specific Volume [m3/kg]
        /// </summary>
        public double SpecificVolume
        {
            get
            {
                return this._v;
            }
        }

        /// <summary>
        /// Returns Enthalpy [kJ/kg]
        /// </summary>
        public double Enthalpy
        {
            get
            {
                return this._h;
            }
        }

        /// <summary>
        /// Dew Point Temperature [Deg. C]
        /// </summary>
        public double DewPointTemperature
        {
            get
            {
                return this._Td;
            }
        }

        /// <summary>
        /// Atmospheric Pressure [Pa]
        /// </summary>
        public double AtmosphericPressurePa
        {
            get
            {
                return this._P;
            }
        }

        /// <summary>
        /// Atmospheric Pressure [kPa]
        /// </summary>
        public double AtmosphericPressureKPa
        {
            get
            {
                return this._P / 1000;
            }
        }

        /// <summary>
        /// Dry Bulb Temperature [Deg. C]
        /// </summary>
        public double DryBulbTemperature
        {
            get
            {
                return this._DbT;
            }
        }

        /// <summary>
        /// Wet Bulb Temperature [Deg. C]
        /// </summary>
        public double WetBulbTemperature
        {
            get
            {
                return this._WbT;
            }
        }

        /// <summary>
        /// Massic Flow [kg/s]
        /// </summary>
        public double MassicFlowKilogramsPerSecond
        {
            get
            {
                return this._m;
            }
        }

        /// <summary>
        /// Air Flow Rate [L/s]
        /// </summary>
        public double VolumetricFlowRateLitersPerSecond
        {
            get
            {
                return this._flowRate;
            }
        }

        #endregion
        #region Constructors

        /// <summary>
        /// Default Constructor. Uses a see level altitude [0 m] to initialize the object.
        /// </summary>
        public PsychrometricPointSI() { }

        /// <summary>
        /// Secondary constructor. Uses the input supplied by the programmer to initialize it's altitude.
        /// </summary>
        /// <param name="Altitude">Programmer-supplied altitude value in meters.</param>
        public PsychrometricPointSI(double Altitude)
        {
            //user has initialized altitude.
            this._alt = Altitude;
        }

        /// <summary>
        /// Terciary Constructor. Uses the input supplied by the programmer to initialize it's altitude
        /// and it's Flow Rate.
        /// </summary>
        /// <param name="Altitude">Altitude [m]</param>
        /// <param name="FlowRateLitersPerSecond">Flow Rate [L/s]</param>
        public PsychrometricPointSI(double Altitude, double FlowRateLitersPerSecond)
        {
            this._alt = Altitude;
            this._flowRate = FlowRateLitersPerSecond;
        }

        #endregion
        #region Interface Methods

        /***********************************
         * These are the only public methods
         ***********************************/

        /// <summary>
        /// Calculate all air properties using Dry-Bulb T [Deg. C] and Wet-Bulb T [Deg. C]
        /// </summary>
        /// <param name="DbDegC">Dry-Bulb Temperature [Deg. C]</param>
        /// <param name="WbDegC">Wet-Bulb Temperature [Deg. C]</param>
        public void CalcAllUsingDbWb(double DbDegC, double WbDegC)
        {
            if (WbDegC > DbDegC)
            {
                throw new WetBulbTemperatureCannotBeGreaterThanDryBulb();
            }
            else
            {
                this._DbT = DbDegC;
                this._WbT = WbDegC;

                this._P = CalcAtmPressurePa(_alt);

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

                this._v = CalcV(this._DbT, this._W, this._P);
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
        /// Calculate all air properties using Dry-Bulb T [Deg. C] and Relative Humidity [Unitless Decimal]
        /// </summary>
        /// <param name="DbDegC">Dry-Bulb Temperature [Deg. C]</param>
        /// <param name="RhDecimal">Relative Humidity [Unitless Decimal]</param>
        public void CalcAllUsingDbRH(double DbDegC, double RhDecimal)
        {
            if (RhDecimal > 1 || RhDecimal < 0)
            {
                throw new RHOutOfRangeException();
            }
            else
            {
                this._DbT = DbDegC;
                this._RH = RhDecimal;

                this._P = CalcAtmPressurePa(_alt);

                this._PwsDb = CalcPws(this._DbT);
                this._Pw = this._RH * this._PwsDb;
                this._W = CalcWs(this._Pw, this._P);
                this._WsDb = CalcWs(this._PwsDb, this._P);
                this._u = CalcU(this._W, this._WsDb);
                this._v = CalcV(this._DbT, this._W, this._P);
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
        /// Calculate all air properties using Dry-Bulb T [Deg. C] and Dew-Point T [Deg. C]
        /// </summary>
        /// <param name="DbDegC">Dry-Bulb Temperature [Deg. C]</param>
        /// <param name="TdDegC">Dew-Point Temperature [Deg. C]</param>
        public void CalcAllUsingDbTd(double DbDegC, double TdDegC)
        {
            if (TdDegC > DbDegC)
            {
                throw new DewpointCannotBeHigherThanDryBulbTemperature();
            }
            else
            {
                this._DbT = DbDegC;
                this._Td = TdDegC;

                this._P = CalcAtmPressurePa(this._alt);

                // Pw = Pws(Td)
                this._Pw = CalcPws(TdDegC);
                this._W = CalcWs(this._Pw, this._P);
                this._PwsDb = CalcPws(DbDegC);
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

                this._v = CalcV(this._DbT, this._W, this._P);
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
        /// Calculate all air properties using Dry-Bulb T [Deg. C] and Absolute water content of air [grams(a)/kg(da)]
        /// </summary>
        /// <param name="DbDegC">Dry-Bulb Temperature [Deg. C]</param>
        /// <param name="grams">Absolute water content of air [grams(a)/kg(da)]</param>
        public void CalcAllUsingDbGrams(double DbDegC, double grams)
        {
            double RH = 0;
            double W = grams / 1000;
            double P = CalcAtmPressurePa(this._alt);
            double PwsDb = CalcPws(DbDegC);
            double Ws = CalcWs(PwsDb, P);
            double u = CalcU(W, Ws);
            RH = CalcRH(u, PwsDb, P);

            CalcAllUsingDbRH(DbDegC, RH);
        }
        #endregion


        #region Supporting Methods

        /// <summary>
        /// Calculate Pressure of Saturated Pure Water(Pws) [Pa]
        /// </summary>
        /// <param name="TDegC">Temperature [Deg. C]</param>
        /// <returns>Pressure of Saturated Pure Water(Pws) [Pa]</returns>
        protected static double CalcPws(double TDegC)
        {
            //See ASHRAE Fundamentals 2005 Chapter 6

            //declare ASHRAE 2005 constants 
            double C1 = -5.6745359e3;
            double C2 = 6.3925247e0;
            double C3 = -9.677843e-3;
            double C4 = 6.2215701e-7;
            double C5 = 2.0747825e-9;
            double C6 = -9.484024e-13;
            double C7 = 4.1635019e0;

            double C8 = -5.8002206e+3;
            double C9 = 1.3914993e0;
            double C10 = -4.8640239e-2;
            double C11 = 4.1764768e-5;
            double C12 = -1.4452093e-8;
            double C13 = 6.5459673e0;

            //local variables
            double Pws = 0;
            double lnPws = 0;

            //Convert into absolute temperature
            double TDegK = DegCToK(TDegC);

            if (TDegK >= 173.15 && TDegK <= 273.15)
            {
                //ASHRAE Eq.(5)

                lnPws = (C1 / TDegK) + C2 + (C3 * TDegK) + (C4 * Math.Pow(TDegK, 2)) +
                    (C5 * Math.Pow(TDegK, 3)) + (C6 * Math.Pow(TDegK, 4)) + (C7 * Math.Log(TDegK));

                Pws = Math.Exp(lnPws);

                return Pws;
            }
            else if (TDegK > 273.15 && TDegK <= 473.15)
            {
                //ASHRAE Eq. (6)
                lnPws = (C8 / TDegK) + C9 + (C10 * TDegK) + (C11 * Math.Pow(TDegK, 2)) +
                    (C12 * Math.Pow(TDegK, 3)) + (C13 * Math.Log(TDegK));

                Pws = Math.Exp(lnPws);

                return Pws;
            }
            else
            {
                throw new TemperatureOutOfRangeException();
            }
        }

        /// <summary>
        /// Calculate Humidity Ratio of Moist air at saturation (Ws or Ws*)  [kgH2O/kgAIR]
        /// using Pressure of Saturated Pure Water (Pws(t) or Pws(t*)) [Pa] and pressure [Pa]
        /// </summary>
        /// <param name="PwsInPa">Pressure of Saturated Pure Water(Pws) [Pa]</param>
        /// <param name="PInPa">Pressure [Pa]</param>
        /// <returns>Humidity Ratio of Moist air at saturation (Ws) [kgH2O/kgAIR]</returns>
        protected static double CalcWs(double PwsInPa, double PInPa)
        {
            //ASHRAE Eq. (23)
            double Ws;
            Ws = (0.621945 * ((PwsInPa) / (PInPa - PwsInPa)));

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
        /// Calculate Air Humidity Ratio (W) [kgH2O/kgAIR]
        /// </summary>
        /// <param name="DbDegC">Dry Bulb Temperature [Deg. C]</param>
        /// <param name="WbDegC">Wet Bulb Temperature [Deg. C]</param>
        /// <param name="WsWb">Humidity Ratio of Moist air at saturation for 
        /// Wet Bulb Temperature [kgH2O/kgAIR]</param>
        /// <returns>Air Humidity Ratio (W) [kgH2O/kgAIR]</returns>
        protected static double CalcW(double DbDegC, double WbDegC, double WsWb)
        {
            //  This method CANNOT return an exception because it would render FindWbT useless.
            //  ASHRAE Eq. (35)
            double W;

            W = (((2501 - (2.326 * WbDegC)) * WsWb) - (1.006 * (DbDegC - WbDegC))) /
               (2501 + (1.86 * DbDegC) - (4.186 * WbDegC));

            return W;
        }

        /// <summary>
        /// Calculate Degree of Saturation (u) using Ws and W
        /// </summary>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <param name="WsDb">Humidity Ratio of Moist air at saturation for 
        /// Wet Bulb Temperature [kgH2O/kgAIR]</param>
        /// <returns>Degree of Saturation (u) [unitless decimal]</returns>
        protected static double CalcU(double W, double WsDb)
        {
            //ASHRAE Eq. (12)
            double u;
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
        /// <param name="PwsDbInPa">Pressure of Saturated Pure Water(Pws) [Pa] at Dry Bulb Temperature</param>
        /// <param name="PInPa">Atmospheric Pressure (p) [Pa]</param>
        /// <returns>Relative Humidity [decimal form]</returns>
        protected static double CalcRH(double u, double PwsDbInPa, double PInPa)
        {
            //ASHRAE Eq. (25)
            double RH;
            RH = u / (1 - ((1 - u) * (PwsDbInPa / PInPa)));

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
        /// Calculate Specific Volume [m3/kg] using Dry Bulb Temperature [Deg. C] 
        /// and Air Humidity Ratio (W) [kgH2O/kgAIR]
        /// </summary>
        /// <param name="DbDegC">Dry Bulb Temperature [Deg. C]</param>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <param name="PInPa">Atmospheric Pressure [Pa]</param>
        /// <returns>Specific Volume (v) [m3/kg]</returns>
        protected static double CalcV(double DbDegC, double W, double PInPa)
        {
            double v;
            v = (0.2871 * (DbDegC + 273.15) * (1 + (1.6078 * W))) / (PInPa / 1000);
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
        /// Calculate Enthalpy of Moist Air [kJ/kg]
        /// </summary>
        /// <param name="DbDegC">Dry Bulb Temperature [Deg. C]</param>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <returns>Enthalpy of Moist Air (h) [kJ/kg]</returns>
        protected static double CalcH(double DbDegC, double W)
        {
            //ASHRAE Eq. (32)
            // NOTE: This is relative enthalpy so it can be negative.
            return ((1.006 * DbDegC) + (W * (2501 + (1.86 * DbDegC))));
        }

        /// <summary>
        /// Calculate Partial Pressure of Water Vapor in moist air [Pa] using 
        /// Atmospheric Pressure (p) [Pa] and Air Humidity Ratio (W) [kgH2O/kgAIR]
        /// </summary>
        /// <param name="PInPa">Atmospheric Pressure (p) [Pa]</param>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <returns>Partial Pressure of Water Vapor in moist air (Pw) [Pa]</returns>
        protected static double CalcPw(double PInPa, double W)
        {
            //ASHRAE Eq. (36)
            double Pw;
            Pw = (PInPa * W) / (0.62198 + W);

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
        /// Calculate Dew-Point Temperature [Deg. C] using Wet Bulb Temperature [Deg. C] 
        /// and Partial Pressure of Water Vapor in moist air (Pw) [Pa]
        /// </summary>
        /// <param name="PwInPa">Partial Pressure of Water Vapor in moist air (Pw) [Pa]</param>
        /// <param name="WbDegC">Wet Bulb Temperature [Deg. C]</param>
        /// <returns>Dew Point Temperature [Deg. C]</returns>
        protected static double CalcTd(double PwInPa, double WbDegC)
        {
            /* Although not exact, the following control statement aims to select
             * the appropriate formula to calculate the dew point
             * */
            double PwInKpa = PwInPa / 1000;
            double a = Math.Log(PwInKpa);


            if (WbDegC >= 0 && WbDegC <= 93)
            {
                //ASHRAE Eq. (37)
                //ASHRAE Constants
                double C14 = 6.54;
                double C15 = 14.526;
                double C16 = 0.7389;
                double C17 = 0.09486;
                double C18 = 0.4569;

                return C14 + (C15 * a) + (C16 * Math.Pow(a, 2))
                    + (C17 * Math.Pow(a, 3)) + (C18 * Math.Pow(PwInKpa, 0.1984));
            }
            else if (WbDegC < 0)
            {
                return 6.09 + (12.608 * a) + (0.4959 * Math.Pow(a, 2));
            }
            else
            {
                throw new DewpointCannotBeCalculatedWithInputTemperature();
            }
        }

        /// <summary>
        /// Estimates Td using sequencial iteration (very precise)
        /// </summary>
        /// <param name="DbDegC">Dry Bulb Temperature [Deg. C]</param>
        /// <param name="TdDegC">Dew Point Temperature [Deg. C]</param>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <param name="PInPa">Atmospheric Pressure (p) [Pa]</param>
        /// <returns>Wet Bulb Temperature [Deg. C]</returns>
        protected static double FindWbT(double DbDegC, double TdDegC, double W, double PInPa)
        {
            if (TdDegC > DbDegC)
            {
                throw new DewpointCannotBeHigherThanDryBulbTemperature();
            }
            else
            {
                double TdPrime = 0;
                double PwsWbPrime;
                double WsWbPrime;
                double WPrime = 0;
                double PwPrime;

                double ProposedTemp;
                ProposedTemp = TdDegC;

                double incrementFactor = 1;

                while ((W - WPrime) > 0)
                {
                    incrementFactor = Math.Max(Math.Abs((DbDegC - TdPrime) / 1000), 0.0001);

                    PwsWbPrime = CalcPws(ProposedTemp);
                    WsWbPrime = CalcWs(PwsWbPrime, PInPa);

                    WPrime = CalcW(DbDegC, ProposedTemp, WsWbPrime);

                    //If W < 0 increment along curve until above 0;
                    while (WPrime < 0)
                    {
                        incrementFactor = Math.Max(Math.Abs((DbDegC - TdPrime) / 100), 0.001);

                        PwsWbPrime = CalcPws(ProposedTemp);
                        WsWbPrime = CalcWs(PwsWbPrime, PInPa);
                        WPrime = CalcW(DbDegC, ProposedTemp, WsWbPrime);

                        ProposedTemp += incrementFactor;

                        //  The Wet-bulb temperature cannot be greater than the dry-bulb temperature
                        if (ProposedTemp > DbDegC)
                        {
                            ProposedTemp = DbDegC;
                            break;
                        }
                    }

                    PwPrime = CalcPw(PInPa, WPrime);
                    TdPrime = CalcTd(PwPrime, ProposedTemp);

                    ProposedTemp += incrementFactor;

                    //  The Wet-bulb temperature cannot be greater than the dry-bulb temperature
                    if (ProposedTemp > DbDegC)
                    {
                        ProposedTemp = DbDegC;
                        break;
                    }
                }

                double WbT = ProposedTemp - incrementFactor;

                if (WbT > DbDegC)
                {
                    //WbT = DbDegC;
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
        /// Calculates Massic Flow Rate Based on given Specific Volume [m3/kg] and
        /// Volumetric Flow Rate [L/s]
        /// </summary>
        /// <param name="SpecificVolume">Specific Volume [m3/kg]</param>
        /// <param name="VolumetricFlowRate">Volumetric Flow Rate [L/s]</param>
        /// <returns>Massic Flow Rate [kg/s]</returns>
        protected static double CalcM(double SpecificVolume, double VolumetricFlowRate)
        {
            if (SpecificVolume <= 0)
            {
                throw new ImpossibleSpecificVolume();
            }
            else
            {
                //  0.028317 is a conversion factor for converting Liters to m3.
                return (VolumetricFlowRate * 0.028317) / SpecificVolume;
            }
        }

        /// <summary>
        /// Calculate Atmospheric Pressure [Pa] based on Altitude [m]
        /// </summary>
        /// <param name="AltitudeInM">Altitude [m]</param>
        /// <returns>Atmospheric Pressure (p) [Pa]</returns>
        protected static double CalcAtmPressurePa(double AltitudeInM)
        {
            return 101325 * Math.Pow(1 - 2.25577e-05 * AltitudeInM, 5.2559);
        }

        /// <summary>
        /// Converts Degrees Celsius to Kelvins
        /// </summary>
        /// <param name="DegC">Degrees Celsius</param>
        /// <returns>Rankines</returns>
        protected static double DegCToK(double DegC)
        {
            return DegC + 273.15;
        }

        #endregion
    }
}