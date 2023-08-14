using System;
using SEDC.HomeworkClass03WebApi.Models;

namespace SEDC.HomeworkClass03WebApi
{
	public static class StaticDb
	{
		public static List<Book> Books = new List<Book>()
		{
			new Book
			{
				Author = "Ajshe Kulin",
				Title = "Posledniot voz za Istambul"
			},

            new Book
            {
                Author = "Adelfonso Falkones",
                Title = "Katedralata na moreto"
            },
            new Book
            {
                Author = "Stiv Beri",
                Title = "Cetirinaesetata kolonija"
            }
        };
		
	}
}

