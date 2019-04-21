namespace App.Library.Persistence
{
  public interface IUnitOfWork
  {
    void Commit();
  }
}