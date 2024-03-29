﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;

namespace RAA_Session_07_Skills
{
    public partial class frmTestForm : Form
    {
        BindingList<TestData> dataList = new BindingList<TestData>();
        public frmTestForm(string filepath)
        {
            TestData data1 = new TestData("a", "b", 1);
            TestData data2 = new TestData("c", "d", 2);

            dataList.Add(data1);
            dataList.Add(data2);

            InitializeComponent();

            lbxText.DataSource = dataList;
            lbxText.DisplayMember = "Combo";
        }

        private void btnButton1_Click(object sender, EventArgs e)
        {
            TaskDialog.Show("Test", "I pressed the button");
        }

        private void btnButton2_Click(object sender, EventArgs e)
        {
            tbxTextBox.Text = "This is Button 2 text";
        }

        private void btnButton3_Click(object sender, EventArgs e)
        {
            lbxText.Items.Add("This is Button 3 text");
        }

        private void lbxText_DoubleClick(object sender, EventArgs e)
        {
            tbxTextBox.Text = "I double clicked an item";
        }
    }
}
 