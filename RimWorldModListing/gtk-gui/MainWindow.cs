
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.VBox vbox1;

	private global::Gtk.HPaned hpaned1;

	private global::Gtk.Label label1;

	private global::Gtk.Entry ePageTitle;

	private global::Gtk.CheckButton cbPackage;

	private global::Gtk.CheckButton cbAws;

	private global::Gtk.HPaned hProfile;

	private global::Gtk.Label lProfile;

	private global::Gtk.Entry eProfile;

	private global::Gtk.HPaned hBucket;

	private global::Gtk.Label lBucket;

	private global::Gtk.Entry eBucket;

	private global::Gtk.HPaned hDistribution;

	private global::Gtk.Label lDistribution;

	private global::Gtk.Entry eDistribution;

	private global::Gtk.Alignment alignment1;

	private global::Gtk.Button bGo;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TextView logTextView;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("RimWorld Mod Listing Generator");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 4;
		this.vbox1.BorderWidth = ((uint)(6));
		// Container child vbox1.Gtk.Box+BoxChild
		this.hpaned1 = new global::Gtk.HPaned();
		this.hpaned1.CanFocus = true;
		this.hpaned1.Name = "hpaned1";
		this.hpaned1.Position = 154;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.label1 = new global::Gtk.Label();
		this.label1.Name = "label1";
		this.label1.Xalign = 0.9F;
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Generated webpage title:");
		this.hpaned1.Add(this.label1);
		global::Gtk.Paned.PanedChild w2 = ((global::Gtk.Paned.PanedChild)(this.hpaned1[this.label1]));
		w2.Resize = false;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.ePageTitle = new global::Gtk.Entry();
		this.ePageTitle.CanFocus = true;
		this.ePageTitle.Name = "ePageTitle";
		this.ePageTitle.IsEditable = true;
		this.ePageTitle.InvisibleChar = '●';
		this.hpaned1.Add(this.ePageTitle);
		this.vbox1.Add(this.hpaned1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hpaned1]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.cbPackage = new global::Gtk.CheckButton();
		this.cbPackage.CanFocus = true;
		this.cbPackage.Name = "cbPackage";
		this.cbPackage.Label = global::Mono.Unix.Catalog.GetString("Zip all mod files?");
		this.cbPackage.DrawIndicator = true;
		this.cbPackage.UseUnderline = true;
		this.cbPackage.FocusOnClick = false;
		this.vbox1.Add(this.cbPackage);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.cbPackage]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.cbAws = new global::Gtk.CheckButton();
		this.cbAws.CanFocus = true;
		this.cbAws.Name = "cbAws";
		this.cbAws.Label = global::Mono.Unix.Catalog.GetString("Upload to AWS? (NB: This costs you money!)");
		this.cbAws.DrawIndicator = true;
		this.cbAws.UseUnderline = true;
		this.cbAws.FocusOnClick = false;
		this.vbox1.Add(this.cbAws);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.cbAws]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hProfile = new global::Gtk.HPaned();
		this.hProfile.CanFocus = true;
		this.hProfile.Name = "hProfile";
		this.hProfile.Position = 164;
		// Container child hProfile.Gtk.Paned+PanedChild
		this.lProfile = new global::Gtk.Label();
		this.lProfile.Name = "lProfile";
		this.lProfile.Xalign = 0.95F;
		this.lProfile.LabelProp = global::Mono.Unix.Catalog.GetString("Named Profile");
		this.lProfile.Justify = ((global::Gtk.Justification)(1));
		this.hProfile.Add(this.lProfile);
		global::Gtk.Paned.PanedChild w7 = ((global::Gtk.Paned.PanedChild)(this.hProfile[this.lProfile]));
		w7.Resize = false;
		// Container child hProfile.Gtk.Paned+PanedChild
		this.eProfile = new global::Gtk.Entry();
		this.eProfile.CanFocus = true;
		this.eProfile.Name = "eProfile";
		this.eProfile.IsEditable = true;
		this.eProfile.InvisibleChar = '●';
		this.hProfile.Add(this.eProfile);
		this.vbox1.Add(this.hProfile);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hProfile]));
		w9.Position = 3;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hBucket = new global::Gtk.HPaned();
		this.hBucket.CanFocus = true;
		this.hBucket.Name = "hBucket";
		this.hBucket.Position = 164;
		// Container child hBucket.Gtk.Paned+PanedChild
		this.lBucket = new global::Gtk.Label();
		this.lBucket.Name = "lBucket";
		this.lBucket.Xalign = 0.95F;
		this.lBucket.LabelProp = global::Mono.Unix.Catalog.GetString("S3 Bucket");
		this.lBucket.Justify = ((global::Gtk.Justification)(1));
		this.hBucket.Add(this.lBucket);
		global::Gtk.Paned.PanedChild w10 = ((global::Gtk.Paned.PanedChild)(this.hBucket[this.lBucket]));
		w10.Resize = false;
		// Container child hBucket.Gtk.Paned+PanedChild
		this.eBucket = new global::Gtk.Entry();
		this.eBucket.CanFocus = true;
		this.eBucket.Name = "eBucket";
		this.eBucket.IsEditable = true;
		this.eBucket.InvisibleChar = '●';
		this.hBucket.Add(this.eBucket);
		this.vbox1.Add(this.hBucket);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hBucket]));
		w12.Position = 4;
		w12.Expand = false;
		w12.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hDistribution = new global::Gtk.HPaned();
		this.hDistribution.CanFocus = true;
		this.hDistribution.Name = "hDistribution";
		this.hDistribution.Position = 164;
		// Container child hDistribution.Gtk.Paned+PanedChild
		this.lDistribution = new global::Gtk.Label();
		this.lDistribution.Name = "lDistribution";
		this.lDistribution.Xalign = 0.95F;
		this.lDistribution.LabelProp = global::Mono.Unix.Catalog.GetString("CloudFront Distribution");
		this.lDistribution.Justify = ((global::Gtk.Justification)(1));
		this.hDistribution.Add(this.lDistribution);
		global::Gtk.Paned.PanedChild w13 = ((global::Gtk.Paned.PanedChild)(this.hDistribution[this.lDistribution]));
		w13.Resize = false;
		// Container child hDistribution.Gtk.Paned+PanedChild
		this.eDistribution = new global::Gtk.Entry();
		this.eDistribution.CanFocus = true;
		this.eDistribution.Name = "eDistribution";
		this.eDistribution.IsEditable = true;
		this.eDistribution.InvisibleChar = '●';
		this.hDistribution.Add(this.eDistribution);
		this.vbox1.Add(this.hDistribution);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hDistribution]));
		w15.Position = 5;
		w15.Expand = false;
		w15.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
		this.alignment1.Name = "alignment1";
		// Container child alignment1.Gtk.Container+ContainerChild
		this.bGo = new global::Gtk.Button();
		this.bGo.CanFocus = true;
		this.bGo.Name = "bGo";
		this.bGo.UseUnderline = true;
		this.bGo.Label = global::Mono.Unix.Catalog.GetString("GO!");
		this.alignment1.Add(this.bGo);
		this.vbox1.Add(this.alignment1);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
		w17.Position = 6;
		w17.Expand = false;
		w17.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.logTextView = new global::Gtk.TextView();
		this.logTextView.Sensitive = false;
		this.logTextView.CanFocus = true;
		this.logTextView.Name = "logTextView";
		this.logTextView.Editable = false;
		this.logTextView.CursorVisible = false;
		this.logTextView.AcceptsTab = false;
		this.GtkScrolledWindow.Add(this.logTextView);
		this.vbox1.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
		w19.Position = 7;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 401;
		this.DefaultHeight = 390;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.cbAws.Toggled += new global::System.EventHandler(this.OnAwsToggle);
		this.bGo.Clicked += new global::System.EventHandler(this.OnGo);
	}
}
