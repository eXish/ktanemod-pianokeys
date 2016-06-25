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
    AltoClef
}

public class PianoIndicator : MonoBehaviour
{
    public TextMesh IndicatorText;

    private const int SymbolCount = 3;

    private void Start()
    {
        PickSymbols();
    }

    public bool HasSymbol(MusicSymbol symbol)
    {
        char character = symbol.GetAttributeOfType<SymbolCharacterAttribute>().Character;
        return IndicatorText.text.IndexOf(character) >= 0;
    }

    private void PickSymbols()
    {
        List<MusicSymbol> symbols = new List<MusicSymbol>((MusicSymbol[])System.Enum.GetValues(typeof(MusicSymbol)));

        IndicatorText.text = "";

        for (int symbolIndex = 0; symbolIndex < SymbolCount; ++symbolIndex)
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
