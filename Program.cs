using System;
using System.IO;
using System.Text;



namespace Krystek_Lab_9_4
{
	class Program
	{
		// =========================================================================
		// Name:	Keith Krystek
		// Date:	08.31.2020
		// Class: SD1104-A - Full Stack C# Development - Sona Patel - 7 / 11 / 2020
		//
		// Assignment: Lab 9_4
		// =========================================================================



		static void Main(string[] args)
		{
				//Console.WriteLine("Hello World!");


			// Create output HTML file. Create new folder manually. Remember escape characters for "/".
				string newFilename = "C://weblogs//Krystek_Lab_9_4.html";
				// Optional deletion of file.
				File.Delete(newFilename);

			// Create instances of classes.
				Header myHeader = new Header();
				UnorderedList myList = new UnorderedList();
				StringBuilder myHTML = new StringBuilder();


			// Collect information for header.
				Console.WriteLine("Enter the text for your HTML header:");
				string myHeaderHTML = myHeader.CreateNewHeader(Console.ReadLine());

			// Collect information for list.
				string[] listItems = new string[3];

				for (int i = 0; i < listItems.Length; i++)
				{
					Console.WriteLine("Add item #" + (i+1) + " to the list.");
					listItems[i] = myList.CreateNewListItem(Console.ReadLine());
				}


			// Build web page using components and save to html file.
				StringBuilder myListHTML = myList.CreateNewList(listItems);

				myHTML.Append(myHeaderHTML);
				myHTML.Append(myListHTML.ToString());

				File.AppendAllText(newFilename, myHTML.ToString());

			//Optional opening new web page in Chrome.
				System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", @newFilename);

		}
	}



	class Header
	{
		// Define start and end of header section.
			public const string h_open = "<h1>";
			public const string h_close = "</h1>";

		// Create Header section of web page.
			public string CreateNewHeader(string text)
			{
				string headerHtml = String.Concat(h_open, text, h_close, "\n");
				return headerHtml;
			}
	}



	class UnorderedList
	{
		// Define start and end of unordered list section.
			public const string ul_open = "<ul>";
			public const string ul_close = "</ul>";

		// Define start and end of list item and create list item string.
			public string CreateNewListItem(string text)
			{
				string li_open = "<li> \n";
				string li_close = "</li> \n";

				string newListItem = String.Concat(li_open, text, li_close, "\n");
				return newListItem;
			}

		// Pull list items together into list section.
			public StringBuilder CreateNewList(string[] listItemArray)
			{
			// Create list with opening and closing ul tags.

				StringBuilder strbldr = new StringBuilder();

				strbldr.Append(ul_open);

			// Loop through list items to create master list string.
				foreach (string item in listItemArray)
				{
					strbldr.Append(item);
				}

				strbldr.Append(ul_close);

			// Return list HTML code.
				return strbldr;
			}
	}





}