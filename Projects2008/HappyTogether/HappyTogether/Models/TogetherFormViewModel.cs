using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyTogether.Models
{
    public class TogetherFormViewModel
    {
        // Properties
        public Together Together { get; private set; }
        public SelectList TogetherTypes { get; private set; }
        public SelectList FeeTypes { get; private set; }
        // Constructor
        public TogetherFormViewModel(Together together)
        {
            Together = together;

            TogetherTypes = CreateTogetherTypes(Together.TogetherType);

            FeeTypes = CreateFeeTypes(Together.FeeType);
        }

        private static SelectList CreateTogetherTypes(TogetherTypeEnum SelectedType)
        {
            Dictionary<int, string> togetherTypes = new Dictionary<int, string>();
            foreach (int i in Enum.GetValues(typeof(TogetherTypeEnum)))
            {
                togetherTypes.Add(i, Together.GetStringFromTogetherType((TogetherTypeEnum)i));
            }
            return new SelectList(togetherTypes, "Key", "Value", (int)SelectedType);
        }

        private static SelectList CreateFeeTypes(FeeTypeEnum SelectedType)
        {
            Dictionary<int, string> feeTypes = new Dictionary<int, string>();
            foreach (int i in Enum.GetValues(typeof(FeeTypeEnum)))
            {
                feeTypes.Add(i, Together.GetStringFromFeeType((FeeTypeEnum)i));
            }
            return new SelectList(feeTypes, "Key", "Value", (int)SelectedType);
        }

        public static SelectList CreateTogetherTypesWithAll()
        {
            Dictionary<int, string> togetherTypes = new Dictionary<int, string>();
            foreach (int i in Enum.GetValues(typeof(TogetherTypeWithAllEnum)))
            {
                if (i == 0)
                {
                    togetherTypes.Add(0, "所有类型");
                }
                else
                {
                    togetherTypes.Add(i, Together.GetStringFromTogetherType((TogetherTypeEnum)i));
                }
            }
            return new SelectList(togetherTypes, "Key", "Value", (int)TogetherTypeWithAllEnum.All);
        }

    }
}
