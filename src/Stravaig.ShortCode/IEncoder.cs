namespace Stravaig.ShortCode
{
    public interface IEncoder
    {
        string Convert(ulong fullCode, int? fixedChars = null, int maxChars = int.MaxValue);
        int MaxLength();
        
        string NamedCharacterSpace { get; }
        string CharacterSpace { get; }
    }
}