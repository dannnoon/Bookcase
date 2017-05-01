using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.util
{
    class UrlImageLoader
    {
        public delegate void ImageHandler(bool success, byte[] image);
        public event ImageHandler ImageHandlerEvent;

        private WebClient client { get; set; }

        public String ImageUrl { get; set; }

        public UrlImageLoader(String url)
        {
            ImageUrl = url;
        }

        public void Load()
        {
            if (!String.IsNullOrWhiteSpace(ImageUrl))
            {
                try
                {
                    client = new WebClient();
                    var uri = new Uri(ImageUrl);

                    client.OpenReadCompleted += OnStreamOpened;
                    client.OpenReadAsync(uri);
                }
                catch
                {
                    OnImageHandlerEvent(false, null);
                }
            }
            else
            {
                OnImageHandlerEvent(false, null);
            }
        }

        private void OnStreamOpened(object sender, OpenReadCompletedEventArgs args)
        {
            var stream = args.Result;

            if (!args.Cancelled && stream != null && stream.CanRead)
            {
                try
                {
                    byte[] data = new byte[1024];

                    using (MemoryStream ms = new MemoryStream())
                    {
                        while (true)
                        {
                            int read = stream.Read(data, 0, data.Length);

                            if (read > 0)
                            {
                                ms.Write(data, 0, read);
                            }
                            else
                            {
                                data = ms.ToArray();
                                break;
                            }
                        }
                    }

                    OnImageHandlerEvent(true, data);
                }
                catch
                {
                    OnImageHandlerEvent(false, null);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Flush();
                        stream.Close();
                    }
                }
            }
            else
            {
                OnImageHandlerEvent(false, null);
            }
        }

        private void OnImageHandlerEvent(bool success, byte[] image)
        {
            ImageHandlerEvent?.Invoke(success, image);
            try
            {
                client.Dispose();
            }
            catch { }
        }
    }
}
