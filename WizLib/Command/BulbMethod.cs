﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WizLib
{
    /// <summary>
    /// Bulb method structure
    /// </summary>
    [JsonConverter(typeof(BulbMethodJsonConverter))]
    public struct BulbMethod
    {
        #region Public Fields

        /// <summary>
        /// FirstBeat Method
        /// </summary>
        /// <remarks>
        /// This method is inbound only.
        /// </remarks>
        public static readonly BulbMethod FirstBeat = new BulbMethod("firstBeat", false, true);

        /// <summary>
        /// GetPilot Method
        /// </summary>
        public static readonly BulbMethod GetPilot = new BulbMethod("getPilot", false);

        /// <summary>
        /// GetSystemConfig Method
        /// </summary>
        public static readonly BulbMethod GetSystemConfig = new BulbMethod("getSystemConfig", false);

        /// <summary>
        /// Pulse Method
        /// </summary>
        public static readonly BulbMethod Pulse = new BulbMethod("pulse", false);

        /// <summary>
        /// Registration Method
        /// </summary>
        /// <remarks>
        /// This method is a set method.
        /// </remarks>
        public static readonly BulbMethod Registration = new BulbMethod("registration", true);

        /// <summary>
        /// SetPilot Method
        /// </summary>
        /// <remarks>
        /// This method is a set method.
        /// </remarks>
        public static readonly BulbMethod SetPilot = new BulbMethod("setPilot", true);

        /// <summary>
        /// SetSystemConfig Method
        /// </summary>
        /// <remarks>
        /// This method is a set method.
        /// </remarks>
        public static readonly BulbMethod SetSystemConfig = new BulbMethod("setSystemConfig", true);

        /// <summary>
        /// SyncPilot Method
        /// </summary>
        /// <remarks>
        /// This method is inbound only.
        /// </remarks>
        public static readonly BulbMethod SyncPilot = new BulbMethod("syncPilot", false, true);

        /// <summary>
        /// All Known Methods
        /// </summary>
        public static readonly BulbMethod[] Methods = new BulbMethod[]
        {
            GetPilot,
            SetPilot,
            SyncPilot,
            FirstBeat,
            GetSystemConfig,
            SetSystemConfig,
            Pulse
        };

        #endregion Public Fields

        #region Private Fields

        bool isInboundOnly;
        bool isSetMethod;
        string mtd;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initialize a new bulb method structure
        /// </summary>
        /// <param name="mtd">Method name</param>
        /// <param name="ism">True if this is method sets a state on the bulb.</param>
        /// <param name="iio">
        /// True if this method is generated by the bulb
        /// and cannot be used in an outbound command.
        /// </param>
        public BulbMethod(string mtd, bool ism, bool iio = false)
        {
            this.mtd = mtd;
            isSetMethod = ism;
            isInboundOnly = iio;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Get a value indicating that this method is generated by the bulb
        /// and cannot be used in an outbound command.
        /// </summary>
        public bool IsInboundOnly
        {
            get => isInboundOnly;
        }

        /// <summary>
        /// Get a value indicating that this method sets a state on the bulb.
        /// </summary>
        public bool IsSetMethod
        {
            get => isSetMethod;
        }
        /// <summary>
        /// Gets the method text.
        /// </summary>
        public string Method
        {
            get => mtd;
        }

        #endregion Public Properties

        #region Public Methods

        public static explicit operator BulbMethod(string src)
        {
            var test = src.ToLower();
            foreach (var mtd in Methods)
            {
                if (mtd.mtd.ToLower() == test)
                {
                    return mtd;
                }
            }

            // we will allow for unknown methods so as
            // not to potentially break the library.
            // The specification of the controller software 
            // might change before this library is updated. 
            return new BulbMethod(src, false);
        }

        public static explicit operator string(BulbMethod src)
                    => src.mtd;
        public static bool operator !=(BulbMethod a, BulbMethod b)
        {
            return !a.Equals(b);
        }

        public static bool operator ==(BulbMethod a, BulbMethod b)
        {
            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (obj is BulbMethod m)
            {
                return m.mtd == mtd && m.isInboundOnly == isInboundOnly && m.isSetMethod == isSetMethod;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return mtd.GetHashCode();
        }

        /// <summary>
        /// Returns the method string of this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => mtd;

        #endregion Public Methods
    }

}
