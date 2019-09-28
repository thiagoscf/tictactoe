using System.Linq;

public static class NumericExtensions {
  public static bool Equals(this int number, params int[] otherNumbers) {
    return otherNumbers.All(otherNumber => number == otherNumber);
  }
}