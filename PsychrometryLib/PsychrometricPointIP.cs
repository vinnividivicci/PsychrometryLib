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
using System.Collections.Generic;
using System.Text;

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
        protected double _alt = 0;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [psia] at dry-bulb temperature [Deg. R]
        /// </summary>
        protected double _PwsDb;

        /// <summary>
        /// Protected class member, Water Vapor Saturation Pressure [psia] at wet-bulb temperature [Deg. R]
        /// </summary>
        protected double _PwsWb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [lbH2O/lbAIR] at dry-bulb temperature [Deg. F]
        /// </summary>
        protected double _WsDb;

        /// <summary>
        /// Protected class member, Saturation Humidity Ratio [lbH2O/lbAIR] at wet-bulb temperature [Deg. F]
        /// </summary>
        protected double _WsWb;

        /// <summary>
        /// Protected class member, Humidity Ratio [lbH2O/lbAIR]
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
        /// Protected class member, Specific Volume [ft3/lb]
        /// </summary>
        protected double _v;

        /// <summary>
        /// Protected class member, Specific Enthalpy [BTU/lbDryAir]
        /// </summary>
        protected double _h;

        /// <summary>
        /// Protected class member, Water Vapor Partial Pressure [psia]
        /// </summary>
        protected double _Pw;

        /// <summary>
        /// Protected class member, Dewpoint Temperature [Deg. F]
        /// </summary>
        protected double _Td;

        /// <summary>
        /// Protected class member, Atmospheric Pressure [psia]
        /// </summary>
        protected double _P;

        /// <summary>
        /// Protected class member, Atmospheric Pressure [inHg]
        /// </summary>
        protected double _PinHg;

        /// <summary>
        /// Protected class member, Dry-bulb Temperature [Deg. F]
        /// </summary>
        protected double _DbT;

        /// <summary>
        /// Protected class member, Wet-bulb Temperature [Deg. F]
        /// </summary>
        protected double _WbT;

        /// <summary>
        /// Protected class member, Flow Rate [ft3/min or CFM]
        /// </summary>
        protected double _flowRate = 0;

        /// <summary>
        /// Protected class member, Mass [lb]
        /// </summary>
        protected double _m;

        #region Getters and Setters
        
        ///<returns>
        ///Altitude [ft]
        /// </returns>  
        public double AltitudeInFeet
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
        public double HumidityRatioInPoundsPerPound
        {
            get
            {
                return this._W;
            }
        }

        /// <returns>
        /// Humidity Ratio [grH2O/lbAIR]
        /// </returns>
        public double HumidityRatioGrainsPerPound
        {
            get
            {
                return this._W * 7000;
            }
        }
        
        /// <returns>
        /// Relative Humidity in percentage form
        /// </returns>
        public double RelativeHumidityPercentage
        {
            get
            {
                return this._RH * 100;
            }
        }
        
        /// <returns>
        /// Relative Humidity in decimal form
        /// </returns>
        public double RelativeHumidityDecimal
        {
            get
            {
                return this._RH;
            }
        }
        
        /// <returns>
        /// Specific Volume [ft3/lb]
        /// </returns>
        public double SpecificVolumeInCubicFeetPerPound
        {
            get
            {
                return this._v;
            }
        }
        
        /// <returns>
        /// Returns Enthalpy [BTU/lb]
        /// </returns>
        public double EnthalpyInBtuPerPound
        {
            get
            {
                return this._h;
            }
        }
        
        /// <returns>
        /// Dew Point Temperature [Deg. F]
        /// </returns>
        public double DewPointTemperatureInDegF
        {
            get
            {
                return this._Td;
            }
        }
        
        /// <returns>
        /// Atmospheric Pressure [psia]
        /// </returns>
        public double AtmosphericPressurePsia
        {
            get
            {
                return this._P;
            }
        }
        
        /// <returns>
        /// Dry Bulb Temperature [Deg. F]
        /// </returns>
        public double DryBulbTemperatureInDegF
        {
            get
            {
                return this._DbT;
            }
        }
        
        /// <returns>
        /// Wet Bulb Temperature [Deg. F]
        /// </returns>
        public double WetBulbTemperatureInDegF
        {
            get
            {
                return this._WbT;
            }
        }

        /// <returns>
        /// Mass [lb/min]
        /// </returns>
        public double MassicFlowInPoundsPerMinute
        {
            get
            {
                return this._m;
            }
        }

        /// <returns>
        /// Flow Rate [CFM]
        /// </returns>
        public double VolumetricFlowRateInCFM
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
        public PsychrometricPointIP(double Altitude)
        {
            this._alt = Altitude;
        }

        /// <summary>
        /// Constructor. Uses the input supplied by the programmer to initialize altitude [ft] 
        /// and it's flow value [cfm].
        /// </summary>
        /// <param name="Altitude">Programmer-supplied altitude value in feet.</param>
        /// <param name="FlowRateCfm">Programmer-supplied Flow Rate value in CFM.</param>
        public PsychrometricPointIP(double Altitude, double FlowRateCfm)
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
        public void CalcAllUsingDbWb(double DbDegF, double WbDegF)
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
        public void CalcAllUsingDbRH(double DbDegF, double RH)
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
        public void CalcAllUsingDbTd(double DbDegF, double TdDegF)
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

        #endregion
        #region Supporting Methods.

        /// <summary>
        /// Calculate Pressure of Saturated Pure Water(Pws) [psia]
        /// </summary>
        /// <param name="TDegF">Temperature [Deg. F]</param>
        /// <returns>Pressure of Saturated Pure Water(Pws) [psia]</returns>
        protected static double CalcPws(double TDegF)
        {
            //See ASHRAE Fundamentals 2005 Chapter 6

            //declare ASHRAE 2005 constants 
            double C1 = -1.0214165e4;
            double C2 = -4.8932428e0;
            double C3 = -5.3765794e-3;
            double C4 = 1.9202377e-7;
            double C5 = 3.5575832e-10;
            double C6 = -9.0344688e-14;
            double C7 = 4.1635019e0;

            double C8 = -1.0440397e4;
            double C9 = -1.1294650e1;
            double C10 = -2.7022355e-2;
            double C11 = 1.2890360e-5;
            double C12 = -2.4780681e-9;
            double C13 = 6.5459673e0;

            //local variables
            double Pws = 0;
            double lnPws = 0;

            //Convert into absolute temperature
            double TDegR = DegFahrToR(TDegF);

            if (TDegR >= 311.67 && TDegR <= 491.67)
            {
                //ASHRAE Eq.(5)
                
                lnPws = (C1 / TDegR) + C2 + (C3 * TDegR) + (C4 * Math.Pow(TDegR, 2)) +
                    (C5 * Math.Pow(TDegR, 3)) + (C6 * Math.Pow(TDegR, 4)) + (C7 * Math.Log(TDegR));

                Pws = Math.Exp(lnPws);

                return Pws;
            }
            else if (TDegR > 491.67 && TDegR <= 851.67)
            {
                //ASHRAE Eq. (6)
                lnPws = (C8 / TDegR) + C9 + (C10 * TDegR) + (C11 * Math.Pow(TDegR, 2)) +
                    (C12 * Math.Pow(TDegR, 3)) + (C13 * Math.Log(TDegR));

                Pws = Math.Exp(lnPws);

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
        protected static double CalcWs(double PwsPsia, double PInPsia)
        { 
            //ASHRAE Eq. (23)
            double Ws;
            Ws = (0.62198 * ((PwsPsia) / (PInPsia - PwsPsia)));

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
        protected static double CalcW(double DbDegF, double WbDegF, double WsWb)
        {
            //ASHRAE Eq. (35)
            return (((1093 - (0.556 * WbDegF)) * WsWb) - (0.240 * (DbDegF - WbDegF))) / 
                (1093 + (0.444 * (DbDegF - WbDegF)));
        }

        /// <summary>
        /// Calculate Degree of Saturation (u) using Ws and W
        /// </summary>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <param name="WsDb">Humidity Ratio of Moist air at saturation for 
        /// Wet Bulb Temperature [lbH2O/lbAIR]</param>
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
        /// <param name="PwsDb">Pressure of Saturated Pure Water(Pws) [psia] at Dry Bulb Temperature</param>
        /// <param name="PInPsia">Atmospheric Pressure (p) [psia]</param>
        /// <returns>Relative Humidity [decimal form]</returns>
        protected static double CalcRH(double u, double PwsDb, double PInPsia)
        {
            //ASHRAE Eq. (25)
            double RH;
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
        protected static double CalcV(double DbDegF, double W, double PInHg)
        {
            double v;
            v = (0.7543 * (DbDegF + 459.67) * (1 + (1.6078 * W))) / PInHg;
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
        protected static double CalcH(double DbDegF, double W)
        {
            //ASHRAE Eq. (32)
            // NOTE: This is relative enthalpy so it can be negative.
            return (0.240 * DbDegF) + (W * (1061 + (0.444 * DbDegF)));
        }

        /// <summary>
        /// Calculate Partial Pressure of Water Vapor in moist air [psia] using 
        /// Atmospheric Pressure (p) [psia] and Air Humidity Ratio (W) [lbH2O/lbAIR]
        /// </summary>
        /// <param name="PInPsia">Atmospheric Pressure (p) [psia]</param>
        /// <param name="W">Air Humidity Ratio (W) [lbH2O/lbAIR]</param>
        /// <returns>Partial Pressure of Water Vapor in moist air (Pw) [psia]</returns>
        protected static double CalcPw(double PInPsia, double W)
        {
            //ASHRAE Eq. (36)
            double Pw;
            Pw = (PInPsia * W) / (0.62198 + W);

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
        protected static double CalcTd(double Pw, double WbDegF)
        {
            /* Although not exact, the following control statement aims to select
             * the appropriate formula to calculate the dew point
             * */
            double a = Math.Log(Pw);

            if (WbDegF >= 32 && WbDegF <= 200)
            {
                //ASHRAE Eq. (37)
                //ASHRAE Constants
                double C14 = 100.45;
                double C15 = 33.193;
                double C16 = 2.319;
                double C17 = 0.17074;
                double C18 = 1.2063;

                return C14 + (C15 * a) + (C16 * Math.Pow(a, 2))
                    + (C17 * Math.Pow(a, 3)) + (C18 * Math.Pow(Pw, 0.1984));
            }
            else if (WbDegF < 32)
            {
                return 90.12 + (26.412 * a) + (0.8927 * Math.Pow(a, 2));
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
        protected static double FindWbT(double DbDegF, double TdDegF, double W, double PInPsia)
        {
            if (TdDegF > DbDegF)
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
                ProposedTemp = TdDegF;

                double incrementFactor = 1;

                while ((W - WPrime) > 0)
                {
                    incrementFactor = Math.Max(Math.Abs((DbDegF - TdPrime) / 1000), 0.0001);

                    PwsWbPrime = CalcPws(ProposedTemp);
                    WsWbPrime = CalcWs(PwsWbPrime, PInPsia);
                    WPrime = CalcW(DbDegF, ProposedTemp, WsWbPrime);

                    while (WPrime < 0)
                    {
                        incrementFactor = Math.Max(Math.Abs((DbDegF - TdPrime) / 100), 0.001);

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

                double WbT = ProposedTemp - incrementFactor;

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
        protected static double CalcM(double SpecificVolume, double FlowRate)
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
        protected static double CalcAtmPressurePsia(double AltitudeInFt)
        {
            //NASA 1976
            double PinHg;
            PinHg = 29.92 * (Math.Pow((1 - ((6.8753e-6) * AltitudeInFt)), 5.2559));

            if (PinHg < 0)
            {
                throw new ImpossibleAbsolutePressureValue();
            }
            else
            {
                //To psia
                return PinHg * 0.491154;
            }
        }

        /// <summary>
        /// Calculate Atmospheric Pressure [inHg] based on Altitude [ft]
        /// </summary>
        /// <param name="AltitudeInFt">Altitude [ft]</param>
        /// <returns>Atmospheric Pressure [inHg]</returns>
        protected static double CalcAtmPressureInHg(double AltitudeInFt)
        {
            // NASA 1976
            double P;
            P = 29.92 * (Math.Pow((1 - ((6.8753e-6) * AltitudeInFt)), 5.2559));

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
        protected static double DegFahrToR(double DegF)
        {
            return DegF + 459.67;
        }

        #endregion
    }
}