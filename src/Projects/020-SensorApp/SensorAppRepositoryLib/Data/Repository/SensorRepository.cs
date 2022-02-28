using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


using static CSD.Util.Async.TaskUtil;

namespace CSD.SensorApp.Data.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly SensorsDBContext m_sensorsDBContext;

        #region callbacks
        private long countCallback()
        {
            return m_sensorsDBContext.Sensors.LongCount();
        }

        private IEnumerable<Sensor> findByNameCallback(string name)
        {
            return m_sensorsDBContext.Sensors.Where(s => s.Name == name);
        }

        private IEnumerable<Sensor> findByNameContainsCallback(string text)
        {
            return m_sensorsDBContext.Sensors.Where(s => s.Name.Contains(text));
        }

        public Sensor saveCallback(Sensor sensor)
        {
            m_sensorsDBContext.Sensors.Add(sensor);

            if (m_sensorsDBContext.SaveChanges() != 1)
                throw new Exception("Save problem occurs");

            return sensor;
        }

        #endregion

        public SensorRepository(SensorsDBContext sensorsDBContext)
        {
            m_sensorsDBContext = sensorsDBContext;
        }

        #region CRUD Async Methods
        public Task<long> CountAsync()
        {
            return CreateTaskAsync(countCallback);
        }

        public Task<IEnumerable<Sensor>> FindByNameAsync(string name)
        {
            return CreateTaskAsync(() => findByNameCallback(name));
        }

        public Task<IEnumerable<Sensor>> FindByNameContainsAsync(string text)
        {
            return CreateTaskAsync(() => findByNameContainsCallback(text));
        }

        public Task<Sensor> SaveAsync(Sensor sensor)
        {
            return CreateTaskAsync(() => saveCallback(sensor));
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////
        public IEnumerable<Sensor> All => throw new NotImplementedException();

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Sensor t)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Sensor t)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sensor>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> FindByFilter(Expression<Func<Sensor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sensor>> FindByFilterAsync(Expression<Func<Sensor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Sensor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Sensor> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> FindByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sensor>> FindByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
        public Sensor Save(Sensor t)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Sensor> Save(IEnumerable<Sensor> entities)
        {
            throw new NotImplementedException();
        }

        

        public Task<IEnumerable<Sensor>> SaveAsync(IEnumerable<Sensor> entities)
        {
            throw new NotImplementedException();
        }
    }
}
