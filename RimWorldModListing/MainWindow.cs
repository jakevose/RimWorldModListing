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
        OnAwsToggle(null, null);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnGo(object sender, EventArgs e)
    {
        setControlsActive(false);

        //loadModFileListings();

        //mapModsConfigToFilePaths();

        //clearOutputDirectory();

        //if (zip != null) { archiveMods(); }

        //if (aws != null) { uploadFiles(); }

        //generateHtmlListing();

        logLine(times++.ToString());

        setControlsActive(true);
    }

    private void logLine(String message)
    {
        var textIter = logTextView.Buffer.EndIter;
        logTextView.Buffer.Insert(ref textIter, message + "\n");
        logTextView.ScrollToIter(logTextView.Buffer.EndIter, 0, false, 0, 0);
    }

    private void setControlsActive(bool active)
    {
        vbox1.Sensitive = active;

        OnAwsToggle(null, null);
    }

    protected void OnAwsToggle(object sender, EventArgs e)
    {
        var active = vbox1.Sensitive && cbAws.Active;

        hProfile.Sensitive = active;
        hBucket.Sensitive = active;
        hDistribution.Sensitive = active;
    }
}
