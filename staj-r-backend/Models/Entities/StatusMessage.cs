namespace staj_r_backend.Models.Entities
{
    public class StatusMessage
    {
        public StatusMessage()
        {

        }

        public StatusMessage(bool _status, string _message)
        {
            status = _status;
            message = _message;
        }
        public bool status { get; set; }
        public string message { get; set; }
    }
}
