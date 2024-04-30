namespace GraphTheorySketchPad
{
    partial class GraphSketchpad
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Button addVertexButton;
        private System.Windows.Forms.Button addEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox vertexLabelTextBox;
        private System.Windows.Forms.Label infoLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Graph Panel for displaying the graph
            this.graphPanel = new System.Windows.Forms.Panel();
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseDown);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseMove);
            this.graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseUp);

            // Buttons for adding vertices, edges, and deleting items
            this.addVertexButton = new System.Windows.Forms.Button() { Text = "Add Vertex", Dock = System.Windows.Forms.DockStyle.Top };
            this.addVertexButton.Click += new System.EventHandler(this.AddVertexButton_Click);

            this.addEdgeButton = new System.Windows.Forms.Button() { Text = "Add Edge", Dock = System.Windows.Forms.DockStyle.Top };
            this.addEdgeButton.Click += new System.EventHandler(this.AddEdgeButton_Click);

            this.deleteButton = new System.Windows.Forms.Button() { Text = "Delete", Dock = System.Windows.Forms.DockStyle.Top };
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            // TextBox for labeling vertices
            this.vertexLabelTextBox = new System.Windows.Forms.TextBox() { Dock = System.Windows.Forms.DockStyle.Top, PlaceholderText = "Vertex Label" };

            // Information label for displaying graph data
            this.infoLabel = new System.Windows.Forms.Label() { Dock = System.Windows.Forms.DockStyle.Bottom, Height = 30, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };

            // Adding controls to the form
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.addVertexButton);
            this.Controls.Add(this.addEdgeButton);
            this.Controls.Add(this.vertexLabelTextBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.infoLabel);

            this.Text = "Graph Theorist's Sketchpad";
            this.ClientSize = new Size(800, 600);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}