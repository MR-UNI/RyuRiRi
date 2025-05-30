using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using LibHac.Fs;
using LibHac.Tools.FsSystem.NcaUtils;
using Ryujinx.Ava.Common;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.Common.Models;
using Ryujinx.Ava.Systems.AppLibrary;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Ava.UI.Views.Dialog;
using Ryujinx.Ava.UI.Windows;
using Ryujinx.Ava.Utilities;
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Helper;
using Ryujinx.HLE.HOS;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using Path = System.IO.Path;

namespace Ryujinx.Ava.UI.Controls
{
    public class ApplicationContextMenu : MenuFlyout
    {
        public ApplicationContextMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
