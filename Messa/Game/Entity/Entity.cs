using Messa.API.Game.Entity;

namespace Messa.Game.Entity
{
    public class Entity : IEntity
    {
        public Entity(double id, int cellId)
        {
            Id = id;
            CellId = cellId;
        }

        public int CellId { get; set; }
        public double Id { get; set; }
    }
}