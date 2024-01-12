using Kingdee.BOS;
using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuzhiBillPlugin
{
    public class tuzhiClass: AbstractBillPlugIn
    {
        public override void DataChanged(DataChangedEventArgs e)
        {
            base.DataChanged(e);
            string name = "";
            string newValue = e.NewValue.ToString();
            if (e.Field.Key.ToUpperInvariant() == "F_VPRD_ATTACHMENT" || newValue != ""){
                StringBuilder sb = new StringBuilder();
                var array = SerializatonUtil.DeserializeFromBase64<JSONArray>(newValue);

                if (array != null && array.Count > 0)

                {
                    for (var i = 0; i < array.Count; i++)

                    {

                        sb.Append("文件名:").Append(((JSONObject)array[i]).GetString("FileName"));
                        name = ((JSONObject)array[i]).GetString("FileName");
                        //var fileContent = Encoding.UTF8.GetString((byte[])((JSONObject)array[i]).Get("FileContent"));
                        var fileContent = Convert.ToBase64String((byte[])((JSONObject)array[i]).Get("FileContent"));

                        sb.Append(";文件内容:").Append(fileContent).AppendLine();

                    }
                }
                

            }
        }
    }
}
