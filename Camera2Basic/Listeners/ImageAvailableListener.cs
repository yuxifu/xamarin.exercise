
using Android.Media;
using Android.Util;
using Java.IO;
using Java.Lang;
using Java.Nio;

namespace Camera2Basic.Listeners
{
    public class ImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
    {
        private static readonly string TAG = "ImageAvailableListener";

		int count = 1;
		public File File { get; set; } //File is the folder to save
        public Camera2BasicFragment Owner { get; set; }
        public void OnImageAvailable(ImageReader reader)
        {
            //get a new file name
            var fileToUse = new File(File, count + ".jpg");
            while (fileToUse.Exists())
			{
				count++;
                fileToUse = new File(File, count + ".jpg");
			} 
            Owner.mBackgroundHandler.Post(new ImageSaver(reader.AcquireNextImage(), fileToUse, Owner));
        }

        // Saves a JPEG {@link Image} into the specified {@link File}.
        private class ImageSaver : Java.Lang.Object, IRunnable
        {
            // The JPEG image
            private Image mImage;

            // The file we save the image into.
            private File mFile;

            public Camera2BasicFragment Owner { get; set; }

            public ImageSaver(Image image, File file, Camera2BasicFragment owner)
            {
                mImage = image;
                mFile = file;
                Owner = owner;
            }

            public void Run()
            {
                ByteBuffer buffer = mImage.GetPlanes()[0].Buffer;
                byte[] bytes = new byte[buffer.Remaining()];
                buffer.Get(bytes);
                using (var output = new FileOutputStream(mFile))
                {
                    try
                    {
                        output.Write(bytes);
						Owner.ShowToast("Saved: " + mFile);
						Log.Debug(TAG, Owner.mFile.ToString());
					}
                    catch (IOException e)
                    {
                        e.PrintStackTrace();
                    }
                    finally
                    {
                        mImage.Close();
                    }
                }
            }
        }
    }
}