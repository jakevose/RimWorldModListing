using System;
using Gtk;
using System.Threading;

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
        setControlsActive(false);

        //loadModFileListings();

        //mapModsConfigToFilePaths();

        //clearOutputDirectory();

        //if (zip != null) { archiveMods(); }

        //if (aws != null) { uploadFiles(); }

        //generateHtmlListing();

        logLine(times++.ToString());

        Thread.Sleep(2000);

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
        hpaned1.Sensitive = active;
        cbPackage.Sensitive = active;
        cbAws.Sensitive = active;

        hProfile.Sensitive = cbAws.Active ? active : false;
        hBucket.Sensitive = cbAws.Active ? active : false;
        hDistribution.Sensitive = cbAws.Active ? active : false;
    }

    protected void OnAwsToggle(object sender, EventArgs e)
    { 
        hProfile.Sensitive = cbAws.Active;
        hBucket.Sensitive = cbAws.Active;
        hDistribution.Sensitive = cbAws.Active;
    }
}
