using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DL
{
    public interface IEntity
    {
        Guid Id
        {
            get;
            set;
        }
        
        DateTime CreatedOn
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
