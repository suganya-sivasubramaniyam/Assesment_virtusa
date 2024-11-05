namespace project1.Services
{
    public class StringTests //: ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();

        }
        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzxzzz";
            var charCounts = new Dictionary<char, int>();

            foreach (var character in word)
            {
                if (charCounts.ContainsKey(character))
                {
                    charCounts[character]++;
                }
                else
                {
                    charCounts[character] = 1;
                }
            }
            Console.WriteLine("Character Counts:");
            foreach (var ch in charCounts)
            {
                Console.WriteLine($"{ch.Key}:{ch.Value}");
            }
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0}>{1} :{2}", word, possibleAnagram, possibleAnagram.isAnagram(word)));

            }
        }
    }
    public static class StringExtension
    {
        public static bool isAnagram(this string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            else
            {
                return string.Concat(a.OrderBy(c => c)) == string.Concat(b.OrderBy(c => c));
            }

        }
    }
    
}
