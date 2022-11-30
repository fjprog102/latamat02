﻿using KOT.Models.Abstracts;

namespace KOT.Models;

public class PlayerPayload : DataHolder
{
    public string? Name { get; set; }
    public Monster? MyMonster { get; set; }

    public PlayerPayload(
        string? id = null,
        string? name = null,
        Monster? myMonster = null
    )
    {
        Id = id;
        Name = name;
        MyMonster = myMonster;
    }
}