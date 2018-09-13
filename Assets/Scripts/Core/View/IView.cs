using MVP.Model;

namespace MVP
{
    public interface IView
    {
        void BindData();

        void BindModel(IDataModel data);
    }
}
