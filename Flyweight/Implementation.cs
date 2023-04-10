using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }

    public class CharacterA : ICharacter
    {
        private char _identifier = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;
        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
        }
    }

    public class CharacterB : ICharacter
    {
        private char _identifier = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;
        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
        }
    }

    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();

        public ICharacter? GetCharacter(char character)
        {
            if (_characters.ContainsKey(character))
            {
                return _characters[character]; ;
            }
            switch (character)
            {
                case 'a':
                    _characters[character] = new CharacterA();
                    return _characters[character];

                case 'b':
                    _characters[character] = new CharacterB();
                    return _characters[character];
                default:
                    break;
            }
            return null;
        }

        public static ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }

    internal class Paragraph : ICharacter
    {
        private readonly int _location;
        private readonly List<ICharacter> _characters = new();
        public Paragraph(List<ICharacter> characters, int location)
        {
            _location = location;
            _characters = characters;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }
}
