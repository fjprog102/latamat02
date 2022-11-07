String user_input = Console.ReadLine();

var values = string_to_int_list(user_input, " ");

var val_min = values.Min();
var val_max = values.Max();

Console.WriteLine(String.Format("{0} {1}", val_max, val_min));

int[] string_to_int_list(String str, String separator)
{
    return Array.ConvertAll(user_input.Split(separator), value => Int32.Parse(value));
}
