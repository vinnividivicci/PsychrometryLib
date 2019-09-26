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
using System.Linq;
using System.Text;
using PsychrometryLib;

namespace PsychrometryLib
{
    /// <summary>
    /// The class PsychrometricAirMixtureSI represents a mix of two PsychrometricPointSI objects.
    /// All calculations are performed in their respective native units [SI].
    /// </summary>
    public class PsychrometricAirMixtureSI : PsychrometricPointSI 
    {
        #region Private Variables

        #endregion
        #region Getters/Setters



        #endregion
        #region Constructors

        /// <summary>
        /// Create an air mixture using two PsychrometricPoints [SI Units] and calculate
        /// the results.
        /// </summary>
        /// <param name="p1">First PsychrometricPoint [SI Units] for mixture.</param>
        /// <param name="p2">Second PsychrometricPoint [SI Units] for mixture.</param>
        public PsychrometricAirMixtureSI(PsychrometricPointSI p1, PsychrometricPointSI p2)
        {
            CalcMixture(p1, p2);
        }

        #endregion
        #region Supporting Methods

        /// <summary>
        /// Calculate all properties for the mixture [SI Units]
        /// </summary>
        /// <param name="p1">First PsychrometricPoint [SI Units] for mixture.</param>
        /// <param name="p2">Second PsychrometricPoint [SI Units] for mixture.</param>
        private void CalcMixture(PsychrometricPointSI p1, PsychrometricPointSI p2)
        {
            //  Check for invalid values
            if (p1.VolumetricFlowRateLitersPerSecond <= 0 || p2.VolumetricFlowRateLitersPerSecond <= 0)
            {
                throw new VolumeCannotBeZero();
            }
            else if (p1.MassicFlowKilogramsPerSecond <= 0 || p2.MassicFlowKilogramsPerSecond <= 0)
            {
                throw new MassCannotBeZero();
            }

            //  Add flow rates  to get total flow rate
            double totalFlowRate = p1.VolumetricFlowRateLitersPerSecond + p2.VolumetricFlowRateLitersPerSecond;
            this._flowRate = totalFlowRate;

            //  Assign altitude from point 1.
            this._alt = p1.AltitudeInMeters;

            //  Calculate Dry-Bulb Temperature of the mix
            double Db = GenericMassRatio(p1.DryBulbTemperature, p1.MassicFlowKilogramsPerSecond,
                p2.DryBulbTemperature, p2.MassicFlowKilogramsPerSecond);

            //  Calculate Wet-Bulb Temperature of the mix
            double Wb = GenericMassRatio(p1.WetBulbTemperature, p1.MassicFlowKilogramsPerSecond,
                p2.WetBulbTemperature, p2.MassicFlowKilogramsPerSecond);

            //  Calculate the mix's properties
            this.CalcAllUsingDbWb(Db, Wb);
        }

        /// <summary>
        /// Generic Mass Ratio Calculation
        /// </summary>
        /// <param name="x1">Any psychrometric value. Must be of same type as x2.</param>
        /// <param name="mass1">Mass 1</param>
        /// <param name="x2">Any psychrometric value. Must be of same type as x1.</param>
        /// <param name="mass2">Mass 2</param>
        /// <returns></returns>
        protected double GenericMassRatio(double x1, double mass1, double x2, double mass2)
        {
            return ((x1 * mass1) + (x2 * mass2)) / (mass1 + mass2);
        }
        
        #endregion
    }
}
