using Avalonia.Controls;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.Systems.Configuration;
using Ryujinx.Ava.UI.ViewModels;
using System.Threading.Tasks;

namespace Ryujinx.Ava.UI.Windows
{
    public partial class CompatibilityListWindow : StyleableAppWindow
    {
        public static async Task Show(string titleId = null)
        {
            using CompatibilityViewModel compatWindow = new(RyujinxApp.MainWindow.ViewModel.ApplicationLibrary);
            
            await ShowAsync(new CompatibilityListWindow
            {
                DataContext = compatWindow,
                SearchBoxFlush = { Text = titleId ?? string.Empty },
                SearchBoxNormal = { Text = titleId ?? string.Empty }
            });
        }

        public CompatibilityListWindow() : base(useCustomTitleBar: true, 37)
        {
            Title = RyujinxApp.FormatTitle(LocaleKeys.CompatibilityListTitle);
            
            InitializeComponent();
            
            FlushControls.IsVisible = !ConfigurationState.Instance.ShowOldUI;
            NormalControls.IsVisible = ConfigurationState.Instance.ShowOldUI;
        }
    }
}
