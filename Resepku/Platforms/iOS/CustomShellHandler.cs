using System;
using CoreGraphics;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;

namespace Resepku.Platforms.iOS;

public class CustomShellRenderer : ShellRenderer
{
    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        return new CustomShellTabBarAppearanceTracker();
    }
}

public class CustomShellTabBarAppearanceTracker : IShellTabBarAppearanceTracker
{
    public void Dispose()
    {
        //throw new NotImplementedException();
    }

    public void ResetAppearance(UITabBarController controller)
    {
        //throw new NotImplementedException();
    }

    public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
    {
        //throw new NotImplementedException();
    }

    public void UpdateLayout(UITabBarController controller)
    {
        foreach (var item in controller.TabBar.Items)
        {
            var prevImage = item.Image;//.Copy() as UIImage;
            var size = new CGSize(30, 30);
            UIGraphics.BeginImageContextWithOptions(size, false, 0);
            prevImage.Draw(new CGRect(new CGPoint(0, 0), size));
            var resizeImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            item.Image = resizeImage;
        }
    }
}