namespace KOF.Services.Test;

using KOF.Models;
using KOF.Services;

public class MonsterServiceTest
{
    [Fact]
    public void ShouldReturnAMonster()
    {
        Assert.Equal("CyberKitty", new MonsterService().GetById(1)?.Name);
        Assert.Equal("Gigazaur", new MonsterService().GetById(2)?.Name);
    }

    [Fact]
    public void ShouldReturnAListWithAllMonsters()
    {
        Assert.IsType<List<Monster>>(new MonsterService().GetAll());

        Assert.True(new MonsterService().GetAll().Any());
    }

    [Fact]
    public void ShouldSuccessfullyAddAMonsterToTheList()
    {
        Assert.Equal(2, new MonsterService().GetAll().Count);

        new MonsterService().Add(new Monster { Name = "New Monster", VictoryPoints = 10, LifePoints = 10 });

        Assert.Equal(3, new MonsterService().GetAll().Count);

        new MonsterService().Add(new Monster { Name = "Another New Monster", VictoryPoints = 10, LifePoints = 10 });

        Assert.Equal(4, new MonsterService().GetAll().Count);
    }

    [Fact]
    public void ShouldSuccessfullyUpdateAMonsterInTheList()
    {
        Assert.Equal("CyberKitty", new MonsterService().GetById(1)?.Name);

        new MonsterService().Update(new Monster { Id = 1, Name = "New Monster", VictoryPoints = 10, LifePoints = 10 });

        Assert.Equal("New Monster", new MonsterService().GetById(1)?.Name);
    }

    // [Fact]
    // public void ShouldSuccessfullyDeleteAMonsterInTheList()
    // {
    //     Assert.Equal(2, new MonsterService().GetAll()?.Count);

    //     new MonsterService().Delete(1);

    //     Assert.Equal(1, new MonsterService().GetAll()?.Count);
    // }
}
