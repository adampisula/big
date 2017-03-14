# big
Library for C#. It allows you operating on infinitely (actually maximum LENGTH of number is 2^31 - 1) huge numbers.

.DLL file is in `Big/obj/Big.dll`, just add it as a reference to your project.

THE LIBRARY STILL HAS A LARGE AMOUNT OF BUGS. If you want to help me developing this lib please contact me at adam.pisula@outlook.com

# Usage
`Big a = new Big(10);
Big b = new Big("5");
Big c = a + b; //ADDING
c = a - b; //SUBTRACTING
c = a * b; //MULTIPLYING
c = Big.Factorial(a) + Big.Factorial(b); //FACTORIAL
c = a ^ b; //POWER`

Library also supports RPN:
`string a = Console.ReadLine();
string rpn = Big.ParseRPN(a);
Big calc = Big.CalcRPN(rpn);`
