int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

// --- MINIMUM VALUE ---
int currentSmallest = int.MaxValue; // Start higher than anything in the array.
foreach (var num in array)
{
    if (num < currentSmallest)
        currentSmallest = num;
}
Console.WriteLine(currentSmallest);
// --- /MINIMUM VALUE ---

// --- AVERAGE VALUE ---
int total = 0;
foreach (var num in array)
    total += num;
float average = (float)total / array.Length;
Console.WriteLine(average);
// --- /AVERAGE VALUE ---