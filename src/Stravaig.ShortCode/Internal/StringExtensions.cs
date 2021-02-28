using System;

namespace Stravaig.ShortCode.Internal
{
    internal static class StringExtensions
    {
        private const int CharacterSpaceMinLength = 2;

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Global
        internal static void ValidateCharacterSpace(this string characterSpace)
        {
            if (string.IsNullOrWhiteSpace(characterSpace))
                throw new ArgumentException(
                    "The value cannot be, null, Empty or contain whitespace.",
                    nameof(characterSpace));
            if (characterSpace.Length < CharacterSpaceMinLength)
                throw new ArgumentException(
                    $"The value must contain at least {CharacterSpaceMinLength} characters.",
                    nameof(characterSpace));
        }
    }
}