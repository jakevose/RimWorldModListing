using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    private int times = 0;
    private object aws = null;
    private object zip = null;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnGo(object sender, EventArgs e)
    {
        //loadModFileListings();

        //mapModsConfigToFilePaths();

        //clearOutputDirectory();

        //if (zip != null) { archiveMods(); }

        //if (aws != null) { uploadFiles(); }

        //generateHtmlListing();

        logLine(times++.ToString());
    }

    private void logLine(String message)
    {
        logTextView.Buffer.Insert(logTextView.Buffer.EndIter, message + "\n");
        logTextView.ScrollToIter(logTextView.Buffer.EndIter, 0, false, 0, 0);
    }
}
