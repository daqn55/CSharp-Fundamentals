using System;
using System.Collections.Generic;
using System.Text;


public class Database
{
    private int lastIndexWithNumber = -1;

    public Database(params int[] numbers)
    {
        this.Numbers = new int[16];
        StoreNumbers(numbers);
    }

    public int[] Numbers { get; private set; }

    private void StoreNumbers(int[] numbers)
    {
        if (numbers.Length > 16)
        {
            throw new InvalidOperationException("Numbers can't be more than 16!");
        }
        else
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                this.Numbers[i] = numbers[i];
                lastIndexWithNumber = i;
            }
        }
    }

    public void Add(int numberToAdd)
    {
        if (lastIndexWithNumber < 15)
        {
            this.Numbers[lastIndexWithNumber + 1] = numberToAdd;
            lastIndexWithNumber++;
        }
        else
        {
            throw new InvalidOperationException("Array is full can't add more numbers!");
        }
    }

    public void Remove()
    {
        if (lastIndexWithNumber < 0)
        {
            throw new InvalidOperationException("Can't remove number, array is empty!");
        }
        else
        {
            this.Numbers[lastIndexWithNumber] = default(int);
            lastIndexWithNumber--;
        }
    }

    public int[] Fetch()
    {
        int[] numbersToFetch = new int[lastIndexWithNumber + 1];

        Array.Copy(this.Numbers, numbersToFetch, lastIndexWithNumber + 1);

        return numbersToFetch;
    }

}

