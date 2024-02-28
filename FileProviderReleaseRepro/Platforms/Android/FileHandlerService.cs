using Android.Content;

namespace FileProviderReleaseRepro.FileHandlerService
{
    public partial class FileHandlerService
    {
        public partial void Test()
        {
            var context = Android.App.Application.Context;
            var path = FileSystem.Current.CacheDirectory;
            var filePath = Path.Combine(path, "test.txt");
            File.AppendAllText(filePath, "test");

            var fileUri = FileProvider.GetUriForFile(context, context.ApplicationContext.PackageName + ".fileProvider", new Java.IO.File(filePath));
            using (var intent = new Intent(Intent.ActionView))
            {
                intent.SetDataAndType(fileUri, "text/plain");
                intent.AddFlags(ActivityFlags.NewTask);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                intent.PutExtra(Intent.ExtraNotUnknownSource, true);

                Platform.CurrentActivity.StartActivity(intent);
            }
        }
    }
}
