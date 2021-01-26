using System;

namespace TestTasks
{
	/// <summary>
	/// Дано начало списка `head` и позиция с конца `n`. Написать функцию, которая удалит из списка элемент, который
	/// находится на позиции `n`с конца и вернет полученный список. Исходный список можно модифицировать.
	/// Пример:
	///
	/// 1 -> 2 -> 3 -> 4 -> 5
	/// n = 2
	///
	/// 1 элемент с конца - 5
	/// 2 элемент с конца - 4
	/// Значит удалить нужно узел с 4. Результирующий список: 1 -> 2 -> 3 -> 5
	/// </summary>
	public class LinkedListTask
	{
		/// <summary>
		/// Решил первым пришедшим в голову вариантом, реверснул линкедлист удалил N-ый элемент, реверснул обратно
		/// </summary>
		/// <param name="startNode"></param>
		/// <param name="n"></param>
		public void DeleteNElementWithReverse(ListNode startNode, int n)
		{
			var headNode = ReverseLinkedList(startNode);
			var searchedNode = headNode;
			var nextNode = searchedNode;
			ListNode prevNode = null;

			for (var i = 1; i < n; i++)
			{
				searchedNode = searchedNode.next;
			}

			for (var i = 0; i < n; i++)
			{
				if (nextNode.Equals(searchedNode))
				{
					// когда мы попытаемся удалить самый последний вариант
					if (prevNode == null)
					{
						headNode = nextNode.next; nextNode.next = null;
					}
					else
					{
						prevNode.next = nextNode.next;
						nextNode.next = null;
					}
					break;
				}

				prevNode = nextNode;
				nextNode = nextNode.next;
			}
			
			var result = ReverseLinkedList(headNode);
			var resultString = $"{result.val}";
			
			while (result.next != null)
			{
				resultString += $" -> {result.next.val}";
				result = result.next;
			}
			
			Console.WriteLine(resultString);
		}

		public ListNode ReverseLinkedList(ListNode startNode)
		{
			var currentNode = startNode;
			ListNode prevNode = null;

			while (currentNode.next != null)
			{
				var nextNode = currentNode.next;
				currentNode.next = prevNode;
				prevNode = currentNode;
				currentNode = nextNode;
			}

			currentNode.next = prevNode;

			return currentNode;
		}
	}
}