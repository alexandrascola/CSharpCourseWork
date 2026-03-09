using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectoryManager
{
    internal class MainForm : Form //Makes our class extend the Form class
    {
        //Form Controls
        //INPUTS
        private readonly TextBox txtId = new() {PlaceholderText = "E0001" };
        private readonly TextBox txtName = new() { PlaceholderText = "Full Name" };
        private readonly TextBox txtDepartment = new() { PlaceholderText = "Department" };
        private readonly TextBox txtRole = new() { PlaceholderText = "Role" };
        private readonly TextBox txtSalary = new() { PlaceholderText = "Salary (e.g. 55000)" };
        private readonly DateTimePicker dtHire = new() { Format = DateTimePickerFormat.Custom, CustomFormat = "yyyy-MM-dd" };

        //BUTTONS
        private readonly Button btnAdd = new() { Text = "Add" };
        private readonly Button btnUpdate = new() { Text = "Update" };
        private readonly Button btnDelete = new() { Text = "Delete" };
        private readonly Button btnSave = new() { Text = "Save" };
        private readonly Button btnLoad = new() { Text = "Load" };
        private readonly Button btnExit = new() { Text = "Exit" };

        //DATAGRID and STATUS
        private readonly DataGridView grid = new()
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AutoGenerateColumns = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        private readonly Label lblStatus = new() { Text = "Status: Ready", AutoEllipsis = true };
        
        //Employee Manager
        private readonly EmployeeManager manager = new();

        //Constructor
        public MainForm()
        { 
            //Form Settings
            Text = "Employee Directory Manager";
            MinimumSize = new Size(960, 560);
            StartPosition = FormStartPosition.CenterScreen;

            //Top Layout
            var top = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 120,
                ColumnCount = 6,
                RowCount = 2,
                Padding = new Padding(10)
            };
            for (int i = 0; i < 6; i++) top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6f));
            top.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            top.RowStyles.Add(new RowStyle(SizeType.Percent, 55));

            //Row Labels
            //ROW 0 LABELS
            top.Controls.Add(new Label { Text = "Employee ID", AutoSize = true }, 0, 0);
            top.Controls.Add(new Label { Text = "Full Name", AutoSize = true }, 1, 0);
            top.Controls.Add(new Label { Text = "Department", AutoSize = true }, 2, 0);
            top.Controls.Add(new Label { Text = "Role", AutoSize = true }, 3, 0);
            top.Controls.Add(new Label { Text = "Salary", AutoSize = true }, 4, 0);
            top.Controls.Add(new Label { Text = "Hire Date", AutoSize = true }, 5, 0);

            //ROW 1 LABELS
            txtId.Anchor = txtName.Anchor = txtDepartment.Anchor = txtRole.Anchor = txtSalary.Anchor = dtHire.Anchor = AnchorStyles.Left | AnchorStyles.Right;



            //Compose the Form
            Controls.Add(top);

        }



        //Actions (Methods)

    }
}
