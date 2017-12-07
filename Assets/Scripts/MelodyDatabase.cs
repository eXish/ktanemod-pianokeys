using System.Collections.Generic;

public static class MelodyDatabase
{
    #region Note Lengths
    private const float Minim = 0.5f;
    private const float Crotchet = 0.25f;
    private const float Quaver = 0.125f;
    private const float Semiquaver = 0.0625f;
    private const float TripletQuaver = Crotchet / 3.0f;
    #endregion

    #region Regular Melodies
    public static readonly Melody FinalFantasyVictory = new Melody()
    {
        Name = "Final Fantasy Victory Fanfare",
        Tempo = 140,
        Notes = new Note[] { new Note(Semitone.ASharp, 3, TripletQuaver),
                                new Note(Semitone.ASharp, 3, TripletQuaver),
                                new Note(Semitone.ASharp, 3, TripletQuaver),
                                new Note(Semitone.ASharp, 3, Crotchet),
                                new Note(Semitone.FSharp, 3, Crotchet),
                                new Note(Semitone.GSharp, 3, Crotchet),
                                new Note(Semitone.ASharp, 3, TripletQuaver * 2),
                                new Note(Semitone.GSharp, 3, TripletQuaver),
                                new Note(Semitone.ASharp, 3)
        }
    };

    public static readonly Melody GuilesTheme = new Melody()
    {
        Name = "Guile's Theme",
        Tempo = 121,
        Notes = new Note[] { new Note(Semitone.DSharp, 3, Quaver),
                                new Note(Semitone.DSharp, 3, Semiquaver),
                                new Note(Semitone.D, 3, Quaver),
                                new Note(Semitone.D, 3, Semiquaver),
                                new Note(Semitone.DSharp, 3, Semiquaver * 7),
                                new Note(Semitone.DSharp, 3, Semiquaver),
                                new Note(Semitone.D, 3, Quaver),
                                new Note(Semitone.DSharp, 3, Quaver),
                                new Note(Semitone.DSharp, 3, Semiquaver),
                                new Note(Semitone.D, 3, Quaver),
                                new Note(Semitone.D, 3, Semiquaver),
                                new Note(Semitone.DSharp, 3)
        }
    };

    public static readonly Melody JamesBond = new Melody()
    {
        Name = "James Bond Theme",
        Tempo = 138,
        Notes = new Note[] { new Note(Semitone.E, 3, Quaver),
                                new Note(Semitone.FSharp, 3, Semiquaver),
                                new Note(Semitone.FSharp, 3, Semiquaver),
                                new Note(Semitone.FSharp, 3, Quaver),
                                new Note(Semitone.FSharp, 3, Crotchet),
                                new Note(Semitone.E, 3, Quaver),
                                new Note(Semitone.E, 3, Quaver),
                                new Note(Semitone.E, 3)
        }
    };

    public static readonly Melody JurrasicPark = new Melody()
    {
        Name = "Jurassic Park Theme",
        Tempo = 105,
        Notes = new Note[] { new Note(Semitone.ASharp, 3, Quaver),
                                new Note(Semitone.A, 3, Quaver),
                                new Note(Semitone.ASharp, 3, Crotchet),
                                new Note(Semitone.F, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, Crotchet),
                                new Note(Semitone.ASharp, 3, Quaver),
                                new Note(Semitone.A, 3, Quaver),
                                new Note(Semitone.ASharp, 3, Crotchet),
                                new Note(Semitone.F, 3, Crotchet),
                                new Note(Semitone.DSharp, 3)
        }
    };

    public static readonly Melody SuperMarioBros = new Melody()
    {
        Name = "Mario Bros. Overworld Theme",
        Tempo = 200,
        Notes = new Note[] { new Note(Semitone.E, 3, Quaver),
                                new Note(Semitone.E, 3, Crotchet),
                                new Note(Semitone.E, 3, Crotchet),
                                new Note(Semitone.C, 3, Quaver),
                                new Note(Semitone.E, 3, Crotchet),
                                new Note(Semitone.G, 3, Minim),
                                new Note(Semitone.G, 2)
        }
    };

