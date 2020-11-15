using ConsoleParser.Enum;
using System.Collections.Generic;

namespace ConsoleParser.Dto
{
    internal class DetailBookDto
    {
        public string OriginalName { get; set; }
        /// <summary>
        /// Уникальный международный номер книжного издания
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// Тип книги: печатная - электронная
        /// </summary>
        public BookEditionType EditionType { get; set; }
        public string Author { get; set; }
        public string Poblisher { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public byte TotalRating { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}
