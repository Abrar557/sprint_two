private void BubbleSort(List<int> data)
{
    for (int i = 0; i < data.Count - 1; i++)
    {
        for (int j = 0; j < data.Count - i - 1; j++)
        {
            if (data[j] > data[j + 1])
            {
                int temp = data[j];
                data[j] = data[j + 1];
                data[j + 1] = temp;
            }
        }
    }
}

private int BinarySearch(List<int> data, int target)
{
    int left = 0, right = data.Count - 1;
    while (left <= right)
    {
        int mid = (left + right) / 2;
        if (data[mid] == target)
            return mid;
        else if (data[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }
    return -1;
}
