using System;

namespace oop_adv_notes
{
    public interface CanRun
    {
        int Run();
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Notice that we call .Add() directly on the calss name Calculator, rather than an instance of type Calculator.
            // Non-static classes can contain static fields and methods, just remember they will still be called from the same class name, not class instances

            int Sum = Calculator.Add(4, 6);
            Console.WriteLine(Sum);

            // Call this function by passing the params and actual delegate reference
            MethodWithCallback(1, 2, handler); // NOT WORKING -- WHERE TO PLACE??

        }

        // Delegates can be defined like this:
        public delegate void Del(string message);
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
        // Instantiate the delegate to reference the DelegateMethod function
        Del handler = DelegateMethod;

        // Now that you have set up a reference to a function as a delegate you can easily pass it to another function as a callback by making a parameter of the delegate type

        public void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
        
       
    }
}

// STATIC CLASSES
// Just like methods, Classes can also be static. A static class can only contain static fields and static methods and cannot be instantiated.
            // Main reason to create a static class is to serve as a toolbox of sorts
                // a static class may contain several useful methods that we want to call from many parts of our code without having to write them in multiple places
                // a simple example of a static class could be a calculator

// EXTENSION METHODS
// If you want to add functionality to a class, one way you can do this is to create a new class to inherit from it and add all needed code there.
// The problem ends up being that now your value type is of that new class and no longer the original one for any object you create

// This can cause some problems, so instead, you can make use of what are called extension methods to directly attach new methods to that class.

// Extension methods are wrapped in a new custom class with the static keyword and when the method you want is declared you must include a variable for the class you want to add the extension to in your parameter proceeded(? maybe they meant preceded) by the keyword --> this <--. See shopping cart example


// EXTENSION METHODS AND INTERFACES
// You can apply extension method directly to an interface as well! 
    // What this allows you to do, is it allows you to add the extension method functionality to every class that implements the interface. Pretty cool, right?!

// DELEGATES
// Callback is a concept that exists in many other languages. The idea is that you can pass a funciton as a parameter to another funciton so that the passed function may be called within the one it was passed to.
// this allows you to create some order by which the functions run as well as improve passing data between them
// Create a callback in C#, you must use a delegate, which is a variable reference to some type of function.