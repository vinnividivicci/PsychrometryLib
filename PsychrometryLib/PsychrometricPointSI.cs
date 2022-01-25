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
        protected decimal _alt = 0;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [Pa] at dry-bulb temperature [Deg. C]
        /// </summary>
        protected decimal _PwsDb;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [Pa] at wet-bulb temperature [Deg. C]
        /// </summary>
        protected decimal _PwsWb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [kgH2O/kgAIR] at dry-bulb temperature [Deg. C]
        /// </summary>
        protected decimal _WsDb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [kgH2O/kgAIR] at wet-bulb temperature [Deg. C]
        /// </summary>
        protected decimal _WsWb;

        /// <summary>
        /// Protected class member, Humidity Ratio [kgH2O/kgAIR]
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
        /// Protected class member, Specific Volume [m3/kg]
        /// </summary>
        protected decimal _v;

        /// <summary>
        /// Protected class member, Specific Enthalpy [kJ/kgDryAir]
        /// </summary>
        protected decimal _h;

        /// <summary>
        /// Protected class member, Water Vapor Partial Pressure [kPa]
        /// </summary>
        protected decimal _Pw;

        /// <summary>
        /// Protected class member, Dewpoint Temperature [Deg. C]
        /// </summary>
        protected decimal _Td;

        /// <summary>
        /// Protected class member, Atmospheric Pressure [kPa]
        /// </summary>
        protected decimal _P;

        /// <summary>
        /// Protected class member, Dry-bulb Temperature [Deg. C]
        /// </summary>
        protected decimal _DbT;

        /// <summary>
        /// Protected class member, Wet-bulb Temperature [Deg. C]
        /// </summary>
        protected decimal _WbT;

        /// <summary>
        /// Protected class member, Flow Rate [L/s]
        /// </summary>
        protected decimal _flowRate = 0;

        /// <summary>
        /// Protected class member, Mass [kg]
        /// </summary>
        protected decimal _m;

        #region Getters and Setters

        ///<summary>
        ///Altitude [m]
        /// </summary>
        public decimal AltitudeInMeters
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
        public decimal HumidityRatio
        {
            get
            {
                return this._W;
            }
        }

        /// <summary>
        /// Humidity Ratio (W) [gH2O/kgAIR]
        /// </summary>
        public decimal HumidityRatioGramsPerKilogram
        {
            get
            {
                return this._W * 1000;
            }
        }

        /// <summary>
        /// Relative Humidity in percentage form
        /// </summary>
        public decimal RelativeHumidityPercentage
        {
            get
            {
                return this._RH * 100;
            }
        }

        /// <summary>
        /// Relative Humidity in decimal form
        /// </summary>
        public decimal RelativeHumidityDecimal
        {
            get
            {
                return this._RH;
            }
        }

        /// <summary>
        /// Specific Volume [m3/kg]
        /// </summary>
        public decimal SpecificVolume
        {
            get
            {
                return this._v;
            }
        }

        /// <summary>
        /// Returns Enthalpy [kJ/kg]
        /// </summary>
        public decimal Enthalpy
        {
            get
            {
                return this._h;
            }
        }

        /// <summary>
        /// Dew Point Temperature [Deg. C]
        /// </summary>
        public decimal DewPointTemperature
        {
            get
            {
                return this._Td;
            }
        }

        /// <summary>
        /// Atmospheric Pressure [Pa]
        /// </summary>
        public decimal AtmosphericPressurePa
        {
            get
            {
                return this._P;
            }
        }

        /// <summary>
        /// Atmospheric Pressure [kPa]
        /// </summary>
        public decimal AtmosphericPressureKPa
        {
            get
            {
                return this._P / 1000;
            }
        }

        /// <summary>
        /// Dry Bulb Temperature [Deg. C]
        /// </summary>
        public decimal DryBulbTemperature
        {
            get
            {
                return this._DbT;
            }
        }

        /// <summary>
        /// Wet Bulb Temperature [Deg. C]
        /// </summary>
        public decimal WetBulbTemperature
        {
            get
            {
                return this._WbT;
            }
        }

        /// <summary>
        /// Massic Flow [kg/s]
        /// </summary>
        public decimal MassicFlowKilogramsPerSecond
        {
            get
            {
                return this._m;
            }
        }

        /// <summary>
        /// Air Flow Rate [L/s]
        /// </summary>
        public decimal VolumetricFlowRateLitersPerSecond
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
        public PsychrometricPointSI(decimal Altitude)
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
        public PsychrometricPointSI(decimal Altitude, decimal FlowRateLitersPerSecond)
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
        public void CalcAllUsingDbWb(decimal DbDegC, decimal WbDegC)
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
        public void CalcAllUsingDbRH(decimal DbDegC, decimal RhDecimal)
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
        public void CalcAllUsingDbTd(decimal DbDegC, decimal TdDegC)
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
        public void CalcAllUsingDbGrams(decimal DbDegC, decimal grams)
        {
            decimal RH = 0;
            decimal W = grams / 1000;
            decimal P = CalcAtmPressurePa(this._alt);
            decimal PwsDb = CalcPws(DbDegC);
            decimal Ws = CalcWs(PwsDb, P);
            decimal u = CalcU(W, Ws);
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
        protected static decimal CalcPws(decimal TDegC)
        {
            //See ASHRAE Fundamentals 2005 Chapter 6

            //declare ASHRAE 2005 constants 
            decimal C1 = Convert.ToDecimal(-5.6745359e3);
            decimal C2 = Convert.ToDecimal(6.3925247e0);
            decimal C3 = Convert.ToDecimal(-9.677843e-3);
            decimal C4 = Convert.ToDecimal(6.2215701e-7);
            decimal C5 = Convert.ToDecimal(2.0747825e-9);
            decimal C6 = Convert.ToDecimal(-9.484024e-13);
            decimal C7 = Convert.ToDecimal(4.1635019e0);

            decimal C8 = Convert.ToDecimal(-5.8002206e+3);
            decimal C9 = Convert.ToDecimal(1.3914993e0);
            decimal C10 = Convert.ToDecimal(-4.8640239e-2);
            decimal C11 = Convert.ToDecimal(4.1764768e-5);
            decimal C12 = Convert.ToDecimal(-1.4452093e-8);
            decimal C13 = Convert.ToDecimal(6.5459673e0);

            //local variables
            decimal Pws = 0;
            decimal lnPws = 0;

            //Convert into absolute temperature
            decimal TDegK = DegCToK(TDegC);

            if (TDegK >= (decimal)173.15 && TDegK <= (decimal)273.15)
            {
                //ASHRAE Eq.(5)

                lnPws = (C1 / TDegK) + C2 + (C3 * TDegK) + (C4 * (decimal)Math.Pow((double)TDegK, 2)) +
                    (C5 * (decimal)Math.Pow((double)TDegK, 3)) + (C6 * (decimal)Math.Pow((double)TDegK, 4)) + (C7 * (decimal)Math.Log((double)TDegK));

                Pws = (decimal)Math.Exp((double)lnPws);

                return Pws;
            }
            else if (TDegK > (decimal)273.15 && TDegK <= (decimal)473.15)
            {
                //ASHRAE Eq. (6)
                lnPws = (C8 / TDegK) + C9 + (C10 * TDegK) + (C11 * (decimal)Math.Pow((double)TDegK, 2)) +
                    (C12 * (decimal)Math.Pow((double)TDegK, 3)) + (C13 * (decimal)Math.Log((double)TDegK));

                Pws = (decimal)Math.Exp((double)lnPws);

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
        protected static decimal CalcWs(decimal PwsInPa, decimal PInPa)
        {
            //ASHRAE Eq. (23)
            decimal Ws;
            Ws = ((decimal)0.621945 * ((PwsInPa) / (PInPa - PwsInPa)));

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
        protected static decimal CalcW(decimal DbDegC, decimal WbDegC, decimal WsWb)
        {
            //  This method CANNOT return an exception because it would render FindWbT useless.
            //  ASHRAE Eq. (35)
            decimal W;

            W = (((2501 - ((decimal)2.326 * WbDegC)) * WsWb) - ((decimal)1.006 * (DbDegC - WbDegC))) /
               (2501 + ((decimal)1.86 * DbDegC) - ((decimal)4.186 * WbDegC));

            return W;
        }

        /// <summary>
        /// Calculate Degree of Saturation (u) using Ws and W
        /// </summary>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <param name="WsDb">Humidity Ratio of Moist air at saturation for 
        /// Wet Bulb Temperature [kgH2O/kgAIR]</param>
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
        /// <param name="PwsDbInPa">Pressure of Saturated Pure Water(Pws) [Pa] at Dry Bulb Temperature</param>
        /// <param name="PInPa">Atmospheric Pressure (p) [Pa]</param>
        /// <returns>Relative Humidity [decimal form]</returns>
        protected static decimal CalcRH(decimal u, decimal PwsDbInPa, decimal PInPa)
        {
            //ASHRAE Eq. (25)
            decimal RH;
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
        protected static decimal CalcV(decimal DbDegC, decimal W, decimal PInPa)
        {
            decimal v;
            v = ((decimal)0.2871 * (DbDegC + (decimal)273.15) * (1 + ((decimal)1.6078 * W))) / (PInPa / 1000);
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
        protected static decimal CalcH(decimal DbDegC, decimal W)
        {
            //ASHRAE Eq. (32)
            // NOTE: This is relative enthalpy so it can be negative.
            return (((decimal)1.006 * DbDegC) + (W * (2501 + ((decimal)1.86 * DbDegC))));
        }

        /// <summary>
        /// Calculate Partial Pressure of Water Vapor in moist air [Pa] using 
        /// Atmospheric Pressure (p) [Pa] and Air Humidity Ratio (W) [kgH2O/kgAIR]
        /// </summary>
        /// <param name="PInPa">Atmospheric Pressure (p) [Pa]</param>
        /// <param name="W">Air Humidity Ratio (W) [kgH2O/kgAIR]</param>
        /// <returns>Partial Pressure of Water Vapor in moist air (Pw) [Pa]</returns>
        protected static decimal CalcPw(decimal PInPa, decimal W)
        {
            //ASHRAE Eq. (36)
            decimal Pw;
            Pw = (PInPa * W) / ((decimal)0.62198 + W);

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
        protected static decimal CalcTd(decimal PwInPa, decimal WbDegC)
        {
            /* Although not exact, the following control statement aims to select
             * the appropriate formula to calculate the dew point
             * */
            decimal PwInKpa = PwInPa / 1000;
            decimal a = (decimal)Math.Log((double)PwInKpa);


            if (WbDegC >= 0 && WbDegC <= 93)
            {
                //ASHRAE Eq. (37)
                //ASHRAE Constants
                decimal C14 = (decimal)6.54;
                decimal C15 = (decimal)14.526;
                decimal C16 = (decimal)0.7389;
                decimal C17 = (decimal)0.09486;
                decimal C18 = (decimal)0.4569;

                return C14 + (C15 * a) + (C16 * (decimal)Math.Pow((double)a, 2))
                    + (C17 * (decimal)Math.Pow((double)a, 3)) + (C18 * (decimal)Math.Pow((double)PwInKpa, 0.1984));
            }
            else if (WbDegC < 0)
            {
                return (decimal)6.09 + ((decimal)12.608 * a) + ((decimal)0.4959 * (decimal)Math.Pow((double)a, 2));
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
        protected static decimal FindWbT(decimal DbDegC, decimal TdDegC, decimal W, decimal PInPa)
        {
            if (TdDegC > DbDegC)
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
                ProposedTemp = TdDegC;

                decimal incrementFactor = 1;

                while ((W - WPrime) > 0)
                {
                    incrementFactor = (decimal)Math.Max(Math.Abs(((double)DbDegC - (double)TdPrime) / 1000), 0.0001);

                    PwsWbPrime = CalcPws(ProposedTemp);
                    WsWbPrime = CalcWs(PwsWbPrime, PInPa);

                    WPrime = CalcW(DbDegC, ProposedTemp, WsWbPrime);

                    //If W < 0 increment along curve until above 0;
                    while (WPrime < 0)
                    {
                        incrementFactor = (decimal)Math.Max(Math.Abs(((double)DbDegC - (double)TdPrime) / 100), 0.001);

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

                decimal WbT = ProposedTemp - incrementFactor;

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
        protected static decimal CalcM(decimal SpecificVolume, decimal VolumetricFlowRate)
        {
            if (SpecificVolume <= 0)
            {
                throw new ImpossibleSpecificVolume();
            }
            else
            {
                //  0.028317 is a conversion factor for converting Liters to m3.
                return (VolumetricFlowRate * (decimal)0.028317) / SpecificVolume;
            }
        }

        /// <summary>
        /// Calculate Atmospheric Pressure [Pa] based on Altitude [m]
        /// </summary>
        /// <param name="AltitudeInM">Altitude [m]</param>
        /// <returns>Atmospheric Pressure (p) [Pa]</returns>
        protected static decimal CalcAtmPressurePa(decimal AltitudeInM)
        {
            return 101325 * (decimal)Math.Pow(1 - 2.25577e-05 * (double)AltitudeInM, 5.2559);
        }

        /// <summary>
        /// Converts Degrees Celsius to Kelvins
        /// </summary>
        /// <param name="DegC">Degrees Celsius</param>
        /// <returns>Rankines</returns>
        protected static decimal DegCToK(decimal DegC)
        {
            return DegC + (decimal)273.15;
        }

        #endregion
    }
}