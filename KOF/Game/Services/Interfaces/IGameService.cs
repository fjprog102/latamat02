﻿using KOT.Models;
using KOT.Models.Abstracts;

namespace KOT.Services.Interfaces;

public interface IGameService
{
    public IEnumerable<Element> Read(DataHolder data);
    public IEnumerable<Element> Create(DataHolder data);
    public IEnumerable<Element> Delete(DataHolder data);
}
