﻿using Gnios.CashBack.Api.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gnios.CashBack.Api.GenericControllers
{
    public static class IncludedEntities
    {
        public static IReadOnlyList<TypeInfo> Types;

        static IncludedEntities()
        {
            var assembly = typeof(BaseDto).GetTypeInfo().Assembly;
            var typeList = new List<TypeInfo>();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(FeatureAttribute), true).Length > 0)
                {
                    typeList.Add(type.GetTypeInfo());
                }
            }

            Types = typeList;
        }
    }
}
