namespace ClientDirectory.Models
{
    public class ModalViewModel
    {
        public string ModalId { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string FormId { get; set; }
        public string SubmitButtonText { get; set; }
        public string PartialView { get; set; }
        public object Model { get; set; }
    }

}
