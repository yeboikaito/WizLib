﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace System.Net
{
    public static class IPAddressExtensions
    {

        /// <summary>
        /// Make a copy of an <see cref="IPAddress"/>
        /// </summary>
        /// <param name="original"><see cref="IPAddress"/> object to copy.</param>
        /// <returns>A copy of original <see cref="IPAddress"/>.</returns>
        public static IPAddress Clone(this IPAddress original)
        {
            return IPAddress.Parse(original.ToString());
        }
    }
}
