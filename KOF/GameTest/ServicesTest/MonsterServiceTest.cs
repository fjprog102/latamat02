namespace KOF.Services.Test;

using KOF.Models;
using KOF.Services;

public class MonsterServiceTest
{
    [Fact]
    public void ShouldReturnAMonster()
    {
        MonsterService service = new MonsterService();

        Assert.Equal("CyberKitty", service.GetById(1)?.Name);
        Assert.Equal("Gigazaur", service.GetById(2)?.Name);
    }

    [Fact]
    public void ShouldReturnAListWithAllMonsters()
    {
        MonsterService service = new MonsterService();

        Assert.IsType<List<Monster>>(service.GetAll());

        Assert.True(service.GetAll().Any());
    }

    [Fact]
    public void ShouldSuccessfullyAddAMonsterToTheList()
    {
        MonsterService service = new MonsterService();

        Assert.Equal(2, service.GetAll().Count);

        service.Add(new Monster { Name = "New Monster", VictoryPoints = 10, LifePoints = 10 });

        Assert.Equal(3, service.GetAll().Count);

        service.Add(new Monster { Name = "Another New Monster", VictoryPoints = 10, LifePoints = 10 });

        Assert.Equal(4, service.GetAll().Count);
    }

    [Fact]
    public void ShouldSuccessfullyUpdateAMonsterInTheList()
    {
        MonsterService service = new MonsterService();
        
        Assert.Equal("CyberKitty", service.GetById(1)?.Name);

        service.Update(new Monster { Id = 1, Name = "New Monster", VictoryPoints = 10, LifePoints = 10 });

        Assert.Equal("New Monster", service.GetById(1)?.Name);
    }

    // [Fact]
    //     public void ShouldSuccessfullyDeleteAMonsterInTheList()
    //     {
    //         MonsterService service = new MonsterService();
    //         Assert.Equal(2, service.GetAll()?.Count);

    //         service.Delete(1);

    //         Assert.Equal(1, service.GetAll()?.Count);
    //     }
}
