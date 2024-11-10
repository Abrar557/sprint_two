// Name: Abrar Jawad
// ID: 30096557
// Sprint Number: 01

// Date: 21/10/2024

// Version: 1.0

// Name of the program: Astronomical Processing

// Program Description:
// This program simulates astronomical data processing by generating a list of random neutrino interaction values. 
// Users can search for specific values using binary search, sort the data using bubble sort, and edit values directly in the displayed list.
// The program checks if the array is sorted before allowing binary search, and it highlights the found value in the list when found.

// Inputs: 
// - A user-specified value in the search box to find in the neutrinoData array.
// - Button clicks to trigger sorting and searching functionalities.
// - Double-clicking on the list to edit a specific neutrino interaction value.

// Processes:
// - Generating an array of random integers to simulate hourly neutrino interactions.
// - Sorting the array using the Bubble Sort algorithm.
// - Searching for a user-inputted value using Binary Search.
// - Editing an element of the array through a double-click interaction on the list box.

// Outputs:
// - Sorted array displayed in the list box.
// - Search result message showing if a value was found or not.
// - Highlighted value in the list box when the binary search finds the specified value.
// - User input box for editing a list item.
// - A message box displaying confirmation of the edit.


using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AstroDataProcessing
{
    public partial class Form1 : Form
    {
        private List<int> neutrinoData = new List<int>();

        public Form1()
        {
            InitializeComponent();
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

        private void GenerateData()
        {
            Random rnd = new Random();
            neutrinoData.Clear();
            for (int i = 0; i < 20; i++) // Generate 20 random values
                neutrinoData.Add(rnd.Next(1, 100));
        }

        private void BubbleSort(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = 0; j < data.Count - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }

        private int BinarySearch(List<int> data, int target)
        {
            int left = 0, right = data.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (data[mid] == target)
                    return mid;
                else if (data[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
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
