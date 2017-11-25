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

    //Added for Cruel
    [SymbolCharacter('')]
    [Description("Crotchet Rest")]
    CrotchetRest,

    //Added for Cruel
    [SymbolCharacter('')]
    [Description("Down-bow")]
    DownBow,

    //Added for Cruel
    [SymbolCharacter('')]
    [Description("Breve")]
    Breve,

    //Added for Cruel
    [SymbolCharacter('')]
    [Description("Semiquaver Rest")]
    SemiquaverRest,

    //Added for Cruel
    [SymbolCharacter('')]
    [Description("Double Sharp")]
    DoubleSharp,

    //Added for Festive
    [SymbolCharacter('x')]
    [Description("Semiquaver Note")]
    SemiquaverNote,

    //Added for Festive
    [SymbolCharacter('w')]
    [Description("Semibreve Note")]
    SemibreveNote,

    //Added for Festive
    [SymbolCharacter('v')]
    [Description("Up-bow")]
    UpBow,

    //Added for Festive
    [SymbolCharacter('"')]
    [Description("Caesura")]
    Caesura,

    //Added for Festive
    [SymbolCharacter('%')]
    [Description("D.S. / Dal Segno")]
    DalSegno,

    //Added for Festive
    [SymbolCharacter('^')]
    [Description("Marcato")]
    Marcato,

    //Added for Festive
    [SymbolCharacter('*')]
    [Description("Pedal Up")]
    PedalUp,

    //Added for Festive
    [SymbolCharacter('>')]
    [Description("Accent")]
    Accent,
}

[ExecuteInEditMode]
public class PianoIndicator : MonoBehaviour
{
    public Font Font;
    public int FontSize;

    public MeshFilter IndicatorFilter;
    public string Text;

    private const int NormalSymbolCount = 3;
    private const int CruelSymbolCount = 4;
    private const int FestiveSymbolCount = 3;

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

    private static readonly MusicSymbol[] CruelSymbolOptions =
    {
        MusicSymbol.Natural,
        MusicSymbol.Flat,
        MusicSymbol.Sharp,
        MusicSymbol.Mordent,
        MusicSymbol.Turn,
        MusicSymbol.CommonTime,
        MusicSymbol.CutCommonTime,
        MusicSymbol.Fermata,
        MusicSymbol.CClef,
        MusicSymbol.CrotchetRest,
        MusicSymbol.DownBow,
        MusicSymbol.Breve,
        MusicSymbol.SemiquaverRest,
        MusicSymbol.DoubleSharp,
    };

    private static readonly MusicSymbol[] FestiveSymbolOptions =
    {
        MusicSymbol.Mordent,
        MusicSymbol.DownBow,
        MusicSymbol.SemiquaverRest,
        MusicSymbol.Breve,
        MusicSymbol.CClef,
        MusicSymbol.Caesura,
        MusicSymbol.DalSegno,
        MusicSymbol.SemiquaverNote,
        MusicSymbol.PedalUp,
        MusicSymbol.UpBow,
        MusicSymbol.Marcato,
        MusicSymbol.SemibreveNote,
        MusicSymbol.Accent,
    };

    public bool HasSymbol(MusicSymbol symbol)
    {
        char character = symbol.GetAttributeOfType<SymbolCharacterAttribute>().FontCharacter;
        return Text.IndexOf(character) >= 0;
    }

    public MusicSymbol[] PickSymbols(PianoKeysModule.Type type)
    {
        List<MusicSymbol> symbols = null;
        int symbolCount = 0;
        switch (type)
        {
            case PianoKeysModule.Type.Normal:
                symbols = new List<MusicSymbol>(NormalSymbolOptions);
                symbolCount = NormalSymbolCount;
                break;

            case PianoKeysModule.Type.Cruel:
                symbols = new List<MusicSymbol>(CruelSymbolOptions);
                symbolCount = CruelSymbolCount;
                break;

            case PianoKeysModule.Type.Festive:
                symbols = new List<MusicSymbol>(FestiveSymbolOptions);
                symbolCount = FestiveSymbolCount;
                break;

            default:
                symbols = new List<MusicSymbol>(NormalSymbolOptions);
                symbolCount = NormalSymbolCount;
                break;
        }

        Text = "";

        MusicSymbol[] pickedSymbols = new MusicSymbol[symbolCount];

        for (int symbolIndex = 0; symbolIndex < symbolCount; ++symbolIndex)
        {
            int listIndex = Random.Range(0, symbols.Count);
            MusicSymbol symbol = symbols[listIndex];
            symbols.RemoveAt(listIndex);

            Text += symbol.GetAttributeOfType<SymbolCharacterAttribute>().FontCharacter;

            pickedSymbols[symbolIndex] = symbol;
        }

        GenerateMesh();

        return pickedSymbols;
    }

    private void Awake()
    {
    }

    private void GenerateMesh()
    {
        Mesh mesh = new Mesh() { name = "Indicator Text" };

        CharacterInfo spaceInfo;
        Font.GetCharacterInfo(' ', out spaceInfo, FontSize);
        int spaceWidth = spaceInfo.advance;

        CharacterInfo[] characters =  new CharacterInfo[Text.Length];
        int totalWidth = 0;
        for (int characterIndex = 0; characterIndex < Text.Length; ++characterIndex)
        {
            Font.GetCharacterInfo(Text[characterIndex], out characters[characterIndex], FontSize);
            totalWidth += characters[characterIndex].advance;
        }

        totalWidth += (Text.Length - 1) * (spaceWidth * 4);

        Vector3[] vertices = new Vector3[4 * Text.Length];
        Vector2[] uvs = new Vector2[4 * Text.Length];
        Color[] colors = new Color[4 * Text.Length];
        int[] triangles = new int[6 * Text.Length];

        float xOffset = totalWidth * -0.5f;
        int vertIndex = 0;
        int triangleIndex = 0;
        for (int characterIndex = 0; characterIndex < Text.Length; ++characterIndex)
        {
            CharacterInfo character = characters[characterIndex];

            int characterWidth = character.glyphWidth;
            int characterHeight = character.glyphHeight;

            vertices[vertIndex] = new Vector3(xOffset, characterHeight * 0.5f, 0.0f);
            vertices[vertIndex + 1] = new Vector3(xOffset + characterWidth, characterHeight * 0.5f, 0.0f);
            vertices[vertIndex + 2] = new Vector3(xOffset, characterHeight * -0.5f, 0.0f);
            vertices[vertIndex + 3] = new Vector3(xOffset + characterWidth, characterHeight * -0.5f, 0.0f);

            uvs[vertIndex] = character.uvTopLeft;
            uvs[vertIndex + 1] = character.uvTopRight;
            uvs[vertIndex + 2] = character.uvBottomLeft;
            uvs[vertIndex + 3] = character.uvBottomRight;

            colors[vertIndex] = Color.black;
            colors[vertIndex + 1] = Color.black;
            colors[vertIndex + 2] = Color.black;
            colors[vertIndex + 3] = Color.black;

            triangles[triangleIndex] = vertIndex;
            triangles[triangleIndex + 1] = vertIndex + 1;
            triangles[triangleIndex + 2] = vertIndex + 2;
            triangles[triangleIndex + 3] = vertIndex + 1;
            triangles[triangleIndex + 4] = vertIndex + 3;
            triangles[triangleIndex + 5] = vertIndex + 2;

            vertIndex += 4;
            triangleIndex += 6;

            xOffset += character.advance + spaceWidth * 4;
        }

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.colors = colors;
        mesh.triangles = triangles;

        mesh.UploadMeshData(false);

        IndicatorFilter.sharedMesh = mesh;
    }
}
