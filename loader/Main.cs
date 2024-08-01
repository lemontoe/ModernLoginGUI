using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using loader.Tabs;

namespace loader {
    public partial class Main : Form {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private System.Windows.Forms.Timer timer;
        public Main() {
            InitializeComponent();
            InitializeTimer();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Dash uc = new Dash();
            addUserControl(uc);
        }

        private void InitializeTimer() {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += new EventHandler(UpdateDate);
            timer.Start();
        }

        private void UpdateDate(object sender, EventArgs e) {
            label2.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void addUserControl(UserControl userControl) { // Tab Functionality
            userControl.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Clear();
            guna2Panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void dashboardButton_Click(object sender, EventArgs e) {
            Dash uc = new Dash();
            addUserControl(uc);
        }

        private void panelButton_Click(object sender, EventArgs e) {
            Tabs.Panel uc = new Tabs.Panel();
            addUserControl(uc);
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            Settings uc = new Settings();
            addUserControl(uc);
        }
    }
}
