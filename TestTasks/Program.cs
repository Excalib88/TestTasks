using System;

namespace TestTasks
{
	class Program
	{
		static void Main(string[] args)
		{
			// 1 задача
			var nums = new int[]
			{
				1, 2, 1, 3, 2, 3, 5, 4, 5
			};
			var duplicateNumbers = new DuplicateNumbers();
			duplicateNumbers.GetUniqueElement(nums);
			duplicateNumbers.GetUniqueElementWithLinq(nums);
			duplicateNumbers.GetUniqueElementWithResize(nums);
			
			// 2 задача
			var startNode = new ListNode(1,
				new ListNode(2, 
					new ListNode(3, 
						new ListNode(4, 
							new ListNode(5, null)))));

			var linkedListTask = new LinkedListTask();
			linkedListTask.DeleteNElementWithReverse(startNode, 5);
		}
			
			// 3 задача
			// Не успел сделать, слишком много работы было((
	}
}
