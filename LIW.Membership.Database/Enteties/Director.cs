

namespace LIW.Membership.Database.Enteties
{
	public class Director : IEntity
	{
		public int Id { get; set; }

		[MaxLength(50),Required]
		public string Name { get; set; }

		public virtual ICollection<Film> Films { get; set; } //En regisör kan ha fler filmer 
	}
}
