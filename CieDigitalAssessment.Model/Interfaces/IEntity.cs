namespace CieDigitalAssessment.API.Models
{
    // This interface allows us to take common actions in the generic repository pattern
    // we use in the API controllers
    public interface IEntity
    {
        int Id { get; set; }
        // TODO Add IsDeleted to allow for soft deletions
    }
}