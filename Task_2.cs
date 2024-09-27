using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Dedok
{
    class EnglishFrenchDictionary
    {
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        public void AddWord(string englishWord, List<string> frenchTranslations)
        {
            if (!dictionary.ContainsKey(englishWord))
            {
                dictionary.Add(englishWord, frenchTranslations);
            }
            else
            {
                dictionary[englishWord].AddRange(frenchTranslations);
            }
        }
        public bool RemoveWord(string englishWord)
        {
            return dictionary.Remove(englishWord);
        }
        public bool RemoveTranslation(string englishWord, string frenchTranslation)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                return dictionary[englishWord].Remove(frenchTranslation);
            }
            return false;
        }
        public bool UpdateWord(string oldEnglishWord, string newEnglishWord)
        {
            if (dictionary.ContainsKey(oldEnglishWord))
            {
                var translations = dictionary[oldEnglishWord];
                dictionary.Remove(oldEnglishWord);
                dictionary[newEnglishWord] = translations;
                return true;
            }
            return false;
        }
        public bool UpdateTranslation(string englishWord, string oldFrenchTranslation, string newFrenchTranslation)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                var translations = dictionary[englishWord];
                var index = translations.IndexOf(oldFrenchTranslation);
                if (index != -1)
                {
                    translations[index] = newFrenchTranslation;
                    return true;
                }
            }
            return false;
        }
        public List<string> SearchTranslation(string englishWord)
        {
            if (dictionary.ContainsKey(englishWord))
            {
                return dictionary[englishWord];
            }
            return null;
        }
        public void PrintDictionary()
        {
            foreach (var entry in dictionary)
            {
                Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
            }
        }
    }
}
