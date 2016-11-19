using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OutsourceSystem.Common.Helpers
{
    public static class AutoMapper
    {
        public static TR Map<T, TR>(T fromModel) where TR : new()
        {
            if (fromModel == null)
            {
                return default(TR);
            }

            var result = Activator.CreateInstance<TR>();
            result.InjectFrom(fromModel);

            return result;
        }

        public static void Map<T, TR>(T fromModel, TR toModel) where TR : new()
        {
            toModel.InjectFrom(fromModel);
        }


        public static List<TR> MapList<T, TR>(IEnumerable<T> listOfSources) where TR : new()
        {
            return listOfSources?.Select(Map<T, TR>).ToList() ?? new List<TR>();
        }
    }
}