    public static readonly Melody PinkPanther = new Melody()
    {
        Name = "The Pink Panther Theme",
        Tempo = 120,
        Notes = new Note[] { new Note(Semitone.CSharp, 3, Semiquaver),
                                new Note(Semitone.D, 3, Semiquaver * 5),
                                new Note(Semitone.E, 3, Semiquaver),
                                new Note(Semitone.F, 3, Semiquaver * 5),
                                new Note(Semitone.CSharp, 3, Semiquaver),
                                new Note(Semitone.D, 3, Quaver),
                                new Note(Semitone.E, 3, Semiquaver),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.ASharp, 3, Semiquaver),
                                new Note(Semitone.A, 3)
        }
    };

    public static readonly Melody Superman = new Melody()
    {
        Name = "Superman Theme",
        Tempo = 112,
        Notes = new Note[] { new Note(Semitone.G, 3, Quaver * 3),
                                new Note(Semitone.G, 3, Quaver),
                                new Note(Semitone.C, 3, Quaver),
                                new Note(Semitone.G, 3, Quaver),
                                new Note(Semitone.G, 3, Quaver * 6),
                                new Note(Semitone.C, 4, Quaver * 3),
                                new Note(Semitone.G, 3, Quaver * 3),
                                new Note(Semitone.C, 3)
        }
    };

    public static readonly Melody TetrisA = new Melody()
    {
        Name = "Tetris Mode-A Theme",
        Tempo = 140,
        Notes = new Note[] { new Note(Semitone.A, 3, Crotchet),
                                new Note(Semitone.E, 3, Quaver),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.E, 3, Quaver),
                                new Note(Semitone.D, 3, Crotchet),
                                new Note(Semitone.D, 3, Quaver),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.A, 3)
        }
    };

    public static readonly Melody EmpireStrikesBack = new Melody()
    {
        Name = "The Empire Strikes Back Theme",
        Tempo = 108,
        Notes = new Note[] { new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, TripletQuaver * 2),
                                new Note(Semitone.ASharp, 3, TripletQuaver),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, TripletQuaver * 2),
                                new Note(Semitone.ASharp, 3, TripletQuaver),
                                new Note(Semitone.G, 3)
        }
    };

    public static readonly Melody ZeldasLullaby = new Melody()
    {
        Name = "Zelda's Lullaby Theme",
        Tempo = 110,
        Notes = new Note[] { new Note(Semitone.B, 3, Minim),
                                new Note(Semitone.D, 4, Crotchet),
                                new Note(Semitone.A, 3, Minim),
                                new Note(Semitone.G, 3, Quaver),
                                new Note(Semitone.A, 3, Quaver),
                                new Note(Semitone.B, 3, Minim),
                                new Note(Semitone.D, 4, Crotchet),
                                new Note(Semitone.A, 3)
        }
    };
    #endregion

    #region Serialism Melodies
    public static readonly Melody[] SerialismMelodies =
    {
        new Melody()
        {
            Name = "Serialism Tone Row 0",
            Notes = new Note[] { new Note(Semitone.F, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.A, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 1",
            Notes = new Note[] { new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.F, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 2",
            Notes = new Note[] { new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.ASharp, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 3",
            Notes = new Note[] { new Note(Semitone.E, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.A, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 4",
            Notes = new Note[] { new Note(Semitone.D, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.G, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 5",
            Notes = new Note[] { new Note(Semitone.C, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.GSharp, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 6",
            Notes = new Note[] { new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.FSharp, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 7",
            Notes = new Note[] { new Note(Semitone.E, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.D, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 8",
            Notes = new Note[] { new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.E, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.B, 3)
            }
        },

        new Melody()
        {
            Name = "Serialism Tone Row 9",
            Notes = new Note[] { new Note(Semitone.DSharp, 3),
                                    new Note(Semitone.GSharp, 3),
                                    new Note(Semitone.C, 3),
                                    new Note(Semitone.B, 3),
                                    new Note(Semitone.D, 3),
                                    new Note(Semitone.CSharp, 3),
                                    new Note(Semitone.FSharp, 3),
                                    new Note(Semitone.ASharp, 3),
                                    new Note(Semitone.F, 3),
                                    new Note(Semitone.G, 3),
                                    new Note(Semitone.A, 3),
                                    new Note(Semitone.E, 3)
            }
        }
    };
    #endregion

    #region Festive Melodies
    public static readonly Melody Rudolph = new Melody()
    {
        Name = "Rudolph The Red-Nosed Reindeer",
        Tempo = 140,
        Notes = new Note[] { new Note(Semitone.DSharp, 3, Quaver),
                                new Note(Semitone.F, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, Quaver),
                                new Note(Semitone.C, 3, Crotchet),
                                new Note(Semitone.GSharp, 3, Crotchet),
                                new Note(Semitone.F, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, Crotchet),
        }
    };

    public static readonly Melody WeThreeKings = new Melody()
    {
        Name = "We Three Kings Of Orient Are",
        Tempo = 200,
        Notes = new Note[] { new Note(Semitone.CSharp, 4, Minim),
                                new Note(Semitone.B, 3, Crotchet),
                                new Note(Semitone.A, 3, Minim),
                                new Note(Semitone.FSharp, 3, Crotchet),
                                new Note(Semitone.GSharp, 3, Crotchet),
                                new Note(Semitone.A, 3, Crotchet),
                                new Note(Semitone.GSharp, 3, Crotchet),
                                new Note(Semitone.FSharp, 3, Crotchet * 3),
        }
    };

    public static readonly Melody SilentNight = new Melody()
    {
        Name = "Silent Night",
        Tempo = 90,
        Notes = new Note[] { new Note(Semitone.G, 3, Crotchet + Quaver),
                                new Note(Semitone.A, 3, Quaver),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.E, 3, Crotchet * 3),
                                new Note(Semitone.G, 3, Crotchet + Quaver),
                                new Note(Semitone.A, 3, Quaver),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.E, 3, Crotchet * 3),
        }
    };

    public static readonly Melody LastChristmas = new Melody()
    {
        Name = "Last Christmas",
        Tempo = 120,
        Notes = new Note[] { new Note(Semitone.DSharp, 3, Crotchet + Quaver),
                                new Note(Semitone.DSharp, 3, Crotchet),
                                new Note(Semitone.CSharp, 3, Crotchet),
                                new Note(Semitone.GSharp, 2, Quaver),
                                new Note(Semitone.DSharp, 3, Quaver),
                                new Note(Semitone.DSharp, 3, Quaver),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.CSharp, 3, Quaver),
        }
    };

    public static readonly Melody AllIWantForChristmas = new Melody()
    {
        Name = "All I Want For Christmas Is You",
        Tempo = 165,
        Notes = new Note[] { new Note(Semitone.B, 3, Crotchet),
                                new Note(Semitone.A, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, Crotchet),
                                new Note(Semitone.D, 3, Crotchet),
                                new Note(Semitone.A, 3, Minim),
                                new Note(Semitone.B, 3, Crotchet),
                                new Note(Semitone.A, 3, Quaver),
                                new Note(Semitone.G, 3, Crotchet),
        }
    };

    public static readonly Melody FrostyTheSnowman = new Melody()
    {
        Name = "Frosty The Snowman",
        Tempo = 150,
        Notes = new Note[] { new Note(Semitone.G, 3, Minim),
                                new Note(Semitone.E, 3, Crotchet + Quaver),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.C, 4, Minim),
                                new Note(Semitone.B, 3, Quaver),
                                new Note(Semitone.C, 4, Quaver),
                                new Note(Semitone.D, 4, Crotchet),
                                new Note(Semitone.C, 4, Crotchet),
                                new Note(Semitone.B, 3, Crotchet),
                                new Note(Semitone.A, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
        }
    };

    public static readonly Melody MostWonderfulTime = new Melody()
    {
        Name = "It's The Most Wonderful Time Of The Year",
        Tempo = 205,
        Notes = new Note[] { new Note(Semitone.FSharp, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.A, 3, Crotchet * 3),
                                new Note(Semitone.A, 3, Crotchet),
                                new Note(Semitone.D, 4, Crotchet),
                                new Note(Semitone.B, 3, Crotchet),
                                new Note(Semitone.A, 3, Crotchet * 3),
                                new Note(Semitone.G, 3, Minim),
                                new Note(Semitone.E, 3, Crotchet),
                                new Note(Semitone.D, 3, Crotchet * 3),
        }
    };

    public static readonly Melody JingleBells = new Melody()
    {
        Name = "Jingle Bells",
        Tempo = 190,
        Notes = new Note[] { new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.G, 3, Minim),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.G, 3, Minim),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.ASharp, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, Crotchet + Quaver),
                                new Note(Semitone.F, 3, Quaver),
                                new Note(Semitone.G, 3, Minim),
        }
    };

    public static readonly Melody JingleBellRock = new Melody()
    {
        Name = "Jingle Bell Rock",
        Tempo = 130,
        Notes = new Note[] { new Note(Semitone.D, 4, TripletQuaver * 2),
                                new Note(Semitone.D, 4, TripletQuaver),
                                new Note(Semitone.D, 4, Crotchet),
                                new Note(Semitone.CSharp, 4, TripletQuaver * 2),
                                new Note(Semitone.CSharp, 4, TripletQuaver),
                                new Note(Semitone.CSharp, 4, Crotchet),
                                new Note(Semitone.B, 3, TripletQuaver * 2),
                                new Note(Semitone.CSharp, 4, TripletQuaver),
                                new Note(Semitone.B, 3, TripletQuaver * 2),
                                new Note(Semitone.FSharp, 3, TripletQuaver),
        }
    };

    public static Melody GenerateCarolOfTheBells(int repetitions)
    {
        List<Note> fullNoteList = new List<Note>();
        Note[] oneRepeat = new Note[] { new Note(Semitone.ASharp, 3, Crotchet),
                                        new Note(Semitone.A, 3, Quaver),
                                        new Note(Semitone.ASharp, 3, Quaver),
                                        new Note(Semitone.G, 3, Crotchet),
        };

        for (int repetition = 0; repetition < repetitions; ++repetition)
        {
            fullNoteList.AddRange(oneRepeat);
        }

        return new Melody()
        {
            Name = string.Format("Carol Of The Bells (x{0})", repetitions),
            Tempo = 200,
            Notes = fullNoteList.ToArray()
        };
    }
    #endregion
}
