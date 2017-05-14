using System;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRecognizer
{
    class SpectrumProvider
    {
        string fileName;
        public SpectrumProvider(string fileName)
        {
            this.fileName = fileName;
        }

        public void SpectrumCreate()
        {
            Visuals vis = new Visuals();
            /*var img = vis.CreateSpectrumLine(sPointer, 1000, 255, System.Drawing.Color.Black,
                System.Drawing.Color.White, System.Drawing.Color.Purple, 1, 3, false, true, true);
            var err = Bass.BASS_ErrorGetCode();
            img.Save(@"C:\pepos\spctrm.bmp");*/
            var img = DrawSpectrogram(1, 1000, 64);
            TurnPixelsUpsideDown(img);
            img.Save(@"C:\pepos\spctrm.bmp");
        }

        private static void TurnPixelsUpsideDown(Bitmap image)
        {
            for (int i = 0; i < image.Width; ++i)
                for (int j = 0; j <= image.Height / 2; ++j)
                {
                    var pix = image.GetPixel(i, j);
                    var rev = image.GetPixel(i, image.Height - j - 1);
                    image.SetPixel(i, j, rev);
                    image.SetPixel(i, image.Height - j - 1, pix);
                }
        }

        private static Bitmap DrawSpectrogram(int channel, int height, int stepsPerSecond)
        {
            long len = Bass.BASS_ChannelGetLength(channel, BASSMode.BASS_POS_BYTES); // the length in bytes
            double time = Bass.BASS_ChannelBytes2Seconds(channel, len); // the length in seconds

            int steps = (int)Math.Floor(stepsPerSecond * time);

            Bitmap result = new Bitmap(steps, height);
            Graphics g = Graphics.FromImage(result);
            var sVol = 0f;
            Bass.BASS_ChannelGetAttribute(channel, BASSAttribute.BASS_ATTRIB_VOL, ref sVol);
            //Bass.BASS_ChannelSetAttribute(channel, BASSAttribute.BASS_ATTRIB_VOL, Utils.GetNormalizationGain())
            Visuals visuals = new Visuals();
            Bass.BASS_ChannelPlay(channel, false);

            for (int i = 0; i < steps; i++)
            {
                Bass.BASS_ChannelSetPosition(channel, 1.0 * i / stepsPerSecond);
                visuals.CreateSpectrum3DVoicePrint(channel, g, new Rectangle(0, 0, result.Width, result.Height), Color.Black, Color.White, i, true, false);
            }

            Bass.BASS_ChannelStop(channel);

            /*double /*fmean = 0, *fmax = double.MinValue, fmin = double.MaxValue;

            for (int i = 0; i < result.Width - 5; ++i)
                for (int j = 0; j < result.Height; ++j)
                {
                    var pix = result.GetPixel(i, j);
                    var value = pix.R + pix.G + pix.B;
                    if (value > fmax) fmax = value;
                    if (value < fmin) fmin = value;
                    var n = (i + 1) * (j + 1);
                    //fmean = fmean * ((n - 1d) / n) + (1d / n) * value;
                }

            for (int i = 0; i < result.Width - 5; ++i)
                for (int j = 0; j < result.Height; ++j)
                {
                    var pix = result.GetPixel(i, j);
                    var value = Math.Min(2 * ((pix.R + pix.G + pix.B) - fmin) / (fmax - fmin), 1);
                    result.SetPixel(i, j, Color.FromArgb((int)(255 * value), (int)(255 * value), (int)(255 * value)));
                }
            */
            return result;
        }

    }
}
