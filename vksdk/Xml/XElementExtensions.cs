using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace VK.Xml
{
    public static class XElementExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only for XElement")]
        public static IEnumerable<XElement> GetDescendants(this XElement element, string descendantName)
        {
            return element.Descendants(descendantName);
        }

        public static XElement GetDescendant(this XElement element, string descendantName)
        {
            return element.GetDescendants(descendantName).Single();
        }

        public static XElement FindDescendant(this XElement element, string descendantName)
        {
            return element.GetDescendants(descendantName).SingleOrDefault();
        }

        public static long FindInt64(this XElement element, string descendantName)
        {
            var descendantElement = element.FindDescendant(descendantName);
            return descendantElement == null ? 0 : descendantElement.GetInt64();
        }

        public static int FindInt32(this XElement element, string descendantName)
        {
            var descendantElement = element.FindDescendant(descendantName);
            return descendantElement == null ? 0 : descendantElement.GetInt32();
        }

        public static string FindString(this XElement element, string descendantName)
        {
            var descendantElement = element.FindDescendant(descendantName);
            return descendantElement == null ? null : descendantElement.Value;
        }

        public static bool FindBoolean(this XElement element, string descendantName)
        {
            var descendantElement = element.FindDescendant(descendantName);
            return descendantElement != null && descendantElement.GetBoolean();
        }

        public static int GetInt32(this XElement element, string descendantName)
        {
            return element.GetDescendant(descendantName).GetInt32();
        }

        public static long GetInt64(this XElement element, string descendantName)
        {
            return element.GetDescendant(descendantName).GetInt64();
        }

        public static double GetDouble(this XElement element, string descendantName)
        {
            return element.GetDescendant(descendantName).GetDouble();
        }

        public static bool GetBoolean(this XElement element, string descendantName)
        {
            return element.GetDescendant(descendantName).GetBoolean();
        }

        public static string GetString(this XElement element, string descendantName)
        {
            return element.GetDescendant(descendantName).Value;
        }

        public static int GetInt32(this XElement element)
        {
            return Int32.Parse(element.Value, CultureInfo.InvariantCulture);
        }

        public static long GetInt64(this XElement element)
        {
            return Int64.Parse(element.Value, CultureInfo.InvariantCulture);
        }

        public static double GetDouble(this XElement element)
        {
            return Double.Parse(element.Value, CultureInfo.InvariantCulture);
        }

        public static bool GetBoolean(this XElement element)
        {
            return GetInt32(element) == 1;
        }
    }
}
