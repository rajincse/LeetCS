using System;
using Common;

namespace Problems
{
    public class MinDominoRotationProblem
    {
        public int MinDominoRotations(int[] A, int[] B) {
            if(A == null || A.Length == 0 || B == null || B.Length == 0 || A.Length != B.Length)
            {
                return -1;
            }
            int Invalid = A.Length+1;
            int answer = Invalid;            
            
            int minRotation = CountRotation(A[0], A, B);
            answer = minRotation==-1? answer: Math.Min(answer, minRotation); 
            
            minRotation = CountRotation(A[0], B, A);
            answer = minRotation==-1? answer: Math.Min(answer, minRotation);

            minRotation = CountRotation(B[0], A, B);
            answer = minRotation==-1? answer: Math.Min(answer, minRotation);

            minRotation = CountRotation(B[0], B, A);
            answer = minRotation==-1? answer: Math.Min(answer, minRotation);

            return answer< Invalid? answer : -1;
        }

        public int CountRotation(int value, int[] currentRow, int[] otherRow)
        {
            if(currentRow == null || currentRow.Length == 0 || otherRow == null || otherRow.Length == 0 || currentRow.Length != otherRow.Length)
            {
                return -1;
            }

            int rotationCount =0;
            for(int i=0;i<currentRow.Length;i++)
            {
                if(value != currentRow[i] && value!= otherRow[i]) //Not possible if nowhere found
                {
                    return -1;
                }
                if(value != currentRow[i] && value == otherRow[i]) // Required rotation
                {
                    rotationCount++;
                }
            }

            return rotationCount;
        }

        // public static void Main(string[] args)
        // {
        //     int[] A = new int[] {2,1,2,4,2,2};
        //     int[] B = new int[] {5,2,6,2,3,2};
        //     var result = new MinDominoRotationProblem().MinDominoRotations(A, B);
        //     Console.WriteLine($"[{Utility.PrintArray<int>(A)}], [{Utility.PrintArray<int>(B)}] => {result}");
        // }
    }
}