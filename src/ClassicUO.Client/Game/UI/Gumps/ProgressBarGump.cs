using ClassicUO.Assets;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Renderer;
using Microsoft.Xna.Framework;

namespace ClassicUO.Game.UI.Gumps
{
    internal class ProgressBarGump : Gump
    {
        public double MaxValue { get; set; } = 1;
        public double MinValue { get; set; } = 0;
        public double CurrentPercentage { get; set; }
        public Color ForegrouneColor { get; set; } = Color.BlueViolet;

        private Vector3 hueVector = ShaderHueTranslator.GetHueVector(0, false, 1);
        public ProgressBarGump(string title, double startPercentage = 1.0, int width = 300, int height = 50) : base(0, 0)
        {
            CanCloseWithRightClick = true;
            CanMove = true;

            Width = width;
            Height = height;
            CurrentPercentage = startPercentage;

            Add(new AlphaBlendControl() { Width = width, Height = height });

            if (!string.IsNullOrEmpty(title))
            {
                TextBox t = new TextBox(title, TrueTypeLoader.EMBEDDED_FONT, 30, width, Microsoft.Xna.Framework.Color.White, FontStashSharp.RichText.TextHorizontalAlignment.Center);
                t.X = -t.MeasuredSize.X - 5; //Set text above progress bar
                Add(t);
            }
        }

        public override bool Draw(UltimaBatcher2D batcher, int x, int y)
        {
            base.Draw(batcher, x, y);

            batcher.DrawRectangle(
                SolidColorTextureCache.GetTexture(ForegrouneColor),
                0,
                0,
                (int)(CurrentPercentage * Width),
                Height,
                hueVector);

            return true;
        }
    }
}
