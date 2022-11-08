namespace VowelCount.Test.Jose;

using VowelCount.Jose;

public class VowelCountTest {

    [Fact]
    void ItShouldSayIfCharIsAVowel() {
        Assert.Equal(true, new VowelCounter().IsVowel('a'));
        Assert.Equal(true, new VowelCounter().IsVowel('e'));
        Assert.Equal(true, new VowelCounter().IsVowel('i'));
        Assert.Equal(true, new VowelCounter().IsVowel('o'));
        Assert.Equal(true, new VowelCounter().IsVowel('u'));
    }

    [Fact]
    void ItShouldSayIfCharIsNotAVowel() {
        Assert.Equal(false, new VowelCounter().IsVowel('b'));
        Assert.Equal(false, new VowelCounter().IsVowel('c'));
        Assert.Equal(false, new VowelCounter().IsVowel('d'));
        Assert.Equal(false, new VowelCounter().IsVowel('f'));
    }
}