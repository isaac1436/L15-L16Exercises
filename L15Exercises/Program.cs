class L15Exercises
{
    static void Main()
    {
        Console.WriteLine("Let's try out a few exceptions ");
        decimal[] decimals = new decimal[10];

        try
        {
            for (int i = 0; i < decimals.Length; i++)
            {
                Console.Write("\nEnter a decimal value: ");
                decimals[i] = decimal.Parse(Console.ReadLine());
                decimal inverse = 1 / decimals[i];

                if (decimals[i] > 10)
                {
                    throw new upperLimits();                 
                }

                if (decimals[i] < -10)
                {
                    throw new lowerLimits();
                }

                Console.WriteLine($"\nThe inverse of {decimals[i]} is { inverse.ToString(" 0.00 ") }");

            }
        }

        catch (IOException)
        {
            Console.WriteLine("\nThere is an error in your input");

            throw new cutShort();
        }

        catch (OutOfMemoryException)
        {
            Console.WriteLine("\nYou are out of memory");

            throw new cutShort();
        }

        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("\nThe input is larger/smaller than the range specified");

            throw new cutShort();
        }

        catch (FormatException)
        {
            Console.WriteLine("\nThe number entered is not a decimal");

            throw new cutShort();
        }

        catch (OverflowException)
        {
            Console.WriteLine("\nValue was too large/small for a decimal");

            throw new cutShort();
        }

        catch (DivideByZeroException)
        {
            Console.WriteLine("\nProgram stopped because you attempted to divide by 0");

            throw new cutShort();
        }

        finally
        {
            Console.WriteLine("\n\n \t\t\tGoodBye");
        }
    }
}

public class upperLimits : Exception
{
    public upperLimits()
    {
        Console.WriteLine("\nThe value entered is larger than expected");

        throw new cutShort();
    }
}

public class lowerLimits : Exception
{
    public lowerLimits()
    {
        Console.WriteLine("\nThe value entered is smaller than expected");

        throw new cutShort();
    }
}

public class cutShort : Exception
{
    public cutShort()
    {
        Console.WriteLine("\nThe program was cancelled before executing fully\n\n");
    }
}