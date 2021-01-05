using Model.BusinessHours;

namespace Model.Users
{
    public class Employee : RegisteredUser
    {

		public virtual BusinessHoursModel BusinessHours { get; set; }

		

	}

	public enum EmployeeType
    {
		Doctor,
		Secretary
    }
}
