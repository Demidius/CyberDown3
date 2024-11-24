using UnityEngine;

namespace BsseCode.Services.ColorHeaders
{
    public class ColoredHeaderAttribute : PropertyAttribute
    {
        public string Header;
        public NamedColor SelectedColor;
        public int FontSize;

        public ColoredHeaderAttribute(string header, NamedColor color, int fontSize = 14)
        {
            Header = header;
            SelectedColor = color;
            FontSize = fontSize;
        }

        public Color GetColor()
        {
            switch (SelectedColor)
            {
                case NamedColor.Red: return Color.red;
                case NamedColor.Green: return Color.green;
                case NamedColor.Blue: return Color.blue;
                case NamedColor.Yellow: return Color.yellow;
                case NamedColor.Cyan: return Color.cyan;
                case NamedColor.Magenta: return Color.magenta;
                case NamedColor.Black: return Color.black;
                case NamedColor.White: return Color.white;
                case NamedColor.Gray: return Color.gray;
                case NamedColor.Orange: return new Color(1f, 0.5f, 0f);
                case NamedColor.Purple: return new Color(0.5f, 0f, 0.5f);
                default: return Color.white;
            }
        }
    }
    
    public enum NamedColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta,
        Black,
        White,
        Gray,
        Orange,
        Purple
    }

}