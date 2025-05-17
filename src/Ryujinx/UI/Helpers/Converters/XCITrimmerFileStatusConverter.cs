using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.Common.Models;
using System;
using System.Globalization;
using static Ryujinx.Common.Utilities.XCIFileTrimmer;

namespace Ryujinx.Ava.UI.Helpers
{
    internal class XCITrimmerFileStatusConverter : IValueConverter
    {
        public static XCITrimmerFileStatusConverter Instance = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UnsetValueType)
            {
                return BindingOperations.DoNothing;
            }

            if (!targetType.IsAssignableFrom(typeof(string)))
            {
                return null;
            }

            if (value is not XCITrimmerFileModel model)
            {
                return null;
            }

            return model.PercentageProgress != null ? String.Empty :
                model.ProcessingOutcome != OperationOutcome.Successful && model.ProcessingOutcome != OperationOutcome.Undetermined ? LocaleManager.Instance[LocaleKeys.TitleXCIStatusFailedLabel] :
                model.Trimmable & model.Untrimmable ? LocaleManager.Instance[LocaleKeys.TitleXCIStatusPartialLabel] :
                model.Trimmable ? LocaleManager.Instance[LocaleKeys.TitleXCIStatusTrimmableLabel] :
                model.Untrimmable ? LocaleManager.Instance[LocaleKeys.TitleXCIStatusUntrimmableLabel] :
                String.Empty;
        }

        public static string From(XCITrimmerFileModel model)
        {
            return (string)Instance.Convert(model, typeof(string), null, CultureInfo.CurrentUICulture) ?? String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
