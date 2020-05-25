using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Repository
{
    public class CommandRepo : RepositoryBase
    {
        private IEnumerable<BaseEntity> _datas;
        private IEnumerable<BaseEntity> Datas
        {
            get
            {
                if(null == _datas || _datas.Count() == 0)
                {
                    this._datas = Enumerable.Range(0,100).Select(p=>{
                                return new Command(){
                                    ID = p,
                                    HowTo = $"How to {p}",
                                    Line = $"line_{p}",
                                    Platform = string.Empty
                                };
                            });
                }
                return this._datas;
            }
        }
        protected override IEnumerable<BaseEntity> MockData()
        {
            return this.Datas;
        }
    }
}