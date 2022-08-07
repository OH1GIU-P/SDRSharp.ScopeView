using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDRSharp.Common;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SDRSharp.ScopeView
{

    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("Scope View Panel")]
    public unsafe partial class ScopeViewPanel : UserControl
    {       
        private ISharpControl _control;
        private Graphics _graphics;
        private Bitmap _lastBuffer = null;
        private bool _render = true;
        private Point[] _lastPoints;

        public ScopeViewPanel(ISharpControl control)
        {
            InitializeComponent();
            // set cache mode only if no internet avaible
            _control = control;
            //Bitmap buffer = new Bitmap(scopePanel.ClientRectangle.Width, scopePanel.ClientRectangle.Height, PixelFormat.Format8bppIndexed);
            _graphics = scopePanel.CreateGraphics();
            ConfigureGraphics(_graphics);
            _lastPoints = new Point[scopePanel.Width + 2];
        }


        private void RenderLockBits(float* samples, int length)
        {

            int amplitude = amplitudeTrackBar.Value;
            int loop = 0;
            bool bothChannels = bothChannelsCheckbox.Checked;

            for (int sample = 0; loop < scopeSpeedTrackBar.Value && sample < length; loop++) //sample < length - 1; sample++)
            {
                Bitmap buffer = new Bitmap(scopePanel.ClientRectangle.Width, scopePanel.ClientRectangle.Height, PixelFormat.Format8bppIndexed);
                Rectangle rect = new Rectangle(0, 0, buffer.Width, buffer.Height);

                System.Drawing.Imaging.BitmapData bmpData =
                    buffer.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    buffer.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap. 
                int bytes  = Math.Abs(bmpData.Stride) * buffer.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                int passStartingSample = sample;
                int x = 0;
                int lasty = buffer.Height/2;
                int lastx = 0;
                for (; sample < length && x < buffer.Width; sample++ )
                {
                    if (! bothChannels && sample % 2 ==0){
                        
                    } else {
                    int value = (int)(samples[sample] * 100000 * Math.Pow(amplitude, 1.4));
                    int center = buffer.Height / 2;
                    int y = center - value;
                    x = (int)((sample - passStartingSample) / 2f);
                    int point = (y * (bmpData.Stride)) + x;
                    if (point > 0 && point < bytes)
                    {
                        //draw the point
                        rgbValues[point] = bothChannels ? (byte)(128 + (127 * (sample % 2))) : (byte)255;
                        //now hack a line between this point and the last one
                        if (y > lasty)
                        {
                            for (; lasty < y; lasty++)
                            {
                                point = (lasty * (bmpData.Stride)) + lastx;
                                if (point > 0 && point < bytes)
                                {
                                    rgbValues[point] = bothChannels ? (byte)(128 + (127 * (sample % 2))) : (byte)255;
                                }
                            }
                        }
                        else
                        {
                            for (; lasty > y; lasty--)
                            {
                                point = (lasty * (bmpData.Stride)) + lastx;
                                if (point > 0 && point < bytes)
                                {
                                    rgbValues[point] = bothChannels ? (byte)(128 + (127 * (sample % 2))) : (byte)255;
                                }
                            }
                        }
                    }
                    lasty = y;
                    lastx = x;
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                buffer.UnlockBits(bmpData);
                _graphics.DrawImage(buffer, 0, 0);
                _lastBuffer = new Bitmap(buffer);
            }

        }

        private void RenderData(float* samples, int length)
        {
            Point[] _points = new Point[scopePanel.Width + 2];
            var yIncrement = 1 / (float)scopePanel.Height;
            int amplitude = amplitudeTrackBar.Value;
            using (var spectrumPen = new Pen(Color.LightGreen))
            {
                var scale = (length - scopePanel.Width) / scopePanel.Width;
                var loops = (length / 2) / scopePanel.Width;
                for (var l = 0; l < 3; l += 2)
                {
                    var offset = 0;
                    for (var i = 0; i < scopePanel.Width && (l * scopePanel.Width + (i * 2)) < length; i++)
                    {
                        int sample = (l * scopePanel.Width) + (i * 2) + offset;// *scale;
                        var strength = samples[sample] * 10000000 * Math.Pow(amplitude, 1.4); //wtf, there's got to be a smarter method
                        var newX = i;
                        var newY = (int)(scopePanel.Height / 2 + (strength * yIncrement));
                        _points[i + 1].X = newX;
                        _points[i + 1].Y = newY;
                    }
                    _points[0] = _points[1];
                    _points[_points.Length - 1] = _points[_points.Length - 2];
                    _graphics.Clear(Color.Black);
                    _graphics.DrawLines(spectrumPen, _points);
                }
            }
            Array.Copy(_points, _lastPoints, _points.Length);
        }

        public void Render(float* samples, int length)
        {
            if (cbActive.Checked)
            {
                if (cbGreenScope.Checked)
                {
                    RenderData(samples, length);
                }
                else
                {
                    RenderLockBits(samples, length);
                }
            }
            else
            {
                if (_render)
                {
                    if (cbGreenScope.Checked)
                    {
                        if (_lastPoints.Length > 1)
                        {
                            var spectrumPen = new Pen(Color.LightGreen);
                            _graphics.DrawLines(spectrumPen, _lastPoints);
                        }
                    }
                    else
                    {
                        if (_lastBuffer != null)
                        {
                            _graphics.DrawImage(_lastBuffer, 0, 0);
                        }
                    }
                }
            }
        }


        public static void ConfigureGraphics(Graphics graphics)
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.SmoothingMode = SmoothingMode.HighSpeed;
            graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.High;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _render = false;
                if (cbGreenScope.Checked)
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("scopeData.txt"))
                    {
                        for (int i = 0; i < _lastPoints.Length; i++)
                        {
                            writer.Write(_lastPoints[i].Y.ToString() + ";");
                        }
                    }
                }
                else
                {
                    if (_lastBuffer != null)
                    {
                        _lastBuffer.Save("scopePanel.jpg", ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception)
            {
            }
            _render = true;
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = !cbActive.Checked;
        }

        private void cbGreenScope_CheckedChanged(object sender, EventArgs e)
        {
            _graphics.Clear(Color.Black);
        }
    }
}

