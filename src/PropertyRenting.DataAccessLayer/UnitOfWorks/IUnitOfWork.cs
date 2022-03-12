using System;


namespace PropertyRenting.DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
