using CefSharp;
using System;

namespace ArteDraw
{ 
public class DownloadHandler : IDownloadHandler
{
    public static event EventHandler<DownloadItem> OnBeforeDownloadFired;

    public static event EventHandler<DownloadItem> OnDownloadUpdatedFired;

    public void OnBeforeDownload(IBrowser chromeBrowser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;
            if (handler != null)
            {
                handler(this, downloadItem);
            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }

        public void OnDownloadUpdated(IBrowser chromeBrowser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            var handler = OnDownloadUpdatedFired;
            if (handler != null)
            {
                handler(this, downloadItem);
            }
        }

    }
}