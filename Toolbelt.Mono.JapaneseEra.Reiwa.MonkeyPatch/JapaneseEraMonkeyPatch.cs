﻿using System;
using System.Globalization;
using System.Reflection;

namespace Toolbelt.Mono.Globalization
{
    /// <summary>
    /// Mono ランタイムにおける System.Globalization.JapaneseCalendar 実装に対するモンキーパッチです。
    /// </summary>
    public static class JapaneseEraMonkeyPatch
    {
        /// <summary>
        /// Mono ランタイムにおける System.Globalization.JapaneseCalendar 実装を書き換え、和暦年号 "令和" を有効にします。
        /// </summary>
        public static void EnableReiwa()
        {
            var japaneseEraInfoField = typeof(JapaneseCalendar).GetField("japaneseEraInfo", BindingFlags.NonPublic | BindingFlags.Static);
            var typeOfEraInfo = typeof(JapaneseCalendar).Assembly.GetType("System.Globalization.EraInfo");

            const int GregorianCalendar_MaxYear = 9999;
            var eraSets = new object[][] {
                new object[] { 5, 2019, 5, 1, 2018, 1, GregorianCalendar_MaxYear - 2018, "\x4ee4\x548c", "\x4ee4", "R" },
                new object[] { 4, 1989, 1, 8, 1988, 1, 2019 - 1988, "\x5e73\x6210", "\x5e73", "H" },
                new object[] { 3, 1926, 12, 25, 1925, 1, 1989 - 1925, "\x662d\x548c", "\x662d", "S" },
                new object[] { 2, 1912, 7, 30, 1911, 1, 1926 - 1911, "\x5927\x6b63", "\x5927", "T" },
                new object[] { 1, 1868, 1, 1, 1867, 1, 1912 - 1867, "\x660e\x6cbb", "\x660e", "M" }
            };
            var eraInfoArray = Array.CreateInstance(typeOfEraInfo, eraSets.Length);
            var index = 0;
            foreach (var eraSet in eraSets)
            {
                var args = eraSet;
                var eraInfo = Activator.CreateInstance(typeOfEraInfo, BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                eraInfoArray.SetValue(eraInfo, index++);
            }
            japaneseEraInfoField.SetValue(null, eraInfoArray);
        }
    }
}
