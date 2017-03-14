<h1>big</h1><br>
Library for C#. It allows you operating on infinitely (actually maximum LENGTH of number is 2^31 - 1) huge numbers.<br /><br />

.DLL file is in <code>Big/obj/Big.dll<code>, just add it as a reference to your project.<br /><br />

THE LIBRARY STILL HAS A LARGE AMOUNT OF BUGS. If you want to help me developing this lib please contact me at <a href="mailto:adam.pisula@outlook.com">adam.pisula@outlook.com</a><br /><br />

<h2>Usage</h2>
<code>Big a = new Big(10);<br />
Big b = new Big("5");<br />
Big c = a + b; //ADDING<br />
c = a - b; //SUBTRACTING<br />
c = a * b; //MULTIPLYING<br />
c = Big.Factorial(a) + Big.Factorial(b); //FACTORIAL<br />
c = a ^ b; //POWER</code><br /><br />

Library also supports RPN:<br />
<code>string a = Console.ReadLine();<br />
string rpn = Big.ParseRPN(a);<br />
Big calc = Big.CalcRPN(rpn);</code>
