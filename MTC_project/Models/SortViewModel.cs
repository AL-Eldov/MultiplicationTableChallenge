namespace MTC_project.Models
{
	public class SortViewModel
	{
		public SortState NameSort { get; } // значение для сортировки по имени
        public SortState RankSort { get; }     // Значение сортировки для ранга
        public SortState RatingSort { get; }     // Значение сортировки для рейтинга
        public SortState Current { get; }     // текущее значение сортировки

		public SortViewModel(SortState sortOrder)
		{
			NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            RankSort = sortOrder == SortState.RankAsc ? SortState.RankDesc : SortState.RankAsc; 
            RatingSort = sortOrder == SortState.RatingAsc ? SortState.RatingDesc : SortState.RatingAsc; 
            Current = sortOrder;
		}
	}
}
