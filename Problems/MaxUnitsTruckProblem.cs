using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class MaxUnitsTruckProblem
    {
        public class BoxType: IComparable<BoxType>
        {
            public int BoxCount {get;set;}
            public int UnitPerBox {get;}
            
            public BoxType(int boxCount, int unitPerBox)
            {
                BoxCount = boxCount;
                UnitPerBox = unitPerBox;
            }
            
            public int CompareTo(BoxType other)
            {
                return other.UnitPerBox - UnitPerBox; 
            }

            public override string ToString()
            {
                return $"{{{BoxCount},{UnitPerBox}}}";
            }
        }
        public int MaximumUnits(int[][] boxTypes, int truckSize) {
            if(boxTypes == null || boxTypes.Length == 0 || boxTypes[0].Length != 2)
            {
                return 0;
            }
            
            List<BoxType> boxTypeList = new List<BoxType>();
            for(int i=0;i<boxTypes.Length;i++)
            {
                boxTypeList.Add(new BoxType(boxTypes[i][0], boxTypes[i][1]));
            }
            
            int answer = 0;
            int remainingSize = truckSize;
            
            boxTypeList.Sort();
            
            foreach(BoxType type in boxTypeList)
            {
                int available = Math.Min(type.BoxCount, remainingSize);
                
                answer += available * type.UnitPerBox;
                remainingSize -= available;
                
                if(remainingSize <=0)                
                {
                    break;
                }
            }
            
            return answer;
        }

        // public static void Main(string[] args)
        // {
        //     var boxTypes = new int[][]
        //     {
        //         new int[]{1,3},
        //         new int[]{2,2},
        //         new int[]{3,1},                
        //     };
        //     int truckSize = 4;
        //     var result = new MaxUnitsTruckProblem().MaximumUnits(boxTypes, truckSize);

        //     Console.WriteLine($"{Utility.Print2DArray<int>(boxTypes)}, {truckSize} => {result}");
        // }
    }

}