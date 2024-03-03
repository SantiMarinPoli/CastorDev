using Castor.EmployeeRecord.Models;
using Castor.EmployeeRecord.Services.Interface;

namespace Castor.EmployeeRecord.Services
{
    public class PositionService: IPositionService
    {
        private readonly Context _connection;

        public PositionService(Context connection)
        {
            _connection = connection;
        }

        public List<Position> GetPositions()
        {
            return _connection.Positions.ToList();
        }
    }
}
