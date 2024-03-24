using System.Drawing;
using System.Windows.Forms;

namespace NNPG2
{
    partial class Mapa
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mapa));
            this.ButtonsMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pridani_uzlu = new System.Windows.Forms.ToolStripButton();
            this.vymazani_uzlu = new System.Windows.Forms.ToolStripButton();
            this.posun_uzlu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.vytvoreni_useku = new System.Windows.Forms.ToolStripButton();
            this.vymazani_useku = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Paths = new System.Windows.Forms.ToolStripLabel();
            this.count_paths = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.DisjunktPaths = new System.Windows.Forms.ToolStripLabel();
            this.DisjunktPathsCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.zakladyTiskuToolStripMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.tiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nahledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seznamTiskarenComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.VlastnostiTisku = new System.Windows.Forms.ToolStripDropDownButton();
            this.VolbaTisku = new System.Windows.Forms.ToolStripComboBox();
            this.PomerStran = new System.Windows.Forms.ToolStripComboBox();
            this.TiskSBitMap = new System.Windows.Forms.ToolStripComboBox();
            this.Zahlavi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomZahlavi = new System.Windows.Forms.ToolStripTextBox();
            this.Zapati = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomZapati = new System.Windows.Forms.ToolStripTextBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.MapaPanel = new System.Windows.Forms.Panel();
            this.PaintPanel = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.Panel();
            this.SeznamDisjunktnichCest = new System.Windows.Forms.ListBox();
            this.SeznamCest = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ButtonsMenu.SuspendLayout();
            this.Panel.SuspendLayout();
            this.MapaPanel.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsMenu
            // 
            this.ButtonsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ButtonsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.pridani_uzlu,
            this.vymazani_uzlu,
            this.posun_uzlu,
            this.toolStripSeparator2,
            this.vytvoreni_useku,
            this.vymazani_useku,
            this.toolStripSeparator3,
            this.Paths,
            this.count_paths,
            this.toolStripSeparator4,
            this.DisjunktPaths,
            this.DisjunktPathsCount,
            this.toolStripSeparator5,
            this.toolStripSeparator6,
            this.zakladyTiskuToolStripMenuItem,
            this.seznamTiskarenComboBox,
            this.VlastnostiTisku});
            this.ButtonsMenu.Location = new System.Drawing.Point(0, 0);
            this.ButtonsMenu.Name = "ButtonsMenu";
            this.ButtonsMenu.Size = new System.Drawing.Size(1590, 25);
            this.ButtonsMenu.TabIndex = 1;
            this.ButtonsMenu.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pridani_uzlu
            // 
            this.pridani_uzlu.BackColor = System.Drawing.Color.Transparent;
            this.pridani_uzlu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pridani_uzlu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pridani_uzlu.Name = "pridani_uzlu";
            this.pridani_uzlu.Size = new System.Drawing.Size(33, 22);
            this.pridani_uzlu.Text = "Add";
            this.pridani_uzlu.Click += new System.EventHandler(this.pridani_uzlu_Click);
            // 
            // vymazani_uzlu
            // 
            this.vymazani_uzlu.CheckOnClick = true;
            this.vymazani_uzlu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.vymazani_uzlu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vymazani_uzlu.Name = "vymazani_uzlu";
            this.vymazani_uzlu.Size = new System.Drawing.Size(44, 22);
            this.vymazani_uzlu.Text = "Delete";
            this.vymazani_uzlu.Click += new System.EventHandler(this.vymazani_uzlu_Click);
            // 
            // posun_uzlu
            // 
            this.posun_uzlu.CheckOnClick = true;
            this.posun_uzlu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.posun_uzlu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posun_uzlu.Name = "posun_uzlu";
            this.posun_uzlu.Size = new System.Drawing.Size(41, 22);
            this.posun_uzlu.Text = "Move";
            this.posun_uzlu.Click += new System.EventHandler(this.posun_uzlu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // vytvoreni_useku
            // 
            this.vytvoreni_useku.CheckOnClick = true;
            this.vytvoreni_useku.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.vytvoreni_useku.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vytvoreni_useku.Name = "vytvoreni_useku";
            this.vytvoreni_useku.Size = new System.Drawing.Size(72, 22);
            this.vytvoreni_useku.Text = "Create path";
            this.vytvoreni_useku.Click += new System.EventHandler(this.vytvoreni_useku_Click);
            // 
            // vymazani_useku
            // 
            this.vymazani_useku.CheckOnClick = true;
            this.vymazani_useku.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.vymazani_useku.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vymazani_useku.Name = "vymazani_useku";
            this.vymazani_useku.Size = new System.Drawing.Size(81, 22);
            this.vymazani_useku.Text = "Remove path";
            this.vymazani_useku.Click += new System.EventHandler(this.vymazani_useku_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // Paths
            // 
            this.Paths.Name = "Paths";
            this.Paths.Size = new System.Drawing.Size(39, 22);
            this.Paths.Text = "Paths:";
            // 
            // count_paths
            // 
            this.count_paths.Name = "count_paths";
            this.count_paths.Size = new System.Drawing.Size(13, 22);
            this.count_paths.Text = "0";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // DisjunktPaths
            // 
            this.DisjunktPaths.Name = "DisjunktPaths";
            this.DisjunktPaths.Size = new System.Drawing.Size(85, 22);
            this.DisjunktPaths.Text = "Disjunkt Paths:";
            // 
            // DisjunktPathsCount
            // 
            this.DisjunktPathsCount.Name = "DisjunktPathsCount";
            this.DisjunktPathsCount.Size = new System.Drawing.Size(13, 22);
            this.DisjunktPathsCount.Text = "0";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // zakladyTiskuToolStripMenuItem
            // 
            this.zakladyTiskuToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zakladyTiskuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiskToolStripMenuItem,
            this.nahledToolStripMenuItem});
            this.zakladyTiskuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("zakladyTiskuToolStripMenuItem.Image")));
            this.zakladyTiskuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zakladyTiskuToolStripMenuItem.Name = "zakladyTiskuToolStripMenuItem";
            this.zakladyTiskuToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.zakladyTiskuToolStripMenuItem.Text = "Tisk";
            // 
            // tiskToolStripMenuItem
            // 
            this.tiskToolStripMenuItem.Name = "tiskToolStripMenuItem";
            this.tiskToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tiskToolStripMenuItem.Text = "Tisk";
            this.tiskToolStripMenuItem.Click += new System.EventHandler(this.tiskToolStripMenuItem_Click);
            // 
            // nahledToolStripMenuItem
            // 
            this.nahledToolStripMenuItem.Name = "nahledToolStripMenuItem";
            this.nahledToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nahledToolStripMenuItem.Text = "Nahled";
            this.nahledToolStripMenuItem.Click += new System.EventHandler(this.nahledToolStripMenuItem_Click);
            // 
            // seznamTiskarenComboBox
            // 
            this.seznamTiskarenComboBox.Name = "seznamTiskarenComboBox";
            this.seznamTiskarenComboBox.Size = new System.Drawing.Size(121, 25);
            this.seznamTiskarenComboBox.SelectedIndexChanged += new System.EventHandler(this.seznamTiskarenComboBox_SelectedIndexChanged);
            this.seznamTiskarenComboBox.Click += new System.EventHandler(this.seznamTiskarenComboBox_Click);
            // 
            // VlastnostiTisku
            // 
            this.VlastnostiTisku.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.VlastnostiTisku.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VolbaTisku,
            this.PomerStran,
            this.TiskSBitMap,
            this.Zahlavi,
            this.Zapati});
            this.VlastnostiTisku.Image = ((System.Drawing.Image)(resources.GetObject("VlastnostiTisku.Image")));
            this.VlastnostiTisku.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VlastnostiTisku.Name = "VlastnostiTisku";
            this.VlastnostiTisku.Size = new System.Drawing.Size(98, 22);
            this.VlastnostiTisku.Text = "VlastnostiTisku";
            // 
            // VolbaTisku
            // 
            this.VolbaTisku.Name = "VolbaTisku";
            this.VolbaTisku.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.VolbaTisku.Size = new System.Drawing.Size(180, 23);
            this.VolbaTisku.SelectedIndexChanged += new System.EventHandler(this.VolbaTisku_SelectedIndexChanged);
            this.VolbaTisku.Click += new System.EventHandler(this.VolbaTisku_Click);
            // 
            // PomerStran
            // 
            this.PomerStran.Name = "PomerStran";
            this.PomerStran.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.PomerStran.Size = new System.Drawing.Size(121, 23);
            this.PomerStran.SelectedIndexChanged += new System.EventHandler(this.PomerStran_SelectedIndexChanged);
            this.PomerStran.Click += new System.EventHandler(this.PomerStran_Click);
            // 
            // TiskSBitMap
            // 
            this.TiskSBitMap.Name = "TiskSBitMap";
            this.TiskSBitMap.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.TiskSBitMap.Size = new System.Drawing.Size(121, 23);
            this.TiskSBitMap.SelectedIndexChanged += new System.EventHandler(this.TiskSBitMap_SelectedIndexChanged);
            this.TiskSBitMap.Click += new System.EventHandler(this.TiskSBitMap_Click);
            // 
            // Zahlavi
            // 
            this.Zahlavi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomZahlavi});
            this.Zahlavi.Name = "Zahlavi";
            this.Zahlavi.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.Zahlavi.Size = new System.Drawing.Size(240, 22);
            this.Zahlavi.Text = "Záhlaví";
            // 
            // CustomZahlavi
            // 
            this.CustomZahlavi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomZahlavi.Name = "CustomZahlavi";
            this.CustomZahlavi.Size = new System.Drawing.Size(100, 23);
            // 
            // Zapati
            // 
            this.Zapati.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomZapati});
            this.Zapati.Name = "Zapati";
            this.Zapati.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.Zapati.Size = new System.Drawing.Size(240, 22);
            this.Zapati.Text = "Zápatí";
            // 
            // CustomZapati
            // 
            this.CustomZapati.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomZapati.Name = "CustomZapati";
            this.CustomZapati.Size = new System.Drawing.Size(100, 23);
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.MapaPanel);
            this.Panel.Controls.Add(this.Menu);
            this.Panel.Controls.Add(this.ButtonsMenu);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1590, 825);
            this.Panel.TabIndex = 2;
            // 
            // MapaPanel
            // 
            this.MapaPanel.AutoScroll = true;
            this.MapaPanel.Controls.Add(this.PaintPanel);
            this.MapaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapaPanel.Location = new System.Drawing.Point(0, 25);
            this.MapaPanel.Name = "MapaPanel";
            this.MapaPanel.Size = new System.Drawing.Size(1401, 800);
            this.MapaPanel.TabIndex = 1;
            // 
            // PaintPanel
            // 
            this.PaintPanel.AutoScroll = true;
            this.PaintPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PaintPanel.BackgroundImage")));
            this.PaintPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PaintPanel.Location = new System.Drawing.Point(0, 2);
            this.PaintPanel.Name = "PaintPanel";
            this.PaintPanel.Size = new System.Drawing.Size(1401, 798);
            this.PaintPanel.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.SeznamDisjunktnichCest);
            this.Menu.Controls.Add(this.SeznamCest);
            this.Menu.Controls.Add(this.label2);
            this.Menu.Controls.Add(this.label1);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.Menu.Location = new System.Drawing.Point(1401, 25);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(189, 800);
            this.Menu.TabIndex = 1;
            // 
            // SeznamDisjunktnichCest
            // 
            this.SeznamDisjunktnichCest.FormattingEnabled = true;
            this.SeznamDisjunktnichCest.Location = new System.Drawing.Point(1, 283);
            this.SeznamDisjunktnichCest.Name = "SeznamDisjunktnichCest";
            this.SeznamDisjunktnichCest.Size = new System.Drawing.Size(206, 524);
            this.SeznamDisjunktnichCest.TabIndex = 4;
            // 
            // SeznamCest
            // 
            this.SeznamCest.FormattingEnabled = true;
            this.SeznamCest.Location = new System.Drawing.Point(1, 21);
            this.SeznamCest.Name = "SeznamCest";
            this.SeznamCest.Size = new System.Drawing.Size(199, 225);
            this.SeznamCest.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seznam disjunktních cest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seznam cest";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Mapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 825);
            this.Controls.Add(this.Panel);
            this.Name = "Mapa";
            this.Text = "Form1";
            this.ButtonsMenu.ResumeLayout(false);
            this.ButtonsMenu.PerformLayout();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.MapaPanel.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ToolStrip ButtonsMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton pridani_uzlu;
        private Panel Panel;
        private Panel PaintPanel;
        private ToolStripButton vymazani_uzlu;
        private ToolStripButton posun_uzlu;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton vytvoreni_useku;
        private ToolStripButton vymazani_useku;
        private ToolStripSeparator toolStripSeparator3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripLabel Paths;
        private ToolStripLabel count_paths;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel DisjunktPaths;
        private ToolStripLabel DisjunktPathsCount;
        private Panel Menu;
        private Label label2;
        private Label label1;
        private ListBox SeznamDisjunktnichCest;
        private ListBox SeznamCest;
        private Panel MapaPanel;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSplitButton zakladyTiskuToolStripMenuItem;
        private ToolStripMenuItem tiskToolStripMenuItem;
        private ToolStripMenuItem nahledToolStripMenuItem;
        private ToolStripComboBox seznamTiskarenComboBox;
        private ToolStripDropDownButton Vlastnosti;
        private ToolStripDropDownButton VlastnostiTisku;
        private ToolStripComboBox VolbaTisku;
        private ToolStripComboBox PomerStran;
        private ToolStripComboBox TiskSBitMap;
        private ToolStripMenuItem Zahlavi;
        private ToolStripTextBox CustomZahlavi;
        private ToolStripMenuItem Zapati;
        private ToolStripTextBox CustomZapati;
    }
}

