using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Request
{
    public class SimpleReq : BaseReq<BaseModel>
    {
        #region -- Overrides --

        /// <summary>
        /// Convert the request to the model
        /// </summary>
        /// <param name="createdBy">Created by</param>
        /// <returns>Return the result</returns>
        public override BaseModel ToModel(int? createdBy = null)
        {
            return new BaseModel(Id);
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SimpleReq() : base() { }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="id">ID</param>
        public SimpleReq(int id) : base(id) { }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="keyword">Keyword</param>
        public SimpleReq(string keyword) : base(keyword) { }

        #endregion
    }
}
