public static class MelodyDatabase
{
    #region Regular Melodies
    public static readonly Melody FinalFantasyVictory = new Melody()
    {
        Name = "Final Fantasy Victory Fanfare",
        Notes = new Note[] { new Note(Semitone.ASharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.FSharp, 3),
                                new Note(Semitone.GSharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.GSharp, 3),
                                new Note(Semitone.ASharp, 3)
        }
    };

    public static readonly Melody GuilesTheme = new Melody()
    {
        Name = "Guile's Theme",
        Notes = new Note[] { new Note(Semitone.DSharp, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.DSharp, 3)
        }
    };

    public static readonly Melody JamesBond = new Melody()
    {
        Name = "James Bond Theme",
        Notes = new Note[] { new Note(Semitone.E, 3),
                                new Note(Semitone.FSharp, 3),
                                new Note(Semitone.FSharp, 3),
                                new Note(Semitone.FSharp, 3),
                                new Note(Semitone.FSharp, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.E, 3)
        }
    };

    public static readonly Melody JurrasicPark = new Melody()
    {
        Name = "Jurassic Park Theme",
        Notes = new Note[] { new Note(Semitone.ASharp, 3),
                                new Note(Semitone.A, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.A, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.DSharp, 3)
        }
    };

    public static readonly Melody SuperMarioBros = new Melody()
    {
        Name = "Mario Bros. Overworld Theme",
        Notes = new Note[] { new Note(Semitone.E, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.C, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.G, 2)
        }
    };

    public static readonly Melody PinkPanther = new Melody()
    {
        Name = "The Pink Panther Theme",
        Notes = new Note[] { new Note(Semitone.CSharp, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.CSharp, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.A, 3)
        }
    };

    public static readonly Melody Superman = new Melody()
    {
        Name = "Superman Theme",
        Notes = new Note[] { new Note(Semitone.G, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.C, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.C, 4),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.C, 3)
        }
    };

    public static readonly Melody TetrisA = new Melody()
    {
        Name = "Tetris Mode-A Theme",
        Notes = new Note[] { new Note(Semitone.A, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.E, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.D, 3),
                                new Note(Semitone.F, 3),
                                new Note(Semitone.A, 3)
        }
    };

    public static readonly Melody EmpireStrikesBack = new Melody()
    {
        Name = "The Empire Strikes Back Theme",
        Notes = new Note[] { new Note(Semitone.G, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.DSharp, 3),
                                new Note(Semitone.ASharp, 3),
                                new Note(Semitone.G, 3)
        }
    };

    public static readonly Melody ZeldasLullaby = new Melody()
    {
        Name = "Zelda's Lullaby Theme",
        Notes = new Note[] { new Note(Semitone.B, 3),
                                new Note(Semitone.D, 4),
                                new Note(Semitone.A, 3),
                                new Note(Semitone.G, 3),
                                new Note(Semitone.A, 3),
                                new Note(Semitone.B, 3),
                                new Note(Semitone.D, 4),
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
