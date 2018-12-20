public interface IDataManager
{
    int Sunrise { get; set;  }
    int Sunset { get; set; }
    int Start { get; set; }
    int Finish { get; set; }

    RGB Red { get; set; }
    RGB Green { get; set; }
    RGB Blue { get; set; }

}