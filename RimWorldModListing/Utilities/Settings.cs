using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace RimWorldModListing.Utilities
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
    {
        private static ISettings AppSettings
        {
            get => CrossSettings.Current;
        }

        public static string PageTitle
        {
            get => AppSettings.GetValueOrDefault(nameof(PageTitle), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(PageTitle), value);
        }

        public static bool Package
        {
            get => AppSettings.GetValueOrDefault(nameof(Package), false);

            set => AppSettings.AddOrUpdateValue(nameof(Package), value);
        }

        public static bool Aws
        {
            get => AppSettings.GetValueOrDefault(nameof(Aws), false);

            set => AppSettings.AddOrUpdateValue(nameof(Aws), value);
        }

        public static string Profile
        {
            get => AppSettings.GetValueOrDefault(nameof(Profile), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Profile), value);
        }

        public static string Bucket
        {
            get => AppSettings.GetValueOrDefault(nameof(Bucket), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Bucket), value);
        }

        public static string Distribution
        {
            get => AppSettings.GetValueOrDefault(nameof(Distribution), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Distribution), value);
        }

    }
}
