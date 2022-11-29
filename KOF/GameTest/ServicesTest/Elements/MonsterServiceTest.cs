// namespace KOT.Services.Test;

// using KOT.Models;
// using KOT.Services;

// public class MonsterServiceTest
// {
//     [Fact]
//     public void ShouldReturnAMonster()
//     {
//         MonsterService _service = new MonsterService();

//         Assert.Equal("CyberKitty", _service.Read(1)?.Name);
//         Assert.Equal("Gigazaur", _service.Read(2)?.Name);
//     }

//     [Fact]
//     public void ShouldReturnAListWithAllMonsters()
//     {
//         MonsterService _service = new MonsterService();

//         Assert.IsType<List<Monster>>(_service.Read());
//         Assert.True(_service.Read().Any());
//     }

//     [Fact]
//     public void ShouldSuccessfullyAddAMonsterToTheList()
//     {
//         MonsterService _service = new MonsterService();
//         Assert.Equal(2, _service.Read().Count);

//         service.Add(new Monster("New Monster", 10, 10));
//         Assert.Equal(3, _service.Read().Count);

//         service.Add(new Monster("Another New Monster", 10, 10));
//         Assert.Equal(4, _service.Read().Count);
//     }

//     [Fact]
//     public void ShouldSuccessfullyUpdateAMonsterInTheList()
//     {
//         MonsterService _service = new MonsterService();
//         Assert.Equal("CyberKitty", _service.Read(1)?.Name);

//         service.Update(new Monster("New Monster", 10, 10));
//         Assert.Equal("New Monster", _service.Read(1)?.Name);
//     }

//     [Fact]
//     public void ShouldSuccessfullyDeleteAMonsterInTheList()
//     {
//         MonsterService _service = new MonsterService();
//         Assert.Equal(2, _service.Read()?.Count);

//         _service.Delete(1);
//         Assert.Equal(1, _service.Read()?.Count);
//     }
// }
