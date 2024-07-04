namespace QuanLySinhVien.Student
{
    partial class Deadline
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewAssignments;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRefresh;

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
            this.listViewAssignments = new System.Windows.Forms.ListView();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.listBoxAssignments = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listViewAssignments
            // 
            this.listViewAssignments.FullRowSelect = true;
            this.listViewAssignments.GridLines = true;
            this.listViewAssignments.HideSelection = false;
            this.listViewAssignments.Location = new System.Drawing.Point(12, 12);
            this.listViewAssignments.Name = "listViewAssignments";
            this.listViewAssignments.Size = new System.Drawing.Size(279, 200);
            this.listViewAssignments.TabIndex = 0;
            this.listViewAssignments.UseCompatibleStateImageBehavior = false;
            this.listViewAssignments.View = System.Windows.Forms.View.Details;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 230);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(110, 235);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 16);
            this.lblFileName.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 270);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(537, 230);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // listBoxAssignments
            // 
            this.listBoxAssignments.FormattingEnabled = true;
            this.listBoxAssignments.ItemHeight = 16;
            this.listBoxAssignments.Location = new System.Drawing.Point(318, 13);
            this.listBoxAssignments.Name = "listBoxAssignments";
            this.listBoxAssignments.Size = new System.Drawing.Size(294, 196);
            this.listBoxAssignments.TabIndex = 5;
            // 
            // Deadline
            // 
            this.ClientSize = new System.Drawing.Size(624, 311);
            this.Controls.Add(this.listBoxAssignments);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.listViewAssignments);
            this.Name = "Deadline";
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.Deadline_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox listBoxAssignments;
    }
}
