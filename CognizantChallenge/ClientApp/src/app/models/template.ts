export class Template {
   fibonacciTemplateCsharp: string = `using System;

    public class Test {
      public static void Main() {
        int input = 0;  // this value will be replaced with tests input, do not change
        Console.Write(Fibonacci(input));
      }

      public static int Fibonacci(int n) {
        // your code goes here
      }
    }`;

  fibonacciTemplateJava: string = `/* package whatever; // don't place package name! */

import java.util.*;
import java.lang.*;
import java.io.*;

/* Name of the class has to be "Main" only if the class is public. */
class Ideone
{
	public static void main (String[] args) throws java.lang.Exception
	{
		int input = 0;  // this value will be replaced with tests input, do not change
    System.out.println(Fibonacci(input));
	}
	public static int Fibonacci(int n) {
    // your code goes here
}`;

  factorialTemplateCsharp: string = `using System;

    public class Test {
      public static void Main() {
        int input = 0;  // this value will be replaced with tests input, do not change
        Console.Write(Factorial(input));
      }

      public static int Factorial(int n) {
        // your code goes here
      }
    }`;

  factorialTemplatJava: string = `/* package whatever; // don't place package name! */

import java.util.*;
import java.lang.*;
import java.io.*;

/* Name of the class has to be "Main" only if the class is public. */
class Ideone
{
	public static void main (String[] args) throws java.lang.Exception
	{
		int input = 0;  // this value will be replaced with tests input, do not change
    System.out.println(Factorial(input));
	}
	public static int Factorial(int n) {
    // your code goes here
}`;

  primeNumbersTemplateCsharp: string = `using System;

    public class Test {
      public static void Main() {
        int input = 0;  // this value will be replaced with tests input, do not change
        Console.Write(IsPrime(input).ToString());
      }

      public static bool IsPrime(int n) {
         // your code goes here
      }
    }`;

  primeNumbersTemplateJava: string = `/* package whatever; // don't place package name! */

import java.util.*;
import java.lang.*;
import java.io.*;

/* Name of the class has to be "Main" only if the class is public. */
class Ideone
{
	public static void main (String[] args) throws java.lang.Exception
	{
		int input = 0;  // this value will be replaced with tests input, do not change
    System.out.println(IsPrime(input).toString());
	}
	public static Boolean IsPrime(int n) {
    // your code goes here
}`;
}
