using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class HandleHomoglyphs
    {
        #region Maps

        static Dictionary<char, char> englishToBulgarianMap = new Dictionary<char, char>()
        {
            {'a', 'а'}, // English 'a' to Bulgarian 'а'
            {'A', 'А'}, // English 'A' to Bulgarian 'А'
            {'b', 'Ь'}, // English 'b' to Bulgarian 'Ь'
            {'B', 'В'}, // English 'B' to Bulgarian 'В'
            {'c', 'с'}, // English 'c' to Bulgarian 'с'
            {'C', 'С'}, // English 'C' to Bulgarian 'С'
            {'E', 'Е'}, // English 'E' to Bulgarian 'Е'
            {'e', 'е'}, // English 'e' to Bulgarian 'е'
            {'o', 'о'}, // English 'o' to Bulgarian 'о'
            {'O', 'О'}, // English 'О' to Bulgarian 'O'
            {'p', 'р'}, // English 'p' to Bulgarian 'р'
            {'x', 'х'}, // English 'x' to Bulgarian 'х'
            {'X', 'Х'}, // English 'X' to Bulgarian 'Х'
            {'y', 'у'}, // English 'y' to Bulgarian 'у'
            {'Y', 'У'}, // English 'Y' to Bulgarian 'У'
            {'0', 'О'}, // English '0' to Bulgarian 'О'
            {'3', 'З'}, // English '3' to Bulgarian 'З'
            {'6', 'б'}, // English '6' to Bulgarian 'б'
            {'r', 'г'}, // English 'r' to Bulgarian 'г'
            {'u', 'и'}, // English 'и' to Bulgarian 'u'
            {'k', 'к'}, // English 'к' to Bulgarian 'k'
            {'K', 'К'}, // English 'K' to Bulgarian 'К'
            {'n', 'п'}, // English 'n' to Bulgarian 'п'
            {'H', 'Н'}, // English 'H' to Bulgarian 'Н'
            {'T', 'Т'}, // English 'Т' to Bulgarian 'Т'
        };

        static Dictionary<char, char> bulgarianToEnglishMap = new Dictionary<char, char>()
        {
            {'а', 'a'}, // Bulgarian 'а' to English 'a'
            {'А', 'A'}, // Bulgarian 'А' to English 'A'
            {'Ь', 'b'}, // Bulgarian 'Ь' to English 'b'
            {'В', 'B'}, // Bulgarian 'В' to English 'B'
            {'с', 'c'}, // Bulgarian 'с' to English 'c'
            {'С', 'C'}, // Bulgarian 'С' to English 'C'
            {'Е', 'E'}, // Bulgarian 'Е' to English 'E'
            {'е', 'e'}, // Bulgarian 'е' to English 'e'
            {'о', 'o'}, // Bulgarian 'о' to English 'o'
            {'О', 'O'}, // Bulgarian 'О' to English 'O'
            {'р', 'p'}, // Bulgarian 'р' to English 'p'
            {'х', 'x'}, // Bulgarian 'х' to English 'x'
            {'Х', 'X'}, // Bulgarian 'Х' to English 'X'
            {'у', 'y'}, // Bulgarian 'у' to English 'y'
            {'У', 'Y'}, // Bulgarian 'У' to English 'Y'
            {'0', 'O'}, // Bulgarian 'О' to English '0'
            {'З', '3'}, // Bulgarian 'З' to English '3'
            {'б', '6'}, // Bulgarian 'б' to English '6'
            {'г', 'r'}, // Bulgarian 'г' to English 'r'
            {'и', 'u'}, // Bulgarian 'и' to English 'u'
            {'к', 'k'}, // Bulgarian 'k' to English 'к'
            {'К', 'K'}, // Bulgarian 'K' to English 'К'
            {'п', 'n'}, // Bulgarian 'п' to English 'n'
            {'Н', 'H'}, // Bulgarian 'Н' to English 'H'
            {'Т', 'T'}, // Bulgarian 'Т' to English 'Т'
        };

        #endregion

        #region Methods

        public static string ConvertQueryToLanguage(string sqlQuery)
        {
            int englishCount = CountCharacters(sqlQuery, englishToBulgarianMap.Keys);
            int bulgarianCount = CountCharacters(sqlQuery, bulgarianToEnglishMap.Keys);

            if (englishCount > bulgarianCount || (englishCount == bulgarianCount))
            {
                return ConvertToEnglish(sqlQuery);
            }
            else
            {
                return ConvertToBulgarian(sqlQuery);
            }
        }

        public static string ConvertToBulgarian(string input)
        {
            StringBuilder convertedQuery = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (englishToBulgarianMap.ContainsKey(c))
                {
                    convertedQuery.Append(englishToBulgarianMap[c]);
                }
                else
                {
                    convertedQuery.Append(c);
                }
            }
            return convertedQuery.ToString();
        }

        public static string ConvertToEnglish(string input)
        {
            StringBuilder convertedQuery = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (bulgarianToEnglishMap.ContainsKey(c))
                {
                    convertedQuery.Append(bulgarianToEnglishMap[c]);
                }
                else
                {
                    convertedQuery.Append(c);
                }
            }
            return convertedQuery.ToString();
        }

        public static int CountCharacters(string input, IEnumerable<char> characters)
        {
            return input.Count(c => characters.Contains(c));
        }



        #endregion
    }
}
