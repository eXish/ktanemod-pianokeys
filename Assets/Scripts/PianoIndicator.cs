using UnityEngine;
using System.Collections.Generic;

public class SymbolCharacterAttribute : System.Attribute
{
    public SymbolCharacterAttribute(char character)
    {
        Character = character;
    }

    public readonly char Character;
}

public enum MusicSymbol
{
    [SymbolCharacter('n')]
    Natural,

    [SymbolCharacter('b')]
    Flat,

    [SymbolCharacter('#')]
    Sharp,

    [SymbolCharacter('m')]
    Mordent,

    [SymbolCharacter('T')]
    Turn,

    [SymbolCharacter('c')]
    CommonTime,

    [SymbolCharacter('C')]
    CutCommonTime,

    [SymbolCharacter('U')]
    Fermata,

    [SymbolCharacter('B')]
    AltoClef,

    [SymbolCharacter('')]
    CrotchetRest,

    [SymbolCharacter('')]
    DownBow,

    [SymbolCharacter('')]
    Breeve,

    [SymbolCharacter('')]
    SemiquaverRest,

    [SymbolCharacter('')]
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
        MusicSymbol.AltoClef
    };
    private static readonly MusicSymbol[] CruelSymbolOptions = (MusicSymbol[])System.Enum.GetValues(typeof(MusicSymbol));

    public bool HasSymbol(MusicSymbol symbol)
    {
        char character = symbol.GetAttributeOfType<SymbolCharacterAttribute>().Character;
        return IndicatorText.text.IndexOf(character) >= 0;
    }

    public void PickSymbols(bool isCruel)
    {
        List<MusicSymbol> symbols = new List<MusicSymbol>(isCruel ? CruelSymbolOptions : NormalSymbolOptions);
        int symbolCount = isCruel ? CruelSymbolCount : NormalSymbolCount;

        IndicatorText.text = "";

        for (int symbolIndex = 0; symbolIndex < symbolCount; ++symbolIndex)
        {
            int listIndex = Random.Range(0, symbols.Count);
            MusicSymbol symbol = symbols[listIndex];
            symbols.RemoveAt(listIndex);

            if (string.IsNullOrEmpty(IndicatorText.text))
            {
                IndicatorText.text += symbol.GetAttributeOfType<SymbolCharacterAttribute>().Character;
            }
            else
            {
                IndicatorText.text += "   " + symbol.GetAttributeOfType<SymbolCharacterAttribute>().Character;
            }
        }        
    }
}
