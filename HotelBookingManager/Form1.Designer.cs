namespace HotelBookingManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcomeLabel = new Label();
            lblGuestName = new Label();
            lblRoomNumber = new Label();
            lblCheckIn = new Label();
            lblCheckOut = new Label();
            txtGuest = new TextBox();
            txtRoom = new TextBox();
            dtIn = new DateTimePicker();
            dtOut = new DateTimePicker();
            btnBook = new Button();
            btnCancel = new Button();
            btnView = new Button();
            btnExit = new Button();
            lblStatus = new Label();
            lvBookings = new ListView();
            SuspendLayout();
            // 
            // lblWelcomeLabel
            // 
            lblWelcomeLabel.AutoSize = true;
            lblWelcomeLabel.Font = new Font("Palatino Linotype", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeLabel.ForeColor = SystemColors.Control;
            lblWelcomeLabel.Location = new Point(71, 28);
            lblWelcomeLabel.Name = "lblWelcomeLabel";
            lblWelcomeLabel.Size = new Size(774, 70);
            lblWelcomeLabel.TabIndex = 0;
            lblWelcomeLabel.Text = "Welcome to the Wrenfield Hotel";
            lblWelcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcomeLabel.Click += lblWelcomeLabel_Click;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.ForeColor = SystemColors.ControlLight;
            lblGuestName.Location = new Point(67, 115);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(113, 25);
            lblGuestName.TabIndex = 1;
            lblGuestName.Text = "Guest Name:";
            lblGuestName.TextAlign = ContentAlignment.TopRight;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.ForeColor = SystemColors.ButtonFace;
            lblRoomNumber.Location = new Point(540, 112);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(134, 25);
            lblRoomNumber.TabIndex = 2;
            lblRoomNumber.Text = "Room Number:";
            lblRoomNumber.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.ForeColor = SystemColors.ButtonFace;
            lblCheckIn.Location = new Point(71, 229);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(85, 25);
            lblCheckIn.TabIndex = 3;
            lblCheckIn.Text = "Check-In:";
            lblCheckIn.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.ForeColor = SystemColors.ButtonFace;
            lblCheckOut.Location = new Point(540, 228);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(100, 25);
            lblCheckOut.TabIndex = 4;
            lblCheckOut.Text = "Check-Out:";
            lblCheckOut.TextAlign = ContentAlignment.TopRight;
            // 
            // txtGuest
            // 
            txtGuest.Location = new Point(186, 109);
            txtGuest.Name = "txtGuest";
            txtGuest.Size = new Size(326, 31);
            txtGuest.TabIndex = 5;
            txtGuest.Text = "Guest Name";
            // 
            // txtRoom
            // 
            txtRoom.Location = new Point(681, 109);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(150, 31);
            txtRoom.TabIndex = 6;
            txtRoom.Text = "Room (e.g 101)";
            // 
            // dtIn
            // 
            dtIn.Location = new Point(181, 229);
            dtIn.Name = "dtIn";
            dtIn.Size = new Size(331, 31);
            dtIn.TabIndex = 7;
            // 
            // dtOut
            // 
            dtOut.Location = new Point(646, 229);
            dtOut.Name = "dtOut";
            dtOut.Size = new Size(300, 31);
            dtOut.TabIndex = 8;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(167, 300);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(155, 38);
            btnBook.TabIndex = 9;
            btnBook.Text = "Book Room";
            btnBook.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(368, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(157, 38);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel Booking";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            btnView.Location = new Point(553, 300);
            btnView.Name = "btnView";
            btnView.Size = new Size(166, 38);
            btnView.TabIndex = 11;
            btnView.Text = "View All Bookings";
            btnView.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(800, 300);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(118, 38);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.ButtonFace;
            lblStatus.Location = new Point(82, 611);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 32);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Ready.";
            // 
            // lvBookings
            // 
            lvBookings.Location = new Point(69, 354);
            lvBookings.Name = "lvBookings";
            lvBookings.Size = new Size(968, 236);
            lvBookings.TabIndex = 14;
            lvBookings.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1099, 669);
            Controls.Add(lvBookings);
            Controls.Add(lblStatus);
            Controls.Add(btnExit);
            Controls.Add(btnView);
            Controls.Add(btnCancel);
            Controls.Add(btnBook);
            Controls.Add(dtOut);
            Controls.Add(dtIn);
            Controls.Add(txtRoom);
            Controls.Add(txtGuest);
            Controls.Add(lblCheckOut);
            Controls.Add(lblCheckIn);
            Controls.Add(lblRoomNumber);
            Controls.Add(lblGuestName);
            Controls.Add(lblWelcomeLabel);
            Name = "Form1";
            Text = "Hotel Booking Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcomeLabel;
        private Label lblGuestName;
        private Label lblRoomNumber;
        private Label lblCheckIn;
        private Label lblCheckOut;
        private TextBox txtGuest;
        private TextBox txtRoom;
        private DateTimePicker dtIn;
        private DateTimePicker dtOut;
        private Button btnBook;
        private Button btnCancel;
        private Button btnView;
        private Button btnExit;
        private Label lblStatus;
        private ListView lvBookings;
    }
}
