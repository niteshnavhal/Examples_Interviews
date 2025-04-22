using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Exaples
{
    public class DictionaryExamples
    {
        private Dictionary<int, string> paymentModes = new Dictionary<int, string>();
        private ConcurrentDictionary<int, string> concurrentPaymentModes = new ConcurrentDictionary<int, string>();

        public void Run()
        {
            bool continueDemo = true;

            while (continueDemo)
            {
                Console.WriteLine("\n===== Dictionary Examples =====");
                Console.WriteLine("1. Add item to Dictionary");
                Console.WriteLine("2. Update item in Dictionary");
                Console.WriteLine("3. Remove item from Dictionary");
                Console.WriteLine("4. Clear Dictionary");
                Console.WriteLine("5. Get item from Dictionary");
                Console.WriteLine("6. Check if key exists in Dictionary");
                Console.WriteLine("7. Display all Dictionary items");
                Console.WriteLine("8. Add item to ConcurrentDictionary");
                Console.WriteLine("9. Update item in ConcurrentDictionary");
                Console.WriteLine("10. Remove item from ConcurrentDictionary");
                Console.WriteLine("11. Clear ConcurrentDictionary");
                Console.WriteLine("12. Get item from ConcurrentDictionary");
                Console.WriteLine("13. TryAdd to ConcurrentDictionary");
                Console.WriteLine("14. GetOrAdd to ConcurrentDictionary");
                Console.WriteLine("15. AddOrUpdate to ConcurrentDictionary");
                Console.WriteLine("16. Display all ConcurrentDictionary items");
                Console.WriteLine("0. Return to main menu");

                Console.Write("\nEnter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 0:
                            continueDemo = false;
                            break;
                        case 1:
                            AddToDictionary();
                            break;
                        case 2:
                            UpdateDictionary();
                            break;
                        case 3:
                            RemoveFromDictionary();
                            break;
                        case 4:
                            ClearDictionary();
                            break;
                        case 5:
                            GetFromDictionary();
                            break;
                        case 6:
                            CheckKeyInDictionary();
                            break;
                        case 7:
                            DisplayDictionary();
                            break;
                        case 8:
                            AddToConcurrentDictionary();
                            break;
                        case 9:
                            UpdateConcurrentDictionary();
                            break;
                        case 10:
                            RemoveFromConcurrentDictionary();
                            break;
                        case 11:
                            ClearConcurrentDictionary();
                            break;
                        case 12:
                            GetFromConcurrentDictionary();
                            break;
                        case 13:
                            TryAddToConcurrentDictionary();
                            break;
                        case 14:
                            GetOrAddToConcurrentDictionary();
                            break;
                        case 15:
                            AddOrUpdateConcurrentDictionary();
                            break;
                        case 16:
                            DisplayConcurrentDictionary();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        // Regular Dictionary Methods
        private void AddToDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID (int): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter payment mode name: ");
                    string name = Console.ReadLine();

                    if (paymentModes.ContainsKey(id))
                    {
                        Console.WriteLine($"Error: ID {id} already exists in Dictionary.");
                    }
                    else
                    {
                        paymentModes.Add(id, name);
                        Console.WriteLine($"Added payment mode: {id} - {name}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding to Dictionary: {ex.Message}");
            }
        }

        private void UpdateDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to update: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (paymentModes.ContainsKey(id))
                    {
                        Console.WriteLine($"Current value: {id} - {paymentModes[id]}");
                        Console.Write("Enter new payment mode name: ");
                        string name = Console.ReadLine();

                        paymentModes[id] = name;
                        Console.WriteLine($"Updated payment mode: {id} - {name}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} not found in Dictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Dictionary: {ex.Message}");
            }
        }

        private void RemoveFromDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to remove: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (paymentModes.ContainsKey(id))
                    {
                        string removedValue = paymentModes[id];
                        paymentModes.Remove(id);
                        Console.WriteLine($"Removed payment mode: {id} - {removedValue}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} not found in Dictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing from Dictionary: {ex.Message}");
            }
        }

        private void ClearDictionary()
        {
            try
            {
                Console.Write("Are you sure you want to clear all items? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    int count = paymentModes.Count;
                    paymentModes.Clear();
                    Console.WriteLine($"Cleared {count} items from Dictionary.");
                }
                else
                {
                    Console.WriteLine("Clear operation cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing Dictionary: {ex.Message}");
            }
        }

        private void GetFromDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to retrieve: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    // Method 1: Direct indexing (throws exception if key doesn't exist)
                    Console.WriteLine("\nMethod 1: Direct indexing");
                    try
                    {
                        Console.WriteLine($"Result: {id} - {paymentModes[id]}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine($"Error: ID {id} not found in Dictionary.");
                    }

                    // Method 2: Using TryGetValue (safer approach)
                    Console.WriteLine("\nMethod 2: Using TryGetValue");
                    if (paymentModes.TryGetValue(id, out string value))
                    {
                        Console.WriteLine($"Result: {id} - {value}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} not found in Dictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving from Dictionary: {ex.Message}");
            }
        }

        private void CheckKeyInDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to check: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (paymentModes.ContainsKey(id))
                    {
                        Console.WriteLine($"ID {id} exists in Dictionary with value: {paymentModes[id]}");
                    }
                    else
                    {
                        Console.WriteLine($"ID {id} does not exist in Dictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking key in Dictionary: {ex.Message}");
            }
        }

        private void DisplayDictionary()
        {
            try
            {
                if (paymentModes.Count == 0)
                {
                    Console.WriteLine("Dictionary is empty.");
                    return;
                }

                Console.WriteLine("\n===== Dictionary Contents =====");
                foreach (var item in paymentModes)
                {
                    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
                }
                Console.WriteLine($"Total items: {paymentModes.Count}");

                // Display keys only
                Console.WriteLine("\nAll Keys:");
                foreach (var key in paymentModes.Keys)
                {
                    Console.Write($"{key} ");
                }

                // Display values only
                Console.WriteLine("\n\nAll Values:");
                foreach (var value in paymentModes.Values)
                {
                    Console.Write($"{value} ");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying Dictionary: {ex.Message}");
            }
        }

        // ConcurrentDictionary Methods
        private void AddToConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID (int): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter payment mode name: ");
                    string name = Console.ReadLine();

                    if (concurrentPaymentModes.TryAdd(id, name))
                    {
                        Console.WriteLine($"Added payment mode: {id} - {name}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} already exists in ConcurrentDictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding to ConcurrentDictionary: {ex.Message}");
            }
        }

        private void UpdateConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to update: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (concurrentPaymentModes.ContainsKey(id))
                    {
                        Console.WriteLine($"Current value: {id} - {concurrentPaymentModes[id]}");
                        Console.Write("Enter new payment mode name: ");
                        string name = Console.ReadLine();

                        string oldValue = concurrentPaymentModes[id];
                        if (concurrentPaymentModes.TryUpdate(id, name, oldValue))
                        {
                            Console.WriteLine($"Updated payment mode: {id} - {name}");
                        }
                        else
                        {
                            Console.WriteLine("Update failed. Value might have been changed by another thread.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} not found in ConcurrentDictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating ConcurrentDictionary: {ex.Message}");
            }
        }

        private void RemoveFromConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to remove: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (concurrentPaymentModes.ContainsKey(id))
                    {
                        if (concurrentPaymentModes.TryRemove(id, out string removedValue))
                        {
                            Console.WriteLine($"Removed payment mode: {id} - {removedValue}");
                        }
                        else
                        {
                            Console.WriteLine("Remove failed. Item might have been removed by another thread.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} not found in ConcurrentDictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing from ConcurrentDictionary: {ex.Message}");
            }
        }

        private void ClearConcurrentDictionary()
        {
            try
            {
                Console.Write("Are you sure you want to clear all items? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    int count = concurrentPaymentModes.Count;
                    concurrentPaymentModes.Clear();
                    Console.WriteLine($"Cleared {count} items from ConcurrentDictionary.");
                }
                else
                {
                    Console.WriteLine("Clear operation cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing ConcurrentDictionary: {ex.Message}");
            }
        }

        private void GetFromConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID to retrieve: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    // Method 1: Direct indexing (throws exception if key doesn't exist)
                    Console.WriteLine("\nMethod 1: Direct indexing");
                    try
                    {
                        Console.WriteLine($"Result: {id} - {concurrentPaymentModes[id]}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine($"Error: ID {id} not found in ConcurrentDictionary.");
                    }

                    // Method 2: Using TryGetValue (safer approach)
                    Console.WriteLine("\nMethod 2: Using TryGetValue");
                    if (concurrentPaymentModes.TryGetValue(id, out string value))
                    {
                        Console.WriteLine($"Result: {id} - {value}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: ID {id} not found in ConcurrentDictionary.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving from ConcurrentDictionary: {ex.Message}");
            }
        }

        private void TryAddToConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID (int): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter payment mode name: ");
                    string name = Console.ReadLine();

                    bool added = concurrentPaymentModes.TryAdd(id, name);
                    if (added)
                    {
                        Console.WriteLine($"Successfully added: {id} - {name}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to add. Key {id} already exists with value: {concurrentPaymentModes[id]}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TryAdd to ConcurrentDictionary: {ex.Message}");
            }
        }

        private void GetOrAddToConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID (int): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter payment mode name (used if key doesn't exist): ");
                    string name = Console.ReadLine();

                    string result = concurrentPaymentModes.GetOrAdd(id, name);

                    if (result == name)
                    {
                        Console.WriteLine($"Key {id} was added with value: {name}");
                    }
                    else
                    {
                        Console.WriteLine($"Key {id} already existed with value: {result}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetOrAdd to ConcurrentDictionary: {ex.Message}");
            }
        }

        private void AddOrUpdateConcurrentDictionary()
        {
            try
            {
                Console.Write("Enter payment mode ID (int): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter payment mode name to add/update: ");
                    string name = Console.ReadLine();

                    string result = concurrentPaymentModes.AddOrUpdate(
                        id,
                        name,
                        (key, oldValue) =>
                        {
                            Console.WriteLine($"Updating existing key {key} from '{oldValue}' to '{name}'");
                            return name;
                        });

                    Console.WriteLine($"Result: {id} - {result}");
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter an integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddOrUpdate to ConcurrentDictionary: {ex.Message}");
            }
        }

        private void DisplayConcurrentDictionary()
        {
            try
            {
                if (concurrentPaymentModes.Count == 0)
                {
                    Console.WriteLine("ConcurrentDictionary is empty.");
                    return;
                }

                Console.WriteLine("\n===== ConcurrentDictionary Contents =====");
                foreach (var item in concurrentPaymentModes)
                {
                    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
                }
                Console.WriteLine($"Total items: {concurrentPaymentModes.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying ConcurrentDictionary: {ex.Message}");
            }
        }
    }
}