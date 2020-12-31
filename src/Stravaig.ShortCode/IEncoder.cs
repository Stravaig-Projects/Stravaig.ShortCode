namespace Stravaig.ShortCode
{
    public interface IEncoder
    {
        string Convert(ulong fullCode, int? fixedChars = null, int maxChars = int.MaxValue);
        ulong RangeRequired(int numChars);
        int MaxLength();
    }
}