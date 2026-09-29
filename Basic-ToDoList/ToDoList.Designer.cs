using System.Drawing;
using System.Windows.Forms;

namespace MyTodoApp
{
    partial class ToDoList
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel tblRoot;
        private TableLayoutPanel tblInput;
        private TableLayoutPanel tblActions;
        private FlowLayoutPanel pnlFilter;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCounter;
        private Label lblEmpty;
        private TextBox txtTask;
        private Button btnAdd;
        private Button btnComplete;
        private Button btnDelete;
        private Button btnClearDone;
        private RadioButton rdoAll;
        private RadioButton rdoActive;
        private RadioButton rdoDone;
        private ListBox lstTasks;

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
            this.tblRoot = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.tblInput = new System.Windows.Forms.TableLayoutPanel();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoDone = new System.Windows.Forms.RadioButton();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.tblActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearDone = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.tblRoot.SuspendLayout();
            this.tblInput.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.lstTasks.SuspendLayout();
            this.tblActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRoot
            // 
            this.tblRoot.ColumnCount = 1;
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.Controls.Add(this.lblSubtitle, 0, 1);
            this.tblRoot.Controls.Add(this.tblInput, 0, 2);
            this.tblRoot.Controls.Add(this.pnlFilter, 0, 3);
            this.tblRoot.Controls.Add(this.lstTasks, 0, 4);
            this.tblRoot.Controls.Add(this.tblActions, 0, 5);
            this.tblRoot.Controls.Add(this.lblCounter, 0, 6);
            this.tblRoot.Controls.Add(this.lblTitle, 0, 0);
            this.tblRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRoot.Location = new System.Drawing.Point(0, 0);
            this.tblRoot.Name = "tblRoot";
            this.tblRoot.Padding = new System.Windows.Forms.Padding(24, 16, 24, 12);
            this.tblRoot.RowCount = 7;
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRoot.Size = new System.Drawing.Size(600, 700);
            this.tblRoot.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(322, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🖍️  My To-Do List";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblSubtitle.Location = new System.Drawing.Point(26, 61);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 0, 8);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(185, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Write it down. Get it done!";
            // 
            // tblInput
            // 
            this.tblInput.ColumnCount = 2;
            this.tblInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tblInput.Controls.Add(this.txtTask, 0, 0);
            this.tblInput.Controls.Add(this.btnAdd, 1, 0);
            this.tblInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInput.Location = new System.Drawing.Point(24, 89);
            this.tblInput.Margin = new System.Windows.Forms.Padding(0);
            this.tblInput.Name = "tblInput";
            this.tblInput.RowCount = 1;
            this.tblInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblInput.Size = new System.Drawing.Size(552, 56);
            this.tblInput.TabIndex = 2;
            // 
            // txtTask
            // 
            this.txtTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTask.BackColor = System.Drawing.Color.White;
            this.txtTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTask.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.txtTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtTask.Location = new System.Drawing.Point(0, 13);
            this.txtTask.Margin = new System.Windows.Forms.Padding(0);
            this.txtTask.MaxLength = 200;
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(422, 30);
            this.txtTask.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAdd.FlatAppearance.BorderSize = 3;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(430, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "✚  Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.rdoAll);
            this.pnlFilter.Controls.Add(this.rdoActive);
            this.pnlFilter.Controls.Add(this.rdoDone);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(24, 145);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 6, 0, 4);
            this.pnlFilter.Size = new System.Drawing.Size(552, 44);
            this.pnlFilter.TabIndex = 3;
            this.pnlFilter.WrapContents = false;
            // 
            // rdoAll
            // 
            this.rdoAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(0, 6);
            this.rdoAll.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(92, 34);
            this.rdoAll.TabIndex = 2;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoActive
            // 
            this.rdoActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoActive.Location = new System.Drawing.Point(100, 6);
            this.rdoActive.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(92, 34);
            this.rdoActive.TabIndex = 3;
            this.rdoActive.Text = "To do";
            this.rdoActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoDone
            // 
            this.rdoDone.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDone.Location = new System.Drawing.Point(200, 6);
            this.rdoDone.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rdoDone.Name = "rdoDone";
            this.rdoDone.Size = new System.Drawing.Size(92, 34);
            this.rdoDone.TabIndex = 4;
            this.rdoDone.Text = "Done";
            this.rdoDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstTasks
            // 
            this.lstTasks.BackColor = System.Drawing.Color.White;
            this.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTasks.Controls.Add(this.lblEmpty);
            this.lstTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstTasks.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.lstTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lstTasks.IntegralHeight = false;
            this.lstTasks.ItemHeight = 38;
            this.lstTasks.Location = new System.Drawing.Point(24, 189);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(0);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(552, 415);
            this.lstTasks.TabIndex = 5;
            // 
            // lblEmpty
            // 
            this.lblEmpty.BackColor = System.Drawing.Color.White;
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic);
            this.lblEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblEmpty.Location = new System.Drawing.Point(0, 0);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(550, 413);
            this.lblEmpty.TabIndex = 0;
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            // 
            // tblActions
            // 
            this.tblActions.ColumnCount = 3;
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tblActions.Controls.Add(this.btnComplete, 0, 0);
            this.tblActions.Controls.Add(this.btnDelete, 1, 0);
            this.tblActions.Controls.Add(this.btnClearDone, 2, 0);
            this.tblActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblActions.Location = new System.Drawing.Point(24, 604);
            this.tblActions.Margin = new System.Windows.Forms.Padding(0);
            this.tblActions.Name = "tblActions";
            this.tblActions.RowCount = 1;
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActions.Size = new System.Drawing.Size(552, 60);
            this.tblActions.TabIndex = 6;
            // 
            // btnComplete
            // 
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnComplete.Location = new System.Drawing.Point(0, 8);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(0, 8, 4, 4);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(179, 48);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.Text = "✔  Done / Undo";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(187, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(175, 48);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "🗑  Delete";
            // 
            // btnClearDone
            // 
            this.btnClearDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearDone.Location = new System.Drawing.Point(370, 8);
            this.btnClearDone.Margin = new System.Windows.Forms.Padding(4, 8, 0, 4);
            this.btnClearDone.Name = "btnClearDone";
            this.btnClearDone.Size = new System.Drawing.Size(182, 48);
            this.btnClearDone.TabIndex = 8;
            this.btnClearDone.Text = "🧹  Clear done";
            // 
            // lblCounter
            // 
            this.lblCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic);
            this.lblCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.lblCounter.Location = new System.Drawing.Point(239, 668);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(122, 20);
            this.lblCounter.TabIndex = 7;
            this.lblCounter.Text = "0 tasks  •  0 done";
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.tblRoot);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.MinimumSize = new System.Drawing.Size(520, 600);
            this.Name = "ToDoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "✏️  My Crayon To-Do List";
            this.tblRoot.ResumeLayout(false);
            this.tblRoot.PerformLayout();
            this.tblInput.ResumeLayout(false);
            this.tblInput.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.lstTasks.ResumeLayout(false);
            this.tblActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}