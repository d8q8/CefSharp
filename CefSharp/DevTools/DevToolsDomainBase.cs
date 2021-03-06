// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.


using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Browser;

namespace CefSharp.DevTools
{
    public abstract class DevToolsDomainBase
    {
        protected string EnumToString(Enum val)
        {
            var memInfo = val.GetType().GetMember(val.ToString());
            var dataMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(memInfo[0], typeof(EnumMemberAttribute), false);

            return dataMemberAttribute.Value;
        }

        protected IEnumerable<string> EnumToString(PermissionType[] values)
        {
            foreach (var val in values)
            {
                var memInfo = val.GetType().GetMember(val.ToString());
                var dataMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(memInfo[0], typeof(EnumMemberAttribute), false);

                yield return dataMemberAttribute.Value;
            }
        }

        protected string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
