using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel;
using Data;


namespace AppTracker
{
    public partial class FormMain : Form
    {
        MenuItem deleteMenuItem = new MenuItem("Delete");
        ContextMenu menu = new ContextMenu();
        TreeNode selectedTreeItem;

        public FormMain()
        {
            InitializeComponent();
            menu.MenuItems.Add(deleteMenuItem);
            deleteMenuItem.Click += new EventHandler(DeleteMenuItem_Click);
            treeViewPeriod.Nodes.Clear();
        }


        private void treeViewPeriod_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedTreeItem = e.Node;
                menu.Show(treeViewPeriod, e.Location);
            }
        }

        void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTreeItem.Tag is Period)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm you wish to delete " + selectedTreeItem.Tag.ToString(), "Delete this Period" + Environment.NewLine + "plus all its positions?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Data.PeriodMethods.DeletePeriod(selectedTreeItem.Tag as Period);
                    treeViewPeriod.Nodes.Remove(selectedTreeItem);
                }
            }
            else if (selectedTreeItem.Tag is Position)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm you wish to delete " + selectedTreeItem.Tag.ToString(), "Delete this Position ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Data.PositionMethods.DeletePosition(selectedTreeItem.Tag as Position);
                    treeViewPeriod.Nodes.Remove(selectedTreeItem);
                }
            }
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            FormPeriod frm = new FormPeriod(new Period() { DateFrom = DateTime.Now, DateTo = DateTime.Now });
            DialogResult retVal = frm.ShowDialog();
            if ( retVal == DialogResult.OK)
            {
                Data.PeriodMethods.InsertPeriod(frm.DataBinding);

                TreeNode newNode = new TreeNode();
                newNode.Tag = frm.DataBinding;
                newNode.Text = frm.DataBinding.ToString();
                treeViewPeriod.Nodes.Add(newNode);
            }
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            Position p = new Position() {
                Position1 = "New Job",
                Company = "Company",
                Location = "Location",
                DateApplied = DateTime.Now,
                Contact = "Contact",
                Description = "No description",
                URL = "www.google.com",
                Period = treeViewPeriod.Nodes[0].Tag as Period
            };

            FormPosition frm = new FormPosition(p);
            DialogResult retVal = frm.ShowDialog();
            if (retVal == DialogResult.OK)
            {
                Data.PositionMethods.InsertPosition(frm.DataBinding);

                var periods = Data.PeriodMethods.SelectPeriods();
                PopulateTree(periods);
            }
        }

        private void PopulateTree(List<Period> periods)
        {
            treeViewPeriod.BeginUpdate();
            treeViewPeriod.Nodes.Clear();

            foreach (Period p in periods)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = p;
                newNode.Text = p.ToString();

                foreach (Position pos in p.Positions)
                {
                    TreeNode posNode = new TreeNode();
                    posNode.Tag = pos;
                    posNode.Text = pos.ToString();
                    newNode.Nodes.Add(posNode);
                }
                treeViewPeriod.Nodes.Add(newNode);
            }
            treeViewPeriod.EndUpdate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var periods = Data.PeriodMethods.SelectPeriods();

            PopulateTree(periods);
        }

        private void treeViewPeriod_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeViewPeriod.SelectedNode;
            if (node.Tag is Period)
            {
                Period tag = node.Tag as Period;

                FormPeriod frm = new FormPeriod(tag);
                //frm.DataBinding = tag;
                DialogResult retVal = frm.ShowDialog();

                if (retVal == DialogResult.OK)
                {
                    Data.PeriodMethods.UpdatePeriod(frm.DataBinding);

                    var periods = Data.PeriodMethods.SelectPeriods();
                    PopulateTree(periods);
                }
            }
            else if (node.Tag is Position)
            {
                Position tag = node.Tag as Position;

                FormPosition frm = new FormPosition(tag);
                //frm.DataBinding = tag;
                DialogResult retVal = frm.ShowDialog();

                if (retVal == DialogResult.OK)
                {
                    Data.PositionMethods.UpdatePosition(frm.DataBinding);

                    var periods = Data.PeriodMethods.SelectPeriods();
                    PopulateTree(periods);
                }
            }
        }
    }
}
