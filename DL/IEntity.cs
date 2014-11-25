using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DL
{
    // Summary
    //    Represents a base entity for the application and
    //    assumes that all entities have this fields.
    //    In special occasions they can be omitted.
    public interface IEntity
    {
        Guid Id
        {
            get;
            set;
        }
        string CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedOn
        {
            get;
            set;
        }

        string ModifiedBy
        {
            get;
            set;
        }

        DateTime ModifiedOn
        {
            get;
            set;
        }
    }
}