namespace HospitalSystem.Core.ViewModels
{
    public class AppoinmentVM
    {
        public string AppointemntId {  get; set; }=Guid.NewGuid().ToString();
        public string PatientID { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        public string SelectedDepartmentID { get; set; }
        [Required(ErrorMessage = "Doctor is required.")]

        public string SelectedDoctorID { get; set; }
        [Required(ErrorMessage = "WorkingHours is required.")]

        public string SelectedWorkingHoursID { get; set; }
        public string? SelectedDepartmentName { get; set; }
        public string? SelectedDoctorName { get; set; }

        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? Doctors { get; set; }
        public IEnumerable<SelectListItem>? WorkingHours { get; set; }
    }
}
