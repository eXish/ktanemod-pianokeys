using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;

public class SymbolCharacterAttribute : System.Attribute
{
    public SymbolCharacterAttribute(char fontCharacter)
    {
        FontCharacter = fontCharacter;
    }

    public readonly char FontCharacter;
}

public enum MusicSymbol
{
    [SymbolCharacter('n')]
    [Description("Natural")]
    Natural,

    [SymbolCharacter('b')]
    [Description("Flat")]
    Flat,

    [SymbolCharacter('#')]
    [Description("Sharp")]
    Sharp,

    [SymbolCharacter('m')]
    [Description("Mordent")]
    Mordent,

    [SymbolCharacter('T')]
    [Description("Turn")]
    Turn,

    [SymbolCharacter('c')]
    [Description("Common Time")]
    CommonTime,

    [SymbolCharacter('C')]
    [Description("Cut-common Time")]
    CutCommonTime,

    [SymbolCharacter('U')]
    [Description("Fermata")]
    Fermata,

    [SymbolCharacter('B')]
    [Description("C Clef")]
    CClef,

    [SymbolCharacter('')]
    [Description("Crotchet Rest")]
    CrotchetRest,

    [SymbolCharacter('')]
    [Description("Down-bow")]
    DownBow,

    [SymbolCharacter('')]
    [Description("Breve")]
    Breve,

    [SymbolCharacter('')]
    [Description("Semiquaver Rest")]
    SemiquaverRest,

    [SymbolCharacter('')]
    [Description("Double Sharp")]
    DoubleSharp
}

public class PianoIndicator : MonoBehaviour
{
    public TextMesh IndicatorText;

    private const int NormalSymbolCount = 3;
    private const int CruelSymbolCount = 4;

    private static readonly MusicSymbol[] NormalSymbolOptions =
    {
        MusicSymbol.Natural,
        MusicSymbol.Flat,
        MusicSymbol.Sharp,
        MusicSymbol.Mordent,
        MusicSymbol.Turn,
        MusicSymbol.CommonTime,
        MusicSymbol.CutCommonTime,
        MusicSymbol.Fermata,
        MusicSymbol.CClef
    };
    private static readonly MusicSymbol[] CruelSymbolOptions = (MusicSymbol[])System.Enum.GetValues(typeof(MusicSymbol));

    public bool HasSymbol(MusicSymbol symbol)
    {
        char character = symbol.GetAttributeOfType<SymbolCharacterAttribute>().FontCharacter;
        return IndicatorText.text.IndexOf(character) >= 0;
    }

    public MusicSymbol[] PickSymbols(bool isCruel)
    {
        List<MusicSymbol> symbols = new List<MusicSymbol>(isCruel ? CruelSymbolOptions : NormalSymbolOptions);
        int symbolCount = isCruel ? CruelSymbolCount : NormalSymbolCount;

        IndicatorText.text = "";

        MusicSymbol[] pickedSymbols = new MusicSymbol[symbolCount];

        for (int symbolIndex = 0; symbolIndex < symbolCount; ++symbolIndex)
        {
            int listIndex = Random.Range(0, symbols.Count);
            MusicSymbol symbol = symbols[listIndex];
            symbols.RemoveAt(listIndex);

            if (string.IsNullOrEmpty(IndicatorText.text))
            {
                IndicatorText.text += symbol.GetAttributeOfType<SymbolCharacterAttribute>().FontCharacter;
            }
            else
            {
                IndicatorText.text += "   " + symbol.GetAttributeOfType<SymbolCharacterAttribute>().FontCharacter;
            }

            pickedSymbols[symbolIndex] = symbol;
        }

        return pickedSymbols;
    }
}
