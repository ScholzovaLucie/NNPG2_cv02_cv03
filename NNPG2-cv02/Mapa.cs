using NNPG2_cv02.DrawData;
using NNPG2_cv02.Graf;
using NNPG2_cv02.Path;
using NNPG2_cv02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace NNPG2_cv02
{
    public partial class Mapa : Form
    {
        private Graf<string, VertexData, EdgeData> graf = null;
        private Vertex<string, VertexData, EdgeData> vertex = null;
        private Edge<string, VertexData, EdgeData> edge = null;
        private Path<string, VertexData, EdgeData> path = null;
        private Paths<string, VertexData, EdgeData> paths;
        private DisjointPaths<string, VertexData, EdgeData> DisjointTuples = null;
        private HashSet<Path<string, VertexData, EdgeData>> disjunktPaths = null;
        private GraphProcessor<string, VertexData, EdgeData> graphProcessor = null;

        private List<Vertex<string, VertexData, EdgeData>> InputVertices { get; set; }
        private List<Vertex<string, VertexData, EdgeData>> OutputVertices { get; set; }
        private Random rnd = new Random();

        private int radius = 20;
        private int border = 200;
        private float zoomFactor = 1.1f;
        private float previousZoomFactor = 1.0f;

        private bool dragging = false;
        private bool drawEdge = false;
        private bool drawingLine = false;
        private bool removeEdge = false;
        private bool moove = false;
        private bool removing = false;
        private bool removeVertex = false;

        Pen linePen;

        private PrintDocument printDocument;
        private PrintDialog printDialog;
        private PageSetupDialog pageSetupDialog;
        private PrintPreviewDialog printPreviewDialog;

        int aktualniTistenaStranka = 1;
        int celkovyPocetStranDokumentu = 2;
        int zbyvajiciPocetStranTisku;

        public Mapa()
        {
            InitializeComponent();
            InitializeGraphProcessor();
            InitializeEventHandlers();
            SetInitialVertexPositions();
            InitializeTisk();

        }

        private void InitializeTisk()
        {
            printDocument = new PrintDocument();
            // Nazev tiskové úlohy, jak se bude zobrazovat ve spravci tisku
            printDocument.DocumentName = "PG2_Úkol_03 - Dopravní síť";

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            // Vytvoříme Dialog Tisk:
            printDialog = new PrintDialog();
            // Nastavíme dokument pro dialog Tisk:
            printDialog.Document = printDocument;

            // Vytvoříme dialog Vzhled stránky:
            pageSetupDialog = new PageSetupDialog();
            // Nastavíme dokument pro dialog Vzhled stránky:
            pageSetupDialog.Document = printDocument;

            // Vytvoříme Dialog Náhled:
            printPreviewDialog = new PrintPreviewDialog();
            // Nastavíme dokument pro dialog Náhled:
            printPreviewDialog.Document = printDocument;


            // naplneni seznamu tiskaren do Comboboxu
            foreach (string strPrintName in PrinterSettings.InstalledPrinters)
            {
                seznamTiskarenComboBox.Items.Add(strPrintName);
            }
        }

        private void InitializeGraphProcessor()
        {
            this.graphProcessor = new GraphProcessor<string, VertexData, EdgeData>();
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "files", "sem_01_maly.json");
            this.graphProcessor.ProcessGraph(path);
            this.OutputVertices = this.graphProcessor.getOutputVertices();
            this.InputVertices = this.graphProcessor.getInputVertices();

            graf = this.graphProcessor.CreateGraf();

            calculatePaths();
        }

        private void calculatePaths()
        {
            paths = new Paths<string, VertexData, EdgeData>(this.graphProcessor, graf);
            int maxTupleSize = Math.Min(this.graphProcessor.getInputVertices().Count, this.graphProcessor.getOutputVertices().Count);
            DisjointTuples = new DisjointPaths<string, VertexData, EdgeData>(paths.paths, maxTupleSize);
            this.count_paths.Text = paths.paths.Count().ToString();
            this.DisjunktPathsCount.Text = DisjointTuples.DisjointPathSets.Count().ToString();

            this.SeznamCest.Items.Clear();
            ListViewItem[] list = new ListViewItem[paths.paths.Count];
            for (int i = 0; i < paths.paths.Count; i++)
            {
                this.SeznamCest.Items.Add(paths.paths[i].Name);
            }

            this.SeznamDisjunktnichCest.Items.Clear();
            for (int i = 0; i < DisjointTuples.DisjointPathSets.Count; i++)
            {
                String disjunkt = "";
                foreach (var item in DisjointTuples.DisjointPathSets[i])
                {
                    disjunkt += item.Name + " ";
                }
                this.SeznamDisjunktnichCest.Items.Add(disjunkt);
            }
        }

        private void InitializeEventHandlers()
        {
            this.PaintPanel.MouseDown += PaintPanel_MouseDown;
            this.PaintPanel.MouseMove += PaintPanel_MouseMove;
            this.PaintPanel.MouseUp += PaintPanel_MouseUp;
            this.PaintPanel.Paint += PaintPanel_Paint;
            this.PaintPanel.MouseWheel += PaintPanel_MouseWheel;
            this.PaintPanel.MouseClick += PaintPanel_MouseClick;
            this.SeznamCest.MouseClick += SeznamCest_ItemClick;
            this.SeznamDisjunktnichCest.MouseClick += SeznamDisjunktnichCest_ItemClick;
        }

        private void SeznamDisjunktnichCest_ItemClick(object sender, MouseEventArgs e)
        {
            if (this.SeznamDisjunktnichCest.SelectedItem != null)
            {
                this.disjunktPaths = this.DisjointTuples.DisjointPathSets[this.SeznamDisjunktnichCest.SelectedIndex];
                this.path = null;
            }
            else
            {
                this.disjunktPaths = null;
            }

            this.PaintPanel.Invalidate();
        }

        private void SeznamCest_ItemClick(object sender, MouseEventArgs e)
        {
            if (this.SeznamCest.SelectedItem != null)
            {
                foreach (var path in this.paths.paths)
                {
                    if (path.Name.Equals(this.SeznamCest.SelectedItem.ToString()))
                    {
                        this.path = path;
                        this.disjunktPaths = null;
                    }
                }
            }
            else
            {
                this.path = null;
            }

            this.PaintPanel.Invalidate();
        }

        private void SetInitialVertexPositions()
        {
            foreach (Vertex<string, VertexData, EdgeData> item in this.graf.Vertices)
            {
                if (this.InputVertices.Contains(item))
                {
                    item.setData(new VertexData());
                    item.data.generateCoordinates(this.rnd, 0, border, this.PaintPanel.ClientSize.Height - radius);
                }
                else if (this.OutputVertices.Contains(item))
                {
                    item.setData(new VertexData());
                    item.data.generateCoordinates(this.rnd, this.PaintPanel.ClientSize.Width - radius - border, this.PaintPanel.ClientSize.Width - radius, this.PaintPanel.ClientSize.Height - radius);
                }
                else
                {
                    item.setData(new VertexData());
                    item.data.generateCoordinates(this.rnd, 200, this.PaintPanel.ClientSize.Width - radius - border, this.PaintPanel.ClientSize.Height - radius);
                }

                item.data.rectangle = new Rectangle(item.data.coordinateX, item.data.coordinateY, radius, radius);
            }
        }

        private void PaintPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.removeEdge)
            {
                for (int i = 0; i < this.graf.Vertices.Count; i++)
                {
                    Vertex<string, VertexData, EdgeData> item = this.graf.Vertices[i];
                    for (int j = 0; j < item.Edges.Count; j++)
                    {
                        var edge = item.Edges[j];
                        double distance = DistancePointToLine(e.Location, edge.StartVertex.data.point, edge.EndVertex.data.point);
                        if (distance <= 50)
                        {
                            item.removeEdge(edge);
                            this.Invalidate();
                        }
                    }
                }
            }
        }

        private void PaintPanel_MouseDown(object sender, MouseEventArgs e)
        {
            bool found = false;

            foreach (Vertex<string, VertexData, EdgeData> item in this.graf.Vertices)
            {

                if (item.data.rectangle.Contains(e.Location))
                {
                    this.vertex = item;
                    found = true;
                    if (moove)
                    {
                        this.dragging = true;
                        this.vertex.data.point = new Point(e.X - item.data.rectangle.X, e.Y - item.data.rectangle.Y);
                    }
                    if (drawEdge)
                    {
                        this.edge = new Edge<string, VertexData, EdgeData>();
                        this.edge.Name = this.graf.Vertices.Sum(vertex => vertex.Edges.Count).ToString();
                        this.edge.StartVertex = this.vertex;
                        this.edge.EndVertex = this.vertex;
                        this.edge.setData(new EdgeData());
                        this.linePen = new Pen(Color.Black, 3);
                        this.drawingLine = true;
                        this.edge.data.startPoint = e.Location;
                        this.edge.data.endPoint = e.Location;
                    }
                    break;
                }
            }

            if (!found)
            {
                this.vertex = null;
            }
            this.PaintPanel.Invalidate();
        }

        private void PaintPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawEdge && drawingLine)
            {
                bool found = false;
                this.edge.data.endPoint = e.Location;

                foreach (Vertex<string, VertexData, EdgeData> item in this.graf.Vertices)
                {
                    if (item.data.rectangle.Contains(e.Location))
                    {
                        this.edge.EndVertex = item;
                        this.edge.StartVertex.Edges.Add(new Edge<string, VertexData, EdgeData>(edge.Name, edge.StartVertex, edge.EndVertex));
                        this.vertex = item;
                        break;
                    }
                }
            }
            if (this.removeVertex)
            {
                foreach (Vertex<string, VertexData, EdgeData> item in this.graf.Vertices)
                {
                    if (item.Equals(this.vertex))
                    {
                        this.graf.RemoveVertex(item);
                        this.vertex = null;
                        this.PaintPanel.Invalidate();
                        break;
                    }
                }
            }
            this.dragging = false;
            this.drawingLine = false;
            this.PaintPanel.Invalidate();
        }

        private void PaintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.vertex.data.rectangle.Location = new Point(e.X - this.vertex.data.point.X, e.Y - this.vertex.data.point.Y);
                this.graf.UpdateVertex(this.vertex);
                this.PaintPanel.Invalidate();
            }
            if (drawEdge && drawingLine && !dragging)
            {
                edge.data.endPoint = e.Location;
                this.PaintPanel.Invalidate();
            }

        }

        private void PaintPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();

            if (dragging && vertex != null)
            {
                g.FillEllipse(Brushes.Green, vertex.data.rectangle);

                foreach (Vertex<string, VertexData, EdgeData> item in this.graf.Vertices)
                {
                    if (!item.Equals(this.vertex))
                    {
                        g.DrawString(item.Name, drawFont, drawBrush, item.data.rectangle.X, item.data.rectangle.Y - radius, drawFormat);
                        g.FillEllipse(Brushes.Blue, item.data.rectangle);
                    }
                }
                redrawEdges(g);
            }

            calculatePaths();

            if (drawEdge && drawingLine)
            {
                g.DrawLine(linePen, edge.data.startPoint, edge.data.endPoint);
                redrawVertices(g);
                redrawEdges(g);
            }
            else
            {
                redrawVertices(g);
                redrawEdges(g);
            }

            if (this.disjunktPaths != null)
            {
                ShowDisjunkt(g);
            }

            if (this.path != null)
            {
                ShowPath(g, this.path, new Pen(Brushes.OrangeRed, 4));
            }
        }

        private void ShowDisjunkt(Graphics g)
        {
            Brush[] brushes = { Brushes.DeepPink, Brushes.Yellow, Brushes.GreenYellow, Brushes.Aqua, Brushes.DarkViolet };
            for (int i = 0; i < disjunktPaths.Count; i++)
            {
                ShowPath(g, disjunktPaths.ElementAt(i), new Pen(brushes[i], 4));
            }
        }

        private void ShowPath(Graphics g, Path<string, VertexData, EdgeData> currentpath, Pen pen)
        {
            foreach (var item in currentpath.Vertices)
            {
                foreach (Edge<string, VertexData, EdgeData> edge in item.Edges)
                {
                    var next = currentpath.Vertices.Find(item).Next.Value;
                    if (item.Name.Equals(edge.StartVertex.Name)
                        && next.Name.Equals(edge.EndVertex.Name))
                    {
                        g.DrawLine(pen, edge.StartVertex.data.rectangle.X + (edge.StartVertex.data.rectangle.Width / 2),
                                      edge.StartVertex.data.rectangle.Y + (edge.StartVertex.data.rectangle.Height / 2),
                                      edge.EndVertex.data.rectangle.X + (edge.EndVertex.data.rectangle.Width / 2),
                                      edge.EndVertex.data.rectangle.Y + (edge.EndVertex.data.rectangle.Height / 2));

                        foreach (var crossList in this.graf.Cross)
                        {
                            if (crossList[1].Name.Equals(edge.EndVertex.Name))
                            {
                                var lastCross = currentpath.Vertices.Find(next).Next.Value;

                                if (crossList[2].Name.Equals(lastCross.Name))
                                {
                                    g.DrawLine(pen, edge.EndVertex.data.rectangle.X + (edge.EndVertex.data.rectangle.Width / 2),
                                                                             edge.EndVertex.data.rectangle.Y + (edge.EndVertex.data.rectangle.Height / 2),
                                                                             crossList[2].data.rectangle.X + (crossList[2].data.rectangle.Width / 2),
                                                                             crossList[2].data.rectangle.Y + (crossList[2].data.rectangle.Height / 2));
                                }


                            }
                        }
                    }

                }
            }
        }

        private void redrawVertices(Graphics g, int zoom = 0)
        {
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();

            for (int i = 0; i < this.graf.Vertices.Count; i++)
            {
                Vertex<string, VertexData, EdgeData> item = this.graf.Vertices[i];
                item.data.rectangle.X += zoom;
                item.data.rectangle.Y += zoom;
                item.data.coordinateX += zoom;
                item.data.coordinateY += zoom;
                if (item.Equals(this.vertex))
                {
                    g.FillEllipse(Brushes.Red, item.data.rectangle);
                    g.DrawString(item.Name, drawFont, drawBrush, item.data.rectangle.X, item.data.rectangle.Y - radius, drawFormat);
                    item.data.setCoordinateX(item.data.rectangle.X);
                    item.data.setCoordinateY(item.data.rectangle.Y);
                }
                else
                {
                    if (this.InputVertices.Contains(item))
                    {
                        g.FillEllipse(Brushes.Green, item.data.rectangle);
                    }
                    else if (this.OutputVertices.Contains(item))
                    {
                        g.FillEllipse(Brushes.Yellow, item.data.rectangle);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.Blue, item.data.rectangle);
                    }

                    foreach (var crossList in this.graf.Cross)
                    {
                        if (crossList[1] == item)
                        {
                            g.FillEllipse(Brushes.Purple, item.data.rectangle);
                        }
                    }

                    g.DrawString(item.Name, drawFont, drawBrush, item.data.coordinateX, item.data.coordinateY - radius, drawFormat);
                }
            }
        }

        private void redrawEdges(Graphics g)
        {
            Pen pen = new Pen(Brushes.Black, 2);
            foreach (Vertex<string, VertexData, EdgeData> v in this.graf.Vertices)
            {
                foreach (Edge<string, VertexData, EdgeData> edge in v.Edges)
                {

                    g.DrawLine(pen, edge.StartVertex.data.rectangle.X + (edge.StartVertex.data.rectangle.Width / 2),
                                      edge.StartVertex.data.rectangle.Y + (edge.StartVertex.data.rectangle.Height / 2),
                                      edge.EndVertex.data.rectangle.X + (edge.EndVertex.data.rectangle.Width / 2),
                                      edge.EndVertex.data.rectangle.Y + (edge.EndVertex.data.rectangle.Height / 2));

                    foreach (var crossList in this.graf.Cross)
                    {
                        if (crossList[1].Name.Equals(edge.EndVertex.Name))
                        {
                            g.DrawLine(pen, edge.EndVertex.data.rectangle.X + (edge.EndVertex.data.rectangle.Width / 2),
                                  edge.EndVertex.data.rectangle.Y + (edge.EndVertex.data.rectangle.Height / 2),
                                  crossList[2].data.rectangle.X + (crossList[2].data.rectangle.Width / 2),
                                  crossList[2].data.rectangle.Y + (crossList[2].data.rectangle.Height / 2));
                        }
                    }
                }
            }

        }

        private void PaintPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.Delta > 0)
                {
                    ZoomIn(e.Location);
                }
                else
                {
                    ZoomOut(e.Location);
                }
            }
        }

        private void ZoomIn(Point zoomCenter)
        {
            AdjustZoom(1.1f, zoomCenter);
        }

        private void ZoomOut(Point zoomCenter)
        {
            AdjustZoom(0.9f, zoomCenter);
        }
        private void AdjustZoom(float factor, Point zoomCenter)
        {
            previousZoomFactor = zoomFactor;
            zoomFactor *= factor;

            RepaintWithZoom(zoomCenter);
        }
        private void RepaintWithZoom(Point zoomCenter)
        {
            int newWidth = (int)(this.PaintPanel.Width * zoomFactor / previousZoomFactor);
            int newHeight = (int)(this.PaintPanel.Height * zoomFactor / previousZoomFactor);

            int offsetX = (int)((zoomCenter.X * (zoomFactor - 1)) - this.AutoScrollPosition.X);
            int offsetY = (int)((zoomCenter.Y * (zoomFactor - 1)) - this.AutoScrollPosition.Y);

            this.PaintPanel.Width = newWidth;
            this.PaintPanel.Height = newHeight;

            foreach (var vertex in this.graf.Vertices)
            {
                vertex.data.rectangle.X = (int)(vertex.data.rectangle.X * zoomFactor / previousZoomFactor);
                vertex.data.rectangle.Y = (int)(vertex.data.rectangle.Y * zoomFactor / previousZoomFactor);
                vertex.data.coordinateX = (int)(vertex.data.coordinateX * zoomFactor / previousZoomFactor);
                vertex.data.coordinateY = (int)(vertex.data.coordinateY * zoomFactor / previousZoomFactor);

            }
            this.MapaPanel.AutoScrollMinSize = new Size(newWidth, newHeight);
            this.AutoScrollPosition = new Point(Math.Max(0, this.AutoScrollPosition.X - offsetX),
                                                 Math.Max(0, this.AutoScrollPosition.Y - offsetY));

            this.PaintPanel.Invalidate();
        }



        private void pridani_uzlu_Click(object sender, EventArgs e)
        {
            Vertex<string, VertexData, EdgeData> newVertex = new Vertex<string, VertexData, EdgeData>((this.graf.Vertices.Count + 1).ToString());
            newVertex.setData(new VertexData());
            newVertex.data.generateCoordinates(this.rnd, 10, 10, 10);
            newVertex.data.rectangle = new Rectangle(newVertex.data.coordinateX, newVertex.data.coordinateY, radius, radius);
            this.graf.Vertices.Add(newVertex);
            this.PaintPanel.Invalidate();
        }

        private void vymazani_uzlu_Click(object sender, EventArgs e)
        {
            if (this.removeVertex)
            {
                this.vymazani_uzlu.Checked = false;
                this.removeVertex = false;
            }
            else
            {
                this.vymazani_uzlu.Checked = true;
                this.removeVertex = true;
            }

        }

        private void posun_uzlu_Click(object sender, EventArgs e)
        {
            if (this.moove)
            {
                this.posun_uzlu.Checked = false;
                this.moove = false;
            }
            else
            {
                this.posun_uzlu.Checked = true;
                this.moove = true;
            }
        }

        private void vytvoreni_useku_Click(object sender, EventArgs e)
        {
            if (this.drawEdge)
            {
                this.vytvoreni_useku.Checked = false;
                this.drawEdge = false;
            }
            else
            {
                this.vytvoreni_useku.Checked = true;
                this.drawEdge = true;
            }
        }

        private void vymazani_useku_Click(object sender, EventArgs e)
        {
            if (this.removeEdge)
            {
                this.vymazani_useku.Checked = false;
                this.removeEdge = false;
            }
            else
            {
                this.vymazani_useku.Checked = true;
                this.removeEdge = true;
            }
        }

        private double DistancePointToLine(Point point, Point lineStart, Point lineEnd)
        {
            double A = point.X - lineStart.X;
            double B = point.Y - lineStart.Y;
            double C = lineEnd.X - lineStart.X;
            double D = lineEnd.Y - lineStart.Y;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = dot / len_sq;

            double xx, yy;

            if (param < 0)
            {
                xx = lineStart.X;
                yy = lineStart.Y;
            }
            else if (param > 1)
            {
                xx = lineEnd.X;
                yy = lineEnd.Y;
            }
            else
            {
                xx = lineStart.X + param * C;
                yy = lineStart.Y + param * D;
            }

            double dx = point.X - xx;
            double dy = point.Y - yy;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void tiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // prednastavime dialog

            printDialog.AllowSomePages = true;
            printDialog.PrinterSettings.MinimumPage = 1;
            printDialog.PrinterSettings.MaximumPage = celkovyPocetStranDokumentu;
            printDialog.PrinterSettings.FromPage = 1;
            printDialog.PrinterSettings.ToPage = celkovyPocetStranDokumentu;

            // zobrazime dialog
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Tistene stanky 

                switch (printDialog.PrinterSettings.PrintRange)
                {
                    case PrintRange.AllPages:
                        aktualniTistenaStranka = 1;
                        zbyvajiciPocetStranTisku = celkovyPocetStranDokumentu;
                        break;
                    case PrintRange.SomePages:
                        aktualniTistenaStranka = printDialog.PrinterSettings.FromPage;
                        zbyvajiciPocetStranTisku = printDialog.PrinterSettings.ToPage
                                          - printDialog.PrinterSettings.FromPage + 1;
                        break;
                }

                // Nastaveni orientace
                printDialog.Document.DefaultPageSettings.Landscape = true;

                // Vlastní tisk
                printDocument.Print();
            }
        }

        private void nahledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (printDialog.PrinterSettings.PrintRange)
            {
                case PrintRange.AllPages:
                    aktualniTistenaStranka = 1;
                    zbyvajiciPocetStranTisku = celkovyPocetStranDokumentu;
                    break;
                case PrintRange.SomePages:
                    aktualniTistenaStranka = printDialog.PrinterSettings.FromPage;
                    zbyvajiciPocetStranTisku = printDialog.PrinterSettings.ToPage
                                               - printDialog.PrinterSettings.FromPage + 1;
                    break;
            }

            // Nastaveni orientace
            printDialog.Document.DefaultPageSettings.Landscape = true;

            printPreviewDialog.ShowDialog();
        }

        private void vzhledStrankyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            RectangleF rectPageBounds = e.PageBounds;
            g.DrawRectangles(Pens.Black, new RectangleF[] { rectPageBounds });
            RectangleF rectMarginBounds = e.MarginBounds;
            g.DrawRectangles(Pens.Red, new RectangleF[] { rectMarginBounds });

            int desiredWidth = this.PaintPanel.Width - radius - (Glob.ScrMaxX + Glob.ScrMinX);
            int desiredHeight = this.PaintPanel.Height - radius - (Glob.ScrMaxY + Glob.ScrMinY);

            // Aktuální rozměry grafiky
            float currentWidth = g.VisibleClipBounds.Width;
            float currentHeight = g.VisibleClipBounds.Height;

            // Výpočet poměru škálování pro oba směry
            float scaleX = desiredWidth / currentWidth;
            float scaleY = desiredHeight / currentHeight;
            float scale = Math.Min(scaleX, scaleY); // Použití menšího poměru pro zachování poměru stran

            // Zmenšení plátna s zachováním poměru
            g.ScaleTransform(scale, scale);

            // Vypočtěte posunutí pro vycentrování na ose X
            float offsetX = Math.Abs(currentWidth - desiredWidth * scale);

            // Vypočtěte posunutí pro vycentrování na ose Y
            float offsetY = Math.Abs(currentHeight - desiredHeight * scale) / 2;

            // Posunutí plátna
            g.TranslateTransform(offsetX, offsetY);

            // Vykreslení obsahu
            Kresli(g, aktualniTistenaStranka);

            // Resetování transformace
            g.ResetTransform();



            // varianta s formatovanim textu
            Font font7 = new Font("Arial Bold", 7f, GraphicsUnit.Millimeter);
            string textHorni = "PG2_Úkol_03 - Dopravní síť\n";

            if (aktualniTistenaStranka == 1)
                textHorni += "Stránka 1 (síť včetně podkladové mapy)";
            else
                textHorni += "Stránka 2 (pouze síť)";

            StringFormat strfmt = new StringFormat();
            strfmt.Alignment = StringAlignment.Center;
            strfmt.LineAlignment = StringAlignment.Center;
            Rectangle rectTextHorni = new Rectangle(e.PageBounds.Left, e.PageBounds.Top,
                                                    e.PageBounds.Width, e.MarginBounds.Top - e.PageBounds.Top);
            g.DrawString(textHorni, font7, Brushes.Black, rectTextHorni, strfmt);

            //presne umisteni textu
            Font font5 = new Font("Arial", 5f, GraphicsUnit.Millimeter);
            string textDolniL = "Lucie Scholzová";
            SizeF sizeTextDolniL = g.MeasureString(textDolniL, font5);
            g.DrawString(textDolniL, font5, Brushes.Black,
                         1, e.PageBounds.Height - e.PageBounds.Top - sizeTextDolniL.Height - 1);


            string textDolniR = "Tisk: " + DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
            SizeF sizeTextDolniR = g.MeasureString(textDolniR, font5);
            g.DrawString(textDolniR, font5, Brushes.Black,
                         e.PageBounds.Left + e.PageBounds.Width - sizeTextDolniR.Width - 1,
                         e.PageBounds.Top + e.PageBounds.Height - sizeTextDolniR.Height - 1);


            aktualniTistenaStranka++;
            zbyvajiciPocetStranTisku--;
            if (zbyvajiciPocetStranTisku > 0)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

        }

        public void Kresli(Graphics g, int strana)
        {
            Image mapa = global::NNPG2_cv02.Properties.Resources.mapa;
            try
            {
                if (strana == 1)
                {
                    Rectangle kresliciPlocha = new Rectangle(
                        0, 
                        0, 
                        this.PaintPanel.Width - radius, 
                        this.PaintPanel.Height - radius
                        );
                    g.DrawImage(mapa, kresliciPlocha);

                    redrawVertices(g);

                    redrawEdges(g);
                }

                
            }
            catch
            {
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
			if (seznamTiskarenComboBox.SelectedItem!=null)
				printDocument.PrinterSettings.PrinterName = seznamTiskarenComboBox.SelectedItem.ToString();
			 */
        }

        private void seznamTiskarenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*
			foreach (string strPrintName in PrinterSettings.InstalledPrinters)
			{
				seznamTiskarenComboBox.Items.Add(strPrintName);
			}
			 */
        }

        private void seznamTiskarenComboBox_Click(object sender, EventArgs e)
        {
            
			if (seznamTiskarenComboBox.SelectedItem != null)
				printDocument.PrinterSettings.PrinterName = seznamTiskarenComboBox.SelectedItem.ToString();
			 
        }

        private void seznamTiskarenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seznamTiskarenComboBox.SelectedItem != null)
                printDocument.PrinterSettings.PrinterName = seznamTiskarenComboBox.SelectedItem.ToString();
        }
    }
}
