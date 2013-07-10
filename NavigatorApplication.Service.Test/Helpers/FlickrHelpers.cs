namespace NavigatorApplication.Service.Test.Helpers
{
    using FlickrNet;

    public static class FlickrHelpers
    {
        public static string AccessToken
        {
            get { return GetRegistryKey("AccessToken"); }
            set { SetRegistryKey("AccessToken", value); }
        }

        private static string GetRegistryKey(string name)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\FlickrNetTest", true);
            if (key != null && key.GetValue(name) != null)
                return key.GetValue(name).ToString();
            else
                return null;
        }

        private static void SetRegistryKey(string name, string value)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\FlickrNetTest", true);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\FlickrNetTest");
            key.SetValue(name, value);
        }

        public static string AccessTokenSecret
        {
            get { return GetRegistryKey("AccessTokenSecret"); }
            set { SetRegistryKey("AccessTokenSecret", value); }
        }

        public static Flickr GetAuthInstance()
        {
            var f = new Flickr();
            f.InstanceCacheDisabled = true;
            f.OAuthAccessToken = AccessToken;
            f.OAuthAccessTokenSecret = AccessTokenSecret;
            return f;
        }


    }
}
