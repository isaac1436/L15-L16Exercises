using System.Text;
using System.Text.RegularExpressions;
class L16Exercises
{
    static void Main()
    {
        string phrase = "Starlight is the light emitted by stars.[1] It typically refers to visible electromagnetic radiation from stars other than the\n" +
            " Sun, observable from Earth at night, although a component of starlight is observable from Earth during daytime.\n" +
            "Sun light is the term used for the Sun's starlight observed during daytime.[2] During nighttime, albedo describes solar\n" +
            " reflections from other Solar System objects, including moonlight, planet shine, and zodiacal light.[3]";

        string Verbatim = "Starlight is the light emitted by stars.[1] It typically refers to visible electromagnetic radiation from stars other than the" +
            " Sun, observable from Earth at night, although a component of starlight is observable from Earth during daytime." +
            "Sun light is the term used for the Sun's starlight observed during daytime.[2] During nighttime, albedo describes solar" +
            " reflections from other Solar System objects, including moonlight, planet shine, and zodiacal light.[3]";
        Verbatim = Verbatim.ToLower();

        string[] vowel = { "a", "e", "i", "o", "u" };
        string[] consonant = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
        string[] nums = { "1", "2", "3" };
        string[] specialChars = { ".", "[", "]", ",", "\'" };


        StringBuilder firstObj = new StringBuilder();

        firstObj.Append(phrase.Substring(phrase.IndexOf("observable") + 10, 15));

        firstObj.Append(phrase.Substring(phrase.IndexOf("zodiacal") - 10, 10));

        Console.WriteLine(firstObj);

        string secondObj = phrase.Replace("sun", "Solar Emmision", StringComparison.CurrentCultureIgnoreCase);
        Console.WriteLine($"\n\n{secondObj}");
        int index;

        for (int i = secondObj.IndexOf("Solar Emmision", 0); i < secondObj.Length;)
        {
            if (i == -1) { break; }
            Console.WriteLine($"\nAn occurence of \"Solar Emmision\" can be found at index {i}");

            index = i;

            i = secondObj.IndexOf("Solar Emmision", index + 1);
        }

        StringBuilder thirdObj = new StringBuilder();

        string[] firstSplit = { ".", "[", "]", "1", "2", "3" };

        string[] ThirdObj = phrase.Split(firstSplit, StringSplitOptions.RemoveEmptyEntries);

        thirdObj.Append(ThirdObj[0] + ".");
        thirdObj.Append(ThirdObj[ThirdObj.Length - 1] + ".");

        Console.WriteLine($"\n\n{thirdObj}");

        StringBuilder fourthObj = new StringBuilder();

        
        for (int i = phrase.IndexOf("[", 0); i < phrase.Length;)
        {
            if (i == -1) { break; }
            fourthObj.Append(phrase[i]);
            fourthObj.Append(phrase[i + 1]);
            fourthObj.Append(phrase[i + 2] + " ");
            index = i;

            i = phrase.IndexOf("[", index + 1);
        }

        Console.WriteLine($"\nThe indexes contained in the phrase are: {fourthObj}");

        //The consonants
        Console.Write("\n\nThe consonants in the phrase are: ");
        string[] test1 = Testers(nums, vowel, specialChars);

        string[] consonants = Verbatim.Split(test1, StringSplitOptions.RemoveEmptyEntries);


        for (int i = 0; i < consonants.Length; i++)
        {
            Console.Write(consonants[i]);
        }

        //The vowels
        Console.Write("\n\nThe vowels in the phrase are: ");
        string[] test2 = Testers(nums, consonant, specialChars);

        string[] vowels = Verbatim.Split(test2, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < vowels.Length; i++)
        {
            Console.Write(vowels[i]);
        }

        //The numbers
        Console.Write("\n\nThe numbers in the phrase are: ");
        string[] test3 = Testers(consonant, vowel, specialChars);

        string[] numbers = Verbatim.Split(test3, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i]);
        }

        //The special characters
        Console.Write("\n\nThe special characters are: ");
        string[] test4 = Testers(nums, vowel, consonant);

        string[] chars = Verbatim.Split(test4, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < chars.Length; i++)
        {
            Console.Write(chars[i]);
        }


    }

    static string[] Testers(string[] array1, string[] array2, string[] array3)
    {
        string[] superArray = new string[array1.Length + array2.Length + array3.Length];
        array1.CopyTo(superArray, 0);
        array2.CopyTo(superArray, array1.Length);
        array3.CopyTo(superArray, array1.Length + array2.Length);

        return superArray;
    }
}