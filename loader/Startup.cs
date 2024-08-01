using loader;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace loader {
    public partial class Startup : Form {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public static api KeyAuthApp = new api(
            name: " ", // Application Name
            ownerid: " ", // Owner ID
            secret: " ", // Application Secret
            version: " " // Application Version /*
                           //path: @"Your_Path_Here" // (OPTIONAL) see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
        );

        public Startup() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e) {
            runChecks();
            KeyAuthApp.init();
        }

        static bool IsProcessRunning(string processName) {
            return Process.GetProcessesByName(processName).Length > 0;
        }

        private async void runChecks() {
            string text = $"[Console {DateTime.Now.ToString("hh:mm:ss")}] Checking for debuggers..";
            string text2 = $"{Environment.NewLine}[Console {DateTime.Now.ToString("hh:mm:ss")}] Checking for saved login info..";
            string logintext1 = $"{Environment.NewLine}[Console {DateTime.Now.ToString("hh:mm:ss")}] Saved login info found!{Environment.NewLine}[Console {DateTime.Now.ToString("hh:mm:ss")}] Logging in..";
            string logintext2 = $"{Environment.NewLine}[Console {DateTime.Now.ToString("hh:mm:ss")}] No saved login info found.{Environment.NewLine}[Console {DateTime.Now.ToString("hh:mm:ss")}] Returning to login panel..";
            int ccI = 0;

            // first typing sequence
            while (ccI < text.Length) {
                await Task.Delay(35); // typing speed
                guna2TextBox1.Invoke(new Action(() => guna2TextBox1.Text += text[ccI]));
                ccI++;
            }

            string[] processNames = new string[] {
                "ida64", "dotPeek64", "ida32", "ida", "reclass.net", "reclass", "heyrays", "lighthouse", "cheatengine-x86_64",
                "classinformer", "ida-x86emu", "cffexplorer", "winhex", "hiew", "fiddler", "httpdebugger", "httpdebuggerpro",
                "scylla", "Cheat Engine", "dnSpy", "dnSpy.Console"
            };

            if (processNames.Any(IsProcessRunning)) {
                MessageBox.Show("The program has crashed / ended due to a reason. Please close any debugger that might be open.", "Error Code: [DEBUGGER]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            await Task.Delay(3000);
            ccI = 0;

            // second typing sequence
            while (ccI < text2.Length) {
                await Task.Delay(35); // typing speed
                guna2TextBox1.Invoke(new Action(() => guna2TextBox1.Text += text2[ccI]));
                ccI++;
            }

            await Task.Delay(2000);

            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string savedLoginInfoFile = Path.Combine(documentsFolder, "Login.txt");

            if (File.Exists(savedLoginInfoFile)) {
                ccI = 0;

                // saved login typing sequence
                while (ccI < logintext1.Length) {
                    await Task.Delay(35); // typing speed
                    guna2TextBox1.Invoke(new Action(() => guna2TextBox1.Text += logintext1[ccI]));
                    ccI++;
                }

                // login and go to main page
            }
            else {
                ccI = 0;

                // no saved login typing sequence
                while (ccI < logintext2.Length) {
                    await Task.Delay(35); // typing speed
                    guna2TextBox1.Invoke(new Action(() => guna2TextBox1.Text += logintext2[ccI]));
                    ccI++;
                }

                await Task.Delay(2000);

                // return to login page
                this.Hide();
                var login = new Login();
                login.Show();
            }
        }
    }
}
