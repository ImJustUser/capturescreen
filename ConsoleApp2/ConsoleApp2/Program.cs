using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class Program
{
    const int ENUM_CURRENT_SETTINGS = -1;

    static void Main()
    {
        Graphics g;
        Bitmap bmp;

        bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width / 8, Screen.PrimaryScreen.Bounds.Height / 4);
        g = Graphics.FromImage(bmp);

        g.CopyFromScreen(Screen.PrimaryScreen.Bounds.Width / 6 * 5, Screen.PrimaryScreen.Bounds.Height / 24 * 15, 0, 0, new Size(bmp.Width, bmp.Height));

        // Save the screenshot to the specified path that the user has chosen.
        bmp.Save("Screenshot.png", ImageFormat.Png);
    }
    

    [DllImport("user32.dll")]
    public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

    [StructLayout(LayoutKind.Sequential)]
    public struct DEVMODE
    {
        private const int CCHDEVICENAME = 0x20;
        private const int CCHFORMNAME = 0x20;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public ScreenOrientation dmDisplayOrientation;
        public int dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public string dmFormName;
        public short dmLogPixels;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    }
}