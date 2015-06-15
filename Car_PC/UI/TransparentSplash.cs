// TransparentSplash.cs by Lloyd Franklin

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Car_PC.UI
{
    public sealed class TransparentSplash : Control
    {
        #region manifest constants
        private const int WS_EX_TOPMOST = unchecked((int)0x00000008L);
        private const int WS_EX_TOOLWINDOW = unchecked((int)0x00000080);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const int HWND_TOPMOST = -1;
        #endregion

        #region private static class members
        private static TransparentSplash TransparentSplashInstance { get; set; }
        private static object LockObject = new object();
        #endregion

        #region Interop definitions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDst, int xDst, int yDst, int cx, int cy, IntPtr hdcSrc, int xSrc, int ySrc, uint ulRop);
        [DllImport("gdi32.dll")]
        static extern uint SetPixel(IntPtr hdc, int X, int Y, uint crColor);
        #endregion

        #region properties and fields
        private string m_strTitleString;
        private string m_strCommentaryString;
        private StringFormat StringFormat { get; set; }
        private int TextOffsetY { get; set; }
        private int TextOffsetX { get; set; }
        private int Leading { get; set; }
        public int TextAreaX { get; set; }
        public int TextAreaY { get; set; }
        public int TextAreaWidth { get; set; }
        public int TextAreaHeight { get; set; }
        public Color TransparencyColor { get; set; }
        private RectangleF RectangleFTitleString { get; set; }
        private RectangleF RectangleFCommentaryString { get; set; }
        public Font CommentaryFont { get; set; }
        #endregion

        #region construction and disposal
        private TransparentSplash()
        {
            LockObject = new object();
            TitleString = string.Empty;
            CommentaryString = string.Empty;
            Font = new System.Drawing.Font("¿¬Ìå", 28, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CommentaryFont = new System.Drawing.Font("¿¬Ìå",9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SetStyle(ControlStyles.DoubleBuffer, false);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            StringFormat = new StringFormat();
            StringFormat.FormatFlags |= StringFormatFlags.NoWrap;
            StringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            TextOffsetY = 0;
            TextOffsetX = 10;
            Leading = 6;
            Visible = false;
            TextAreaX = 0;
            TextAreaY = 0;
            TextAreaWidth = 0;
            TextAreaHeight = 0;
            TransparencyColor = Color.Black;
            RectangleFCommentaryString = RectangleF.Empty;
            RectangleFTitleString = RectangleF.Empty;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CommentaryFont.Dispose();
                CommentaryFont = null;
                if (StringFormat != null)
                {
                    StringFormat.Dispose();
                    StringFormat = null;
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region protected overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            IntPtr hWndDeskTop = IntPtr.Zero;
            if (Handle != IntPtr.Zero)
            {
                hWndDeskTop = GetDesktopWindow();
                SetParent(Handle, hWndDeskTop);
            }
            if (TextAreaWidth == 0)
            {
                TextAreaWidth = ClientRectangle.Width;
            }
            if (TextAreaHeight == 0)
            {
                TextAreaHeight = ClientRectangle.Height;
            }
            RectangleFCommentaryString = new RectangleF(0, 0, (float)TextAreaWidth, (float)TextAreaHeight);
            RectangleFTitleString = new RectangleF(0, 0, (float)TextAreaWidth, (float)TextAreaHeight);
            base.OnHandleCreated(e);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //must override and consume
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Bounds.Width > 0 && Bounds.Height > 0 && Visible)
            {
                try
                {
                    Graphics g = e.Graphics;
                    g.SetClip(e.ClipRectangle);
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    #region image painting
                    Color colorMatch = Color.FromArgb(TransparencyColor.R, TransparencyColor.G, TransparencyColor.B);
                    IntPtr hdc = g.GetHdc();
                    Point point = new Point();
                    Color pixelColor = new Color();
                    Bitmap bmp = (Bitmap)BackgroundImage;
                    FastBitmap fastBitmap = new FastBitmap(bmp);
                    fastBitmap.LockImage();
                    for (point.Y = 0; point.Y < BackgroundImage.Height; point.Y++)
                    {
                        for (point.X = 0; point.X < BackgroundImage.Width; point.X++)
                        {
                            if ((pixelColor = fastBitmap.GetPixel(point.X, point.Y)) != colorMatch)
                            {
                                SetPixel(hdc, point.X, point.Y, ColorToRGB(pixelColor));
                            }
                        }
                    }
                    fastBitmap.UnlockImage();
                    g.ReleaseHdc();
                    #endregion

                    #region text painting
                    TextOffsetY = TextAreaY;
                    if (TitleString != string.Empty)
                    {
                        Font fontTitle = new Font(Font, FontStyle.Bold);
                        SizeF sizeF = g.MeasureString(TitleString, fontTitle, TextAreaWidth, StringFormat);
                        RectangleF rectangleF = new RectangleF(TextAreaX + TextOffsetX, TextOffsetY, sizeF.Width, sizeF.Height);
                        SolidBrush brushFont = new SolidBrush(ForeColor);
                        g.DrawString(TitleString, fontTitle, brushFont, rectangleF, StringFormat);
                        brushFont.Dispose();
                        fontTitle.Dispose();
                        RectangleFTitleString = rectangleF;
                        TextOffsetY += Leading + Convert.ToInt32(rectangleF.Height);
                    }
                    if (CommentaryString != string.Empty)
                    {
                        SizeF sizeF = g.MeasureString(CommentaryString, CommentaryFont, TextAreaWidth, StringFormat);
                        TextOffsetY += Convert.ToInt32(Math.Ceiling(sizeF.Height));
                        RectangleF rectangleF = new RectangleF(TextAreaX + TextOffsetX, TextOffsetY, sizeF.Width, sizeF.Height);
                        SolidBrush brushFont = new SolidBrush(ForeColor);
                        g.DrawString(CommentaryString, CommentaryFont, brushFont, rectangleF, StringFormat);
                        brushFont.Dispose();
                        RectangleFCommentaryString = rectangleF;
                    }
                    #endregion
                }
                catch (Exception exception)
                {
                    System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame(true);
                    Console.WriteLine("\nException: {0}, \n\t{1}, \n\t{2}, \n\t{3}\n", this.GetType().ToString(), stackFrame.GetMethod().ToString(), stackFrame.GetFileLineNumber(), exception.Message);
                }
            }
        }
        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            if (BackgroundImage != null)
            {
                Width = BackgroundImage.Width;
                Height = BackgroundImage.Height;
                Reorient();
            }
            Refresh();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
                cp.Parent = IntPtr.Zero;
                return cp;
            }
        }
        #endregion

        #region private methods
        private void Reorient()
        {
            Rectangle screenArea = SystemInformation.WorkingArea;
            int nX = (screenArea.Width - Width) / 2;
            int nY = (screenArea.Height - Height) / 2;
            Location = new Point(nX, nY);
        }
        private uint ColorToRGB(Color crColor)
        {
            return Convert.ToUInt32((crColor.B << 16 | crColor.G << 8 | crColor.R));
        }
        #endregion

        #region public static methods
        #region Comments
        /// <summary>
        /// Begins the splash screen display
        /// </summary>
        /// <remarks>
        /// Always ensure that a call to EndDisplay will follow a call to this method
        /// </remarks>
        #endregion
        public static void BeginDisplay()
        {
            if (!Instance.Visible)
            {
                Instance.Reorient();
                if (!Instance.Created)
                {
                    Instance.CreateControl();
                }
                SetWindowPos(Instance.Handle, (System.IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                Instance.Visible = true;
                Instance.Refresh();
            }
        }
        #region Comments
        /// <summary>
        /// Ends the splash screen display
        /// </summary>
        /// <remarks>
        /// Always ensure that a call to this method follows a call to BeginDisplay
        /// </remarks>
        #endregion
        public static void EndDisplay()
        {
            Instance.Visible = false;
        }
        #region Comments
        /// <summary>
        /// Sets the title text displayed by the splash screen
        /// </summary>
        #endregion
        public static void SetTitleString(string title)
        {
            Instance.TitleString = title;
        }
        #region Comments
        /// <summary>
        /// Sets the commentary text displayed by the splash screen
        /// </summary>
        #endregion
        public static void SetCommentaryString(string commentary)
        {
            Instance.CommentaryString = commentary;
        }
        #region Comments
        /// <summary>
        /// Sets an image to be displayed in the background by the splash screen
        /// </summary>
        #endregion
        public static void SetBackgroundImage(Image image)
        {
            Instance.BackgroundImage = image;
        }
        #endregion

        #region public static properties
        public static TransparentSplash Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (TransparentSplashInstance == null || TransparentSplashInstance.IsDisposed)
                    {
                        TransparentSplashInstance = new TransparentSplash();
                    }
                    return TransparentSplashInstance;
                }
            }
        }
        #endregion

        #region  properties
        public string CommentaryString
        {
            get
            {
                return m_strCommentaryString;
            }
            set
            {
                if (m_strCommentaryString != value)
                {
                    m_strCommentaryString = value;

                    Invalidate(new Rectangle(Convert.ToInt32(RectangleFCommentaryString.X), Convert.ToInt32(RectangleFCommentaryString.Y), TextAreaWidth, Convert.ToInt32(RectangleFCommentaryString.Height)));
                    Update();
                }
            }
        }
        public string TitleString
        {
            get
            {
                return m_strTitleString;
            }
            set
            {
                if (m_strTitleString != value)
                {
                    m_strTitleString = value;
                    Invalidate(new Rectangle(Convert.ToInt32(RectangleFTitleString.X), Convert.ToInt32(RectangleFTitleString.Y), TextAreaWidth, Convert.ToInt32(RectangleFTitleString.Height)));
                    Update();
                }
            }
        }
        #endregion
    }
}
