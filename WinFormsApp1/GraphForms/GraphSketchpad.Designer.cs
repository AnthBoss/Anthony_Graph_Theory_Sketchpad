
namespace GraphTheoristSketchpad
{
    partial class SketchPad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            graphPanel = new Panel();
            select_color_button = new Button();
            deleteButton = new Button();
            paint_color_dialog = new ColorDialog();
            paint_button = new Button();
            delete_label = new Label();
            select_color_label = new Label();
            vertex_label = new Label();
            edge_label = new Label();
            deg_label = new Label();
            component_label = new Label();
            clear_all_button = new Button();
            matrix_display = new RichTextBox();
            bipartite_label = new Label();
            bipartite_test_button = new Button();
            SuspendLayout();
            // 
            // graphPanel
            // 
            graphPanel.AutoSize = true;
            graphPanel.BackColor = Color.PapayaWhip;
            graphPanel.Location = new Point(12, 12);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(1226, 647);
            graphPanel.TabIndex = 0;
            graphPanel.Paint += panel1_Paint;
            graphPanel.MouseClick += panel1_MouseClick_1;
            graphPanel.MouseDown += GraphPanel_MouseDown;
            graphPanel.MouseMove += GraphPanel_MouseMove;
            graphPanel.MouseUp += GraphPanel_MouseUp;
            // 
            // select_color_button
            // 
            select_color_button.AutoSize = true;
            select_color_button.BackColor = Color.Red;
            select_color_button.Location = new Point(817, 775);
            select_color_button.Name = "select_color_button";
            select_color_button.Size = new Size(75, 70);
            select_color_button.TabIndex = 2;
            select_color_button.UseVisualStyleBackColor = false;
            select_color_button.Click += Select_color_button_Click;
            // 
            // deleteButton
            // 
            deleteButton.AutoSize = true;
            deleteButton.BackColor = SystemColors.ButtonFace;
            deleteButton.ForeColor = SystemColors.ActiveCaptionText;
            deleteButton.Location = new Point(989, 775);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 70);
            deleteButton.TabIndex = 1;
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += DeleteButton_Click;
            // 
            // paint_color_dialog
            // 
            paint_color_dialog.AnyColor = true;
            paint_color_dialog.Color = Color.Red;
            // 
            // paint_button
            // 
            paint_button.AutoSize = true;
            paint_button.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            paint_button.Location = new Point(817, 851);
            paint_button.Name = "paint_button";
            paint_button.Size = new Size(75, 30);
            paint_button.TabIndex = 3;
            paint_button.Text = "paint";
            paint_button.TextAlign = ContentAlignment.TopCenter;
            paint_button.UseVisualStyleBackColor = true;
            paint_button.Click += Paint_button_Click_1;
            // 
            // delete_label
            // 
            delete_label.AutoSize = true;
            delete_label.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            delete_label.Location = new Point(998, 752);
            delete_label.Name = "delete_label";
            delete_label.Size = new Size(54, 20);
            delete_label.TabIndex = 4;
            delete_label.Text = "Delete";
            delete_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // select_color_label
            // 
            select_color_label.AutoSize = true;
            select_color_label.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            select_color_label.Location = new Point(801, 752);
            select_color_label.Name = "select_color_label";
            select_color_label.Size = new Size(91, 20);
            select_color_label.TabIndex = 5;
            select_color_label.Text = "Select Color";
            select_color_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // vertex_label
            // 
            vertex_label.AutoSize = true;
            vertex_label.Font = new Font("Cambria Math", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            vertex_label.Location = new Point(292, 660);
            vertex_label.Name = "vertex_label";
            vertex_label.Size = new Size(69, 100);
            vertex_label.TabIndex = 6;
            vertex_label.Text = "n =";
            // 
            // edge_label
            // 
            edge_label.AutoSize = true;
            edge_label.Font = new Font("Cambria Math", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            edge_label.Location = new Point(292, 760);
            edge_label.Name = "edge_label";
            edge_label.Size = new Size(74, 100);
            edge_label.TabIndex = 7;
            edge_label.Text = "m =";
            // 
            // deg_label
            // 
            deg_label.AutoSize = true;
            deg_label.Font = new Font("Cambria Math", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            deg_label.Location = new Point(12, 760);
            deg_label.Name = "deg_label";
            deg_label.Size = new Size(112, 100);
            deg_label.TabIndex = 8;
            deg_label.Text = "deg(V) =";
            // 
            // component_label
            // 
            component_label.AutoSize = true;
            component_label.Font = new Font("Cambria Math", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            component_label.Location = new Point(12, 660);
            component_label.Name = "component_label";
            component_label.Size = new Size(155, 100);
            component_label.TabIndex = 9;
            component_label.Text = "components =";
            // 
            // clear_all_button
            // 
            clear_all_button.AutoSize = true;
            clear_all_button.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear_all_button.Location = new Point(989, 851);
            clear_all_button.Name = "clear_all_button";
            clear_all_button.Size = new Size(75, 30);
            clear_all_button.TabIndex = 10;
            clear_all_button.Text = "clear all";
            clear_all_button.TextAlign = ContentAlignment.TopCenter;
            clear_all_button.UseVisualStyleBackColor = true;
            clear_all_button.Click += Clear_all_button_Click;
            // 
            // matrix_display
            // 
            matrix_display.BackColor = SystemColors.ActiveCaption;
            matrix_display.BorderStyle = BorderStyle.None;
            matrix_display.Font = new Font("Arial Narrow", 12F, FontStyle.Italic, GraphicsUnit.Point);
            matrix_display.Location = new Point(1521, 37);
            matrix_display.Name = "matrix_display";
            matrix_display.ReadOnly = true;
            matrix_display.Size = new Size(196, 296);
            matrix_display.TabIndex = 12;
            matrix_display.Text = "";
            // 
            // bipartite_label
            // 
            bipartite_label.AutoSize = true;
            bipartite_label.Font = new Font("Cambria Math", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            bipartite_label.Location = new Point(507, 660);
            bipartite_label.Name = "bipartite_label";
            bipartite_label.Size = new Size(114, 100);
            bipartite_label.TabIndex = 13;
            bipartite_label.Text = "bipartite:";
            // 
            // bipartite_test_button
            // 
            bipartite_test_button.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bipartite_test_button.Location = new Point(522, 730);
            bipartite_test_button.Name = "bipartite_test_button";
            bipartite_test_button.Size = new Size(75, 30);
            bipartite_test_button.TabIndex = 14;
            bipartite_test_button.Text = "run test";
            bipartite_test_button.UseVisualStyleBackColor = true;
            bipartite_test_button.Click += Bipartite_test_button_Click;
            // 
            // SketchPad
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1874, 958);
            Controls.Add(select_color_button);
            Controls.Add(bipartite_test_button);
            Controls.Add(bipartite_label);
            Controls.Add(matrix_display);
            Controls.Add(clear_all_button);
            Controls.Add(component_label);
            Controls.Add(deg_label);
            Controls.Add(edge_label);
            Controls.Add(vertex_label);
            Controls.Add(select_color_label);
            Controls.Add(delete_label);
            Controls.Add(paint_button);
            Controls.Add(deleteButton);
            Controls.Add(graphPanel);
            ForeColor = SystemColors.ControlText;
            Name = "SketchPad";
            Text = "GraphSketchPad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel graphPanel;
        private Button deleteButton;
        private Button select_color_button;
        private ColorDialog paint_color_dialog;
        private Button paint_button;
        private Label delete_label;
        private Label select_color_label;
        private Label vertex_label;
        private Label edge_label;
        private Label deg_label;
        private Label component_label;
        private Button clear_all_button;
        private RichTextBox matrix_display;
        private Label bipartite_label;
        private Button bipartite_test_button;
    }
}

