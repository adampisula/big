# big
Library for C#. It allows you to operate on infinitely (actually maximum LENGTH of the number is 2^31 - 1) long numbers.

.DLL file is in `Big/obj/Big.dll`, just add it as a reference to your project.

THE LIBRARY STILL HAS A LARGE AMOUNT OF BUGS. If you want to help me developing this lib please contact me at * [adam.pisula@outlook.com] (mailto:adam.pisula@outlook.com)

## Usage
```
Big a = new Big(10);
Big b = new Big("5")
Big c = a + b; //ADDITION
c = a - b; //SUBTRACTION
c = a * b; //MULTIPLICATION
c = Big.Factorial(a) + Big.Factorial(b); //FACTORIAL
c = a ^ b; //POWER
```

Library also supports RPN:
```
string a = Console.ReadLine();
string rpn = Big.ParseRPN(a);
Big calc = Big.CalcRPN(rpn);
```
