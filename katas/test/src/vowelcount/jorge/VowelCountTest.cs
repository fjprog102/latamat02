namespace VowelCount.Test.Jorge{
    using VowelCount.Jorge;
public class VowelCountTest {

    [Fact]
    public void VowelCount() {
        Assert.True(5 == new VowelCount().Phrase("abracadabra"));
        Assert.True(8 == new VowelCount().Phrase("It's a piece of cake"));
        Assert.True(15 == new VowelCount().Phrase("To not hold someone responsible for something"));
    }

}
}

