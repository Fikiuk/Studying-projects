using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Library
{
    public class Equation 
    {
        public void FirstMethod()
        {
            string inputRaw = Console.ReadLine();
            const string error1 = "+-";                                             // wykrywane błędy we wpisywaniu 'input'
            const string error2 = "^-";
            const string error3 = "*-";
            string input = inputRaw.Replace(" ", string.Empty);             // usunięcie spacji w 'input'
            int input_length = input.Length;
            for (int i = 0; i < input_length - 1; i++)                                // przesuwanie się po kolejnych char 
            {
                char[] chars = { input[i], input[i + 1] };                            // dla kolejnych par znaków w naszym działaniu 'input'
                string chars_pair = string.Join("", chars);

                bool is_equal1 = String.Equals(chars_pair, error1);                 // wartości logiczne; sprawdzenie czy użytkownik wpisał źle 'input'
                bool is_equal2 = String.Equals(chars_pair, error2);
                bool is_equal3 = String.Equals(chars_pair, error3);

                if (is_equal1 == true || is_equal2 == true || is_equal3 == true)    // jeśli wpisał źle 'input', to wypisz komunikat
                {
                    Console.WriteLine("BŁĄD WPISYWANIA.");
                }
                else
                {
                    int j = 0;
                    Queue output_q = new Queue();
                    Stack operator_stack = new Stack();

                    while (j < input_length + 1)
                    {
                        j++;
                        if (Char.IsDigit(input, j) == true) // jeśli 'j-ty' element zmiennej 'input_clear' jest liczbą >>> Char.IsDigit(String, Int32) Method
                        {
                            output_q.Enqueue(input[j]);        // to daj go do output_queue
                        }
                        else if (input[j] == '+' || input[j] == '-' || input[j] == '*' || input[j] == '/' || input[j] == '^')
                        {
                            var stack_top = operator_stack.Pop();
                            while (Ranga(input[j]) < Ranga(stack_top))
                            {
                                output_q.Enqueue(operator_stack.Pop()); // to weź element z góry stosu i dodaj go do 'output'
                            }
                            operator_stack.Push(input[j]);  // w innym przypadku weź operator na stack
                        }
                        else if (input[j] == '(')
                        {
                            operator_stack.Push(input[j]);
                        }
                        else if (input[j] == ')')
                        {
                            var stack_top = operator_stack.Pop();
                            bool is_equal4 = String.Equals(stack_top, '(');
                            while (is_equal4 == false) // jeśli to nieprawda, że element na górze stosu jest '('
                            {
                                output_q.Enqueue(operator_stack.Pop());
                            }
                        }
                    }
                    while (operator_stack.Count > 0)
                    {
                        output_q.Enqueue(output_q);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
