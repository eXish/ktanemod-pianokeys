public static class MelodyDatabase
{
    #region Note Lengths
    private const float Minim = 0.5f;
    private const float Crotchet = 0.25f;
    private const float Quaver = 0.125f;
    private const float Semiquaver = 0.0625f;
    private const float Triplet = Crotchet / 3.0f;
    #endregion

    #region Regular Melodies
    public static readonly Melody FinalFantasyVictory = new Melody()
    {
        Name = "Final Fantasy Victory Fanfare",
        Tempo = 140,
        Notes = new Note[] { new Note(Semitone.ASharp, 3, Triplet),
                                new Note(Semitone.ASharp, 3, Triplet),
                                new Note(Semitone.ASharp, 3, Triplet),
                                new Note(Semitone.ASharp, 3, Crotchet),
                                new Note(Semitone.FSharp, 3, Crotchet),
                                new Note(Semitone.GSharp, 3, Crotchet),
                                new Note(Semitone.ASharp, 3, Triplet * 2),
                                new Note(Semitone.GSharp, 3, Triplet),
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
                                new Note(Semitone.DSharp, 3, Triplet * 2),
                                new Note(Semitone.ASharp, 3, Triplet),
                                new Note(Semitone.G, 3, Crotchet),
                                new Note(Semitone.DSharp, 3, Triplet * 2),
                                new Note(Semitone.ASharp, 3, Triplet),
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
}
