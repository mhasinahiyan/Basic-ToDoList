using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MyTodoApp
{
    public partial class ToDoList : Form
    {
        private enum TaskFilter { All, Active, Done }

        private sealed class TaskItem
        {
            public string Title;
            public bool IsDone;
            public override string ToString() { return Title; }
        }

        // Crayon palette
        private static readonly Color CrayonPurple = Color.FromArgb(155, 89, 182);
        private static readonly Color CrayonGreen = Color.FromArgb(46, 204, 113);
        private static readonly Color CrayonInk = Color.FromArgb(52, 73, 94);
        private static readonly Color CrayonMuted = Color.FromArgb(170, 170, 170);
        private static readonly Color RowSelected = Color.FromArgb(255, 240, 200);
        private static readonly Color RowAlt = Color.FromArgb(255, 253, 245);

        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        private readonly ToolTip _hint = new ToolTip();

        private Font _strikeFont;
        private TaskFilter _filter = TaskFilter.All;
        private float _scale = 1f;

        public ToDoList()
        {
            InitializeComponent();
            ApplyTheme();

            using (Graphics g = CreateGraphics())
                _scale = g.DpiX / 96f;

            _strikeFont = new Font(lstTasks.Font, lstTasks.Font.Style | FontStyle.Strikeout);

            btnAdd.Click += BtnAdd_Click;
            btnComplete.Click += BtnComplete_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClearDone.Click += BtnClearDone_Click;
            txtTask.KeyDown += TxtTask_KeyDown;
            lstTasks.DrawItem += LstTasks_DrawItem;
            lstTasks.MouseDown += LstTasks_MouseDown;
            lstTasks.KeyDown += LstTasks_KeyDown;
            lstTasks.SelectedIndexChanged += (s, e) => UpdateButtons();
            rdoAll.CheckedChanged += FilterChanged;
            rdoActive.CheckedChanged += FilterChanged;
            rdoDone.CheckedChanged += FilterChanged;
            Shown += (s, e) => txtTask.Focus();
            FormClosed += (s, e) =>
            {
                _strikeFont.Dispose();
                _hint.Dispose();
            };

            RefreshList();
        }

        // Styling lives here (not in the Designer file) so the Windows Forms designer
        // can't wipe it out the next time you drag something around.
        private void ApplyTheme()
        {
            StyleAction(btnAdd, Color.FromArgb(46, 204, 113), Color.FromArgb(39, 174, 96));
            StyleAction(btnComplete, Color.FromArgb(52, 152, 219), Color.FromArgb(41, 128, 185));
            StyleAction(btnDelete, Color.FromArgb(231, 76, 60), Color.FromArgb(192, 57, 43));
            StyleAction(btnClearDone, CrayonPurple, Color.FromArgb(125, 60, 152));

            foreach (RadioButton rb in new[] { rdoAll, rdoActive, rdoDone })
            {
                rb.Cursor = Cursors.Hand;
                rb.FlatStyle = FlatStyle.Flat;
                rb.FlatAppearance.BorderColor = CrayonPurple;
                rb.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 226, 150);
                rb.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
                rb.ForeColor = CrayonInk;
            }
        }

        private static void StyleAction(Button b, Color back, Color border)
        {
            b.BackColor = back;
            b.Cursor = Cursors.Hand;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = border;
            b.FlatAppearance.BorderSize = 3;
            b.Font = new Font("Comic Sans MS", 11F, FontStyle.Bold);
            b.ForeColor = Color.White;
            b.UseVisualStyleBackColor = false;
        }

        private int S(int value)
        {
            return (int)Math.Round(value * _scale);
        }

        // ─────────────────────────────────────────────
        //  Add
        // ─────────────────────────────────────────────
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void TxtTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // avoid the "ding"
                e.Handled = true;
                AddTask();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txtTask.Clear();
            }
        }

        private void AddTask()
        {
            string title = txtTask.Text.Trim();

            if (title.Length == 0)
            {
                ShowHint("Write something first! 🖍️");
                return;
            }

            if (_tasks.Any(t => !t.IsDone &&
                string.Equals(t.Title, title, StringComparison.OrdinalIgnoreCase)))
            {
                ShowHint("That's already on your list.");
                return;
            }

            TaskItem item = new TaskItem { Title = title };
            _tasks.Add(item);
            txtTask.Clear();

            if (_filter == TaskFilter.Done)
                rdoAll.Checked = true;   // otherwise the new task would be hidden

            RefreshList();
            lstTasks.SelectedItem = item;
            txtTask.Focus();
        }

        // ─────────────────────────────────────────────
        //  Toggle done / undone
        // ─────────────────────────────────────────────
        private void BtnComplete_Click(object sender, EventArgs e)
        {
            TaskItem item = lstTasks.SelectedItem as TaskItem;
            if (item != null) Toggle(item);
        }

        private void Toggle(TaskItem item)
        {
            item.IsDone = !item.IsDone;
            RefreshList();
        }

        // ─────────────────────────────────────────────
        //  Delete / clear completed
        // ─────────────────────────────────────────────
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void DeleteSelected()
        {
            TaskItem item = lstTasks.SelectedItem as TaskItem;
            if (item == null) return;

            string preview = item.Title.Length > 80 ? item.Title.Substring(0, 80) + "…" : item.Title;
            DialogResult confirm = MessageBox.Show(this,
                "Delete this task?\n\n\"" + preview + "\"",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            _tasks.Remove(item);
            RefreshList();
        }

        private void BtnClearDone_Click(object sender, EventArgs e)
        {
            int doneCount = _tasks.Count(t => t.IsDone);
            if (doneCount == 0) return;

            DialogResult confirm = MessageBox.Show(this,
                "Remove " + doneCount + " completed task" + (doneCount == 1 ? "" : "s") + "?",
                "Clear completed",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            _tasks.RemoveAll(t => t.IsDone);
            RefreshList();
        }

        // ─────────────────────────────────────────────
        //  List interaction
        // ─────────────────────────────────────────────
        private void LstTasks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            int index = lstTasks.IndexFromPoint(e.Location);
            if (index < 0) return;

            Rectangle hitArea = GetCheckBoxRect(lstTasks.GetItemRectangle(index));
            hitArea.Inflate(S(6), S(6));

            if (hitArea.Contains(e.Location))
            {
                lstTasks.SelectedIndex = index;
                Toggle((TaskItem)lstTasks.Items[index]);
            }
        }

        private void LstTasks_KeyDown(object sender, KeyEventArgs e)
        {
            TaskItem item = lstTasks.SelectedItem as TaskItem;
            if (item == null) return;

            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Toggle(item);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                DeleteSelected();
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked) return;

            _filter = rb == rdoActive ? TaskFilter.Active
                    : rb == rdoDone ? TaskFilter.Done
                    : TaskFilter.All;
            RefreshList();
        }

        // ─────────────────────────────────────────────
        //  Rendering
        // ─────────────────────────────────────────────
        private Rectangle GetCheckBoxRect(Rectangle row)
        {
            int size = S(18);
            return new Rectangle(row.Left + S(14), row.Top + (row.Height - size) / 2, size, size);
        }

        private void LstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstTasks.Items.Count) return;

            TaskItem item = (TaskItem)lstTasks.Items[e.Index];
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color bg = selected ? RowSelected : (e.Index % 2 == 0 ? Color.White : RowAlt);
            using (SolidBrush b = new SolidBrush(bg))
                e.Graphics.FillRectangle(b, e.Bounds);

            // Left accent bar so the selection is obvious even without focus
            if (selected)
            {
                using (SolidBrush accent = new SolidBrush(CrayonPurple))
                    e.Graphics.FillRectangle(accent, e.Bounds.Left, e.Bounds.Top, S(4), e.Bounds.Height);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Checkbox
            Rectangle box = GetCheckBoxRect(e.Bounds);
            using (Pen boxPen = new Pen(CrayonPurple, 2))
                e.Graphics.DrawRectangle(boxPen, box);

            if (item.IsDone)
            {
                using (Pen checkPen = new Pen(CrayonGreen, 3))
                {
                    checkPen.StartCap = LineCap.Round;
                    checkPen.EndCap = LineCap.Round;
                    checkPen.LineJoin = LineJoin.Round;

                    Point[] tick =
                    {
                        new Point(box.Left + box.Width * 3 / 18, box.Top + box.Height * 9 / 18),
                        new Point(box.Left + box.Width * 7 / 18, box.Top + box.Height * 14 / 18),
                        new Point(box.Left + box.Width * 15 / 18, box.Top + box.Height * 3 / 18)
                    };
                    e.Graphics.DrawLines(checkPen, tick);
                }
            }

            // Text (NoPrefix: a task like "Fish & chips" must not turn "&c" into an underline)
            Font textFont = item.IsDone ? _strikeFont : e.Font;
            Color textColor = item.IsDone ? CrayonMuted : CrayonInk;

            Rectangle textRect = new Rectangle(
                box.Right + S(12),
                e.Bounds.Top,
                Math.Max(0, e.Bounds.Right - box.Right - S(12) - S(10)),
                e.Bounds.Height);

            TextRenderer.DrawText(e.Graphics, item.Title, textFont, textRect, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);

            // Dotted separator
            using (Pen sep = new Pen(Color.FromArgb(240, 230, 210), 1))
            {
                sep.DashStyle = DashStyle.Dot;
                e.Graphics.DrawLine(sep,
                    e.Bounds.Left + S(10), e.Bounds.Bottom - 1,
                    e.Bounds.Right - S(10), e.Bounds.Bottom - 1);
            }
        }

        // ─────────────────────────────────────────────
        //  State -> UI
        // ─────────────────────────────────────────────
        private void RefreshList()
        {
            TaskItem selected = lstTasks.SelectedItem as TaskItem;
            int oldIndex = lstTasks.SelectedIndex;

            IEnumerable<TaskItem> visible = _tasks;
            if (_filter == TaskFilter.Active) visible = _tasks.Where(t => !t.IsDone);
            else if (_filter == TaskFilter.Done) visible = _tasks.Where(t => t.IsDone);

            lstTasks.BeginUpdate();
            try
            {
                lstTasks.Items.Clear();
                foreach (TaskItem t in visible) lstTasks.Items.Add(t);

                int newIndex = selected != null ? lstTasks.Items.IndexOf(selected) : -1;

                // Selected item vanished (deleted / filtered out): keep the neighbour selected
                if (newIndex < 0 && oldIndex >= 0 && lstTasks.Items.Count > 0)
                    newIndex = Math.Min(oldIndex, lstTasks.Items.Count - 1);

                lstTasks.SelectedIndex = newIndex;
            }
            finally
            {
                lstTasks.EndUpdate();
            }

            if (_tasks.Count == 0)
                lblEmpty.Text = "Nothing here yet!\nAdd your first task above. 🖍️";
            else if (_filter == TaskFilter.Active)
                lblEmpty.Text = "All caught up! 🎉";
            else
                lblEmpty.Text = "Nothing finished yet.\nYou've got this! 💪";
            lblEmpty.Visible = lstTasks.Items.Count == 0;

            UpdateButtons();
            UpdateCounter();
        }

        private void UpdateCounter()
        {
            int total = _tasks.Count;
            int done = _tasks.Count(t => t.IsDone);
            lblCounter.Text = $"{total} task{(total == 1 ? "" : "s")}  •  {done} done";
        }

        private void UpdateButtons()
        {
            bool hasSelection = lstTasks.SelectedItem != null;
            btnComplete.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnClearDone.Enabled = _tasks.Any(t => t.IsDone);
        }

        private void ShowHint(string text)
        {
            _hint.Show(text, txtTask, 0, txtTask.Height + 4, 1800);
            txtTask.Focus();
        }
    }
}