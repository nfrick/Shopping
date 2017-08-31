using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

// https://stackoverflow.com/questions/793459/how-to-set-decimal-separators-in-asp-net-mvc-controllers/5117441#5117441

namespace ShoppingMVC {
    public class DecimalModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext) {
            string modelName = bindingContext.ModelName;
            string attemptedValue =
                bindingContext.ValueProvider.GetValue(modelName).AttemptedValue;

            if (bindingContext.ModelMetadata.IsNullableValueType
                && string.IsNullOrWhiteSpace(attemptedValue)) {
                return null;
            }

            if (string.IsNullOrWhiteSpace(attemptedValue)) {
                return decimal.Zero;
            }

            decimal value = decimal.Zero;
            Regex digitsOnly = new Regex(@"[^\d]", RegexOptions.Compiled);
            var numbersOnly = digitsOnly.Replace(attemptedValue, "");
            if (!string.IsNullOrWhiteSpace(numbersOnly)) {
                var numbers = Convert.ToDecimal(numbersOnly);
                value = (numbers / 100m);

                return value;
            }
            else {
                if (bindingContext.ModelMetadata.IsNullableValueType) {
                    return null;
                }

            }

            return value;
        }
    }
}