using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DL
{
    public class Entity : IEntity
    {
        public Guid Id
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }
    }
}
