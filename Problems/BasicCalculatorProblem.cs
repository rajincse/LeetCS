using System;
using System.Collections.Generic;

namespace Problems
{
    public class BasicCalculatorProblem
    {
        enum Mode
        {
            Addition, Subtraction, Multiplication, Division
        };
        public int Calculate(string s) {
            if(string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            
            char[] charArray = s.ToCharArray();
            Stack<int> stack = new Stack<int>();
            
            
            int currentNumber = 0;
            Mode lastMode = Mode.Addition;
            foreach(char calculationCharacter in charArray)
            {
                if(calculationCharacter != ' ')
                {
                    if (char.IsDigit(calculationCharacter))
                    {
                        currentNumber = currentNumber * 10 + (calculationCharacter - '0');
                    }
                    else 
                    {
                        if(lastMode == Mode.Addition)
                        {
                            stack.Push(currentNumber);
                        }
                        else if(lastMode == Mode.Subtraction)
                        {
                            stack.Push( - currentNumber);
                        }
                        else if(lastMode == Mode.Multiplication)
                        {
                            int previousNumber = stack.Pop();
                            stack.Push(previousNumber * currentNumber);                            
                        }
                        else if(lastMode == Mode.Division )
                        {
                            int previousNumber = stack.Pop();
                            stack.Push(previousNumber / currentNumber);                            
                        }
                        
                        lastMode = GetCurrentMode(calculationCharacter);
                        currentNumber = 0;
                    }
                }
            }
            if(lastMode == Mode.Addition)
            {
                stack.Push(currentNumber);
            }
            else if(lastMode == Mode.Subtraction)
            {
                stack.Push( - currentNumber);
            }
            else if(lastMode == Mode.Multiplication)
            {
                int previousNumber = stack.Pop();
                stack.Push(previousNumber * currentNumber);                            
            }
            else if(lastMode == Mode.Division )
            {
                int previousNumber = stack.Pop();
                stack.Push(previousNumber / currentNumber);                            
            }

            int total = 0;
            while(stack.Count != 0)
            {
                total += stack.Pop();
            }
            return total;
        }

        private Mode GetCurrentMode(char calculationCharacter)
        {
            if(calculationCharacter == '+')
            {
                return Mode.Addition;
            }
            else if(calculationCharacter == '-')
            {
                return Mode.Subtraction;
            }
            else if(calculationCharacter == '*')
            {
                return Mode.Multiplication;
            }
            else if(calculationCharacter == '/') 
            {
                return Mode.Division;
            }
            else
            {
                return Mode.Addition;
            }
        }
        // public static void Main(string[] args)
        // {
        //     var s = "3+5 / 2";
        //     var result = new BasicCalculatorProblem().Calculate(s);
        //     Console.WriteLine($"{s} => {result}");
        // }
    }
}