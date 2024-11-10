using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Astronomical_Processing_;

namespace AstroDataProcessing
{
    public partial class MainForm : Form
    {
        private List<int> neutrinoData = new List<int>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateListDisplay();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateData();
            UpdateListDisplay();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            BubbleSort(neutrinoData);
            UpdateListDisplay();
            lblStatus.Text = "List sorted!";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int valueToSearch;
            if (int.TryParse(txtSearch.Text, out valueToSearch))
            {
                int resultIndex = BinarySearch(neutrinoData, valueToSearch);
                if (resultIndex != -1)
                {
                    HighlightValue(resultIndex);
                    lblStatus.Text = "Value found!";
                }
                else
                    lblStatus.Text = "Value not found.";
            }
            else
            {
                lblStatus.Text = "Invalid input.";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Editing functionality code goes here
        }

        private void UpdateListDisplay()
        {
            lstData.Items.Clear();
            foreach (var item in neutrinoData)
                lstData.Items.Add(item);
        }

        private void HighlightValue(int index)
        {
            lstData.SelectedIndex = index;
        }
    }
}
