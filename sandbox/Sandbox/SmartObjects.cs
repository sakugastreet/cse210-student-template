using System;

// Base class representing a generic smart object
public class SmartObject
{
    public virtual void ConnectToInternet()
    {
        Console.WriteLine("Connecting to the Internet...");
    }

    public virtual void PerformFunctionality()
    {
        Console.WriteLine("Generic smart object functionality.");
    }
}

// Child class representing a smart lightbulb
public class SmartLightbulb : SmartObject
{
    public override void PerformFunctionality()
    {
        Console.WriteLine("Adjusting brightness and color of the smart lightbulb.");
    }
}

// Child class representing a smart oven
public class SmartOven : SmartObject
{
    public override void PerformFunctionality()
    {
        Console.WriteLine("Preheating the smart oven and providing cooking options.");
    }
}

// Child class representing a smart dishwasher
public class SmartDishwasher : SmartObject
{
    public override void PerformFunctionality()
    {
        Console.WriteLine("Running a smart cleaning cycle in the dishwasher.");
    }
}

class PolymorphismExample
{
    public void Main()
    {
        // Create instances of smart objects
        SmartObject smartLightbulb = new SmartLightbulb();
        SmartObject smartOven = new SmartOven();
        SmartObject smartDishwasher = new SmartDishwasher();

        // Demonstrate polymorphic behavior
        ConnectAndPerformFunctionality(smartLightbulb);
        ConnectAndPerformFunctionality(smartOven);
        ConnectAndPerformFunctionality(smartDishwasher);
    }

    static void ConnectAndPerformFunctionality(SmartObject smartObject)
    {
        smartObject.ConnectToInternet();
        smartObject.PerformFunctionality();
        Console.WriteLine(); // Add a line break for better output readability
    }
}
