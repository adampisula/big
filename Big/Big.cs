using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStr
{
    public class Big
    {
        public string value = "0";

        //CONSTRUCTORS
        public Big(string val)
        {
            if (IsNumeric(val))
                value = val;
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(byte val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(sbyte val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(short val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(ushort val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(int val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(uint val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(long val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(ulong val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(float val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(double val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }
        public Big(decimal val)
        {
            if (IsNumeric(val.ToString()))
                value = val.ToString();
            else
                throw new System.ArgumentException("Parameter is not a number!", "original");
        }

        //METHODS
        private static Big Subtract(Big b1, Big b2)
        {
            return Subtract(b1.value, b2.value);
        }
        private static Big Subtract(string n1, string n2)
        {
            if (Compare(n1, "0") == 2)
                return Negate(n2);
            else if (Compare(n2, "0") == 2)
                return new Big(n1);

            byte[] a = null;
            byte[] b = null;
            bool toneg = false;

            if (IsNegative(n1) == true && IsNegative(n2) == false)
            {
                n1 = Negate(n1).value;

                return Negate(Add(n2, n1));
            }
            else if (IsNegative(n1) == false && IsNegative(n2) == true)
            {
                n2 = Negate(n2).value;

                return Add(n1, n2);
            }
            else if (IsNegative(n1) == true && IsNegative(n2) == true)
            {
                n1 = Negate(n1).value;
                n2 = Negate(n2).value;

                return (Compare(n2, n1) == 0) ? Subtract(n2, n1) : Negate(Subtract(n1, n2));
            }
            else
            {
                if (Compare(n2, n1) == 0)
                    toneg = true;
            }

            //JESLI n1 WIEKSZE
            if (Compare(n1, n2) == 0)
            {
                a = new byte[n1.Length];
                b = new byte[n1.Length];
                n2 = new String('0', n1.Length - n2.Length) + n2;

                for (int j = 0; j < n1.Length; j++)
                {
                    a[j] = Convert.ToByte(Char.GetNumericValue(n1[j]));
                    b[j] = Convert.ToByte(Char.GetNumericValue(n2[j]));
                }
            }

            //JESLI n2 WIEKSZE
            else if (Compare(n1, n2) == 1)
            {
                a = new byte[n2.Length];
                b = new byte[n2.Length];
                n1 = new String('0', n2.Length - n1.Length) + n1;

                for (int j = 0; j < n1.Length; j++)
                {
                    a[j] = Convert.ToByte(Char.GetNumericValue(n2[j]));
                    b[j] = Convert.ToByte(Char.GetNumericValue(n1[j]));
                }
            }

            //JESLI IDENTYCZNE
            else if (Compare(n1, n2) == 2)
                return new Big(0);

            int al = a.Length - 1;
            int bl = b.Length - 1;
            int i = 0;
            byte ac = 0;
            byte bc = 0;
            string c = "";
            string cd = "";

            while (i < a.Length)
            {
                ac = a[al - i];
                bc = b[bl - i];

                if (ac - bc < 0)
                {
                    for (int j = al - i - 1; j >= 0; j--)
                    {
                        if (a[j] == 0)
                            a[j] = 9;
                        else
                        {
                            a[j] -= 1;
                            break;
                        }
                    }

                    c += (ac - bc + 10).ToString();
                }
                else
                    c += ac - bc;

                i++;
            }

            for (int j = c.Length - 1; j >= 0; j--)
                cd += c[j];

            return (toneg) ? Negate(TrimZero(cd)) : TrimZero(cd);
        }

        private static Big Add(Big b1, Big b2)
        {
            return Add(b1.value, b2.value);
        }
        private static Big Add(string a, string b)
        {
            bool toneg = false;

            if (Compare(a, "0") == 2)
                return new Big(b);
            else if (Compare(b, "0") == 2)
                return new Big(a);

            if (IsNegative(a) == true && IsNegative(b) == false)
            {
                a = Negate(a).value;

                return (Compare(a, b) == 0) ? Negate(Subtract(a, b)) : Subtract(b, a);
            }
            else if (IsNegative(a) == false && IsNegative(b) == true)
            {
                b = Negate(b).value;

                return (Compare(b, a) == 0) ? Negate(Subtract(b, a)) : Subtract(a, b);

            }
            else if (IsNegative(b) == true && IsNegative(b) == true)
            {
                a = Negate(a).value;
                b = Negate(b).value;

                toneg = true;
            }

            int al = a.Length - 1;
            int bl = b.Length - 1;
            int s = 0;
            int i = 0;
            int ac = 0;
            int bc = 0;
            int cc = 0;
            string c = "";

            while ((i < a.Length) || (i < b.Length))
            {
                if (al - i < 0) ac = 0;
                else ac = (int)Char.GetNumericValue(a[al - i]);
                if (bl - i < 0) bc = 0;
                else bc = (int)Char.GetNumericValue(b[bl - i]);

                cc = (ac + bc + s) % 10;
                s = (ac + bc + s) / 10;

                c += cc.ToString();

                i++;
            }

            c += s.ToString();

            string cd = "";
            for (int j = c.Length - 1; j >= 0; j--)
                cd += c[j];

            return (toneg) ? TrimZero(Negate(cd)) : TrimZero(cd);
        }

        private static Big Multiply(Big a, Big b)
        {
            return Multiply(a.value, b.value);
        }
        private static Big Multiply(string a, string b)
        {
            if ((IsNegative(a) == true && IsNegative(b) == false) || (IsNegative(a) == false && IsNegative(b) == true))
                return (IsNegative(a) == true) ? Negate(Multiply(Negate(a).value, b)) : Negate(Multiply(a, Negate(b).value));
            else if (IsNegative(a) == true && IsNegative(b) == true)
            {
                a = Negate(a).value;
                b = Negate(b).value;
            }

            int ac = 0;
            int bc = 0;
            int w = 0;
            int s = 0;
            int al = a.Length - 1;
            int bl = b.Length - 1;
            string res = "0";
            string resin = "";
            string buff = "";

            for (int i = bl; i >= 0; i--)
            {
                buff = "";
                s = 0;

                for (int j = al; j >= 0; j--)
                {
                    ac = Convert.ToByte(Char.GetNumericValue(a[j]));
                    bc = Convert.ToByte(Char.GetNumericValue(b[i]));

                    w = (ac * bc + s) % 10;
                    s = (ac * bc + s) / 10;
                    buff += w.ToString();
                }

                buff += s.ToString();

                resin = Reverse(buff).value;

                for (int k = 0; k < bl - i; k++)
                    resin += '0';

                res = Add(res, resin).value;
            }

            return TrimZero(res);
        }

        public static Big Factorial(Big b)
        {
            return Factorial(b.value);
        }
        public static Big Factorial(string a)
        {
            if (Compare(a, "1") != 0)
                return new Big(1);

            string result = "1";

            for (Big i = new Big(1); i < a + "1"; i++)
                result = (result * i).value;

            return TrimZero(result);
        }

        private static Big Power(Big a, Big b)
        {
            return Power(a.value, b.value);
        }
        private static Big Power(string a, string b)
        {
            Big result = new Big(1);

            for (Big i = new Big(1); i < b; i++)
                result = result * a;

            return TrimZero(result);
        }

        public static Big SquareRoot(Big s, Big ac)
        {
            return SquareRoot(s.value, ac.value);
        }
        public static Big SquareRoot(string s, string ac = "5")
        {
            Big a = new Big(ac);
            string buff = "";
            string output = "";
            Big n = new Big(0);
            Big c = new Big(0);

            if (s.Length % 2 == 1)
                s = s.Insert(0, "0");

            for (Big i = new Big(0); i < a; i++)
                s += "00";

            string[] pairs = new string[s.Length / 2];

            for (int i = 0; i < pairs.Length * 2; i += 2)
            {
                pairs[i / 2] = s[i].ToString();
                pairs[i / 2] += s[i + 1].ToString();
            }

            Big j = new BigStr.Big(9);

            for (; j >= "0"; j--)
            {
                if ((j ^ "2") < pairs[0] || (j ^ "2") == pairs[0])
                    break;
            }

            n = j;
            output = n.ToString();

            if (pairs.Length == 1)
                return new Big(output);

            buff = (new Big(pairs[0]) - (n ^ "2")).value;

            Big k = new Big(0);
            Big pairslength = new Big(pairs.Length);

            for (Big i = new Big(1); i < pairslength; i++)
            {
                if (i == pairslength - a)
                    c = i;

                buff += pairs[Convert.ToInt32(i.value)];
                string q = "";
                string m = "";

                for (k.value = "9"; k >= "0"; k--)
                {
                    m = (new Big(output) * "2").value + k.ToString();
                    q = (m * k).value;

                    if (Compare(q, buff) != 0)
                        break;
                }

                buff = (new Big(buff) - q).value;
                output += k.ToString();
            }

            output = output.Insert(Convert.ToInt32(c.value), ".");

            return TrimZero(output);
        }

        private static Big TrimZero(Big b)
        {
            return TrimZero(b.value);
        }
        private static Big TrimZero(string a)
        {
            bool aisneg = false;
            bool f = false;

            for (int k = 0; k < a.Length; k++)
            {
                if (a[k] == '.')
                    f = true;
            }

            if (a[0] == '-')
            {
                aisneg = true;
                a = Negate(a).value;
            }
            else
                aisneg = false;

            StringBuilder asb = new StringBuilder(a);
            int i = 0;

            for (i = 0; i < asb.Length; i++)
            {
                if (asb[i] == '0')
                    continue;
                else
                    break;
            }

            if (i == asb.Length)
                return new BigStr.Big("0");

            asb = asb.Remove(0, i);

            if (f == true)
            {
                int j = 0;

                for (j = asb.Length - 1; j >= 0; j--)
                {
                    if (asb[j] != '.' && asb[j] != '0')
                        break;
                    else
                        asb = asb.Remove(asb.Length - 1, 1);
                }
            }

            return (aisneg) ? Negate(asb.ToString()) : new Big(asb.ToString());
        }

        private static Big Negate(Big b)
        {
            return Negate(b.value);
        }
        private static Big Negate(string a)
        {
            if (a == "0" || a == "-0")
                return new BigStr.Big("0");
            else if (a[0] == '-')
                return new Big(a.Trim('-'));
            else
                return new Big(a.Insert(0, "-"));
        }

        private static Big Reverse(Big b)
        {
            return Reverse(b.value);
        }
        private static Big Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new Big(new string(charArray));
        }

        private static int Compare(Big b1, Big b2)
        {
            return Compare(b1.value, b2.value);
        }
        private static int Compare(string n1, string n2)
        {
            //0 -> a>b
            //1 -> a<b
            //2 -> a=b

            if (IsNegative(n1) == true && IsNegative(n2) == false)
                return 1;
            else if (IsNegative(n1) == false && IsNegative(n2) == true)
                return 0;

            if (n1.Length > n2.Length)
            {
                n2 = (IsNegative(n2) == false) ? new String('0', n1.Length - n2.Length) + n2 : Negate(new String('0', n1.Length - n2.Length) + Negate(n2).value).value;
            }
            else if (n1.Length < n2.Length)
            {
                n1 = (IsNegative(n1) == false) ? new String('0', n2.Length - n1.Length) + n1 : Negate(new String('0', n2.Length - n1.Length) + Negate(n1).value).value;
            }

            int i = (IsNegative(n1) && IsNegative(n2)) ? 1 : 0;

            while (i < n1.Length)
            {
                if (Char.GetNumericValue(n1[i]) > Char.GetNumericValue(n2[i]))
                    return (IsNegative(n1) && IsNegative(n2)) ? 1 : 0;
                else if (Char.GetNumericValue(n1[i]) < Char.GetNumericValue(n2[i]))
                    return (IsNegative(n1) && IsNegative(n2)) ? 0 : 1;
                else
                    i++;
            }

            if (i == n1.Length && IsNegative(n1) == false)
                return 2;
            else if (i == n1.Length && IsNegative(n2) == true)
                return 2;

            return 3;
        }

        public static bool IsNumeric(Big b)
        {
            return IsNumeric(b.value);
        }
        public static bool IsNumeric(string s)
        {
            if (s == "" || s == "-")
                return false;

            int i = (IsNegative(s)) ? 1 : 0;

            while (i < s.Length)
            {
                if (Char.IsNumber(s[i]) == true || s[i] == '.')
                {
                    i++;
                    continue;
                }
                else
                    break;
            }

            return ((i == s.Length - 1 && IsNegative(s)) || (i == s.Length)) ? true : false;
        }

        private static bool IsNegative(Big b)
        {
            return IsNegative(b.value);
        }
        private static bool IsNegative(string a)
        {
            if (a[0] == '-')
                return true;
            else
                return false;
        }

		public static Big CalcRPN(string s)
		{
			Stack<string> stack = new Stack<string>();
			string[] words = s.Split(' ');
			string el = "";
			string a = "";
			string b = "";
			string w = "";
			int i = 0;

			while (i < words.Length)
			{
				el = words[i];

				if (el == "")
					break;

				else if (IsNumeric(el) == true)
					stack.Push(el);

				else if (stack.Count >= 2)
				{
					b = stack.Pop().ToString();
					a = stack.Pop().ToString();

					if (el == "^") w = Power(a, b).value;
					else if (el == "*") w = Multiply(a, b).value;
					else if (el == "/") w = (Double.Parse(a) / Double.Parse(a)).ToString();
					else if (el == "%") w = (Int32.Parse(a) % Int32.Parse(a)).ToString();
					else if (el == "+") w = Add(a, b).value;
					else if (el == "-") w = Subtract(a, b).value;

					stack.Push(w);
				}               

				i++;
			}

			return new Big(stack.Pop().ToString());
		}

		public static string ParseRPN(string s, int a = 5)
		{
			string[] words = s.Split(' ');
			Stack<string> stack = new Stack<string>();
			string el = "";
			string output = "";
			int i = 0;

			for (int j = 0; j < words.Length; j++)
			{
				if (words[j][words[j].Length - 1] == '!')
				{
					words[j] = words[j].Remove(words[j].Length - 1);
					words[j] = Factorial(words[j]).value;
				}
				else if (words[j][0] == '√')
				{
					words[j] = words[j].Substring(1);
					words[j] = SquareRoot(words[j], a.ToString()).value;
				}
			}

			while (i < words.Length)
			{
				el = words[i];

				if (el == "")
					break;

				else if (IsNumeric(el) == true)
				{
					output += el + " ";
					i++;
					continue;
				}
				else if (el == "(")
				{
					stack.Push("(");
					i++;
					continue;
				}
				else if (el == ")")
				{
					while (stack.Peek().ToString() != "(")
						output += stack.Pop() + " ";

					stack.Pop();
					i++;
					continue;
				}
				else
				{
					if (stack.Count != 0)
					{
						while (Priority(el) <= Priority(stack.Peek().ToString()))
						{
							output += stack.Pop() + " ";

							if (stack.Count == 0)
								break;
						}
					}

					stack.Push(el);

					i++;
					continue;
				}
			}

			while (stack.Count != 0)
			{
				output += stack.Pop() + " ";
			}

			return (output[output.Length - 1] == ' ') ? output.Remove(output.Length - 1) : output;
		}

		private static byte Priority(string s)
		{
			if (s == "^")
				return 3;
			else if (s == "*" || s == "/" || s == "%")
				return 2;
			else if (s == "+" || s == "-")
				return 1;
			else
				return 0;
		}

		public static bool IsFloat(string a)
		{
			for (int k = 0; k < a.Length; k++)
			{
				if (a [k] == '.')
					return true;
			}

			return false;
		}

        //OPERATOR OVERLOADING
        //+
        public static Big operator +(Big b1, Big b2) => Add(b1, b2);
        public static Big operator +(Big b1, string b2) => Add(b1, new Big(b2));
        public static Big operator +(string b1, Big b2) => Add(new Big(b1), b2);

        //-
        public static Big operator -(Big b1, Big b2) => Subtract(b1, b2);
        public static Big operator -(Big b1, string b2) => Subtract(b1, new Big(b2));
        public static Big operator -(string b1, Big b2) => Subtract(new Big(b1), b2);

        //*
        public static Big operator *(Big b1, Big b2) => Multiply(b1, b2);
        public static Big operator *(Big b1, string b2) => Multiply(b1, new Big(b2));
        public static Big operator *(string b1, Big b2) => Multiply(new Big(b1), b2);

        //^
        public static Big operator ^(Big b1, Big b2) => Power(b1, b2);
        public static Big operator ^(Big b1, string b2) => Power(b1, new Big(b2));
        public static Big operator ^(string b1, Big b2) => Power(new Big(b1), b2);

        //++
        public static Big operator ++(Big b1) => Add(b1, new Big(1));

        //--
        public static Big operator --(Big b1) => Subtract(b1, new Big(1));

        //!
        public static Big operator !(Big b1) => Negate(b1);

        //==
        public static bool operator ==(Big b1, Big b2) => (Compare(b1, b2) == 2) ? true : false;
        public static bool operator ==(Big b1, string b2) => (Compare(b1, new Big(b2)) == 2) ? true : false;
        public static bool operator ==(string b1, Big b2) => (Compare(new Big(b1), b2) == 2) ? true : false;

        //!=
        public static bool operator !=(Big b1, Big b2) => (Compare(b1, b2) != 2) ? true : false;
        public static bool operator !=(Big b1, string b2) => (Compare(b1, new Big(b2)) != 2) ? true : false;
        public static bool operator !=(string b1, Big b2) => (Compare(new Big(b1), b2) != 2) ? true : false;

        //>
        public static bool operator >(Big b1, Big b2) => (Compare(b1, b2) == 0) ? true : false;
        public static bool operator >(Big b1, string b2) => (Compare(b1, new Big(b2)) == 0) ? true : false;
        public static bool operator >(string b1, Big b2) => (Compare(new Big(b1), b2) == 0) ? true : false;

        //<
        public static bool operator <(Big b1, Big b2) => (Compare(b1, b2) == 1) ? true : false;
        public static bool operator <(Big b1, string b2) => (Compare(b1, new Big(b2)) == 1) ? true : false;
        public static bool operator <(string b1, Big b2) => (Compare(new Big(b1), b2) == 1) ? true : false;

        //<=
        public static bool operator <=(Big b1, Big b2) => (b1 == b2 || b1 < b2) ? true : false;
        public static bool operator <=(Big b1, string b2) => (b1 == b2 || b1 < b2) ? true : false;
        public static bool operator <=(string b1, Big b2) => (b1 == b2 || b1 < b2) ? true : false;

        //>=
        public static bool operator >=(Big b1, Big b2) => (b1 == b2 || b1 > b2) ? true : false;
        public static bool operator >=(Big b1, string b2) => (b1 == b2 || b1 > b2) ? true : false;
        public static bool operator >=(string b1, Big b2) => (b1 == b2 || b1 > b2) ? true : false;

        //TOSTRING
        public override string ToString() => value;
    }
}
