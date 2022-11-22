namespace KOF.Services.Test;

using KOF.Models;
using KOF.Services;

public class MonsterServiceTest
{
    [Fact]
    public void ShouldReturnAListWithAllMonsters()
    {
        //Is type List<Monster>
        Assert.IsType<List<Monster>>(MonsterService.GetAll());

        //There is at least one element in the list
        Assert.True(MonsterService.GetAll().Any());
    }

    [Fact]
    public void ShouldSuccessfullyAddAMonsterToTheList()
    {
        //Asserts that the list contains two elements before adding
        Assert.Equal(2, MonsterService.GetAll().Count);
        //Adds a new monster
        MonsterService.Add(new Monster { Name = "New Monster", VictoryPoints = 10, LifePoints = 10 });
        //Asserts that the list contains three elements after adding a new monster
        Assert.Equal(3, MonsterService.GetAll().Count);
        //Adds a new monster
        MonsterService.Add(new Monster { Name = "Another New Monster", VictoryPoints = 10, LifePoints = 10 });
        //Asserts that the list contains four elements after adding another monster
        Assert.Equal(4, MonsterService.GetAll().Count);
    }
}
