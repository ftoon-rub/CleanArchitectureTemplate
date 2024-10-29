namespace ApplicationLayer.Models.BaseModels
{
    public class Output <T>
    {
        public Output()
        {
            errorDetails = new();
        }
        public T result { get; set; }
        public ErrorDetails errorDetails { get; set; }

    }
}
