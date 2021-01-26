using System;
using System.Linq;

namespace TestTasks
{
	/// <summary>
	/// Дан непустой массив чисел `nums`. В этом массиве каждый элемент встречается дважды, за исключением одного.
	/// Написать функцию, которая возвращает этот один элемент.
	/// </summary>
	public class DuplicateNumbers
	{
		/// <summary>
		/// Вариант в лоб
		/// O(n^2)
		/// </summary>
		/// <param name="inputArray"></param>
		public void GetUniqueElement(int[] inputArray)
		{
			var prev = 0;
			for (var i = 0; i < inputArray.Length; i++)
			{
				prev = inputArray[i];
				
				//можно использовать nullable int, но решил заюзать такое решение
				inputArray[i] = prev != 0 ? 0 : 1;
				
				if (inputArray.Contains(prev))
				{
					inputArray[i] = prev;
				}
				else
				{
					Console.WriteLine(prev);
					break;
				}
			}
		}

		/// <summary>
		/// Красивый, но не оч эффективный вариант
		/// O(n^2)
		/// </summary>
		/// <param name="inputArray"></param>
		public void GetUniqueElementWithLinq(int[] inputArray)
		{
			var result = inputArray
				.FirstOrDefault(x => inputArray.Count(y => y == x) == 1);
			
			Console.WriteLine(result);
		}
		
		/// O((n^2)/2) -
		/// p.s. +1 не указываем так как это не имеет значения
		/// <summary>
		/// Решение, берем первый элемент проверяем его есть ли его брат дубликат, если есть то меняем местами последний и текущий ресайзим массив
		/// </summary>
		/// <param name="inputArray"></param>
		public void GetUniqueElementWithResize(int[] inputArray)
		{
			var prev = 0;
			
			for (var i = 0; i < inputArray.Length; i++)
			{
				prev = inputArray[i];
				var count = 1;
				
				for (var j = i + 1; j < inputArray.Length; j++)
				{
					if (prev == inputArray[j])
					{
						SwapResize(ref inputArray, j);
						count++;
						break;
					}
				}

				if (count == 1)
				{
					Console.WriteLine(inputArray[i]);
				}
			}
		}

		private void SwapResize(ref int[] inputArray, int index)
		{
			var prev = inputArray[index];
			inputArray[index] = inputArray[^1];
			Array.Resize(ref inputArray, inputArray.Length-1);
		}
	}
}