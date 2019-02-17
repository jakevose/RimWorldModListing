using Gtk;

using System;

using RimWorldModListing.Utilities;

public partial class MainWindow : Gtk.Window
{
    private ListingProcessor listingProcessor;

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

    public void LogLine(String message)
    {
        var textIter = logTextView.Buffer.EndIter;
        logTextView.Buffer.Insert(ref textIter, message + "\n");
        logTextView.ScrollToIter(logTextView.Buffer.EndIter, 0, false, 0, 0);

        while (Gtk.Application.EventsPending())
            Gtk.Application.RunIteration();
    }

    private void SetControlsActive(bool active)
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

    protected void OnButtonRelease(object sender, EventArgs e)
    {
        SetControlsActive(false);

        listingProcessor = new ListingProcessor(this,
                                                ePageTitle.Text,
                                                cbPackage.Active,
                                                cbAws.Active,
                                                eProfile.Text,
                                                eBucket.Text,
                                                eDistribution.Text);
        try {
            listingProcessor.Run();
        }
        catch (Exception ex)
        {
            LogLine(ex.Message);
            LogLine(ex.StackTrace);
        }

        SetControlsActive(true);
    }
}
