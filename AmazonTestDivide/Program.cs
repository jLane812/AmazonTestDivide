using System.Data;

List<int> dataSet = new List<int>();
List<int> result = new List<int>();

dataSet.Add(8);
dataSet.Add(10);
dataSet.Add(5);
dataSet.Add(0);
dataSet.Add(4);
dataSet.Add(7);
dataSet.Add(2);
dataSet.Add(9);
dataSet.Add(7);

Demo demo = new Demo();
result = demo.sort(dataSet);

foreach(int data in result)
{
    Console.WriteLine(data);
}

class Demo
{
    public List<int> sort(List<int> dataSet)
    {
        List<int> sorted = new List<int>();
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        if (dataSet.Count() <= 1)
        {
            return dataSet;
        }

        int mid = dataSet.Count() / 2;
        int count = dataSet.Count();
      
        foreach (int data in dataSet.GetRange(0, mid))
        {
            left.Add(data);
        }

        foreach (int data in dataSet.GetRange(mid, count - mid))
        {
            right.Add(data);
        }

        left = sort(left);
        right = sort(right);

        sorted = merge(left,right);

        return sorted;
    }

    public List<int> merge(List<int> left, List<int>right)
    {
        List<int> mergeSortData = new List<int>();
        int indexLeft = 0;
        int indexRight = 0;

        while (indexLeft < left.Count() || indexRight < right.Count())
        {
            if (indexLeft < left.Count() && indexRight < right.Count())
            {
                if(left[indexLeft] < right[indexRight])
                {
                    mergeSortData.Add(left[indexLeft]);
                    indexLeft++;
                } 
                else
                {
                    mergeSortData.Add(right[indexRight]);
                    indexRight++;
                }
            }
            else if (indexLeft >= left.Count() && indexRight < right.Count())
            {
                mergeSortData.Add(right[indexRight]);
                indexRight++;
            }
            else
            {
                mergeSortData.Add(left[indexLeft]);
                indexLeft++;
            }
        }
        

        return mergeSortData;
    }
}